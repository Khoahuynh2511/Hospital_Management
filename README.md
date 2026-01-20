# PHẦN MỀM QUẢN LÝ BỆNH VIỆN
## Nhóm 20 UIT - ĐỒ ÁN MÔN LẬP TRÌNH TRỰC QUAN

---

## PHẦN 1: GIỚI THIỆU ĐỀ TÀI

### 1.1. Giới thiệu đề tài

Phần mềm Quản lý Bệnh viện là một ứng dụng desktop được phát triển trên nền tảng Windows, hỗ trợ quản lý toàn diện các hoạt động của một phòng khám tư nhân hoặc bệnh viện. Hệ thống được thiết kế với giao diện trực quan, dễ sử dụng, giúp nhân viên y tế quản lý thông tin bệnh nhân, lịch khám, đơn thuốc, hóa đơn và các dịch vụ khám chữa bệnh một cách hiệu quả.

### 1.2. Mô tả đề tài

Hệ thống quản lý bệnh viện được xây dựng nhằm số hóa và tự động hóa các quy trình quản lý trong môi trường y tế, bao gồm:

- **Quản lý thông tin bệnh nhân**: Lưu trữ và quản lý hồ sơ bệnh nhân, thông tin cá nhân, lịch sử khám chữa bệnh
- **Quản lý bệnh án và đơn thuốc**: Ghi nhận bệnh án, kê đơn thuốc, theo dõi lịch sử điều trị
- **Quản lý lịch khám**: Đặt lịch khám, quản lý hàng đợi, chọn dịch vụ và ca khám
- **Quản lý dịch vụ y tế**: Quản lý các dịch vụ khám chữa bệnh, giá cả, khoa phòng
- **Quản lý thuốc**: Quản lý kho thuốc, số lượng, giá cả, hạn sử dụng
- **Quản lý hóa đơn**: Tạo và quản lý hóa đơn thanh toán, theo dõi trạng thái thanh toán

### 1.3. Lý do chọn đề tài

Việc phát triển phần mềm quản lý bệnh viện được lựa chọn dựa trên các lý do sau:

1. **Nhu cầu thực tế**: Các cơ sở y tế hiện nay đang có nhu cầu cao về việc số hóa quy trình quản lý để nâng cao hiệu quả hoạt động và chất lượng phục vụ bệnh nhân

2. **Tính ứng dụng cao**: Đề tài có tính thực tiễn cao, có thể áp dụng trực tiếp vào các phòng khám tư nhân, bệnh viện nhỏ và vừa

3. **Kiến thức tổng hợp**: Đề tài yêu cầu vận dụng nhiều kiến thức về lập trình giao diện, cơ sở dữ liệu, kiến trúc phần mềm, giúp củng cố và mở rộng kỹ năng lập trình

4. **Thách thức kỹ thuật**: Hệ thống yêu cầu xử lý nhiều nghiệp vụ phức tạp, quản lý dữ liệu lớn, đảm bảo tính nhất quán và bảo mật thông tin

5. **Đóng góp xã hội**: Phần mềm có thể góp phần cải thiện chất lượng dịch vụ y tế, giảm thiểu sai sót trong quản lý, nâng cao trải nghiệm của bệnh nhân

### 1.4. Các chức năng chính của đề tài

#### 1.4.1. Quản lý bệnh nhân
- Thêm, sửa, xóa, tìm kiếm thông tin bệnh nhân
- Xem chi tiết hồ sơ bệnh nhân
- Quản lý lịch sử khám chữa bệnh của bệnh nhân
- Quản lý thông tin liên hệ (số điện thoại, email)

#### 1.4.2. Quản lý bệnh án và đơn thuốc
- Tạo và quản lý bệnh án cho bệnh nhân
- Kê đơn thuốc với chi tiết số lượng, liều lượng, cách dùng
- Xem lịch sử bệnh án và đơn thuốc
- Cập nhật và chỉnh sửa bệnh án

#### 1.4.3. Quản lý lịch khám
- Đặt lịch khám cho bệnh nhân
- Chọn dịch vụ khám
- Quản lý ca khám (12 ca từ 7:00 đến 18:00)
- Xem và chỉnh sửa lịch khám

#### 1.4.4. Quản lý hàng đợi
- Thêm bệnh nhân vào hàng đợi
- Quản lý thứ tự khám
- Cập nhật trạng thái khám (chờ khám, đang khám, đã khám)
- Ghi chú đặc biệt cho bệnh nhân ưu tiên

#### 1.4.5. Quản lý dịch vụ y tế
- Quản lý danh sách dịch vụ khám chữa bệnh
- Thiết lập giá cả cho từng dịch vụ

#### 1.4.6. Quản lý thuốc
- Quản lý danh mục thuốc
- Theo dõi số lượng tồn kho
- Quản lý giá cả và đơn vị tính
- Quản lý hạn sử dụng thuốc

#### 1.4.7. Quản lý hóa đơn
- Tạo hóa đơn thanh toán
- Tính toán tổng tiền, giảm giá, thành tiền
- Quản lý phương thức thanh toán (tiền mặt, chuyển khoản, thẻ)
- Theo dõi trạng thái thanh toán

#### 1.4.8. Dashboard và báo cáo
- Hiển thị thống kê tổng quan về hoạt động bệnh viện
- Biểu đồ thống kê số lượng bệnh nhân, doanh thu
- Thông tin nhanh về các hoạt động trong ngày

### 1.5. Công nghệ sử dụng

#### 1.5.1. Frontend
- **WPF (Windows Presentation Foundation)**: Framework chính để xây dựng giao diện người dùng desktop trên Windows
- **Material Design**: Thư viện MaterialDesignThemes và MaterialDesignColors để tạo giao diện hiện đại, đẹp mắt
- **FontAwesome.Sharp**: Thư viện icon để sử dụng các biểu tượng trong giao diện
- **LiveCharts**: Thư viện vẽ biểu đồ và đồ thị thống kê
- **Microsoft.Xaml.Behaviors.Wpf**: Hỗ trợ các hành vi tương tác trong XAML

#### 1.5.2. Backend và Database
- **Entity Framework 6.2.0**: ORM (Object-Relational Mapping) để làm việc với cơ sở dữ liệu
- **SQL Server**: Hệ quản trị cơ sở dữ liệu quan hệ để lưu trữ dữ liệu
- **System.Data.SqlClient**: Thư viện kết nối và thao tác với SQL Server

#### 1.5.3. API và Cloud Services
- **Node.js**: Xây dựng RESTful API để lưu trữ và quản lý media (hình ảnh, file)
- **AWS EC2**: Dịch vụ cloud để deploy Node.js server
- **AWS RDS**: Dịch vụ quản lý cơ sở dữ liệu SQL Server trên cloud

#### 1.5.4. Thư viện hỗ trợ
- **Newtonsoft.Json**: Xử lý dữ liệu JSON
- **RestSharp**: Thư viện gọi REST API
- **Json.Net**: Hỗ trợ xử lý JSON

### 1.6. Môi trường lập trình

#### 1.6.1. Hệ điều hành
- Windows 10/11 hoặc các phiên bản Windows hỗ trợ .NET Framework 4.7.2

#### 1.6.2. IDE và công cụ phát triển
- **Visual Studio 2019/2022**: Môi trường phát triển tích hợp (IDE) chính
- **SQL Server Management Studio (SSMS)**: Công cụ quản lý và phát triển cơ sở dữ liệu
- **Git**: Hệ thống quản lý phiên bản mã nguồn

#### 1.6.3. Framework và Runtime
- **.NET Framework 4.7.2**: Nền tảng phát triển ứng dụng
- **C# 8.0**: Ngôn ngữ lập trình chính
- **SQL Server 2008 trở lên**: Hệ quản trị cơ sở dữ liệu

#### 1.6.4. Công cụ hỗ trợ
- **Entity Framework Designer**: Thiết kế mô hình dữ liệu (EDMX)
- **NuGet Package Manager**: Quản lý các thư viện và package

---

## PHẦN 2: THIẾT KẾ HỆ THỐNG

### 2.1. Khảo sát hiện trạng hệ thống

