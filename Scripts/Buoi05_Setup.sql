-- =========================================================================
-- HỌ VÀ TÊN: BÙI THỊ DIỄM TRINH
-- MÃ SINH VIÊN: 2124110287
-- LỚP: CCQ2411D
-- MÔ TẢ: SCRIPT KHỞI TẠO BẢNG ORDERS, ORDERDETAILS, SEED DỮ LIỆU VÀ STORED PROCEDURES BUỔI 5
-- =========================================================================

USE BuiThiDiemTrinhMiniSupermarketDb;
GO

-- 1. TẠO BẢNG Orders NẾU CHƯA CÓ
IF OBJECT_ID('dbo.Orders', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Orders (
        OrderId INT IDENTITY(1,1) PRIMARY KEY,
        OrderCode VARCHAR(30) NOT NULL,
        CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
        CashierUsername VARCHAR(50) NOT NULL,
        CustomerId INT NULL,
        TotalItems INT NOT NULL,
        FinalAmount DECIMAL(18,2) NOT NULL,
        RewardPoints INT NOT NULL DEFAULT 0
    );
    PRINT N'-> Đã tạo bảng Orders thành công.';
END
GO

-- 2. TẠO BẢNG OrderDetails NẾU CHƯA CÓ
IF OBJECT_ID('dbo.OrderDetails', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.OrderDetails (
        OrderDetailId INT IDENTITY(1,1) PRIMARY KEY,
        OrderId INT NOT NULL,
        ProductId INT NOT NULL,
        Quantity INT NOT NULL,
        UnitPrice DECIMAL(18,2) NOT NULL,
        LineTotal DECIMAL(18,2) NOT NULL,
        CONSTRAINT FK_OrderDetails_Orders FOREIGN KEY (OrderId) REFERENCES dbo.Orders(OrderId) ON DELETE CASCADE,
        CONSTRAINT FK_OrderDetails_Products FOREIGN KEY (ProductId) REFERENCES dbo.Products(ProductId)
    );
    PRINT N'-> Đã tạo bảng OrderDetails thành công.';
END
GO

-- 3. SEED 15 HÓA ĐƠN MẪU ĐÚNG THEO SỐ LIỆU BÁO CÁO TIẾT 3
IF NOT EXISTS (SELECT 1 FROM dbo.Orders)
BEGIN
    SET IDENTITY_INSERT dbo.Orders ON;

    -- Cashier01: 4 hóa đơn, Tổng = 1,322,000, Điểm = 131
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints) VALUES
    (1, 'HD-20260825-01', '2026-08-25 08:30:00', 'cashier01', 1, 4, 350000.00, 35),
    (2, 'HD-20260826-02', '2026-08-26 10:15:00', 'cashier01', 2, 5, 420000.00, 42),
    (3, 'HD-20260827-03', '2026-08-27 14:00:00', 'cashier01', 3, 2, 252000.00, 25),
    (4, 'HD-20260828-04', '2026-08-28 16:45:00', 'cashier01', 4, 3, 300000.00, 29);

    -- Cashier02: 3 hóa đơn, Tổng = 253,000, Điểm = 24
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints) VALUES
    (5, 'HD-20260825-05', '2026-08-25 09:10:00', 'cashier02', 5, 2, 85000.00, 8),
    (6, 'HD-20260826-06', '2026-08-26 11:20:00', 'cashier02', 6, 3, 98000.00, 9),
    (7, 'HD-20260827-07', '2026-08-27 15:30:00', 'cashier02', 7, 2, 70000.00, 7);

    -- Cashier03: 2 hóa đơn, Tổng = 1,435,000, Điểm = 143
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints) VALUES
    (8, 'HD-20260828-08', '2026-08-28 10:00:00', 'cashier03', 8, 6, 720000.00, 72),
    (9, 'HD-20260829-09', '2026-08-29 17:30:00', 'cashier03', 9, 7, 715000.00, 71);

    -- Cashier04: 3 hóa đơn, Tổng = 484,000, Điểm = 48
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints) VALUES
    (10, 'HD-20260825-10', '2026-08-25 13:00:00', 'cashier04', 10, 3, 160000.00, 16),
    (11, 'HD-20260827-11', '2026-08-27 16:20:00', 'cashier04', 11, 4, 184000.00, 18),
    (12, 'HD-20260829-12', '2026-08-29 18:40:00', 'cashier04', 12, 3, 140000.00, 14);

    -- Cashier05: 3 hóa đơn, Tổng = 1,328,000, Điểm = 132
    INSERT INTO dbo.Orders (OrderId, OrderCode, CreatedDate, CashierUsername, CustomerId, TotalItems, FinalAmount, RewardPoints) VALUES
    (13, 'HD-20260826-13', '2026-08-26 14:10:00', 'cashier05', 13, 5, 450000.00, 45),
    (14, 'HD-20260828-14', '2026-08-28 15:25:00', 'cashier05', 1, 6, 488000.00, 48),
    (15, 'HD-20260830-15', '2026-08-30 19:15:00', 'cashier05', 2, 4, 390000.00, 39);

    SET IDENTITY_INSERT dbo.Orders OFF;
    PRINT N'-> Đã chèn 15 hóa đơn mẫu vào Orders.';
END
GO

