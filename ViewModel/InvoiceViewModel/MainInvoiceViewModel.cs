using LTTQ_DoAn.View;
using LTTQ_DoAn.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Objects;

namespace LTTQ_DoAn.ViewModel
{
    public class InvoiceItem
    {
        public int MaHoaDonId { get; set; }
        public string MaHoaDon { get; set; }
        public string MaBenhNhan { get; set; }
        public string TenBenhNhan { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string PhuongThuc { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }
    }

    public class HoaDonResult
    {
        public int MAHOADON { get; set; }
        public string SUB_ID { get; set; }
        public int? MABENHNHAN { get; set; }
        public int? MABENHAN { get; set; }
        public DateTime? NGAYLAP { get; set; }
        public decimal? TONGTIEN { get; set; }
        public decimal? GIAMGIA { get; set; }
        public decimal? THANHTIEN { get; set; }
        public string PHUONGTHUCTHANHTOAN { get; set; }
        public string TRANGTHAI { get; set; }
        public string GHICHU { get; set; }
        public string BENHNHAN_SUB_ID { get; set; }
        public string HOTEN { get; set; }
    }

    public class InvoiceViewModel : BaseViewModel
    {
        public ICommand CreateInvoiceCommand { get; }
        public ICommand ViewCommand { get; }
        public ICommand PayCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand PrintCommand { get; }

        private List<InvoiceItem> invoiceList;
        private List<InvoiceItem> allInvoices;
        private InvoiceItem selectedItem;
        private string searchText = "";
        
        private decimal todayTotal = 0;
        private int unpaidCount = 0;

        public bool createVisibility = true;

        QUANLYBENHVIENEntities _db;

        public List<InvoiceItem> InvoiceList
        {
            get => invoiceList;
            set
            {
                invoiceList = value;
                OnPropertyChanged(nameof(InvoiceList));
            }
        }

        public InvoiceItem SelectedItem
        {
            get => selectedItem;
            set
            {
                selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterInvoices();
            }
        }

        public decimal TodayTotal
        {
            get => todayTotal;
            set
            {
                todayTotal = value;
                OnPropertyChanged(nameof(TodayTotal));
                OnPropertyChanged(nameof(TodayTotalFormatted));
            }
        }

        public string TodayTotalFormatted
        {
            get => todayTotal.ToString("N0") + " VND";
        }

        public int UnpaidCount
        {
            get => unpaidCount;
            set
            {
                unpaidCount = value;
                OnPropertyChanged(nameof(UnpaidCount));
            }
        }

        public bool CreateVisibility
        {
            get => createVisibility;
            set
            {
                createVisibility = value;
                OnPropertyChanged(nameof(CreateVisibility));
            }
        }

        private void Load()
        {
            _db = new QUANLYBENHVIENEntities();
            
            allInvoices = new List<InvoiceItem>();
            
            try
            {
                string query = @"SELECT h.MAHOADON, h.SUB_ID, h.MABENHNHAN, h.MABENHAN, h.NGAYLAP, 
                                h.TONGTIEN, h.GIAMGIA, h.THANHTIEN, h.PHUONGTHUCTHANHTOAN, 
                                h.TRANGTHAI, h.GHICHU, bn.SUB_ID as BENHNHAN_SUB_ID, bn.HOTEN
                                FROM HOADON h
                                INNER JOIN BENHNHAN bn ON h.MABENHNHAN = bn.MABENHNHAN
                                ORDER BY h.NGAYLAP DESC";
                
                var results = _db.ExecuteStoreQuery<HoaDonResult>(query).ToList();
                
                foreach (var item in results)
                {
                    allInvoices.Add(new InvoiceItem
                    {
                        MaHoaDonId = item.MAHOADON,
                        MaHoaDon = item.SUB_ID ?? "",
                        MaBenhNhan = item.BENHNHAN_SUB_ID ?? "",
                        TenBenhNhan = item.HOTEN ?? "",
                        NgayLap = item.NGAYLAP ?? DateTime.Now,
                        TongTien = item.TONGTIEN ?? 0,
                        GiamGia = item.GIAMGIA ?? 0,
                        ThanhTien = item.THANHTIEN ?? 0,
                        PhuongThuc = item.PHUONGTHUCTHANHTOAN ?? "Tiền mặt",
                        TrangThai = item.TRANGTHAI ?? "Chưa thanh toán",
                        GhiChu = item.GHICHU ?? ""
                    });
                }
            }
            catch
            {
                allInvoices = new List<InvoiceItem>();
            }
            
            InvoiceList = allInvoices;
            CalculateStats();
        }