#### 2.1.1. Hệ thống quản lý truyền thống
Trước khi phát triển phần mềm, các phòng khám và bệnh viện nhỏ thường sử dụng phương thức quản lý thủ công:

- **Quản lý hồ sơ giấy tờ**: Thông tin bệnh nhân, bệnh án được lưu trữ dưới dạng giấy tờ, dễ bị thất lạc, khó tìm kiếm
- **Ghi chép thủ công**: Nhân viên phải ghi chép thông tin bằng tay, dễ xảy ra sai sót
- **Khó khăn trong tra cứu**: Việc tìm kiếm thông tin bệnh nhân, lịch sử khám chữa bệnh mất nhiều thời gian
- **Thiếu đồng bộ**: Thông tin không được đồng bộ giữa các bộ phận, dễ dẫn đến nhầm lẫn
- **Khó thống kê**: Việc thống kê, báo cáo phải làm thủ công, tốn nhiều thời gian và dễ sai sót

#### 2.1.2. Nhu cầu cải thiện
- Số hóa toàn bộ quy trình quản lý
- Tự động hóa các thao tác lặp lại
- Tăng tốc độ xử lý và tra cứu thông tin
- Đảm bảo tính chính xác và nhất quán của dữ liệu
- Hỗ trợ thống kê và báo cáo nhanh chóng
- Cải thiện trải nghiệm người dùng

### 2.2. Lưu đồ thuật toán

#### 2.2.1. Lưu đồ đăng nhập hệ thống
```
Bắt đầu
  ↓
Hiển thị màn hình đăng nhập
  ↓
Người dùng nhập tên đăng nhập và mật khẩu
  ↓
Kiểm tra thông tin đăng nhập
  ↓
┌─────────────────┐
│ Thông tin hợp lệ?│
└────────┬────────┘
         │
    ┌────┴────┐
    │         │
   Có        Không
    │         │
    ↓         ↓
Kiểm tra quyền  Hiển thị thông báo lỗi
    │
    ↓
Hiển thị màn hình chính
    │
    ↓
Kết thúc
```

#### 2.2.2. Lưu đồ quản lý bệnh nhân
```
Bắt đầu
  ↓
Hiển thị danh sách bệnh nhân
  ↓
┌──────────────────────┐
│ Chọn thao tác        │
└──────────┬───────────┘
           │
    ┌──────┼──────┬──────┐
    │      │      │      │
   Thêm   Sửa   Xóa   Xem
    │      │      │      │
    ↓      ↓      ↓      ↓
Nhập thông tin  Chọn bệnh nhân  Xác nhận  Hiển thị
    │      │      │      │
    ↓      ↓      ↓      │
Kiểm tra  Cập nhật  Xóa  │
    │      │      │      │
    ↓      ↓      ↓      │
Lưu vào DB  Lưu vào DB  Lưu vào DB  │
    │      │      │      │
    └──────┴──────┴──────┘
           │
           ↓
    Cập nhật danh sách
           │
           ↓
    Kết thúc
```

#### 2.2.3. Lưu đồ tạo bệnh án và đơn thuốc
```
Bắt đầu
  ↓
Chọn bệnh nhân
  ↓
Nhập thông tin bệnh án
  - Triệu chứng
  - Kết luận
  - Dịch vụ khám
  ↓
Tính toán thành tiền
  ↓
Lưu bệnh án vào database
  ↓
┌──────────────────────┐
│ Có kê đơn thuốc?     │
└──────────┬───────────┘
           │
    ┌──────┴──────┐
    │             │
   Có            Không
    │             │
    ↓             │
Chọn thuốc       │
    │             │
    ↓             │
Nhập số lượng,   │
liều lượng       │
    │             │
    ↓             │
Lưu đơn thuốc    │
    │             │
    └──────┬──────┘
           │
           ↓
    Hoàn tất
    ↓
Kết thúc
```

#### 2.2.4. Lưu đồ quản lý hàng đợi
```
Bắt đầu
  ↓
Hiển thị danh sách hàng đợi
  ↓
┌──────────────────────┐
│ Chọn thao tác        │
└──────────┬───────────┘
           │
    ┌──────┼──────┐
    │      │      │
   Thêm   Cập nhật  Xóa
    │      │      │
    ↓      ↓      ↓
Chọn bệnh  Chọn  Xác nhận
nhân      bệnh nhân
    │      │      │
    ↓      ↓      ↓
Tự động  Cập nhật  Xóa
tăng số  trạng thái
thứ tự
    │      │      │
    └──────┴──────┘
           │
           ↓
    Lưu vào database
           │
           ↓
    Cập nhật giao diện
           │
           ↓
    Kết thúc
```

### 2.3. Cấu trúc tổng quan

#### 2.3.1. Kiến trúc hệ thống
Hệ thống được xây dựng theo mô hình **MVVM (Model-View-ViewModel)**:

```
┌─────────────────────────────────────────┐
│              VIEW (XAML)                │
│  - LoginWindow.xaml                     │
│  - MainWindow.xaml                      │
│  - Victim.xaml, Appointment.xaml, ...   │
└──────────────┬──────────────────────────┘
               │ Data Binding
┌──────────────▼──────────────────────────┐
│         VIEWMODEL (C#)                  │
│  - LoginViewModel                       │
│  - MainViewModel                        │
│  - VictimViewModel, ...                 │
└──────────────┬──────────────────────────┘
               │
┌──────────────▼──────────────────────────┐
│         MODEL (C#)                      │
│  - Entity Framework Entities            │
│  - UserModel, VictimModel, ...          │
└──────────────┬──────────────────────────┘
               │
┌──────────────▼──────────────────────────┐
│      REPOSITORY (C#)                │
│  - UserRepository                      │
│  - VictimRepository                    │
└──────────────┬──────────────────────────┘
               │
┌──────────────▼──────────────────────────┐
│         DATABASE (SQL Server)           │
│  - QUANLYBENHVIEN Database              │
└─────────────────────────────────────────┘
```

#### 2.3.2. Cấu trúc thư mục dự án
```
Hospital-Management-dev/
├── View/                    # Giao diện người dùng (XAML)
│   ├── LoginWindow.xaml
│   ├── MainWindow.xaml
│   ├── HomeView.xaml
│   ├── Victim.xaml
│   ├── Appointment.xaml
│   └── ...
├── ViewModel/               # Logic xử lý (MVVM)
│   ├── BaseViewModel.cs
│   ├── LoginViewModel/
│   ├── MainViewModel.cs
│   ├── VictimViewModel/
│   ├── AppointmentViewModel/
│   └── ...
├── Model/                   # Mô hình dữ liệu
│   ├── UserModel.cs
│   ├── VictimModel.cs
│   └── ...
├── Repositories/            # Tầng truy cập dữ liệu
│   ├── UserRepository.cs
│   ├── VictimRepository.cs
│   └── ...
├── Database/                # Scripts cơ sở dữ liệu
│   ├── UpdateDatabase.sql
│   ├── SampleData.sql
│   └── ExpandFieldLengths.sql
├── Resource/                # Tài nguyên
├── Photo/                   # Hình ảnh
├── style/                   # Style XAML
└── QLBVModel.edmx          # Entity Framework Model
```

### 2.4. Mô tả các thực thể của Database

#### 2.4.1. BENHNHAN (Bệnh nhân)
Thực thể trung tâm của hệ thống, lưu trữ thông tin cá nhân của bệnh nhân.

**Các thuộc tính:**
- MABENHNHAN: Mã bệnh nhân (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed: "BN" + MABENHNHAN)
- MAPHONG: Mã phòng (Foreign Key → PHONG)
- HOTEN: Họ tên bệnh nhân
- GIOITINH: Giới tính
- NGAYSINH: Ngày sinh
- DIACHI: Địa chỉ
- MABHYT: Mã bảo hiểm y tế
- NGAYNHAPVIEN: Ngày nhập viện
- SODIENTHOAI: Số điện thoại
- EMAIL: Email

**Mối quan hệ:**
- Một bệnh nhân có nhiều bệnh án (1-N với BENHAN)
- Một bệnh nhân có nhiều lịch khám (1-N với LICHKHAM)
- Một bệnh nhân thuộc một phòng (N-1 với PHONG)

