-- 添加30个测试菜品（覆盖所有分类）- 已修正SaleStatus为OnSale
USE OnlineOrdering;

-- 热菜 (8个) - CategoryId=1, Category='热菜'
INSERT INTO Dishes (Name, Description, Price, CategoryId, Category, SpicyLevel, IsAvailable, SaleStatus, SortOrder, IsDeleted, CreatedAt, UpdatedAt) VALUES
('宫保鸡丁', '经典川菜，鸡肉嫩滑，花生酥脆，微辣可口', 38.00, 1, '热菜', 2, 1, 'OnSale', 1, 0, NOW(), NOW()),
('麻婆豆腐', '正宗四川风味，麻辣鲜香，下饭神器', 28.00, 1, '热菜', 3, 1, 'OnSale', 2, 0, NOW(), NOW()),
('红烧肉', '肥而不腻，入口即化，经典家常菜', 42.00, 1, '热菜', 0, 1, 'OnSale', 3, 0, NOW(), NOW()),
('糖醋排骨', '酸甜适口，外酥里嫩，老少皆宜', 45.00, 1, '热菜', 0, 1, 'OnSale', 4, 0, NOW(), NOW()),
('鱼香肉丝', '鱼香浓郁，肉丝滑嫩，配饭一绝', 32.00, 1, '热菜', 2, 1, 'OnSale', 5, 0, NOW(), NOW()),
('回锅肉', '川菜之魂，肥瘦相间，香辣过瘾', 35.00, 1, '热菜', 2, 1, 'OnSale', 6, 0, NOW(), NOW()),
('水煮牛肉', '麻辣鲜香，牛肉嫩滑，红油诱人', 48.00, 1, '热菜', 3, 1, 'OnSale', 7, 0, NOW(), NOW()),
('地三鲜', '土豆茄子青椒，家常美味，营养丰富', 26.00, 1, '热菜', 0, 1, 'OnSale', 8, 0, NOW(), NOW());

-- 凉菜 (5个) - CategoryId=2, Category='凉菜'
INSERT INTO Dishes (Name, Description, Price, CategoryId, Category, SpicyLevel, IsAvailable, SaleStatus, SortOrder, IsDeleted, CreatedAt, UpdatedAt) VALUES
('凉拌黄瓜', '清脆爽口，开胃解腻，夏日必备', 12.00, 2, '凉菜', 0, 1, 'OnSale', 1, 0, NOW(), NOW()),
('口水鸡', '麻辣鲜香，鸡肉嫩滑，川味十足', 32.00, 2, '凉菜', 2, 1, 'OnSale', 2, 0, NOW(), NOW()),
('拍黄瓜', '简单清爽，蒜香四溢，佐餐佳品', 10.00, 2, '凉菜', 0, 1, 'OnSale', 3, 0, NOW(), NOW()),
('夫妻肺片', '麻辣鲜香，牛杂丰富，经典凉菜', 38.00, 2, '凉菜', 2, 1, 'OnSale', 4, 0, NOW(), NOW()),
('凉拌木耳', '脆嫩爽口，营养丰富，健康选择', 16.00, 2, '凉菜', 0, 1, 'OnSale', 5, 0, NOW(), NOW());

-- 主食 (5个) - CategoryId=3, Category='主食'
INSERT INTO Dishes (Name, Description, Price, CategoryId, Category, SpicyLevel, IsAvailable, SaleStatus, SortOrder, IsDeleted, CreatedAt, UpdatedAt) VALUES
('扬州炒饭', '粒粒分明，配料丰富，经典主食', 18.00, 3, '主食', 0, 1, 'OnSale', 1, 0, NOW(), NOW()),
('西红柿鸡蛋面', '酸甜开胃，面条劲道，家常味道', 15.00, 3, '主食', 0, 1, 'OnSale', 2, 0, NOW(), NOW()),
('牛肉面', '汤浓肉香，面条爽滑，能量满满', 22.00, 3, '主食', 0, 1, 'OnSale', 3, 0, NOW(), NOW()),
('蛋炒饭', '金黄诱人，粒粒分明，简单美味', 12.00, 3, '主食', 0, 1, 'OnSale', 4, 0, NOW(), NOW()),
('水饺（份）', '皮薄馅大，手工制作，鲜美多汁', 20.00, 3, '主食', 0, 1, 'OnSale', 5, 0, NOW(), NOW());

-- 饮品 (4个) - CategoryId=4, Category='饮品'
INSERT INTO Dishes (Name, Description, Price, CategoryId, Category, SpicyLevel, IsAvailable, SaleStatus, SortOrder, IsDeleted, CreatedAt, UpdatedAt) VALUES
('鲜榨橙汁', '新鲜橙子榨取，维C满满，酸甜可口', 15.00, 4, '饮品', 0, 1, 'OnSale', 1, 0, NOW(), NOW()),
('冰镇酸梅汤', '消暑解渴，酸甜适中，传统饮品', 8.00, 4, '饮品', 0, 1, 'OnSale', 2, 0, NOW(), NOW()),
('珍珠奶茶', '香浓丝滑，珍珠Q弹，人气饮品', 13.00, 4, '饮品', 0, 1, 'OnSale', 3, 0, NOW(), NOW()),
('绿豆汤', '清热解暑，天然健康，夏日必备', 6.00, 4, '饮品', 0, 1, 'OnSale', 4, 0, NOW(), NOW());

-- 汤类 (4个) - CategoryId=5, Category='汤类'
INSERT INTO Dishes (Name, Description, Price, CategoryId, Category, SpicyLevel, IsAvailable, SaleStatus, SortOrder, IsDeleted, CreatedAt, UpdatedAt) VALUES
('番茄蛋花汤', '酸甜开胃，蛋花嫩滑，家常美味', 12.00, 5, '汤类', 0, 1, 'OnSale', 1, 0, NOW(), NOW()),
('紫菜蛋花汤', '清淡营养，紫菜鲜美，老少皆宜', 10.00, 5, '汤类', 0, 1, 'OnSale', 2, 0, NOW(), NOW()),
('冬瓜排骨汤', '清热降火，排骨酥烂，营养滋补', 25.00, 5, '汤类', 0, 1, 'OnSale', 3, 0, NOW(), NOW()),
('酸菜鱼片汤', '酸辣开胃，鱼肉嫩滑，汤鲜味美', 28.00, 5, '汤类', 1, 1, 'OnSale', 4, 0, NOW(), NOW());

-- 小吃 (4个) - CategoryId=6, Category='小吃'
INSERT INTO Dishes (Name, Description, Price, CategoryId, Category, SpicyLevel, IsAvailable, SaleStatus, SortOrder, IsDeleted, CreatedAt, UpdatedAt) VALUES
('炸鸡翅', '外酥里嫩，香气四溢，追剧必备', 18.00, 6, '小吃', 0, 1, 'OnSale', 1, 0, NOW(), NOW()),
('薯条（份）', '金黄酥脆，搭配番茄酱，经典小吃', 12.00, 6, '小吃', 0, 1, 'OnSale', 2, 0, NOW(), NOW()),
('春卷', '外皮酥脆，内馅丰富，传统美食', 15.00, 6, '小吃', 0, 1, 'OnSale', 3, 0, NOW(), NOW()),
('臭豆腐（份）', '闻着臭吃着香，湖南特色小吃', 14.00, 6, '小吃', 1, 1, 'OnSale', 4, 0, NOW(), NOW());
