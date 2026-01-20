-- Sample Data for Private Clinic Management System
-- Run this script after UpdateDatabase.sql

USE QUANLYBENHVIEN;
GO

-- Clear existing data (optional - comment out if you want to keep existing data)
DELETE FROM CHITIETDONTHUOC;
DELETE FROM DONTHUOC;
DELETE FROM HOADON;
DELETE FROM HANGDOI;
DELETE FROM LICHKHAM;
DELETE FROM BENHAN_HISTORY;
DELETE FROM BENHAN;
DELETE FROM BENHNHAN;
DELETE FROM YSI;
DELETE FROM KHOA;
DELETE FROM PHONG;
DELETE FROM DICHVU;
DELETE FROM THUOC;
DELETE FROM TAIKHOAN;
GO

-- Reset identity columns
DBCC CHECKIDENT ('PHONG', RESEED, 0);
DBCC CHECKIDENT ('KHOA', RESEED, 0);
DBCC CHECKIDENT ('YSI', RESEED, 0);
DBCC CHECKIDENT ('BENHNHAN', RESEED, 0);
DBCC CHECKIDENT ('DICHVU', RESEED, 0);
DBCC CHECKIDENT ('THUOC', RESEED, 0);
DBCC CHECKIDENT ('BENHAN', RESEED, 0);
DBCC CHECKIDENT ('DONTHUOC', RESEED, 0);
DBCC CHECKIDENT ('LICHKHAM', RESEED, 0);
DBCC CHECKIDENT ('HANGDOI', RESEED, 0);
DBCC CHECKIDENT ('HOADON', RESEED, 0);
GO

-- =============================================
-- 1. PHONG (Rooms)
-- =============================================
SET IDENTITY_INSERT PHONG ON;
INSERT INTO PHONG (MAPHONG, TANG, TENPHONG, SUCCHUA) VALUES
(1, 1, N'Phong kham 101', 10),
(2, 1, N'Phong kham 102', 8),
(3, 1, N'Phong kham 103', 12),
(4, 2, N'Phong kham 201', 10),
(5, 2, N'Phong kham 202', 8),
(6, 2, N'Phong xet nghiem', 6),
(7, 3, N'Phong sieu am', 4),
(8, 3, N'Phong X-Quang', 4),
(9, 3, N'Phong thu thuat', 6),
(10, 1, N'Phong tiep nhan', 20);
SET IDENTITY_INSERT PHONG OFF;
GO

-- =============================================
-- 2. KHOA (Departments) - insert without TRUONGKHOA first
-- =============================================
SET IDENTITY_INSERT KHOA ON;
INSERT INTO KHOA (MAKHOA, TENKHOA, NGAYTHANHLAP, TRUONGKHOA, PICTURE) VALUES
(1, N'Khoa Noi', '2020-01-15', NULL, NULL),
(2, N'Khoa Ngoai', '2020-01-15', NULL, NULL),
(3, N'Khoa Nhi', '2020-03-01', NULL, NULL),
(4, N'Khoa San', '2020-03-01', NULL, NULL),
(5, N'Khoa Mat', '2020-06-01', NULL, NULL),
(6, N'Khoa Rang Ham Mat', '2021-01-01', NULL, NULL),
(7, N'Khoa Chan Doan Hinh Anh', '2020-01-15', NULL, NULL),
(8, N'Khoa Xet Nghiem', '2020-01-15', NULL, NULL);
SET IDENTITY_INSERT KHOA OFF;
GO