#### 2.4.2. YSI (Y bác sĩ)
Bảng lưu trữ thông tin nhân viên y tế bao gồm bác sĩ, y tá, kỹ thuật viên. Bảng này được sử dụng để tham chiếu trong các bảng khác (bệnh án, lịch khám) nhưng không có giao diện quản lý riêng trong hệ thống.

**Các thuộc tính:**
- MAYSI: Mã y sĩ (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed)
- MAKHOA: Mã khoa (Foreign Key → KHOA)
- MAPHONG: Mã phòng (Foreign Key → PHONG)
- HOTEN: Họ tên
- GIOITINH: Giới tính
- NGAYSINH: Ngày sinh
- NGAYVAOLAM: Ngày vào làm
- LOAIYSI: Loại y sĩ (Bác sĩ, Y tá, Kỹ thuật viên, Lễ tân)
- MACHIHUY: Mã chỉ huy (Foreign Key → YSI, tự tham chiếu)

**Mối quan hệ:**
- Một y sĩ thuộc một khoa (N-1 với KHOA)
- Một y sĩ làm việc tại một phòng (N-1 với PHONG)
- Một y sĩ có thể có nhiều bệnh án (1-N với BENHAN)
- Một y sĩ có thể có nhiều lịch khám (1-N với LICHKHAM)
- Một y sĩ có thể là trưởng khoa (1-1 với KHOA)
- Một y sĩ có thể có cấp dưới (tự tham chiếu)

#### 2.4.3. BENHAN (Bệnh án)
Lưu trữ thông tin về các lần khám chữa bệnh của bệnh nhân.

**Các thuộc tính:**
- MABENHAN: Mã bệnh án (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed)
- MAYSI: Mã y sĩ khám (Foreign Key → YSI)
- MABENHNHAN: Mã bệnh nhân (Foreign Key → BENHNHAN)
- MADICHVU: Mã dịch vụ (Foreign Key → DICHVU)
- THANHTIEN: Thành tiền
- TRIEUCHUNG: Triệu chứng
- NGAYKHAM: Ngày khám
- KETLUAN: Kết luận

**Mối quan hệ:**
- Một bệnh án thuộc một bệnh nhân (N-1 với BENHNHAN)
- Một bệnh án do một y sĩ khám (N-1 với YSI)
- Một bệnh án sử dụng một dịch vụ (N-1 với DICHVU)
- Một bệnh án có thể có nhiều đơn thuốc (1-N với DONTHUOC)
- Một bệnh án có nhiều lịch sử thay đổi (1-N với BENHAN_HISTORY)

#### 2.4.4. DONTHUOC (Đơn thuốc)
Lưu trữ thông tin đơn thuốc được kê cho bệnh nhân.

**Các thuộc tính:**
- MADONTHUOC: Mã đơn thuốc (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed)
- MABENHAN: Mã bệnh án (Foreign Key → BENHAN)
- GHICHU: Ghi chú

**Mối quan hệ:**
- Một đơn thuốc thuộc một bệnh án (N-1 với BENHAN, một bệnh án có thể có nhiều đơn thuốc)
- Một đơn thuốc có nhiều chi tiết thuốc (1-N với CHITIETDONTHUOC)

#### 2.4.5. CHITIETDONTHUOC (Chi tiết đơn thuốc)
Lưu trữ chi tiết các loại thuốc trong đơn thuốc.

**Các thuộc tính:**
- MADONTHUOC: Mã đơn thuốc (Primary Key, Foreign Key → DONTHUOC)
- MATHUOC: Mã thuốc (Primary Key, Foreign Key → THUOC)
- SOLUONG: Số lượng
- SOLAN: Số lần uống trong ngày
- GHICHU: Ghi chú cách dùng

**Mối quan hệ:**
- Một chi tiết thuộc một đơn thuốc (N-1 với DONTHUOC)
- Một chi tiết về một loại thuốc (N-1 với THUOC)

#### 2.4.6. THUOC (Thuốc)
Lưu trữ thông tin về các loại thuốc trong kho.

**Các thuộc tính:**
- MATHUOC: Mã thuốc (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed)
- TENTHUOC: Tên thuốc
- DONVITINH: Đơn vị tính (Viên, Chai, Lọ, ...)
- GIATIEN: Giá tiền
- SOLUONG: Số lượng tồn kho
- GHICHU: Ghi chú
- NGAYHETHAN: Ngày hết hạn

**Mối quan hệ:**
- Một thuốc có trong nhiều chi tiết đơn thuốc (1-N với CHITIETDONTHUOC)

#### 2.4.7. DICHVU (Dịch vụ)
Lưu trữ thông tin các dịch vụ khám chữa bệnh.

**Các thuộc tính:**
- MADICHVU: Mã dịch vụ (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed)
- TENDICHVU: Tên dịch vụ
- GIATIEN: Giá tiền
- PICTURE: Hình ảnh (URL)

**Mối quan hệ:**
- Một dịch vụ được sử dụng trong nhiều bệnh án (1-N với BENHAN)
- Một dịch vụ có trong nhiều lịch khám (1-N với LICHKHAM)

#### 2.4.8. KHOA (Khoa)
Bảng lưu trữ thông tin các khoa trong bệnh viện. Bảng này được sử dụng để tham chiếu trong các bảng khác nhưng không có giao diện quản lý riêng trong hệ thống.

**Các thuộc tính:**
- MAKHOA: Mã khoa (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed)
- TENKHOA: Tên khoa
- NGAYTHANHLAP: Ngày thành lập
- TRUONGKHOA: Mã trưởng khoa (Foreign Key → YSI)
- PICTURE: Hình ảnh (URL)

**Mối quan hệ:**
- Một khoa có nhiều y sĩ (1-N với YSI)
- Một khoa có một trưởng khoa (1-1 với YSI)

#### 2.4.9. PHONG (Phòng)
Bảng lưu trữ thông tin các phòng trong bệnh viện. Bảng này được sử dụng để tham chiếu trong các bảng khác (bệnh nhân, y sĩ, lịch khám) nhưng không có giao diện quản lý riêng trong hệ thống.

**Các thuộc tính:**
- MAPHONG: Mã phòng (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed)
- TANG: Tầng
- TENPHONG: Tên phòng
- SUCCHUA: Sức chứa

**Mối quan hệ:**
- Một phòng có nhiều bệnh nhân (1-N với BENHNHAN)
- Một phòng có nhiều y sĩ (1-N với YSI)
- Một phòng có nhiều lịch khám (1-N với LICHKHAM)

#### 2.4.10. LICHKHAM (Lịch khám)
Lưu trữ thông tin lịch hẹn khám của bệnh nhân.

**Các thuộc tính:**
- MALICHKHAM: Mã lịch khám (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed)
- MABACSI: Mã bác sĩ (Foreign Key → YSI)
- MABENHNHAN: Mã bệnh nhân (Foreign Key → BENHNHAN)
- MAPHONG: Mã phòng (Foreign Key → PHONG)
- MADICHVU: Mã dịch vụ (Foreign Key → DICHVU)
- NGAYKHAM: Ngày khám
- NGAYLENLICH: Ngày lên lịch
- CAKHAM: Ca khám (1-12: từ 7:00 đến 18:00, mỗi ca cách nhau 1 giờ)

**Mối quan hệ:**
- Một lịch khám thuộc một bệnh nhân (N-1 với BENHNHAN)
- Một lịch khám với một bác sĩ (N-1 với YSI)
- Một lịch khám tại một phòng (N-1 với PHONG)
- Một lịch khám cho một dịch vụ (N-1 với DICHVU)

#### 2.4.11. HANGDOI (Hàng đợi)
Lưu trữ thông tin hàng đợi khám của bệnh nhân.

**Các thuộc tính:**
- MAHANGDOI: Mã hàng đợi (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed: "HD" + MAHANGDOI)
- MABENHNHAN: Mã bệnh nhân (Foreign Key → BENHNHAN)
- SOTHUTU: Số thứ tự
- THOIGIANDANGKY: Thời gian đăng ký
- TRANGTHAI: Trạng thái (Chờ khám, Đang khám, Đã khám)
- GHICHU: Ghi chú

