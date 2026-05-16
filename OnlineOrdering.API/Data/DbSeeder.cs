using Microsoft.EntityFrameworkCore;
using OnlineOrdering.API.Models;
using System.Data;

namespace OnlineOrdering.API.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext db)
        {
            await EnsureSchemaAsync(db);

            if (!await db.DeliveryZones.AnyAsync())
            {
                db.DeliveryZones.AddRange(
                    new DeliveryZone
                    {
                        Province = "\u6E56\u5317\u7701",
                        City = "\u6B66\u6C49\u5E02",
                        District = "\u6B66\u660C\u533A",
                        DeliveryFee = 4m,
                        SortOrder = 1,
                        IsActive = true
                    },
                    new DeliveryZone
                    {
                        Province = "\u6E56\u5317\u7701",
                        City = "\u6B66\u6C49\u5E02",
                        District = "\u6D2A\u5C71\u533A",
                        DeliveryFee = 5m,
                        SortOrder = 2,
                        IsActive = true
                    },
                    new DeliveryZone
                    {
                        Province = "\u6E56\u5317\u7701",
                        City = "\u6B66\u6C49\u5E02",
                        District = "\u6C5F\u590F\u533A",
                        DeliveryFee = 7m,
                        SortOrder = 3,
                        IsActive = true
                    }
                );
            }

            if (!await db.DiningTables.AnyAsync())
            {
                db.DiningTables.AddRange(
                    new DiningTable { TableNumber = "A01", SeatCount = 2, IsEnabled = true, IsOccupied = false },
                    new DiningTable { TableNumber = "A02", SeatCount = 2, IsEnabled = true, IsOccupied = false },
                    new DiningTable { TableNumber = "B01", SeatCount = 4, IsEnabled = true, IsOccupied = false },
                    new DiningTable { TableNumber = "B02", SeatCount = 4, IsEnabled = true, IsOccupied = false },
                    new DiningTable { TableNumber = "C01", SeatCount = 6, IsEnabled = true, IsOccupied = false },
                    new DiningTable { TableNumber = "C02", SeatCount = 8, IsEnabled = true, IsOccupied = false }
                );
            }

            await db.SaveChangesAsync();
        }

        private static async Task EnsureSchemaAsync(AppDbContext db)
        {
            await db.Database.ExecuteSqlRawAsync("""
                CREATE TABLE IF NOT EXISTS `DeliveryZones` (
                    `Id` int NOT NULL AUTO_INCREMENT,
                    `Province` longtext NOT NULL,
                    `City` longtext NOT NULL,
                    `District` longtext NOT NULL,
                    `DeliveryFee` decimal(65,30) NOT NULL,
                    `IsActive` tinyint(1) NOT NULL,
                    `SortOrder` int NOT NULL,
                    PRIMARY KEY (`Id`)
                ) CHARACTER SET=utf8mb4;
                """);

            await db.Database.ExecuteSqlRawAsync("""
                CREATE TABLE IF NOT EXISTS `DiningTables` (
                    `Id` int NOT NULL AUTO_INCREMENT,
                    `TableNumber` longtext NOT NULL,
                    `SeatCount` int NOT NULL,
                    `IsOccupied` tinyint(1) NOT NULL,
                    `IsEnabled` tinyint(1) NOT NULL,
                    PRIMARY KEY (`Id`)
                ) CHARACTER SET=utf8mb4;
                """);

            await EnsureColumnExistsAsync(db, "Orders", "DiningTableId", "int NULL");
            await EnsureColumnExistsAsync(db, "Orders", "DeliveryZoneId", "int NULL");
            await EnsureColumnExistsAsync(db, "Orders", "DeliveryRegion", "longtext NULL");
        }

        private static async Task EnsureColumnExistsAsync(
            AppDbContext db,
            string tableName,
            string columnName,
            string columnDefinition)
        {
            var connection = db.Database.GetDbConnection();
            var shouldClose = connection.State != ConnectionState.Open;

            if (shouldClose)
            {
                await connection.OpenAsync();
            }

            try
            {
                await using var existsCommand = connection.CreateCommand();
                existsCommand.CommandText = """
                    SELECT COUNT(*)
                    FROM INFORMATION_SCHEMA.COLUMNS
                    WHERE TABLE_SCHEMA = DATABASE()
                      AND TABLE_NAME = @tableName
                      AND COLUMN_NAME = @columnName;
                    """;

                var tableParam = existsCommand.CreateParameter();
                tableParam.ParameterName = "@tableName";
                tableParam.Value = tableName;
                existsCommand.Parameters.Add(tableParam);

                var columnParam = existsCommand.CreateParameter();
                columnParam.ParameterName = "@columnName";
                columnParam.Value = columnName;
                existsCommand.Parameters.Add(columnParam);

                var exists = Convert.ToInt32(await existsCommand.ExecuteScalarAsync()) > 0;
                if (exists)
                {
                    return;
                }

                var sql =
                    "ALTER TABLE `" + tableName + "` ADD COLUMN `" + columnName + "` " + columnDefinition + ";";
                await db.Database.ExecuteSqlRawAsync(sql);
            }
            finally
            {
                if (shouldClose)
                {
                    await connection.CloseAsync();
                }
            }
        }
    }
}