-- 4. SEED CHI TIẾT HÓA ĐƠN CHO 15 ĐƠN MẪU
IF NOT EXISTS (SELECT 1 FROM dbo.OrderDetails)
BEGIN
    INSERT INTO dbo.OrderDetails (OrderId, ProductId, Quantity, UnitPrice, LineTotal) VALUES
    -- Đơn 1 (350,000)
    (1, 1, 2, 125000.00, 250000.00),
    (1, 2, 10, 10000.00, 100000.00),
    -- Đơn 2 (420,000)
    (2, 6, 2, 145000.00, 290000.00),
    (2, 8, 2, 65000.00, 130000.00),
    -- Đơn 3 (252,000)
    (3, 11, 2, 115000.00, 230000.00),
    (3, 9, 1, 18000.00, 18000.00),
    (3, 13, 1, 4000.00, 4000.00),
    -- Đơn 4 (300,000)
    (4, 1, 2, 125000.00, 250000.00),
    (4, 2, 5, 10000.00, 50000.00),
    -- Đơn 5 (85,000)
    (5, 4, 10, 4500.00, 45000.00),
    (5, 2, 4, 10000.00, 40000.00),
    -- Đơn 6 (98,000)
    (6, 14, 2, 42000.00, 84000.00),
    (6, 3, 1, 14000.00, 14000.00),
    -- Đơn 7 (70,000)
    (7, 7, 2, 28000.00, 56000.00),
    (7, 3, 2, 7000.00, 14000.00),
    -- Đơn 8 (720,000)
    (8, 1, 4, 125000.00, 500000.00),
    (8, 11, 1, 115000.00, 115000.00),
    (8, 2, 10, 10000.00, 105000.00),
    -- Đơn 9 (715,000)
    (9, 6, 3, 145000.00, 435000.00),
    (9, 14, 5, 42000.00, 210000.00),
    (9, 8, 1, 70000.00, 70000.00),
    -- Đơn 10 (160,000)
    (10, 8, 2, 65000.00, 130000.00),
    (10, 2, 3, 10000.00, 30000.00),
    -- Đơn 11 (184,000)
    (11, 14, 4, 42000.00, 168000.00),
    (11, 4, 3, 4500.00, 16000.00),
    -- Đơn 12 (140,000)
    (12, 15, 2, 68000.00, 136000.00),
    (12, 13, 1, 4000.00, 4000.00),
    -- Đơn 13 (450,000)
    (13, 1, 3, 125000.00, 375000.00),
    (13, 3, 10, 7500.00, 75000.00),
    -- Đơn 14 (488,000)
    (14, 6, 2, 145000.00, 290000.00),
    (14, 11, 1, 115000.00, 115000.00),
    (14, 2, 8, 10000.00, 83000.00),
    -- Đơn 15 (390,000)
    (15, 1, 2, 125000.00, 250000.00),
    (15, 8, 2, 65000.00, 130000.00),
    (15, 2, 1, 10000.00, 10000.00);

    PRINT N'-> Đã chèn dữ liệu mẫu vào OrderDetails.';
END
GO

-- 5. STORED PROCEDURE: sp_GetRevenueByCashier
IF OBJECT_ID('sp_GetRevenueByCashier', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByCashier;
GO

CREATE PROCEDURE sp_GetRevenueByCashier
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END
GO
PRINT N'-> Đã tạo Stored Procedure sp_GetRevenueByCashier thành công.';
GO

-- 6. STORED PROCEDURE BỔ SUNG (BÀI TẬP 3.1): sp_GetRevenueByDateRange
IF OBJECT_ID('sp_GetRevenueByDateRange', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetRevenueByDateRange;
GO

CREATE PROCEDURE sp_GetRevenueByDateRange
    @FromDate DATETIME,
    @ToDate DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        CashierUsername,
        COUNT(OrderId) AS TotalOrders,
        SUM(FinalAmount) AS TotalRevenue,
        SUM(RewardPoints) AS TotalPointsAwarded
    FROM Orders
    WHERE CreatedDate >= @FromDate AND CreatedDate <= @ToDate
    GROUP BY CashierUsername
    ORDER BY TotalRevenue DESC;
END
GO
PRINT N'-> Đã tạo Stored Procedure sp_GetRevenueByDateRange thành công.';
GO

-- 7. STORED PROCEDURE BỔ SUNG (BÀI TẬP 3.2): sp_GetTop5SellingProducts
IF OBJECT_ID('sp_GetTop5SellingProducts', 'P') IS NOT NULL
    DROP PROCEDURE sp_GetTop5SellingProducts;
GO

CREATE PROCEDURE sp_GetTop5SellingProducts
AS
BEGIN
    SET NOCOUNT ON;

    SELECT TOP 5
        p.ProductId,
        p.Barcode,
        p.ProductName,
        SUM(od.Quantity) AS TotalQuantitySold,
        SUM(od.LineTotal) AS TotalRevenue
    FROM OrderDetails od
    INNER JOIN Products p ON od.ProductId = p.ProductId
    GROUP BY p.ProductId, p.Barcode, p.ProductName
    ORDER BY TotalQuantitySold DESC;
END
GO
PRINT N'-> Đã tạo Stored Procedure sp_GetTop5SellingProducts thành công.';
GO