-- =============================================
-- 3. YSI (Doctors/Medical Staff)
-- =============================================
SET IDENTITY_INSERT YSI ON;
INSERT INTO YSI (MAYSI, MAKHOA, MAPHONG, HOTEN, GIOITINH, NGAYSINH, NGAYVAOLAM, LOAIYSI, MACHIHUY) VALUES
(1, 1, 1, N'Nguyen Van An', N'Nam', '1975-05-10', '2020-01-15', N'Bác sĩ', NULL),
(2, 1, 2, N'Tran Thi Binh', N'Nu', '1980-08-20', '2020-02-01', N'Bác sĩ', 1),
(3, 2, 3, N'Le Van Cuong', N'Nam', '1978-03-15', '2020-01-15', N'Bác sĩ', NULL),
(4, 2, 4, N'Pham Thi Dung', N'Nu', '1985-11-25', '2020-03-01', N'Bác sĩ', 3),
(5, 3, 5, N'Hoang Van Em', N'Nam', '1982-07-08', '2020-03-15', N'Bác sĩ', NULL),
(6, 4, 1, N'Nguyen Thi Phuong', N'Nu', '1979-09-12', '2020-04-01', N'Bác sĩ', NULL),
(7, 5, 2, N'Vo Van Giang', N'Nam', '1983-01-30', '2020-06-01', N'Bác sĩ', NULL),
(8, 6, 3, N'Tran Van Hung', N'Nam', '1981-04-18', '2021-01-01', N'Bác sĩ', NULL),
(9, 7, 7, N'Le Thi Huong', N'Nu', '1986-12-05', '2020-02-15', N'Kỹ thuật viên', NULL),
(10, 8, 6, N'Phan Van Khanh', N'Nam', '1988-06-22', '2020-02-15', N'Kỹ thuật viên', NULL),
(11, 1, 1, N'Dinh Thi Lan', N'Nu', '1990-02-14', '2021-06-01', N'Y tá', 1),
(12, 2, 3, N'Bui Van Minh', N'Nam', '1992-10-08', '2021-08-01', N'Y tá', 3),
(13, 1, 10, N'Cao Thi Nga', N'Nu', '1993-05-20', '2022-01-01', N'Lễ tân', NULL),
(14, 1, 10, N'Do Van Phuc', N'Nam', '1995-07-15', '2022-03-01', N'Lễ tân', 13),
(15, 3, 5, N'Truong Thi Quyen', N'Nu', '1987-09-28', '2020-05-01', N'Y tá', 5);
SET IDENTITY_INSERT YSI OFF;
GO

-- Update department heads
UPDATE KHOA SET TRUONGKHOA = 1 WHERE MAKHOA = 1;
UPDATE KHOA SET TRUONGKHOA = 3 WHERE MAKHOA = 2;
UPDATE KHOA SET TRUONGKHOA = 5 WHERE MAKHOA = 3;
UPDATE KHOA SET TRUONGKHOA = 6 WHERE MAKHOA = 4;
UPDATE KHOA SET TRUONGKHOA = 7 WHERE MAKHOA = 5;
UPDATE KHOA SET TRUONGKHOA = 8 WHERE MAKHOA = 6;
UPDATE KHOA SET TRUONGKHOA = 9 WHERE MAKHOA = 7;
UPDATE KHOA SET TRUONGKHOA = 10 WHERE MAKHOA = 8;
GO

-- =============================================
-- 4. TAIKHOAN (User Accounts)
-- Password hash is for '123456' using MYHASH format
-- =============================================
INSERT INTO TAIKHOAN (TENDANGNHAP, MATKHAU, MASO, LOAITAIKHOAN, AVATAR) VALUES
('admin', '$MYHASH$V1$10000$gUJf0rgFlWSFDXYEuXiAnX9L/DMh1z9LlHKqAdI09a1s1sl7', 'ADMIN001', N'Admin', NULL),
('bacsi01', '$MYHASH$V1$10000$gUJf0rgFlWSFDXYEuXiAnX9L/DMh1z9LlHKqAdI09a1s1sl7', 'BS001', N'Bac si', NULL),
('bacsi02', '$MYHASH$V1$10000$gUJf0rgFlWSFDXYEuXiAnX9L/DMh1z9LlHKqAdI09a1s1sl7', 'BS002', N'Bac si', NULL),
('bacsi03', '$MYHASH$V1$10000$gUJf0rgFlWSFDXYEuXiAnX9L/DMh1z9LlHKqAdI09a1s1sl7', 'BS003', N'Bac si', NULL),
('yta01', '$MYHASH$V1$10000$gUJf0rgFlWSFDXYEuXiAnX9L/DMh1z9LlHKqAdI09a1s1sl7', 'YT001', N'Y ta', NULL),
('letan01', '$MYHASH$V1$10000$gUJf0rgFlWSFDXYEuXiAnX9L/DMh1z9LlHKqAdI09a1s1sl7', 'LT001', N'Le tan', NULL);
GO