**Mối quan hệ:**
- Một hàng đợi thuộc một bệnh nhân (N-1 với BENHNHAN)

#### 2.4.12. HOADON (Hóa đơn)
Lưu trữ thông tin hóa đơn thanh toán.

**Các thuộc tính:**
- MAHOADON: Mã hóa đơn (Primary Key, Identity)
- SUB_ID: Mã hiển thị (Computed: "INV" + MAHOADON)
- MABENHNHAN: Mã bệnh nhân (Foreign Key → BENHNHAN)
- MABENHAN: Mã bệnh án (Foreign Key → BENHAN)
- NGAYLAP: Ngày lập
- TONGTIEN: Tổng tiền
- GIAMGIA: Giảm giá
- THANHTIEN: Thành tiền
- PHUONGTHUCTHANHTOAN: Phương thức thanh toán
- TRANGTHAI: Trạng thái (Chưa thanh toán, Đã thanh toán)
- GHICHU: Ghi chú

**Mối quan hệ:**
- Một hóa đơn thuộc một bệnh nhân (N-1 với BENHNHAN)
- Một hóa đơn cho một bệnh án (N-1 với BENHAN)

#### 2.4.13. TAIKHOAN (Tài khoản)
Lưu trữ thông tin tài khoản đăng nhập hệ thống.

**Các thuộc tính:**
- TENDANGNHAP: Tên đăng nhập (Primary Key)
- MATKHAU: Mật khẩu (đã mã hóa)
- MASO: Mã số nhân viên
- LOAITAIKHOAN: Loại tài khoản (Admin, Bác sĩ, Y tá, Lễ tân)
- AVATAR: Ảnh đại diện (URL)

#### 2.4.14. BENHAN_HISTORY (Lịch sử bệnh án)
Lưu trữ lịch sử thay đổi của bệnh án.

**Các thuộc tính:**
- MALICHSU: Mã lịch sử (Primary Key, Identity)
- MABENHAN: Mã bệnh án (Foreign Key → BENHAN)
- MAYSI: Mã y sĩ
- MABENHNHAN: Mã bệnh nhân
- MADICHVU: Mã dịch vụ
- TRIEUCHUNG: Triệu chứng
- NGAYKHAM: Ngày khám
- THANHTIEN: Thành tiền
- KETLUAN: Kết luận
- CHANGED_DATE: Ngày thay đổi

**Mối quan hệ:**
- Một lịch sử thuộc một bệnh án (N-1 với BENHAN)

### 2.5. Cấu trúc các bảng dữ liệu

#### 2.5.1. Bảng BENHNHAN
```sql
CREATE TABLE BENHNHAN (
    MABENHNHAN INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('BN' + RIGHT('000000' + CAST(MABENHNHAN AS VARCHAR(6)), 6)),
    MAPHONG INT,
    HOTEN NVARCHAR(100),
    GIOITINH NVARCHAR(5),
    NGAYSINH DATETIME,
    DIACHI NVARCHAR(200),
    MABHYT VARCHAR(20),
    NGAYNHAPVIEN DATETIME,
    SODIENTHOAI NVARCHAR(15),
    EMAIL NVARCHAR(100),
    FOREIGN KEY (MAPHONG) REFERENCES PHONG(MAPHONG)
);
```

#### 2.5.2. Bảng YSI
```sql
CREATE TABLE YSI (
    MAYSI INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('YS' + RIGHT('000000' + CAST(MAYSI AS VARCHAR(6)), 6)),
    MAKHOA INT,
    MAPHONG INT,
    HOTEN NVARCHAR(100),
    GIOITINH NVARCHAR(5),
    NGAYSINH DATETIME,
    NGAYVAOLAM DATETIME,
    LOAIYSI NVARCHAR(50),
    MACHIHUY INT,
    FOREIGN KEY (MAKHOA) REFERENCES KHOA(MAKHOA),
    FOREIGN KEY (MAPHONG) REFERENCES PHONG(MAPHONG),
    FOREIGN KEY (MACHIHUY) REFERENCES YSI(MAYSI)
);
```

#### 2.5.3. Bảng BENHAN
```sql
CREATE TABLE BENHAN (
    MABENHAN INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('BA' + RIGHT('000000' + CAST(MABENHAN AS VARCHAR(6)), 6)),
    MAYSI INT,
    MABENHNHAN INT,
    MADICHVU INT,
    THANHTIEN MONEY,
    TRIEUCHUNG NVARCHAR(MAX),
    NGAYKHAM SMALLDATETIME,
    KETLUAN NVARCHAR(MAX),
    FOREIGN KEY (MAYSI) REFERENCES YSI(MAYSI),
    FOREIGN KEY (MABENHNHAN) REFERENCES BENHNHAN(MABENHNHAN),
    FOREIGN KEY (MADICHVU) REFERENCES DICHVU(MADICHVU)
);
```

#### 2.5.4. Bảng DONTHUOC
```sql
CREATE TABLE DONTHUOC (
    MADONTHUOC INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('DT' + RIGHT('000000' + CAST(MADONTHUOC AS VARCHAR(6)), 6)),
    MABENHAN INT,
    GHICHU NVARCHAR(MAX),
    FOREIGN KEY (MABENHAN) REFERENCES BENHAN(MABENHAN)
);
```

#### 2.5.5. Bảng CHITIETDONTHUOC
```sql
CREATE TABLE CHITIETDONTHUOC (
    MADONTHUOC INT,
    MATHUOC INT,
    SOLUONG FLOAT,
    SOLAN INT,
    GHICHU NVARCHAR(MAX),
    PRIMARY KEY (MADONTHUOC, MATHUOC),
    FOREIGN KEY (MADONTHUOC) REFERENCES DONTHUOC(MADONTHUOC),
    FOREIGN KEY (MATHUOC) REFERENCES THUOC(MATHUOC)
);
```

#### 2.5.6. Bảng THUOC
```sql
CREATE TABLE THUOC (
    MATHUOC INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('TH' + RIGHT('000000' + CAST(MATHUOC AS VARCHAR(6)), 6)),
    TENTHUOC NVARCHAR(200),
    DONVITINH NVARCHAR(50),
    GIATIEN MONEY,
    SOLUONG FLOAT,
    GHICHU NVARCHAR(MAX),
    NGAYHETHAN DATETIME
);
```

#### 2.5.7. Bảng DICHVU
```sql
CREATE TABLE DICHVU (
    MADICHVU INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('DV' + RIGHT('000000' + CAST(MADICHVU AS VARCHAR(6)), 6)),
    TENDICHVU NVARCHAR(100),
    GIATIEN MONEY,
    PICTURE NVARCHAR(MAX)
);
```

#### 2.5.8. Bảng KHOA
```sql
CREATE TABLE KHOA (
    MAKHOA INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('KH' + RIGHT('000000' + CAST(MAKHOA AS VARCHAR(6)), 6)),
    TENKHOA NVARCHAR(100),
    NGAYTHANHLAP DATETIME,
    TRUONGKHOA INT,
    PICTURE NVARCHAR(MAX),
    FOREIGN KEY (TRUONGKHOA) REFERENCES YSI(MAYSI)
);
```

#### 2.5.9. Bảng PHONG
```sql
CREATE TABLE PHONG (
    MAPHONG INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('PHG' + RIGHT('000000' + CAST(MAPHONG AS VARCHAR(6)), 6)),
    TANG TINYINT,
    TENPHONG NVARCHAR(100),
    SUCCHUA TINYINT
);
```

#### 2.5.10. Bảng LICHKHAM
```sql
CREATE TABLE LICHKHAM (
    MALICHKHAM INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('LK' + RIGHT('000000' + CAST(MALICHKHAM AS VARCHAR(6)), 6)),
    MABACSI INT,
    MABENHNHAN INT,
    MAPHONG INT,
    MADICHVU INT,
    NGAYKHAM DATETIME,
    NGAYLENLICH DATETIME,
    CAKHAM INT,
    FOREIGN KEY (MABACSI) REFERENCES YSI(MAYSI),
    FOREIGN KEY (MABENHNHAN) REFERENCES BENHNHAN(MABENHNHAN),
    FOREIGN KEY (MAPHONG) REFERENCES PHONG(MAPHONG),
    FOREIGN KEY (MADICHVU) REFERENCES DICHVU(MADICHVU)
);
```