        private void CalculateStats()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            
            try
            {
                decimal revenue = 0;
                var benhAnToday = _db.BENHAN
                    .Where(b => b.NGAYKHAM >= today && b.NGAYKHAM < tomorrow)
                    .ToList();
                
                foreach (var ba in benhAnToday)
                {
                    decimal dichVuTien = ba.DICHVU?.GIATIEN ?? 0;
                    decimal thuocTien = 0;
                    
                    if (ba.DONTHUOC != null)
                    {
                        foreach (var dt in ba.DONTHUOC)
                        {
                            if (dt.CHITIETDONTHUOC != null)
                            {
                                foreach (var ctdt in dt.CHITIETDONTHUOC)
                                {
                                    if (ctdt.THUOC != null)
                                    {
                                        decimal donGia = ctdt.THUOC.GIATIEN ?? 0;
                                        double soLuong = ctdt.SOLUONG ?? 0;
                                        thuocTien += donGia * (decimal)soLuong;
                                    }
                                }
                            }
                        }
                    }
                    
                    revenue += dichVuTien + thuocTien;
                }
                
                TodayTotal = revenue;
            }
            catch
            {
                TodayTotal = 0;
            }
            
            UnpaidCount = allInvoices.Count(i => i.TrangThai == "Chưa thanh toán");
        }

