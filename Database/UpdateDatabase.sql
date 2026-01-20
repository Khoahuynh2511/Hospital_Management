-- SQL Script to update database for Private Clinic
-- Run this script on your SQL Server database

-- =====================================================
-- 1. Add phone number and email to BENHNHAN table
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('BENHNHAN') AND name = 'SODIENTHOAI')
BEGIN
    ALTER TABLE BENHNHAN ADD SODIENTHOAI NVARCHAR(15) NULL;
    PRINT 'Added SODIENTHOAI column to BENHNHAN';
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('BENHNHAN') AND name = 'EMAIL')
BEGIN
    ALTER TABLE BENHNHAN ADD EMAIL NVARCHAR(100) NULL;
    PRINT 'Added EMAIL column to BENHNHAN';
END

-- =====================================================
-- 2. Add expiry date to THUOC table
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('THUOC') AND name = 'NGAYHETHAN')
BEGIN
    ALTER TABLE THUOC ADD NGAYHETHAN DATETIME NULL;
    PRINT 'Added NGAYHETHAN column to THUOC';
END

-- =====================================================
-- 3. Create HANGDOI (Queue) table
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HANGDOI')
BEGIN
    CREATE TABLE HANGDOI (
        MAHANGDOI INT IDENTITY(1,1) PRIMARY KEY,
        SUB_ID AS ('HD' + RIGHT('000000' + CAST(MAHANGDOI AS VARCHAR(6)), 6)),
        MABENHNHAN INT NULL,
        SOTHUTU INT NOT NULL,
        THOIGIANDANGKY DATETIME DEFAULT GETDATE(),
        TRANGTHAI NVARCHAR(20) DEFAULT N'Cho kham',
        GHICHU NVARCHAR(200) NULL,
        CONSTRAINT FK_HANGDOI_BENHNHAN FOREIGN KEY (MABENHNHAN) REFERENCES BENHNHAN(MABENHNHAN)
    );
    PRINT 'Created HANGDOI table';
END

-- =====================================================
-- 4. Create HOADON (Invoice) table
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'HOADON')
BEGIN
    CREATE TABLE HOADON (
        MAHOADON INT IDENTITY(1,1) PRIMARY KEY,
        SUB_ID AS ('INV' + RIGHT('000000' + CAST(MAHOADON AS VARCHAR(6)), 6)),
        MABENHNHAN INT NULL,
        MABENHAN INT NULL,
        NGAYLAP DATETIME DEFAULT GETDATE(),
        TONGTIEN MONEY NOT NULL DEFAULT 0,
        GIAMGIA MONEY DEFAULT 0,
        THANHTIEN MONEY NOT NULL DEFAULT 0,
        PHUONGTHUCTHANHTOAN NVARCHAR(50) DEFAULT N'Tien mat',
        TRANGTHAI NVARCHAR(20) DEFAULT N'Chua thanh toan',
        GHICHU NVARCHAR(500) NULL,
        CONSTRAINT FK_HOADON_BENHNHAN FOREIGN KEY (MABENHNHAN) REFERENCES BENHNHAN(MABENHNHAN),
        CONSTRAINT FK_HOADON_BENHAN FOREIGN KEY (MABENHAN) REFERENCES BENHAN(MABENHAN)
    );
    PRINT 'Created HOADON table';
END

-- =====================================================
-- 5. Create indexes for better performance
-- =====================================================
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_HANGDOI_TRANGTHAI')
BEGIN
    CREATE INDEX IX_HANGDOI_TRANGTHAI ON HANGDOI(TRANGTHAI);
END

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_HANGDOI_NGAY')
BEGIN
    CREATE INDEX IX_HANGDOI_NGAY ON HANGDOI(THOIGIANDANGKY);
END

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_HOADON_NGAY')
BEGIN
    CREATE INDEX IX_HOADON_NGAY ON HOADON(NGAYLAP);
END

IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_HOADON_TRANGTHAI')
BEGIN
    CREATE INDEX IX_HOADON_TRANGTHAI ON HOADON(TRANGTHAI);
END

PRINT '';
PRINT '=====================================================';
PRINT 'Database updated successfully for Private Clinic';
PRINT '=====================================================';