-- =============================================
-- 5. DICHVU (Services)
-- =============================================
SET IDENTITY_INSERT DICHVU ON;
INSERT INTO DICHVU (MADICHVU, TENDICHVU, GIATIEN, PICTURE) VALUES
(1, N'Kham tong quat', 150000, NULL),
(2, N'Kham noi khoa', 120000, NULL),
(3, N'Kham ngoai khoa', 150000, NULL),
(4, N'Kham nhi khoa', 130000, NULL),
(5, N'Kham san phu khoa', 180000, NULL),
(6, N'Kham mat', 100000, NULL),
(7, N'Kham rang ham mat', 120000, NULL),
(8, N'Sieu am bung', 200000, NULL),
(9, N'Sieu am tim', 350000, NULL),
(10, N'Chup X-Quang', 180000, NULL),
(11, N'Xet nghiem mau', 150000, NULL),
(12, N'Xet nghiem nuoc tieu', 80000, NULL),
(13, N'Dien tam do', 120000, NULL),
(14, N'Do mat', 50000, NULL),
(15, N'Nho rang', 200000, NULL),
(16, N'Tram rang', 150000, NULL),
(17, N'Tiem ngua', 100000, NULL),
(18, N'Thay bang', 50000, NULL),
(19, N'Cat chi', 80000, NULL),
(20, N'Tu van dinh duong', 100000, NULL);
SET IDENTITY_INSERT DICHVU OFF;
GO

-- =============================================
-- 6. THUOC (Medicines)
-- =============================================
SET IDENTITY_INSERT THUOC ON;
INSERT INTO THUOC (MATHUOC, GHICHU, GIATIEN, DONVITINH, TENTHUOC, SOLUONG) VALUES
(1, N'Giam dau, ha sot', 2000, N'Vien', N'Paracetamol 500mg', 1000),
(2, N'Khang sinh', 5000, N'Vien', N'Amoxicillin 500mg', 500),
(3, N'Khang sinh', 8000, N'Vien', N'Azithromycin 250mg', 300),
(4, N'Giam dau chong viem', 3000, N'Vien', N'Ibuprofen 400mg', 800),
(5, N'Di ung', 2500, N'Vien', N'Loratadine 10mg', 600),
(6, N'Ho', 15000, N'Chai', N'Siro ho Prospan', 200),
(7, N'Tieu hoa', 3000, N'Vien', N'Omeprazole 20mg', 400),
(8, N'Vitamin', 1500, N'Vien', N'Vitamin C 500mg', 1000),
(9, N'Vitamin', 2000, N'Vien', N'Vitamin B Complex', 800),
(10, N'Dau mat', 25000, N'Lo', N'Natri Clorid 0.9%', 300),
(11, N'Ha huyet ap', 4000, N'Vien', N'Amlodipine 5mg', 400),
(12, N'Tieu duong', 5000, N'Vien', N'Metformin 500mg', 500),
(13, N'Giam dau co xuong khop', 6000, N'Vien', N'Meloxicam 7.5mg', 300),
(14, N'Khi dung', 35000, N'Ong', N'Ventolin', 150),
(15, N'Kem boi', 45000, N'Tuyp', N'Betamethasone', 100),
(16, N'Khang sinh', 12000, N'Vien', N'Cefixime 200mg', 250),
(17, N'Tieu hoa', 2500, N'Vien', N'Domperidone 10mg', 500),
(18, N'An than', 8000, N'Vien', N'Diazepam 5mg', 100),
(19, N'Khang virus', 15000, N'Vien', N'Acyclovir 400mg', 200),
(20, N'Bo sung sat', 3500, N'Vien', N'Ferrous Sulfate', 400);
SET IDENTITY_INSERT THUOC OFF;
GO

