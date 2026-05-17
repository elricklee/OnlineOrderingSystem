-- 重置数据库迁移脚本
-- 执行此脚本后，需要重新运行 dotnet ef migrations add InitialCreate 和 Update-Database

-- 1. 删除所有表（按依赖顺序）
SET FOREIGN_KEY_CHECKS = 0;

DROP TABLE IF EXISTS OrderStatusHistories;
DROP TABLE IF EXISTS OrderItems;
DROP TABLE IF EXISTS Orders;
DROP TABLE IF EXISTS TableSessions;
DROP TABLE IF EXISTS Dishes;
DROP TABLE IF EXISTS DishCategories;
DROP TABLE IF EXISTS DeliveryZones;
DROP TABLE IF EXISTS DiningTables;
DROP TABLE IF EXISTS Users;
DROP TABLE IF EXISTS __EFMigrationsHistory;

SET FOREIGN_KEY_CHECKS = 1;

-- 2. 验证所有表已删除
SHOW TABLES;
