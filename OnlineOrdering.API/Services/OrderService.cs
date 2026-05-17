using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Data;
using OnlineOrdering.API.DTOs;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;

        public OrderService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<OrderDto> CreateOrderAsync(OrderCreateDto dto)
        {
            if (dto.OrderItems.Count == 0)
            {
                throw new InvalidOperationException("订单至少需要一个菜品。");
            }

            var normalizedOrderType = dto.OrderType?.Trim();
            if (normalizedOrderType != OrderTypes.DineIn && normalizedOrderType != OrderTypes.Delivery)
            {
                throw new InvalidOperationException("不支持的订单类型。");
            }

            var user = dto.UserId == null
                ? null
                : await _db.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId.Value);

            var order = new Order
            {
                OrderNo = GenerateOrderNo(),
                UserId = dto.UserId,
                User = user,
                CustomerName = ResolveCustomerName(dto.CustomerName, user, normalizedOrderType),
                Phone = ResolvePhone(dto.Phone, user),
                OrderType = normalizedOrderType,
                Note = dto.Note?.Trim(),
                Status = OrderStatuses.Pending,
                IsDeleted = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (normalizedOrderType == OrderTypes.DineIn)
            {
                await ConfigureDineInOrderAsync(dto, order);
            }
            else
            {
                await ConfigureDeliveryOrderAsync(dto, order);
            }

            decimal total = 0;
            int totalQuantity = 0;
            int maxDishPrepMinutes = 0;
            int weightedPrepMinutes = 0;

            foreach (var item in dto.OrderItems)
            {
                if (item.Quantity <= 0)
                {
                    throw new InvalidOperationException("菜品数量必须大于 0。");
                }

                var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == item.DishId);
                if (dish == null)
                {
                    throw new InvalidOperationException("菜品不存在或已删除。");
                }

                if (!dish.IsAvailable || dish.SaleStatus != DishSaleStatuses.OnSale)
                {
                    throw new InvalidOperationException($"{dish.Name} 当前不可售，请刷新菜品后重新提交。");
                }

                order.OrderItems.Add(new OrderItem
                {
                    DishId = item.DishId,
                    DishName = dish.Name,
                    Price = dish.Price,
                    DishCategorySnapshot = dish.Category,
                    Quantity = item.Quantity
                });

                total += dish.Price * item.Quantity;
                totalQuantity += item.Quantity;
                var dishPrepMinutes = GetDishPrepMinutes(dish);
                maxDishPrepMinutes = Math.Max(maxDishPrepMinutes, dishPrepMinutes);
                weightedPrepMinutes += dishPrepMinutes * item.Quantity;
            }

            order.TotalAmount = total + order.DeliveryFee;
            order.EstimatedMinutes = CalculateEstimatedMinutes(
                normalizedOrderType,
                totalQuantity,
                maxDishPrepMinutes,
                weightedPrepMinutes);

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            await AddStatusHistoryAsync(order.Id, string.Empty, OrderStatuses.Pending, "订单创建", dto.UserId, UserRoles.Customer);
            await _db.SaveChangesAsync();

            return await GetOrderByIdAsync(order.Id) ?? MapToDto(order);
        }

        public async Task<OrderDto?> UpdateOrderStatusAsync(int id, string status, string? cancelReason = null)
        {
            var order = await _db.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DiningTable)
                .Include(x => x.TableSession)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return null;
            }

            if (string.Equals(order.Status, status, StringComparison.Ordinal))
            {
                return MapToDto(order);
            }

            if (!CanChangeStatus(order.OrderType, order.Status, status))
            {
                throw new InvalidOperationException($"不能将订单从 {GetStatusText(order.Status)} 改为 {GetStatusText(status)}。");
            }

            if (status == OrderStatuses.Cancelled && string.IsNullOrWhiteSpace(cancelReason))
            {
                throw new InvalidOperationException("取消订单必须填写原因。");
            }

            var oldStatus = order.Status;
            order.Status = status;
            order.UpdatedAt = DateTime.Now;

            switch (status)
            {
                case OrderStatuses.Confirmed:
                    order.ConfirmedAt = DateTime.Now;
                    break;
                case OrderStatuses.Preparing:
                    order.PreparingAt = DateTime.Now;
                    break;
                case OrderStatuses.Ready:
                    order.ReadyAt = DateTime.Now;
                    break;
                case OrderStatuses.Delivering:
                    order.DeliveringAt = DateTime.Now;
                    break;
                case OrderStatuses.Completed:
                    order.CompletedAt = DateTime.Now;
                    break;
                case OrderStatuses.Cancelled:
                    order.CancelledAt = DateTime.Now;
                    order.CancelReason = cancelReason?.Trim();
                    break;
            }

            await _db.SaveChangesAsync();

            await AddStatusHistoryAsync(
                order.Id,
                oldStatus,
                status,
                status == OrderStatuses.Cancelled ? order.CancelReason : null,
                null,
                UserRoles.Admin);

            if (order.DiningTableId.HasValue)
            {
                await RefreshDiningTableStateAsync(order.DiningTableId.Value);
            }

            await _db.SaveChangesAsync();
            return await GetOrderByIdAsync(order.Id);
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var list = await _db.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DiningTable)
                .Include(x => x.TableSession)
                .Include(x => x.DeliveryZone)
                .Include(x => x.User)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return list.Select(MapToDto).ToList();
        }

        public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var list = await _db.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DiningTable)
                .Include(x => x.TableSession)
                .Include(x => x.DeliveryZone)
                .Include(x => x.User)
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return list.Select(MapToDto).ToList();
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _db.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DiningTable)
                .Include(x => x.TableSession)
                .Include(x => x.DeliveryZone)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            return order == null ? null : MapToDto(order);
        }

        public async Task<List<OrderStatusHistoryDto>> GetStatusHistoryAsync(int id)
        {
            var orderExists = await _db.Orders.AnyAsync(o => o.Id == id);
            if (!orderExists)
            {
                return new List<OrderStatusHistoryDto>();
            }

            return await _db.OrderStatusHistories
                .Where(h => h.OrderId == id)
                .OrderBy(h => h.CreatedAt)
                .Select(h => new OrderStatusHistoryDto
                {
                    Id = h.Id,
                    FromStatus = h.FromStatus,
                    ToStatus = h.ToStatus,
                    OperatorUserId = h.OperatorUserId,
                    OperatorRole = h.OperatorRole,
                    Remark = h.Remark,
                    CreatedAt = h.CreatedAt
                })
                .ToListAsync();
        }

        private async Task ConfigureDineInOrderAsync(OrderCreateDto dto, Order order)
        {
            if (dto.DiningTableId == null)
            {
                throw new InvalidOperationException("堂食订单必须选择餐桌。");
            }

            var diningTable = await _db.DiningTables.FirstOrDefaultAsync(t => t.Id == dto.DiningTableId.Value && t.IsEnabled);
            if (diningTable == null)
            {
                throw new InvalidOperationException("所选餐桌不存在或已停用。");
            }

            var dinerCount = dto.DinerCount ?? 1;
            if (dinerCount <= 0)
            {
                dinerCount = 1;
            }

            if (dinerCount > diningTable.SeatCount)
            {
                throw new InvalidOperationException($"餐桌 {diningTable.TableNumber} 最多容纳 {diningTable.SeatCount} 人。");
            }

            var openSession = await _db.TableSessions
                .OrderByDescending(s => s.OpenedAt)
                .FirstOrDefaultAsync(s => s.DiningTableId == diningTable.Id && s.Status == TableSessionStatuses.Open);

            if (openSession != null)
            {
                if (!dto.TableSessionId.HasValue || dto.TableSessionId.Value != openSession.Id)
                {
                    throw new InvalidOperationException($"餐桌 {diningTable.TableNumber} 当前已有进行中的桌次，请勿重复占桌。");
                }

                order.TableSessionId = openSession.Id;
                order.DinerCount = openSession.PartySize;
            }
            else
            {
                var session = new TableSession
                {
                    DiningTableId = diningTable.Id,
                    SessionNo = GenerateTableSessionNo(diningTable.TableNumber),
                    PartySize = dinerCount,
                    Status = TableSessionStatuses.Open,
                    OpenedAt = DateTime.Now,
                    OpenedByUserId = dto.UserId,
                    Remark = "顾客下单自动开台"
                };

                _db.TableSessions.Add(session);
                order.TableSession = session;
                order.DinerCount = dinerCount;
            }

            order.DiningTableId = diningTable.Id;
            order.TableNumber = diningTable.TableNumber;
            order.DeliveryFee = 0m;
            order.Address = null;
            order.DeliveryZoneId = null;
            order.DeliveryRegion = null;

            diningTable.CurrentOccupiedSeats = order.DinerCount ?? dinerCount;
            diningTable.IsOccupied = true;
            diningTable.Status = DiningTableStatuses.Occupied;
        }

        private async Task ConfigureDeliveryOrderAsync(OrderCreateDto dto, Order order)
        {
            if (dto.DeliveryZoneId == null)
            {
                throw new InvalidOperationException("外卖订单必须选择配送区域。");
            }

            if (string.IsNullOrWhiteSpace(dto.Address))
            {
                throw new InvalidOperationException("外卖订单必须填写详细配送地址。");
            }

            if (string.IsNullOrWhiteSpace(order.Phone))
            {
                throw new InvalidOperationException("外卖订单必须填写手机号。");
            }

            var zone = await _db.DeliveryZones.FirstOrDefaultAsync(z => z.Id == dto.DeliveryZoneId.Value && z.IsActive);
            if (zone == null)
            {
                throw new InvalidOperationException("所选配送区域不存在或当前不可配送。");
            }

            order.DeliveryZoneId = zone.Id;
            order.DeliveryRegion = $"{zone.Province} {zone.City} {zone.District}";
            order.Address = dto.Address.Trim();
            order.DeliveryFee = zone.DeliveryFee;
            order.DiningTableId = null;
            order.TableNumber = null;
            order.DinerCount = null;
        }

        private async Task AddStatusHistoryAsync(
            int orderId,
            string fromStatus,
            string toStatus,
            string? remark,
            int? operatorUserId,
            string operatorRole)
        {
            _db.OrderStatusHistories.Add(new OrderStatusHistory
            {
                OrderId = orderId,
                FromStatus = fromStatus,
                ToStatus = toStatus,
                OperatorUserId = operatorUserId,
                OperatorRole = operatorRole,
                Remark = remark,
                CreatedAt = DateTime.Now
            });

            await Task.CompletedTask;
        }

        private async Task RefreshDiningTableStateAsync(int diningTableId)
        {
            var table = await _db.DiningTables.FirstOrDefaultAsync(t => t.Id == diningTableId);
            if (table == null)
            {
                return;
            }

            if (!table.IsEnabled)
            {
                table.IsOccupied = false;
                table.CurrentOccupiedSeats = 0;
                table.Status = DiningTableStatuses.Disabled;
                return;
            }

            var openSession = await _db.TableSessions
                .OrderByDescending(s => s.OpenedAt)
                .FirstOrDefaultAsync(s => s.DiningTableId == diningTableId && s.Status == TableSessionStatuses.Open);

            if (openSession == null)
            {
                table.IsOccupied = false;
                table.CurrentOccupiedSeats = 0;
                table.Status = DiningTableStatuses.Available;
                return;
            }

            var activeOrders = await _db.Orders
                .Where(o => o.TableSessionId == openSession.Id &&
                            o.Status != OrderStatuses.Completed &&
                            o.Status != OrderStatuses.Cancelled)
                .ToListAsync();

            if (activeOrders.Count == 0)
            {
                openSession.Status = TableSessionStatuses.Closed;
                openSession.ClosedAt = DateTime.Now;
                table.IsOccupied = false;
                table.CurrentOccupiedSeats = 0;
                table.Status = DiningTableStatuses.Available;
                return;
            }

            table.IsOccupied = true;
            table.CurrentOccupiedSeats = Math.Min(table.SeatCount, Math.Max(1, openSession.PartySize));
            table.Status = DiningTableStatuses.Occupied;
        }

        private static bool CanChangeStatus(string orderType, string currentStatus, string targetStatus)
        {
            if (currentStatus == OrderStatuses.Completed || currentStatus == OrderStatuses.Cancelled)
            {
                return false;
            }

            if (orderType == OrderTypes.DineIn && targetStatus == OrderStatuses.Delivering)
            {
                return false;
            }

            var allowedTransitions = new Dictionary<string, string[]>
            {
                [OrderStatuses.Pending] = new[] { OrderStatuses.Confirmed, OrderStatuses.Cancelled },
                [OrderStatuses.Confirmed] = new[] { OrderStatuses.Preparing, OrderStatuses.Cancelled },
                [OrderStatuses.Preparing] = new[] { OrderStatuses.Ready, OrderStatuses.Cancelled },
                [OrderStatuses.Ready] = orderType == OrderTypes.Delivery
                    ? new[] { OrderStatuses.Delivering, OrderStatuses.Completed }
                    : new[] { OrderStatuses.Completed },
                [OrderStatuses.Delivering] = new[] { OrderStatuses.Completed }
            };

            return allowedTransitions.TryGetValue(currentStatus, out var targets)
                && targets.Contains(targetStatus);
        }

        private static string GetStatusText(string status)
        {
            return status switch
            {
                OrderStatuses.Pending => "待处理",
                OrderStatuses.Confirmed => "已确认",
                OrderStatuses.Preparing => "制作中",
                OrderStatuses.Ready => "已出餐",
                OrderStatuses.Delivering => "配送中",
                OrderStatuses.Completed => "已完成",
                OrderStatuses.Cancelled => "已取消",
                _ => status
            };
        }

        private static OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                OrderNo = order.OrderNo,
                UserId = order.UserId,
                CustomerName = string.IsNullOrWhiteSpace(order.CustomerName) ? order.User?.RealName ?? order.User?.Username ?? string.Empty : order.CustomerName,
                Phone = string.IsNullOrWhiteSpace(order.Phone) ? order.User?.Phone ?? string.Empty : order.Phone,
                Address = order.Address,
                TableNumber = order.TableNumber,
                DiningTableId = order.DiningTableId,
                TableSessionId = order.TableSessionId,
                TableSessionNo = order.TableSession?.SessionNo,
                Note = order.Note,
                TotalAmount = order.TotalAmount,
                DeliveryFee = order.DeliveryFee,
                DeliveryZoneId = order.DeliveryZoneId,
                DeliveryRegion = order.DeliveryRegion,
                OrderType = order.OrderType,
                Status = order.Status,
                CreatedAt = order.CreatedAt,
                CancelReason = order.CancelReason,
                ConfirmedAt = order.ConfirmedAt,
                PreparingAt = order.PreparingAt,
                ReadyAt = order.ReadyAt,
                DeliveringAt = order.DeliveringAt,
                CompletedAt = order.CompletedAt,
                CancelledAt = order.CancelledAt,
                EstimatedMinutes = order.EstimatedMinutes,
                DeliveryPersonName = order.DeliveryPersonName,
                DeliveryPersonPhone = order.DeliveryPersonPhone,
                OrderItems = order.OrderItems.Select(i => new OrderItemResponseDto
                {
                    Id = i.Id,
                    DishId = i.DishId,
                    DishName = i.DishName,
                    Price = i.Price,
                    DishCategorySnapshot = i.DishCategorySnapshot,
                    Quantity = i.Quantity
                }).ToList()
            };
        }

        private static string ResolveCustomerName(string? submittedName, User? user, string orderType)
        {
            var name = submittedName?.Trim();
            if (!string.IsNullOrWhiteSpace(name) && name != "外卖顾客" && !name.StartsWith("桌号", StringComparison.Ordinal))
            {
                return name;
            }

            if (!string.IsNullOrWhiteSpace(user?.RealName))
            {
                return user.RealName.Trim();
            }

            if (!string.IsNullOrWhiteSpace(user?.Username))
            {
                return user.Username.Trim();
            }

            return orderType == OrderTypes.DineIn ? "堂食顾客" : "外卖顾客";
        }

        private static string ResolvePhone(string? submittedPhone, User? user)
        {
            var phone = submittedPhone?.Trim();
            if (!string.IsNullOrWhiteSpace(phone))
            {
                return phone;
            }

            return user?.Phone?.Trim() ?? string.Empty;
        }

        private static string GenerateOrderNo()
        {
            return $"OD{DateTime.Now:yyyyMMddHHmmssfff}{Random.Shared.Next(100, 999)}";
        }

        private static string GenerateTableSessionNo(string tableNumber)
        {
            return $"TS-{tableNumber}-{DateTime.Now:yyyyMMddHHmmss}";
        }

        private static int GetDishPrepMinutes(Dish dish)
        {
            var categoryMinutes = dish.Category switch
            {
                "凉菜" => 4,
                "饮品" => 3,
                "主食" => 8,
                "汤类" => 10,
                "热菜" => 12,
                _ => 8
            };

            return categoryMinutes + Math.Min(Math.Max(dish.SpicyLevel, 0), 3);
        }

        private static int CalculateEstimatedMinutes(
            string orderType,
            int totalQuantity,
            int maxDishPrepMinutes,
            int weightedPrepMinutes)
        {
            var parallelPrepMinutes = Math.Max(maxDishPrepMinutes, (int)Math.Ceiling(weightedPrepMinutes / 3.0));
            var queueBuffer = Math.Min(18, Math.Max(0, totalQuantity - 1) * 2);
            var serviceBuffer = orderType == OrderTypes.Delivery ? 18 : 5;
            var estimated = serviceBuffer + parallelPrepMinutes + queueBuffer;

            return Math.Clamp(estimated, orderType == OrderTypes.Delivery ? 25 : 12, orderType == OrderTypes.Delivery ? 75 : 60);
        }
    }
}