#### 2.5.11. Bảng HANGDOI
```sql
CREATE TABLE HANGDOI (
    MAHANGDOI INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('HD' + RIGHT('000000' + CAST(MAHANGDOI AS VARCHAR(6)), 6)),
    MABENHNHAN INT,
    SOTHUTU INT NOT NULL,
    THOIGIANDANGKY DATETIME DEFAULT GETDATE(),
    TRANGTHAI NVARCHAR(20) DEFAULT N'Cho kham',
    GHICHU NVARCHAR(200),
    FOREIGN KEY (MABENHNHAN) REFERENCES BENHNHAN(MABENHNHAN)
);
```

#### 2.5.12. Bảng HOADON
```sql
CREATE TABLE HOADON (
    MAHOADON INT IDENTITY(1,1) PRIMARY KEY,
    SUB_ID AS ('INV' + RIGHT('000000' + CAST(MAHOADON AS VARCHAR(6)), 6)),
    MABENHNHAN INT,
    MABENHAN INT,
    NGAYLAP DATETIME DEFAULT GETDATE(),
    TONGTIEN MONEY NOT NULL DEFAULT 0,
    GIAMGIA MONEY DEFAULT 0,
    THANHTIEN MONEY NOT NULL DEFAULT 0,
    PHUONGTHUCTHANHTOAN NVARCHAR(50) DEFAULT N'Tien mat',
    TRANGTHAI NVARCHAR(20) DEFAULT N'Chua thanh toan',
    GHICHU NVARCHAR(500),
    FOREIGN KEY (MABENHNHAN) REFERENCES BENHNHAN(MABENHNHAN),
    FOREIGN KEY (MABENHAN) REFERENCES BENHAN(MABENHAN)
);
```

#### 2.5.13. Bảng TAIKHOAN
```sql
CREATE TABLE TAIKHOAN (
    TENDANGNHAP VARCHAR(30) PRIMARY KEY,
    MATKHAU VARCHAR(100),
    MASO VARCHAR(20),
    LOAITAIKHOAN NVARCHAR(10),
    AVATAR VARCHAR(100)
);
```

#### 2.5.14. Bảng BENHAN_HISTORY
```sql
CREATE TABLE BENHAN_HISTORY (
    MALICHSU INT IDENTITY(1,1) PRIMARY KEY,
    MABENHAN INT,
    MAYSI INT,
    MABENHNHAN INT,
    MADICHVU INT,
    TRIEUCHUNG NVARCHAR(MAX),
    NGAYKHAM SMALLDATETIME,
    THANHTIEN MONEY,
    KETLUAN NVARCHAR(MAX),
    CHANGED_DATE DATETIME,
    FOREIGN KEY (MABENHAN) REFERENCES BENHAN(MABENHAN)
);
```

---

## PHẦN 3: XÂY DỰNG ỨNG DỤNG

### 3.1. Luồng hoạt động của các giao diện

#### 3.1.1. Giao diện đăng nhập (LoginWindow)

**Mục đích**: Xác thực người dùng trước khi truy cập hệ thống

**Luồng hoạt động**:
1. Người dùng khởi động ứng dụng, màn hình đăng nhập hiển thị
2. Người dùng nhập tên đăng nhập và mật khẩu
3. Hệ thống kiểm tra thông tin đăng nhập trong bảng TAIKHOAN
4. Nếu thông tin hợp lệ:
   - Hệ thống lấy thông tin quyền của người dùng
   - Mở màn hình chính (MainWindow) với các chức năng tương ứng với quyền
   - Đóng màn hình đăng nhập
5. Nếu thông tin không hợp lệ:
   - Hiển thị thông báo lỗi
   - Yêu cầu người dùng nhập lại

**Các thành phần**:
- TextBox tên đăng nhập
- PasswordBox mật khẩu
- Button đăng nhập
- Button hủy

#### 3.1.2. Giao diện chính (MainWindow)

**Mục đích**: Giao diện chính của ứng dụng, chứa menu điều hướng và vùng hiển thị nội dung

**Luồng hoạt động**:
1. Sau khi đăng nhập thành công, MainWindow được mở
2. Giao diện được chia thành 2 phần:
   - **Menu bên trái**: Chứa các nút điều hướng đến các chức năng
   - **Vùng nội dung bên phải**: Hiển thị giao diện tương ứng với chức năng được chọn
3. Người dùng click vào menu item để chuyển đổi giữa các chức năng
4. Mỗi menu item sẽ load ViewModel và View tương ứng vào vùng nội dung
5. Header hiển thị icon và tên chức năng hiện tại

**Các menu chính**:
- Dashboard (Trang chủ)
- Bệnh nhân
- Hàng đợi
- Lịch khám
- Dịch vụ
- Thuốc
- Hóa đơn
- Đăng xuất

#### 3.1.3. Giao diện Dashboard (HomeView)

**Mục đích**: Hiển thị tổng quan về hoạt động của bệnh viện

**Luồng hoạt động**:
1. Khi người dùng chọn menu Dashboard, HomeView được hiển thị
2. Hệ thống truy vấn database để lấy các thống kê:
   - Số bệnh nhân hôm nay
   - Số lịch hẹn hôm nay
   - Doanh thu hôm nay
   - Số thuốc sắp hết (số lượng < 10)
3. Dữ liệu được hiển thị dưới dạng:
   - Các card thống kê với số liệu và icon
   - Biểu đồ cột/đường thể hiện xu hướng
   - Danh sách các hoạt động gần đây
4. Dữ liệu được cập nhật tự động khi có thay đổi

**Các thành phần**:
- Card thống kê số bệnh nhân hôm nay
- Card thống kê số lịch hẹn hôm nay
- Card thống kê doanh thu hôm nay
- Card thống kê số thuốc sắp hết
- Biểu đồ thống kê theo thời gian (bệnh nhân, bệnh án, đơn thuốc, thuốc bán ra, doanh thu)
- Danh sách thuốc bán chạy
- Danh sách doanh thu theo dịch vụ

#### 3.1.4. Giao diện quản lý bệnh nhân (Victim)

**Mục đích**: Quản lý thông tin bệnh nhân

**Luồng hoạt động**:

**a) Xem danh sách bệnh nhân**:
1. Hiển thị danh sách tất cả bệnh nhân trong DataGrid
2. Hỗ trợ tìm kiếm theo tên, mã bệnh nhân, số điện thoại
3. Hỗ trợ lọc theo phòng, giới tính
4. Hiển thị thông tin: Mã, Họ tên, Giới tính, Ngày sinh, Địa chỉ, Phòng

**b) Thêm bệnh nhân mới**:
1. Click nút "Thêm mới", mở cửa sổ AddVictim
2. Người dùng nhập thông tin:
   - Họ tên (bắt buộc)
   - Giới tính
   - Ngày sinh
   - Địa chỉ
   - Số điện thoại
   - Email
   - Mã BHYT (nếu có)
   - Chọn phòng
3. Hệ thống kiểm tra tính hợp lệ của dữ liệu
4. Click "Lưu":
   - Tạo mã bệnh nhân mới (tự động)
   - Lưu vào database
   - Cập nhật danh sách
   - Đóng cửa sổ

**c) Sửa thông tin bệnh nhân**:
1. Chọn bệnh nhân trong danh sách
2. Click nút "Sửa", mở cửa sổ ChangeVictim với dữ liệu đã điền sẵn
3. Người dùng chỉnh sửa thông tin
4. Click "Lưu":
   - Cập nhật vào database
   - Cập nhật danh sách
   - Đóng cửa sổ

**d) Xem chi tiết bệnh nhân**:
1. Chọn bệnh nhân trong danh sách
2. Click nút "Xem", mở cửa sổ ViewVictim
3. Hiển thị đầy đủ thông tin bệnh nhân
4. Hiển thị lịch sử khám chữa bệnh (nếu có)
5. Có thể xem bệnh án và đơn thuốc từ đây