-- =============================================
-- 7. BENHNHAN (Patients)
-- =============================================
SET IDENTITY_INSERT BENHNHAN ON;
INSERT INTO BENHNHAN (MABENHNHAN, MAPHONG, HOTEN, GIOITINH, NGAYSINH, DIACHI, MABHYT, NGAYNHAPVIEN, SODIENTHOAI, EMAIL) VALUES
(1, 1, N'Nguyen Van Anh', N'Nam', '1985-03-15', N'123 Le Loi, Q1, HCM', 'BH001234567890', '2024-01-10', '0901234567', 'nguyenvananh@email.com'),
(2, 2, N'Tran Thi Be', N'Nu', '1990-07-22', N'456 Nguyen Hue, Q1, HCM', 'BH001234567891', '2024-01-12', '0901234568', 'tranthibe@email.com'),
(3, 3, N'Le Van Cao', N'Nam', '1978-11-08', N'789 Hai Ba Trung, Q3, HCM', NULL, '2024-01-15', '0901234569', NULL),
(4, 1, N'Pham Thi Dao', N'Nu', '1995-05-30', N'321 CMT8, Q10, HCM', 'BH001234567892', '2024-01-18', '0901234570', 'phamthidao@email.com'),
(5, 2, N'Hoang Van Em', N'Nam', '2015-09-12', N'654 Ly Tu Trong, Q1, HCM', 'BH001234567893', '2024-01-20', '0901234571', NULL),
(6, 3, N'Vo Thi Phuong', N'Nu', '1988-02-28', N'987 Dien Bien Phu, BT, HCM', NULL, '2024-01-22', '0901234572', 'vothiphuong@email.com'),
(7, 1, N'Dang Van Giang', N'Nam', '1972-08-05', N'147 Ba Thang Hai, Q10, HCM', 'BH001234567894', '2024-01-25', '0901234573', NULL),
(8, 2, N'Bui Thi Huong', N'Nu', '2000-12-18', N'258 Nguyen Trai, Q5, HCM', NULL, '2024-01-28', '0901234574', 'buithihuong@email.com'),
(9, 3, N'Cao Van Ich', N'Nam', '1982-04-10', N'369 Vo Van Tan, Q3, HCM', 'BH001234567895', '2024-02-01', '0901234575', NULL),
(10, 1, N'Do Thi Kim', N'Nu', '1965-06-25', N'741 Le Van Sy, PN, HCM', 'BH001234567896', '2024-02-05', '0901234576', 'dothikim@email.com'),
(11, 2, N'Nguyen Van Long', N'Nam', '1998-01-14', N'852 Truong Chinh, TB, HCM', NULL, '2024-02-08', '0901234577', NULL),
(12, 3, N'Tran Thi Mai', N'Nu', '2010-10-20', N'963 Cach Mang T8, Q3, HCM', 'BH001234567897', '2024-02-10', '0901234578', NULL),
(13, 1, N'Le Van Nam', N'Nam', '1955-07-03', N'159 Pasteur, Q1, HCM', 'BH001234567898', '2024-02-12', '0901234579', 'levannam@email.com'),
(14, 2, N'Pham Thi Oanh', N'Nu', '1993-09-17', N'357 Nam Ky Khoi Nghia, Q3, HCM', NULL, '2024-02-15', '0901234580', NULL),
(15, 3, N'Hoang Van Phuc', N'Nam', '1987-11-29', N'468 Nguyen Dinh Chieu, Q3, HCM', 'BH001234567899', '2024-02-18', '0901234581', 'hoangvanphuc@email.com'),
(16, 1, N'Vo Thi Quyen', N'Nu', '1975-03-08', N'579 Tran Hung Dao, Q5, HCM', NULL, '2024-02-20', '0901234582', NULL),
(17, 2, N'Dang Van Rung', N'Nam', '2005-08-22', N'681 Le Hong Phong, Q10, HCM', 'BH001234567900', '2024-02-22', '0901234583', NULL),
(18, 3, N'Bui Thi Sen', N'Nu', '1992-04-15', N'792 An Duong Vuong, Q5, HCM', NULL, '2024-02-25', '0901234584', 'buithisen@email.com'),
(19, 1, N'Cao Van Tai', N'Nam', '1968-12-01', N'813 Hong Bang, Q5, HCM', 'BH001234567901', '2024-02-28', '0901234585', NULL),
(20, 2, N'Do Thi Uyen', N'Nu', '2018-06-30', N'924 Ly Thai To, Q10, HCM', 'BH001234567902', '2024-03-01', '0901234586', NULL);
SET IDENTITY_INSERT BENHNHAN OFF;
GO

