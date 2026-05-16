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
		public DbSet<DeliveryZone> DeliveryZones { get; set; }
		public DbSet<DiningTable> DiningTables { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderItem>()
				.HasOne(oi => oi.Order)
				.WithMany(o => o.OrderItems)
				.HasForeignKey(oi => oi.OrderId);

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

			modelBuilder.Entity<DeliveryZone>()
				.HasIndex(z => new { z.Province, z.City, z.District })
				.IsUnique();

			modelBuilder.Entity<DiningTable>()
				.HasIndex(t => t.TableNumber)
				.IsUnique();
		}
	}
}