**e) Xóa bệnh nhân**:
1. Chọn bệnh nhân trong danh sách
2. Click nút "Xóa"
3. Hiển thị hộp thoại xác nhận
4. Nếu xác nhận:
   - Kiểm tra ràng buộc (có bệnh án, lịch khám không)
   - Nếu không có ràng buộc: Xóa khỏi database
   - Nếu có ràng buộc: Hiển thị cảnh báo, không cho xóa
   - Cập nhật danh sách

**Các thành phần**:
- DataGrid hiển thị danh sách bệnh nhân
- TextBox tìm kiếm
- ComboBox lọc theo phòng
- Các nút: Thêm, Sửa, Xóa, Xem
- Cửa sổ con: AddVictim, ChangeVictim, ViewVictim

#### 3.1.5. Giao diện quản lý bệnh án và đơn thuốc (HealthRecordAndPrescription)

**Mục đích**: Quản lý bệnh án và kê đơn thuốc cho bệnh nhân

**Luồng hoạt động**:

**a) Tạo bệnh án mới**:
1. Từ giao diện bệnh nhân, chọn bệnh nhân và click "Bệnh án"
2. Mở cửa sổ AddHealthRecord
3. Người dùng nhập thông tin:
   - Chọn bác sĩ khám
   - Chọn dịch vụ khám
   - Nhập triệu chứng
   - Nhập kết luận
   - Ngày khám (mặc định là ngày hiện tại)
4. Hệ thống tự động tính thành tiền dựa trên giá dịch vụ
5. Click "Lưu":
   - Lưu bệnh án vào database
   - Hiển thị thông báo thành công
   - Có thể tiếp tục kê đơn thuốc

**b) Kê đơn thuốc**:
1. Sau khi tạo bệnh án, click "Kê đơn thuốc" hoặc từ danh sách bệnh án
2. Mở cửa sổ AddPrescription
3. Chọn thuốc từ danh sách
4. Nhập thông tin:
   - Số lượng
   - Số lần uống trong ngày
   - Ghi chú cách dùng
5. Click "Thêm vào đơn" để thêm thuốc vào danh sách
6. Có thể thêm nhiều loại thuốc
7. Click "Lưu đơn thuốc":
   - Lưu đơn thuốc và chi tiết vào database
   - Cập nhật số lượng thuốc trong kho
   - Hiển thị thông báo thành công

**c) Xem lịch sử bệnh án**:
1. Từ giao diện bệnh nhân, click "Lịch sử bệnh án"
2. Hiển thị danh sách tất cả bệnh án của bệnh nhân
3. Có thể xem chi tiết từng bệnh án
4. Có thể xem đơn thuốc tương ứng

**d) Sửa bệnh án**:
1. Chọn bệnh án trong danh sách
2. Click "Sửa", mở cửa sổ ChangeHealthRecord
3. Chỉnh sửa thông tin (lưu lịch sử vào BENHAN_HISTORY)
4. Lưu thay đổi

**Các thành phần**:
- DataGrid danh sách bệnh án
- Cửa sổ AddHealthRecord, ChangeHealthRecord
- Cửa sổ AddPrescription, ChangePrescription
- Cửa sổ HealthRecordHistory

#### 3.1.6. Giao diện quản lý lịch khám (Appointment)

**Mục đích**: Quản lý lịch hẹn khám của bệnh nhân

**Luồng hoạt động**:

**a) Xem danh sách lịch khám**:
1. Hiển thị danh sách tất cả lịch khám
2. Có thể lọc theo ngày, dịch vụ
3. Hiển thị thông tin: Mã lịch, Bệnh nhân, Dịch vụ, Ngày khám, Ca khám, Ngày lên lịch
4. Tự động xóa các lịch khám đã quá hạn (ngày khám < ngày hiện tại)

**b) Đặt lịch khám mới**:
1. Click "Thêm mới", mở cửa sổ AddAppointment
2. Chọn bệnh nhân (có thể tìm kiếm trong ComboBox)
3. Chọn dịch vụ khám
4. Chọn ngày lên lịch (DatePicker)
5. Chọn ngày khám (DatePicker)
6. Chọn ca khám (12 ca từ 7:00 đến 18:00, mỗi ca cách nhau 1 giờ)
7. Hệ thống kiểm tra:
   - Ngày khám không được là ngày trong quá khứ
   - Ngày lên lịch phải hợp lệ
8. Click "Xác nhận":
   - Lưu lịch khám vào database
   - Cập nhật danh sách
   - Hiển thị thông báo thành công
   - Đóng cửa sổ

**c) Sửa lịch khám**:
1. Chọn lịch khám trong danh sách
2. Click "Sửa", mở cửa sổ ChangeAppointment
3. Chỉnh sửa thông tin
4. Lưu thay đổi

**d) Xóa lịch khám**:
1. Chọn lịch khám
2. Click "Xóa"
3. Xác nhận và xóa

**Các thành phần**:
- DataGrid danh sách lịch khám
- DatePicker chọn ngày lên lịch và ngày khám
- ComboBox chọn bệnh nhân (có thể tìm kiếm), dịch vụ, ca khám
- Cửa sổ AddAppointment, ChangeAppointment, ViewAppointment

#### 3.1.7. Giao diện quản lý hàng đợi (Queue)

**Mục đích**: Quản lý hàng đợi khám của bệnh nhân

**Luồng hoạt động**:

**a) Xem hàng đợi hiện tại**:
1. Hiển thị danh sách bệnh nhân trong hàng đợi hôm nay (chỉ hiển thị bệnh nhân chưa khám xong)
2. Sắp xếp theo số thứ tự
3. Hiển thị: Số thứ tự, Mã bệnh nhân, Tên bệnh nhân, Thời gian đăng ký, Trạng thái
4. Hỗ trợ tìm kiếm theo tên, mã bệnh nhân, số thứ tự
5. Tự động cập nhật số thứ tự hiện tại đang khám

**b) Thêm bệnh nhân vào hàng đợi**:
1. Click "Thêm vào hàng đợi", mở cửa sổ AddToQueue
2. Chọn bệnh nhân (có thể tìm kiếm trong ComboBox)
3. Nhập ghi chú (nếu có, ví dụ: bệnh nhân ưu tiên)
4. Hệ thống kiểm tra:
   - Bệnh nhân phải có lịch khám vào ngày hôm nay
   - Bệnh nhân chưa có trong hàng đợi
5. Nếu hợp lệ, hệ thống tự động:
   - Tăng số thứ tự (số thứ tự = số lượng bệnh nhân trong hàng đợi hôm nay + 1)
   - Đặt trạng thái mặc định: "Chờ khám"
   - Ghi nhận thời gian đăng ký (mặc định là thời gian hiện tại)
6. Click "Xác nhận":
   - Lưu vào database
   - Cập nhật danh sách hàng đợi
   - Hiển thị thông báo thành công với số thứ tự

**c) Gọi bệnh nhân tiếp theo**:
1. Click nút "Gọi tiếp"
2. Hệ thống kiểm tra:
   - Không có bệnh nhân nào đang khám (trạng thái "Đang khám")
3. Nếu hợp lệ:
   - Tự động chọn bệnh nhân đầu tiên trong hàng đợi (số thứ tự nhỏ nhất, trạng thái "Chờ khám")
   - Chuyển trạng thái sang "Đang khám"
   - Cập nhật số thứ tự hiện tại đang khám
   - Hiển thị thông báo với số thứ tự và tên bệnh nhân
   - Cập nhật danh sách hàng đợi

**d) Hoàn thành khám**:
1. Chọn bệnh nhân đang khám trong hàng đợi
2. Click nút "Hoàn thành"
3. Hệ thống:
   - Chuyển trạng thái sang "Đã khám"
   - Cập nhật trong database
   - Nếu là bệnh nhân đang được gọi, reset số thứ tự hiện tại về 0
   - Cập nhật danh sách (bệnh nhân "Đã khám" sẽ không hiển thị trong danh sách chính)

**e) Hủy lượt khám**:
1. Chọn bệnh nhân trong hàng đợi
2. Click nút "Hủy"
3. Hiển thị hộp thoại xác nhận
4. Nếu xác nhận:
   - Xóa khỏi hàng đợi
   - Nếu là bệnh nhân đang được gọi, reset số thứ tự hiện tại về 0
   - Cập nhật danh sách