-- =============================================
-- 8. BENHAN (Medical Records)
-- =============================================
SET IDENTITY_INSERT BENHAN ON;
INSERT INTO BENHAN (MABENHAN, MAYSI, MABENHNHAN, MADICHVU, THANHTIEN, TRIEUCHUNG, NGAYKHAM, KETLUAN) VALUES
(1, 1, 1, 2, 120000, N'Dau dau, met moi, sot nhe', '2024-01-10', N'Cam cum thong thuong'),
(2, 2, 2, 1, 150000, N'Ho, dau hong, so mui', '2024-01-12', N'Viem hong cap'),
(3, 3, 3, 3, 150000, N'Dau bung, buon non', '2024-01-15', N'Roi loan tieu hoa'),
(4, 5, 5, 4, 130000, N'Sot, ho, chay nuoc mui', '2024-01-20', N'Viem duong ho hap tren'),
(5, 6, 4, 5, 180000, N'Kham thai dinh ky', '2024-01-18', N'Thai 12 tuan, binh thuong'),
(6, 7, 6, 6, 100000, N'Mo mat, nhin khong ro', '2024-01-22', N'Can thi nhe'),
(7, 8, 7, 7, 120000, N'Dau rang, sung loi', '2024-01-25', N'Viem loi'),
(8, 1, 8, 2, 120000, N'Chong mat, buon non', '2024-01-28', N'Roi loan tien dinh'),
(9, 2, 9, 1, 150000, N'Dau khop, cung co', '2024-02-01', N'Viem khop dang thap'),
(10, 3, 10, 3, 150000, N'Dau nguc, kho tho', '2024-02-05', N'Tang huyet ap'),
(11, 5, 12, 4, 130000, N'Sot cao, phat ban', '2024-02-10', N'Soi'),
(12, 1, 13, 2, 120000, N'Met moi, an kem', '2024-02-12', N'Thieu mau'),
(13, 2, 14, 1, 150000, N'Dau lung, te chan', '2024-02-15', N'Thoat vi dia dem'),
(14, 3, 15, 3, 150000, N'Tieu chay, mat nuoc', '2024-02-18', N'Nhiem trung duong ruot'),
(15, 1, 16, 2, 120000, N'Ho keo dai, dau nguc', '2024-02-20', N'Viem phe quan'),
(16, 5, 17, 4, 130000, N'Dau bung, non oi', '2024-02-22', N'Viem da day'),
(17, 6, 18, 5, 180000, N'Kham phu khoa dinh ky', '2024-02-25', N'Binh thuong'),
(18, 7, 19, 6, 100000, N'Dau mat, chay nuoc mat', '2024-02-28', N'Viem ket mac'),
(19, 8, 1, 7, 120000, N'Dau rang so 6', '2024-03-01', N'Sau rang, can tram'),
(20, 1, 2, 2, 120000, N'Dau dau du doi', '2024-03-05', N'Dau nua dau'),
(21, 2, 3, 8, 200000, N'Dau bung phai', '2024-03-08', N'Soi mat'),
(22, 3, 4, 10, 180000, N'Ho dam, kho tho', '2024-03-10', N'Viem phoi');
SET IDENTITY_INSERT BENHAN OFF;
GO

-- =============================================
-- 9. DONTHUOC (Prescriptions)
-- =============================================
SET IDENTITY_INSERT DONTHUOC ON;
INSERT INTO DONTHUOC (MADONTHUOC, MABENHAN, GHICHU) VALUES
(1, 1, N'Uong sau an. Nghi ngoi nhieu'),
(2, 2, N'Uong du lieu trinh 7 ngay'),
(3, 3, N'Uong truoc an 30 phut'),
(4, 4, N'Uong khi sot tren 38.5 do'),
(5, 5, NULL),
(6, 7, N'Suc mieng nuoc muoi sau an'),
(7, 8, N'Han che van dong manh'),
(8, 9, N'Tai kham sau 2 tuan'),
(9, 10, N'Kiem tra huyet ap thuong xuyen'),
(10, 12, N'Bo sung dinh duong'),
(11, 14, N'Uong nhieu nuoc'),
(12, 15, N'Tranh khoi bui'),
(13, 16, N'An nhe, chia nho bua an'),
(14, 18, N'Nho mat 3 lan/ngay'),
(15, 19, N'Khong an do nong lanh'),
(16, 20, N'Nghi ngoi phong toi'),
(17, 21, N'Kham lai sau 1 thang'),
(18, 22, N'Uong du lieu trinh khang sinh');
SET IDENTITY_INSERT DONTHUOC OFF;
GO

