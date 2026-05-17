using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Models;

namespace OnlineOrdering.API.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Dish> Dishes { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
		public DbSet<DeliveryZone> DeliveryZones { get; set; }
		public DbSet<DiningTable> DiningTables { get; set; }
		public DbSet<DishCategory> DishCategories { get; set; }
		public DbSet<TableSession> TableSessions { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Order)
				.WithMany(o => o.OrderItems)
				.HasForeignKey(oi => oi.OrderId);

			modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Dish)
				.WithMany(d => d.OrderItems)
				.HasForeignKey(oi => oi.DishId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Dish>()
				.HasOne(d => d.CategoryEntity)
				.WithMany(c => c.Dishes)
				.HasForeignKey(d => d.CategoryId)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<OrderStatusHistory>()
				.HasOne(h => h.Order)
				.WithMany(o => o.StatusHistories)
				.HasForeignKey(h => h.OrderId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Order>()
				.HasOne(o => o.User)
				.WithMany(u => u.Orders)
				.HasForeignKey(o => o.UserId)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Order>()
				.HasOne(o => o.DeliveryZone)
				.WithMany(z => z.Orders)
				.HasForeignKey(o => o.DeliveryZoneId)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Order>()
				.HasOne(o => o.DiningTable)
				.WithMany(t => t.Orders)
				.HasForeignKey(o => o.DiningTableId)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<Order>()
				.HasOne(o => o.TableSession)
				.WithMany(s => s.Orders)
				.HasForeignKey(o => o.TableSessionId)
				.OnDelete(DeleteBehavior.SetNull);

			modelBuilder.Entity<TableSession>()
				.HasOne(s => s.DiningTable)
				.WithMany(t => t.TableSessions)
				.HasForeignKey(s => s.DiningTableId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<DeliveryZone>()
				.HasIndex(z => new { z.Province, z.City, z.District })
				.IsUnique();

			modelBuilder.Entity<DishCategory>()
				.HasIndex(c => c.Name)
				.IsUnique();

			modelBuilder.Entity<DishCategory>()
				.HasQueryFilter(c => !c.IsDeleted);

			modelBuilder.Entity<TableSession>()
				.HasIndex(s => s.SessionNo)
				.IsUnique();

			modelBuilder.Entity<DeliveryZone>()
				.Property(z => z.DeliveryFee)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Dish>()
				.HasQueryFilter(d => !d.IsDeleted);

			modelBuilder.Entity<Order>()
				.HasQueryFilter(o => !o.IsDeleted);

			modelBuilder.Entity<DeliveryZone>()
				.HasQueryFilter(z => !z.IsDeleted);

			modelBuilder.Entity<DiningTable>()
				.HasQueryFilter(t => !t.IsDeleted);

			modelBuilder.Entity<User>()
				.HasQueryFilter(u => !u.IsDeleted);

			modelBuilder.Entity<Order>()
				.Property(o => o.TotalAmount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Order>()
				.Property(o => o.DeliveryFee)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Dish>()
				.Property(d => d.Price)
				.HasPrecision(10, 2);

			modelBuilder.Entity<OrderItem>()
				.Property(oi => oi.Price)
				.HasPrecision(10, 2);

			modelBuilder.Entity<DiningTable>()
				.HasIndex(t => t.TableNumber)
				.IsUnique();

			modelBuilder.Entity<User>()
				.HasIndex(u => u.Username)
				.IsUnique();

			modelBuilder.Entity<Order>()
				.HasIndex(o => o.OrderNo)
				.IsUnique();
		}
	}
}