**Các thành phần**:
- DataGrid hàng đợi (chỉ hiển thị bệnh nhân chưa khám xong)
- TextBox tìm kiếm theo tên, mã bệnh nhân, số thứ tự
- Nút "Thêm vào hàng đợi" (chỉ Admin, Staff, Lễ tân)
- Nút "Gọi tiếp" (Admin, Staff, Lễ tân, Bác sĩ)
- Nút "Hoàn thành" cho từng bệnh nhân
- Nút "Hủy" cho từng bệnh nhân
- Nút "Làm mới" để tải lại dữ liệu
- Cửa sổ AddToQueue
- Hiển thị số thứ tự hiện tại đang khám

#### 3.1.8. Giao diện quản lý hóa đơn (Invoice)

**Mục đích**: Tạo và quản lý hóa đơn thanh toán

**Luồng hoạt động**:

**a) Xem danh sách hóa đơn**:
1. Hiển thị danh sách tất cả hóa đơn
2. Có thể lọc theo ngày, trạng thái thanh toán, bệnh nhân
3. Hiển thị: Mã hóa đơn, Bệnh nhân, Ngày lập, Tổng tiền, Thành tiền, Trạng thái

**b) Tạo hóa đơn mới**:
1. Click "Thêm mới", mở cửa sổ AddInvoice
2. Chọn bệnh nhân
3. Chọn bệnh án (tự động lấy danh sách bệnh án của bệnh nhân)
4. Hệ thống tự động tính:
   - Tổng tiền = Giá dịch vụ khám + Tổng tiền thuốc (nếu có đơn thuốc)
5. Nhập giảm giá (nếu có)
6. Hệ thống tính: Thành tiền = Tổng tiền - Giảm giá
7. Chọn phương thức thanh toán: Tiền mặt, Chuyển khoản, Thẻ
8. Nhập ghi chú (nếu có)
9. Click "Lưu":
   - Tạo hóa đơn mới
   - Trạng thái mặc định: "Chưa thanh toán"
   - Lưu vào database

**c) Thanh toán hóa đơn**:
1. Chọn hóa đơn chưa thanh toán
2. Click "Thanh toán"
3. Cập nhật trạng thái thành "Đã thanh toán"
4. Lưu vào database

**d) In hóa đơn**:
1. Chọn hóa đơn
2. Click "In hóa đơn"
3. Hiển thị preview hóa đơn
4. In hoặc xuất PDF

**Các thành phần**:
- DataGrid danh sách hóa đơn
- Cửa sổ AddInvoice
- Các nút: Thanh toán, In hóa đơn
- Hiển thị tổng doanh thu, số hóa đơn chưa thanh toán

#### 3.1.9. Giao diện quản lý dịch vụ (Services)

**Mục đích**: Quản lý các dịch vụ khám chữa bệnh

**Luồng hoạt động**:
1. Hiển thị danh sách dịch vụ
2. Thêm, sửa, xóa dịch vụ
3. Thiết lập giá cả cho từng dịch vụ
4. Upload hình ảnh dịch vụ (nếu có)

**Các thành phần**:
- DataGrid danh sách dịch vụ
- Cửa sổ AddService, ChangeService
- TextBox nhập tên dịch vụ, giá tiền
- Image upload

#### 3.1.10. Giao diện quản lý thuốc (Medicine)

**Mục đích**: Quản lý kho thuốc

**Luồng hoạt động**:
1. Hiển thị danh sách thuốc
2. Thêm, sửa, xóa thuốc
3. Quản lý số lượng tồn kho
4. Quản lý hạn sử dụng
5. Cảnh báo khi thuốc sắp hết hạn hoặc hết hàng

**Các thành phần**:
- DataGrid danh sách thuốc
- Cửa sổ AddMedicine, ChangeMedicine, ViewMedicine
- Hiển thị cảnh báo số lượng thấp, hạn sử dụng

---

## PHẦN 4: TỔNG KẾT VÀ HƯỚNG PHÁT TRIỂN

### 4.1. Tổng kết

#### 4.1.1. Kết quả đạt được

Sau quá trình phát triển, phần mềm Quản lý Bệnh viện đã đạt được các kết quả sau:

1. **Hoàn thiện các chức năng cơ bản**:
   - Đã xây dựng đầy đủ các module quản lý: bệnh nhân, bệnh án, đơn thuốc, lịch khám, hàng đợi, hóa đơn, dịch vụ, thuốc
   - Hệ thống đăng nhập với phân quyền người dùng
   - Dashboard thống kê tổng quan

2. **Giao diện người dùng**:
   - Giao diện hiện đại, trực quan sử dụng Material Design
   - Dễ sử dụng, thân thiện với người dùng
   - Responsive, hỗ trợ tìm kiếm và lọc dữ liệu hiệu quả

3. **Cơ sở dữ liệu**:
   - Thiết kế database chuẩn hóa, đảm bảo tính nhất quán
   - Quan hệ giữa các bảng được thiết kế hợp lý
   - Hỗ trợ lưu trữ lịch sử thay đổi

4. **Kiến trúc phần mềm**:
   - Áp dụng mô hình MVVM, tách biệt logic và giao diện
   - Code có cấu trúc rõ ràng, dễ bảo trì và mở rộng
   - Sử dụng Repository pattern để quản lý truy cập dữ liệu

#### 4.1.2. Những khó khăn gặp phải

Trong quá trình phát triển, nhóm đã gặp một số khó khăn:

1. **Phức tạp của nghiệp vụ y tế**:
   - Cần hiểu rõ các quy trình trong bệnh viện để thiết kế hệ thống phù hợp
   - Xử lý các trường hợp đặc biệt (bệnh nhân ưu tiên, thuốc hết hạn, ...)

2. **Quản lý dữ liệu**:
   - Đảm bảo tính nhất quán dữ liệu khi có nhiều thao tác đồng thời
   - Xử lý các ràng buộc giữa các bảng khi xóa dữ liệu

3. **Hiệu năng**:
   - Tối ưu hóa truy vấn database khi có lượng dữ liệu lớn
   - Cải thiện tốc độ tải dữ liệu trong DataGrid

4. **Giao diện**:
   - Thiết kế giao diện vừa đẹp vừa dễ sử dụng
   - Xử lý các trường hợp dữ liệu null, rỗng

### 4.2. Ưu điểm và nhược điểm

#### 4.2.1. Ưu điểm

1. **Giao diện đẹp và thân thiện**:
   - Sử dụng Material Design, giao diện hiện đại, chuyên nghiệp
   - Bố cục rõ ràng, dễ sử dụng
   - Icon và màu sắc phù hợp với ngữ cảnh y tế

2. **Chức năng đầy đủ**:
   - Bao phủ hầu hết các nghiệp vụ quản lý trong bệnh viện
   - Hỗ trợ đầy đủ các thao tác CRUD (Create, Read, Update, Delete)
   - Tích hợp nhiều tính năng: tìm kiếm, lọc, thống kê

3. **Kiến trúc tốt**:
   - Áp dụng MVVM pattern, code dễ bảo trì
   - Tách biệt các tầng rõ ràng
   - Dễ mở rộng và phát triển thêm tính năng

4. **Database được thiết kế tốt**:
   - Chuẩn hóa dữ liệu, giảm dư thừa
   - Quan hệ giữa các bảng hợp lý
   - Hỗ trợ lưu trữ lịch sử

5. **Bảo mật**:
   - Hệ thống đăng nhập với mật khẩu được mã hóa
   - Phân quyền người dùng

#### 4.2.2. Nhược điểm

1. **Hiệu năng với dữ liệu lớn**:
   - Khi số lượng bệnh nhân, bệnh án lớn, việc tải dữ liệu có thể chậm
   - Chưa có phân trang cho DataGrid
   - Chưa có caching dữ liệu

2. **Thiếu một số tính năng nâng cao**:
   - Chưa có báo cáo chi tiết, xuất Excel/PDF
   - Chưa có thông báo tự động (nhắc lịch khám, thuốc hết hạn)
   - Chưa có backup/restore dữ liệu tự động