-- =============================================
-- 10. CHITIETDONTHUOC (Prescription Details)
-- =============================================
INSERT INTO CHITIETDONTHUOC (MADONTHUOC, MATHUOC, SOLUONG, SOLAN, GHICHU) VALUES
(1, 1, 20, 3, N'Uong khi sot'),
(1, 8, 10, 1, N'Uong sang'),
(2, 2, 21, 3, N'Uong sau an'),
(2, 6, 1, 3, N'5ml moi lan'),
(3, 7, 14, 2, N'Uong truoc an'),
(3, 17, 14, 3, N'Uong sau an'),
(4, 1, 10, 3, N'Khi sot cao'),
(4, 5, 7, 1, N'Uong toi'),
(6, 2, 14, 2, N'Uong sau an'),
(7, 4, 10, 2, N'Uong sau an'),
(7, 9, 10, 1, N'Uong sang'),
(8, 4, 14, 2, N'Uong sau an'),
(8, 13, 14, 1, N'Uong trua'),
(9, 11, 30, 1, N'Uong sang'),
(10, 20, 30, 1, N'Uong sau an'),
(10, 8, 30, 1, N'Uong sang'),
(11, 7, 10, 2, N'Uong truoc an'),
(12, 2, 21, 3, N'Uong du lieu'),
(12, 6, 1, 3, N'5ml moi lan'),
(13, 7, 14, 2, N'Uong truoc an'),
(13, 17, 14, 3, N'Uong sau an'),
(14, 10, 1, 4, N'Nho 2 giot moi mat'),
(15, 4, 7, 2, N'Uong sau an'),
(16, 1, 10, 3, N'Khi dau'),
(17, 7, 30, 2, N'Uong truoc an'),
(18, 16, 14, 2, N'Uong sau an'),
(18, 6, 1, 3, N'5ml moi lan');
GO

-- =============================================
-- 11. LICHKHAM (Appointments)
-- =============================================
SET IDENTITY_INSERT LICHKHAM ON;
INSERT INTO LICHKHAM (MALICHKHAM, MABACSI, MABENHNHAN, MAPHONG, MADICHVU, NGAYKHAM, NGAYLENLICH, CAKHAM) VALUES
(1, 1, 1, 1, 2, '2024-03-15', '2024-03-10', 1),
(2, 2, 2, 2, 1, '2024-03-15', '2024-03-10', 1),
(3, 3, 3, 3, 3, '2024-03-15', '2024-03-11', 2),
(4, 5, 5, 5, 4, '2024-03-16', '2024-03-12', 1),
(5, 6, 4, 1, 5, '2024-03-16', '2024-03-12', 2),
(6, 7, 6, 2, 6, '2024-03-17', '2024-03-13', 1),
(7, 8, 7, 3, 7, '2024-03-17', '2024-03-13', 2),
(8, 1, 8, 1, 2, '2024-03-18', '2024-03-14', 1),
(9, 2, 9, 2, 1, '2024-03-18', '2024-03-14', 2),
(10, 3, 10, 3, 3, '2024-03-19', '2024-03-15', 1),
(11, 1, 11, 1, 2, '2024-03-19', '2024-03-15', 2),
(12, 5, 12, 5, 4, '2024-03-20', '2024-03-16', 1),
(13, 1, 13, 1, 2, '2024-03-20', '2024-03-16', 2),
(14, 2, 14, 2, 1, '2024-03-21', '2024-03-17', 1),
(15, 3, 15, 3, 3, '2024-03-21', '2024-03-17', 2);
SET IDENTITY_INSERT LICHKHAM OFF;
GO