        private void FilterInvoices()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                InvoiceList = allInvoices;
            }
            else
            {
                string keyword = SearchText.ToLower();
                InvoiceList = allInvoices.Where(i =>
                    (i.TenBenhNhan != null && i.TenBenhNhan.ToLower().Contains(keyword)) ||
                    (i.MaBenhNhan != null && i.MaBenhNhan.ToLower().Contains(keyword)) ||
                    (i.MaHoaDon != null && i.MaHoaDon.ToLower().Contains(keyword))
                ).ToList();
            }
        }

        public InvoiceViewModel()
        {
            Load();
            Set_permission(MainViewModel._currentUserAccount.LOAITAIKHOAN);
            CreateInvoiceCommand = new ViewModelCommand(ExecuteCreateInvoiceCommand);
            ViewCommand = new ViewModelCommand(ExecuteViewCommand);
            PayCommand = new ViewModelCommand(ExecutePayCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand);
            PrintCommand = new ViewModelCommand(ExecutePrintCommand);
        }

        void Set_permission(string type)
        {
            // Phong mach tu nhan - full quyen
            CreateVisibility = true;
        }

        private void ExecuteCreateInvoiceCommand(object obj)
        {
            AddInvoice addInvoiceWindow = new AddInvoice();
            Application.Current.MainWindow = addInvoiceWindow;
            addInvoiceWindow.Closed += (s, e) => Load();
            addInvoiceWindow.ShowDialog();
        }

        private void ExecuteViewCommand(object obj)
        {
            if (SelectedItem != null)
            {
                string info = "Mã hóa đơn: " + SelectedItem.MaHoaDon + "\n" +
                             "Bệnh nhân: " + SelectedItem.TenBenhNhan + "\n" +
                             "Ngày lập: " + SelectedItem.NgayLap.ToString("dd/MM/yyyy") + "\n" +
                             "Tổng tiền: " + SelectedItem.TongTien.ToString("N0") + " VND\n" +
                             "Giảm giá: " + SelectedItem.GiamGia.ToString("N0") + " VND\n" +
                             "Thành tiền: " + SelectedItem.ThanhTien.ToString("N0") + " VND\n" +
                             "Trạng thái: " + SelectedItem.TrangThai;
                new MessageBoxCustom("Chi tiết hóa đơn", info, MessageType.Info, MessageButtons.OK).ShowDialog();
            }
        }

        private void ExecutePayCommand(object obj)
        {
            InvoiceItem invoice = obj as InvoiceItem ?? SelectedItem;
            
            if (invoice != null && invoice.TrangThai == "Chưa thanh toán")
            {
                var result = new MessageBoxCustom("Xác nhận thanh toán", 
                    "Bạn có chắc chắn muốn xác nhận thanh toán cho hóa đơn " + invoice.MaHoaDon + "?",
                    MessageType.Info, 
                    MessageButtons.YesNo).ShowDialog();
                
                if (result == true)
                {
                    try
                    {
                        string updateQuery = "UPDATE HOADON SET TRANGTHAI = @p0 WHERE MAHOADON = @p1";
                        _db.ExecuteStoreCommand(updateQuery, "Đã thanh toán", invoice.MaHoaDonId);
                        _db.SaveChanges();
                        
                        invoice.TrangThai = "Đã thanh toán";
                        
                        new MessageBoxCustom("Thành công", 
                            "Đã xác nhận thanh toán hóa đơn: " + invoice.MaHoaDon,
                            MessageType.Success, 
                            MessageButtons.OK).ShowDialog();
                        
                        CalculateStats();
                        FilterInvoices();
                    }
                    catch (Exception ex)
                    {
                        new MessageBoxCustom("Lỗi", 
                            "Không thể xác nhận thanh toán: " + ex.Message,
                            MessageType.Error, 
                            MessageButtons.OK).ShowDialog();
                    }
                }
            }
        }

        private void ExecuteDeleteCommand(object obj)
        {
            if (SelectedItem != null)
            {
                var result = new MessageBoxCustom("Xác nhận xóa", 
                    "Bạn có chắc chắn muốn xóa hóa đơn " + SelectedItem.MaHoaDon + "?",
                    MessageType.Warning, 
                    MessageButtons.YesNo).ShowDialog();
                
                if (result == true)
                {
                    try
                    {
                        string deleteQuery = "DELETE FROM HOADON WHERE MAHOADON = @p0";
                        _db.ExecuteStoreCommand(deleteQuery, SelectedItem.MaHoaDonId);
                        _db.SaveChanges();
                        
                        new MessageBoxCustom("Thành công", 
                            "Đã xóa hóa đơn: " + SelectedItem.MaHoaDon,
                            MessageType.Success, 
                            MessageButtons.OK).ShowDialog();
                        
                        Load();
                    }
                    catch (Exception ex)
                    {
                        new MessageBoxCustom("Lỗi", 
                            "Không thể xóa hóa đơn: " + ex.Message,
                            MessageType.Error, 
                            MessageButtons.OK).ShowDialog();
                    }
                }
            }
        }

        private void ExecutePrintCommand(object obj)
        {
            InvoiceItem invoice = obj as InvoiceItem ?? SelectedItem;
            
            if (invoice != null)
            {
                try
                {
                    InvoicePrintData printData = LoadInvoicePrintData(invoice);
                    PrintInvoiceHelper.PrintInvoice(printData);
                }
                catch (Exception ex)
                {
                    new MessageBoxCustom("Lỗi", 
                        "Không thể in hóa đơn: " + ex.Message,
                        MessageType.Error, 
                        MessageButtons.OK).ShowDialog();
                }
            }
        }

        private InvoicePrintData LoadInvoicePrintData(InvoiceItem invoice)
        {
            InvoicePrintData data = new InvoicePrintData
            {
                MaHoaDon = invoice.MaHoaDon,
                NgayLap = invoice.NgayLap.ToString("dd/MM/yyyy"),
                TenBenhNhan = invoice.TenBenhNhan,
                MaBenhNhan = invoice.MaBenhNhan,
                TongTien = invoice.TongTien,
                GiamGia = invoice.GiamGia,
                ThanhTien = invoice.ThanhTien,
                PhuongThucThanhToan = invoice.PhuongThuc,
                TrangThai = invoice.TrangThai,
                GhiChu = invoice.GhiChu
            };

            try
            {
                string query = @"SELECT h.MABENHAN, ba.MADICHVU, dv.TENDICHVU, dv.GIATIEN
                                FROM HOADON h
                                INNER JOIN BENHAN ba ON h.MABENHAN = ba.MABENHAN
                                LEFT JOIN DICHVU dv ON ba.MADICHVU = dv.MADICHVU
                                WHERE h.MAHOADON = @p0";
                
                var serviceResult = _db.ExecuteStoreQuery<ServiceResult>(query, invoice.MaHoaDonId).FirstOrDefault();
                
                if (serviceResult != null && !string.IsNullOrEmpty(serviceResult.TENDICHVU))
                {
                    data.DichVuList.Add(new InvoiceServiceItem
                    {
                        TenDichVu = serviceResult.TENDICHVU,
                        GiaTien = serviceResult.GIATIEN ?? 0
                    });
                }

                if (serviceResult != null && serviceResult.MABENHAN.HasValue)
                {
                    string medicineQuery = @"SELECT t.TENTHUOC, t.GIATIEN, ctdt.SOLUONG
                                            FROM DONTHUOC dt
                                            INNER JOIN CHITIETDONTHUOC ctdt ON dt.MADONTHUOC = ctdt.MADONTHUOC
                                            INNER JOIN THUOC t ON ctdt.MATHUOC = t.MATHUOC
                                            WHERE dt.MABENHAN = @p0";
                    
                    var medicineResults = _db.ExecuteStoreQuery<MedicineResult>(medicineQuery, serviceResult.MABENHAN.Value).ToList();
                    
                    int stt = 1;
                    foreach (var med in medicineResults)
                    {
                        decimal donGia = med.GIATIEN ?? 0;
                        double soLuong = med.SOLUONG ?? 0;
                        decimal thanhTien = donGia * (decimal)soLuong;
                        
                        data.ThuocList.Add(new InvoiceMedicineItem
                        {
                            STT = stt++,
                            TenThuoc = med.TENTHUOC ?? "",
                            DonGia = donGia,
                            SoLuong = soLuong,
                            ThanhTien = thanhTien
                        });
                    }
                }
            }
            catch
            {
            }

            return data;
        }

        private class ServiceResult
        {
            public int? MABENHAN { get; set; }
            public int? MADICHVU { get; set; }
            public string TENDICHVU { get; set; }
            public decimal? GIATIEN { get; set; }
        }

        private class MedicineResult
        {
            public string TENTHUOC { get; set; }
            public decimal? GIATIEN { get; set; }
            public double? SOLUONG { get; set; }
        }
    }
}