3. **Xử lý lỗi**:
   - Chưa có hệ thống log chi tiết
   - Xử lý exception chưa đầy đủ ở một số nơi
   - Thông báo lỗi chưa thân thiện với người dùng cuối

4. **Tài liệu**:
   - Chưa có tài liệu hướng dẫn sử dụng chi tiết
   - Chưa có tài liệu API (nếu có)

5. **Testing**:
   - Chưa có unit test, integration test
   - Chưa có test tự động

6. **Đa ngôn ngữ**:
   - Chỉ hỗ trợ tiếng Việt
   - Chưa có tính năng đa ngôn ngữ

### 4.3. Các tính năng nâng cao dự tính phát triển

#### 4.3.1. Tính năng báo cáo và thống kê nâng cao

1. **Báo cáo doanh thu**:
   - Báo cáo doanh thu theo ngày, tuần, tháng, năm
   - So sánh doanh thu giữa các kỳ
   - Phân tích doanh thu theo dịch vụ, theo thời gian
   - Biểu đồ trực quan hóa dữ liệu

2. **Báo cáo bệnh nhân**:
   - Thống kê số lượng bệnh nhân theo thời gian
   - Phân tích độ tuổi, giới tính
   - Thống kê bệnh thường gặp
   - Báo cáo tái khám

3. **Báo cáo thuốc**:
   - Thống kê thuốc sử dụng nhiều nhất
   - Cảnh báo thuốc sắp hết, hết hạn
   - Báo cáo tồn kho

4. **Xuất báo cáo**:
   - Xuất báo cáo ra file Excel
   - Xuất báo cáo ra file PDF
   - In trực tiếp từ ứng dụng

#### 4.3.2. Tính năng thông báo và nhắc nhở

1. **Thông báo lịch khám**:
   - Tự động gửi SMS/Email nhắc lịch khám cho bệnh nhân
   - Thông báo cho bác sĩ về lịch khám trong ngày
   - Nhắc nhở bệnh nhân tái khám

2. **Cảnh báo tự động**:
   - Cảnh báo thuốc sắp hết hạn
   - Cảnh báo thuốc hết hàng
   - Cảnh báo phòng quá tải
   - Cảnh báo hóa đơn chưa thanh toán

3. **Thông báo hệ thống**:
   - Thông báo khi có bệnh nhân mới vào hàng đợi
   - Thông báo khi có lịch khám mới
   - Thông báo các sự kiện quan trọng

#### 4.3.3. Tính năng tích hợp thanh toán

1. **Thanh toán trực tuyến**:
   - Tích hợp cổng thanh toán (VNPay, MoMo, ...)
   - Thanh toán qua thẻ ngân hàng
   - QR code thanh toán

2. **Quản lý bảo hiểm y tế**:
   - Tích hợp với hệ thống BHYT
   - Tự động tính toán phần BHYT chi trả
   - Quản lý thẻ BHYT

#### 4.3.4. Tính năng di động và web

1. **Ứng dụng di động**:
   - Phát triển app mobile (iOS, Android) cho bệnh nhân
   - Đặt lịch khám từ điện thoại
   - Xem lịch sử khám chữa bệnh
   - Nhận thông báo

2. **Web portal**:
   - Phát triển website cho bệnh nhân đặt lịch khám online
   - Xem thông tin bác sĩ, dịch vụ
   - Tra cứu kết quả khám

#### 4.3.5. Tính năng AI và phân tích dữ liệu

1. **Hỗ trợ chẩn đoán**:
   - Sử dụng AI để gợi ý chẩn đoán dựa trên triệu chứng
   - Phân tích hình ảnh y tế (X-quang, siêu âm)
   - Gợi ý thuốc phù hợp

2. **Phân tích dữ liệu lớn**:
   - Phân tích xu hướng bệnh tật
   - Dự đoán nhu cầu khám chữa bệnh
   - Tối ưu hóa lịch làm việc của bác sĩ

#### 4.3.6. Tính năng bảo mật và backup

1. **Bảo mật nâng cao**:
   - Mã hóa dữ liệu nhạy cảm
   - Audit log (ghi nhận mọi thao tác)
   - Xác thực 2 yếu tố (2FA)
   - Phân quyền chi tiết hơn

2. **Backup và khôi phục**:
   - Tự động backup database định kỳ
   - Backup lên cloud
   - Khôi phục dữ liệu nhanh chóng
   - Version control cho dữ liệu

#### 4.3.7. Tính năng tích hợp thiết bị y tế

1. **Kết nối thiết bị**:
   - Tích hợp máy đo huyết áp, nhịp tim
   - Tích hợp máy xét nghiệm
   - Tự động nhập kết quả vào hệ thống

2. **Lưu trữ hình ảnh y tế**:
   - Lưu trữ và quản lý hình ảnh X-quang, siêu âm
   - Xem hình ảnh trực tiếp trong hệ thống
   - Chia sẻ hình ảnh giữa các bác sĩ

#### 4.3.8. Tính năng đa ngôn ngữ và quốc tế hóa

1. **Hỗ trợ nhiều ngôn ngữ**:
   - Tiếng Việt, Tiếng Anh
   - Dễ dàng thêm ngôn ngữ khác

2. **Định dạng quốc tế**:
   - Hỗ trợ nhiều múi giờ
   - Định dạng ngày tháng theo vùng
   - Định dạng tiền tệ

#### 4.3.9. Tính năng tối ưu hóa hiệu năng

1. **Caching**:
   - Cache dữ liệu thường dùng
   - Giảm số lần truy vấn database

2. **Phân trang và lazy loading**:
   - Phân trang cho DataGrid
   - Lazy loading dữ liệu
   - Virtual scrolling

3. **Tối ưu database**:
   - Index cho các cột thường query
   - Query optimization
   - Connection pooling

#### 4.3.10. Tính năng hỗ trợ người dùng

1. **Hướng dẫn sử dụng**:
   - Tutorial trong ứng dụng
   - Tooltip hướng dẫn
   - Video hướng dẫn

2. **Hỗ trợ khách hàng**:
   - Chat support trong ứng dụng
   - FAQ (Câu hỏi thường gặp)
   - Feedback và đánh giá

---

## KẾT LUẬN

Phần mềm Quản lý Bệnh viện đã được phát triển thành công với đầy đủ các chức năng cơ bản cần thiết cho việc quản lý một phòng khám tư nhân hoặc bệnh viện nhỏ. Hệ thống có giao diện đẹp, dễ sử dụng, kiến trúc tốt và có khả năng mở rộng trong tương lai.

Với các tính năng nâng cao được đề xuất, hệ thống có thể phát triển thành một giải pháp quản lý bệnh viện hoàn chỉnh, đáp ứng nhu cầu của các cơ sở y tế lớn hơn và cung cấp trải nghiệm tốt hơn cho cả nhân viên y tế và bệnh nhân.

---

## TÀI LIỆU THAM KHẢO

1. Microsoft Documentation - WPF và .NET Framework
2. Entity Framework Documentation
3. Material Design Guidelines
4. SQL Server Documentation
5. AWS Documentation - EC2 và RDS

---

## THÔNG TIN DỰ ÁN

- **Tên dự án**: Phần mềm Quản lý Bệnh viện
- **Nhóm thực hiện**: Nhóm 20 UIT
- **Môn học**: Lập trình trực quan
- **Năm học**: 2024
- **Công nghệ**: WPF, C#, SQL Server, Entity Framework
- **License**: [Điền thông tin license nếu có]

---

## HƯỚNG DẪN CÀI ĐẶT

### Yêu cầu hệ thống:
- Windows 10/11
- .NET Framework 4.7.2 trở lên
- SQL Server 2008 trở lên

### Cài đặt:
1. Download file setup.msi tại mục releases
2. Chạy file setup.msi và làm theo hướng dẫn
3. Cấu hình kết nối database trong App.Config
4. Chạy script SQL trong thư mục Database để tạo database và dữ liệu mẫu
5. Khởi động ứng dụng và đăng nhập với tài khoản mặc định:
   - Username: admin
   - Password: 123456

---

## DEVELOPERS

[Điền thông tin thành viên nhóm]