-- =============================================
-- 12. HANGDOI (Queue)
-- =============================================
SET IDENTITY_INSERT HANGDOI ON;
INSERT INTO HANGDOI (MAHANGDOI, MABENHNHAN, SOTHUTU, THOIGIANDANGKY, TRANGTHAI, GHICHU) VALUES
(1, 1, 1, GETDATE(), N'Da kham', NULL),
(2, 2, 2, GETDATE(), N'Da kham', NULL),
(3, 3, 3, GETDATE(), N'Dang kham', NULL),
(4, 4, 4, GETDATE(), N'Cho kham', NULL),
(5, 5, 5, GETDATE(), N'Cho kham', NULL),
(6, 6, 6, GETDATE(), N'Cho kham', N'Benh nhan uu tien'),
(7, 7, 7, GETDATE(), N'Cho kham', NULL),
(8, 8, 8, GETDATE(), N'Cho kham', NULL);
SET IDENTITY_INSERT HANGDOI OFF;
GO

-- =============================================
-- 13. HOADON (Invoices)
-- =============================================
SET IDENTITY_INSERT HOADON ON;
INSERT INTO HOADON (MAHOADON, MABENHNHAN, MABENHAN, NGAYLAP, TONGTIEN, GIAMGIA, THANHTIEN, PHUONGTHUCTHANHTOAN, TRANGTHAI, GHICHU) VALUES
(1, 1, 1, '2024-01-10', 160000, 0, 160000, N'Tien mat', N'Da thanh toan', NULL),
(2, 2, 2, '2024-01-12', 230000, 0, 230000, N'Chuyen khoan', N'Da thanh toan', NULL),
(3, 3, 3, '2024-01-15', 195000, 0, 195000, N'Tien mat', N'Da thanh toan', NULL),
(4, 5, 4, '2024-01-20', 160000, 0, 160000, N'The', N'Da thanh toan', NULL),
(5, 4, 5, '2024-01-18', 180000, 0, 180000, N'Chuyen khoan', N'Da thanh toan', NULL),
(6, 6, 6, '2024-01-22', 100000, 0, 100000, N'Tien mat', N'Da thanh toan', NULL),
(7, 7, 7, '2024-01-25', 162000, 0, 162000, N'Tien mat', N'Da thanh toan', NULL),
(8, 8, 8, '2024-01-28', 159000, 0, 159000, N'Chuyen khoan', N'Da thanh toan', NULL),
(9, 9, 9, '2024-02-01', 234000, 0, 234000, N'Tien mat', N'Da thanh toan', NULL),
(10, 10, 10, '2024-02-05', 270000, 0, 270000, N'The', N'Da thanh toan', NULL),
(11, 12, 11, '2024-02-10', 130000, 0, 130000, N'Tien mat', N'Da thanh toan', NULL),
(12, 13, 12, '2024-02-12', 225000, 0, 225000, N'Chuyen khoan', N'Da thanh toan', NULL),
(13, 14, 13, '2024-02-15', 150000, 0, 150000, N'Tien mat', N'Chua thanh toan', NULL),
(14, 15, 14, '2024-02-18', 195000, 0, 195000, N'Tien mat', N'Da thanh toan', NULL),
(15, 16, 15, '2024-02-20', 191000, 0, 191000, N'Chuyen khoan', N'Da thanh toan', NULL),
(16, 17, 16, '2024-02-22', 175000, 0, 175000, N'Tien mat', N'Chua thanh toan', NULL),
(17, 18, 17, '2024-02-25', 180000, 0, 180000, N'The', N'Da thanh toan', NULL),
(18, 19, 18, '2024-02-28', 125000, 0, 125000, N'Tien mat', N'Da thanh toan', NULL),
(19, 1, 19, '2024-03-01', 134000, 0, 134000, N'Chuyen khoan', N'Da thanh toan', NULL),
(20, 2, 20, '2024-03-05', 140000, 0, 140000, N'Tien mat', N'Chua thanh toan', NULL);
SET IDENTITY_INSERT HOADON OFF;
GO

PRINT 'Sample data inserted successfully!';
PRINT 'Default login: admin / 123456';
GO
