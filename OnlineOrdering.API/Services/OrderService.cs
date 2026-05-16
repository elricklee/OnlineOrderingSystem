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
            if (normalizedOrderType != "DineIn" && normalizedOrderType != "Delivery")
            {
                throw new InvalidOperationException("不支持的订单类型。");
            }

            var order = new Order
            {
                UserId = dto.UserId,
                CustomerName = string.IsNullOrWhiteSpace(dto.CustomerName)
                    ? normalizedOrderType == "DineIn" ? "堂食顾客" : "外卖顾客"
                    : dto.CustomerName.Trim(),
                Phone = dto.Phone?.Trim() ?? string.Empty,
                OrderType = normalizedOrderType,
                Note = dto.Note?.Trim(),
                Status = "Pending",
                IsDeleted = false,
                CreatedAt = DateTime.Now
            };

            if (normalizedOrderType == "DineIn")
            {
                await ConfigureDineInOrderAsync(dto, order);
            }
            else
            {
                await ConfigureDeliveryOrderAsync(dto, order);
            }

            decimal total = 0;
            int totalQuantity = 0;

            foreach (var item in dto.OrderItems)
            {
                if (item.Quantity <= 0)
                {
                    throw new InvalidOperationException("菜品数量必须大于 0。");
                }

                var dish = await _db.Dishes.FirstOrDefaultAsync(d => d.Id == item.DishId && !d.IsDeleted);
                if (dish == null)
                {
                    throw new InvalidOperationException($"菜品不存在或已下架");
                }

                if (!dish.IsAvailable)
                {
                    throw new InvalidOperationException($"{dish.Name} 当前不可售，请从购物车移除后重新提交");
                }

                order.OrderItems.Add(new OrderItem
                {
                    DishId = item.DishId,
                    DishName = dish.Name,
                    Price = dish.Price,
                    Quantity = item.Quantity
                });

                total += dish.Price * item.Quantity;
                totalQuantity += item.Quantity;
            }

            order.TotalAmount = total + order.DeliveryFee;
            order.EstimatedMinutes = 10 + totalQuantity * 3;

            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            return MapToDto(order);
        }

        public async Task<OrderDto?> UpdateOrderStatusAsync(int id, string status, string? cancelReason = null)
        {
            var order = await _db.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DiningTable)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            if (order == null)
            {
                return null;
            }

            if (!CanChangeStatus(order.OrderType, order.Status, status))
            {
                throw new InvalidOperationException($"不能将订单从 {GetStatusText(order.Status)} 改为 {GetStatusText(status)}");
            }

            var oldStatus = order.Status;
            order.Status = status;

            switch (status)
            {
                case "Confirmed":
                    order.ConfirmedAt = DateTime.Now;
                    if (order.DiningTable != null)
                    {
                        order.DiningTable.Status = "Occupied";
                    }
                    break;
                case "Preparing":
                    order.PreparingAt = DateTime.Now;
                    break;
                case "Ready":
                    order.ReadyAt = DateTime.Now;
                    break;
                case "Delivering":
                    order.DeliveringAt = DateTime.Now;
                    break;
                case "Completed":
                    order.CompletedAt = DateTime.Now;
                    if (order.DiningTable != null)
                    {
                        order.DiningTable.Status = "Available";
                        order.DiningTable.CurrentOccupiedSeats = Math.Max(0, order.DiningTable.CurrentOccupiedSeats - (order.DinerCount ?? 1));
                    }
                    break;
                case "Cancelled":
                    order.CancelledAt = DateTime.Now;
                    order.CancelReason = cancelReason ?? "未填写原因";
                    if (order.DiningTable != null && oldStatus != "Pending")
                    {
                        order.DiningTable.Status = "Available";
                        order.DiningTable.CurrentOccupiedSeats = Math.Max(0, order.DiningTable.CurrentOccupiedSeats - (order.DinerCount ?? 1));
                    }
                    break;
            }

            await _db.SaveChangesAsync();
            return MapToDto(order);
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var list = await _db.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DiningTable)
                .Include(x => x.DeliveryZone)
                .Where(o => !o.IsDeleted)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return list.Select(MapToDto).ToList();
        }

        public async Task<List<OrderDto>> GetOrdersByUserIdAsync(int userId)
        {
            var list = await _db.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DiningTable)
                .Include(x => x.DeliveryZone)
                .Where(o => !o.IsDeleted && o.UserId == userId)
                .OrderByDescending(o => o.CreatedAt)
                .ToListAsync();

            return list.Select(MapToDto).ToList();
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            var order = await _db.Orders
                .Include(x => x.OrderItems)
                .Include(x => x.DiningTable)
                .Include(x => x.DeliveryZone)
                .FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);

            return order == null ? null : MapToDto(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _db.Orders
                .Include(o => o.DiningTable)
                .FirstOrDefaultAsync(o => o.Id == id && !o.IsDeleted);

            if (order == null)
            {
                return false;
            }

            if (order.Status != "Pending" && order.Status != "Confirmed")
            {
                throw new InvalidOperationException("只能删除待处理或已接单的订单");
            }

            order.IsDeleted = true;

            if (order.DiningTable != null && order.Status != "Pending")
            {
                order.DiningTable.Status = "Available";
            }

            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HardDeleteOrderAsync(int id)
        {
            var order = await _db.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.DiningTable)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return false;
            }

            if (order.DiningTable != null)
            {
                order.DiningTable.Status = "Available";
            }

            _db.OrderItems.RemoveRange(order.OrderItems);
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreOrderAsync(int id)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(o => o.Id == id && o.IsDeleted);
            if (order == null)
            {
                return false;
            }

            order.IsDeleted = false;
            await _db.SaveChangesAsync();
            return true;
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

            if (diningTable.Status != "Available" && !string.IsNullOrEmpty(diningTable.Status))
            {
                throw new InvalidOperationException($"餐桌 {diningTable.TableNumber} 当前不可用，请重新选择。");
            }

            var dinerCount = dto.DinerCount ?? 1;
            if (dinerCount <= 0) dinerCount = 1;

            var remainingSeats = diningTable.SeatCount - diningTable.CurrentOccupiedSeats;
            if (dinerCount > remainingSeats)
            {
                throw new InvalidOperationException($"餐桌 {diningTable.TableNumber} 剩余 {remainingSeats} 个座位，无法容纳 {dinerCount} 人就餐。");
            }

            order.DiningTableId = diningTable.Id;
            order.TableNumber = diningTable.TableNumber;
            order.DinerCount = dinerCount;
            diningTable.CurrentOccupiedSeats += dinerCount;
            order.DeliveryFee = 0m;
            order.Address = null;
            order.DeliveryZoneId = null;
            order.DeliveryRegion = null;
            order.CustomerName = $"桌号{diningTable.TableNumber}";
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

            if (string.IsNullOrWhiteSpace(dto.Phone))
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
            order.CustomerName = string.IsNullOrWhiteSpace(dto.CustomerName) ? "外卖顾客" : dto.CustomerName.Trim();
        }

        private static bool CanChangeStatus(string orderType, string currentStatus, string targetStatus)
        {
            if (currentStatus == "Completed" || currentStatus == "Cancelled")
            {
                return false;
            }

            if (orderType == "DineIn" && targetStatus == "Delivering")
            {
                return false;
            }

            var allowedTransitions = new Dictionary<string, string[]>
            {
                ["Pending"] = new[] { "Confirmed", "Cancelled" },
                ["Confirmed"] = new[] { "Preparing", "Cancelled" },
                ["Preparing"] = new[] { "Ready", "Cancelled" },
                ["Ready"] = orderType == "Delivery"
                    ? new[] { "Delivering", "Completed" }
                    : new[] { "Completed" },
                ["Delivering"] = new[] { "Completed" }
            };

            return allowedTransitions.TryGetValue(currentStatus, out var targets)
                && targets.Contains(targetStatus);
        }

        private static string GetStatusText(string status)
        {
            return status switch
            {
                "Pending" => "待处理",
                "Confirmed" => "已接单",
                "Preparing" => "制作中",
                "Ready" => "待出餐",
                "Delivering" => "配送中",
                "Completed" => "已完成",
                "Cancelled" => "已取消",
                _ => status
            };
        }

        private static OrderDto MapToDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                CustomerName = order.CustomerName,
                Phone = order.Phone,
                Address = order.Address,
                TableNumber = order.TableNumber,
                DiningTableId = order.DiningTableId,
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
                    Quantity = i.Quantity
                }).ToList()
            };
        }
    }
}
