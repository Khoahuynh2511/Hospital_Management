using LTTQ_DoAn.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data.Objects;

namespace LTTQ_DoAn.ViewModel
{
    public class InvoiceDetailItem
    {
        public string TenThuoc { get; set; }
        public decimal DonGia { get; set; }
        public double SoLuong { get; set; }
        public decimal ThanhTien { get; set; }
        public string GhiChu { get; set; }
    }

    public class AddInvoiceViewModel : BaseViewModel
    {
        public ICommand CancelCommand { get; }
        public ICommand ConfirmAddCommand { get; }

        private List<string> benhAnList;
        private string selectedBenhAn;
        private BENHAN currentBenhAn;
        private BENHNHAN benhNhan;
        private string tenBenhNhan;
        private string dichVu;
        private decimal giaDichVu;
        private string dichVuGhiChu = "";
        private string donThuocGhiChu = "";
        private List<InvoiceDetailItem> thuocList;
        private decimal tongTien;
        private decimal giamGia;
        private decimal thanhTien;
        private string phuongThuc;
        private List<string> phuongThucList;
        private string ghiChu;

        QUANLYBENHVIENEntities _db;

        public List<string> BenhAnList
        {
            get => benhAnList;
            set
            {
                benhAnList = value;
                OnPropertyChanged(nameof(BenhAnList));
            }
        }

        public string SelectedBenhAn
        {
            get => selectedBenhAn;
            set
            {
                selectedBenhAn = value;
                OnPropertyChanged(nameof(SelectedBenhAn));
                LoadBenhAnDetails();
            }
        }

        public string TenBenhNhan
        {
            get => tenBenhNhan;
            set
            {
                tenBenhNhan = value;
                OnPropertyChanged(nameof(TenBenhNhan));
            }
        }

        public string DichVu
        {
            get => dichVu;
            set
            {
                dichVu = value;
                OnPropertyChanged(nameof(DichVu));
            }
        }

        public decimal GiaDichVu
        {
            get => giaDichVu;
            set
            {
                giaDichVu = value;
                OnPropertyChanged(nameof(GiaDichVu));
                CalculateTotal();
            }
        }

        public string DichVuGhiChu
        {
            get => dichVuGhiChu;
            set
            {
                dichVuGhiChu = value;
                OnPropertyChanged(nameof(DichVuGhiChu));
            }
        }

        public string DonThuocGhiChu
        {
            get => donThuocGhiChu;
            set
            {
                donThuocGhiChu = value;
                OnPropertyChanged(nameof(DonThuocGhiChu));
            }
        }

        public List<InvoiceDetailItem> ThuocList
        {
            get => thuocList;
            set
            {
                thuocList = value;
                OnPropertyChanged(nameof(ThuocList));
                CalculateTotal();
            }
        }

        public decimal TongTien
        {
            get => tongTien;
            set
            {
                tongTien = value;
                OnPropertyChanged(nameof(TongTien));
                OnPropertyChanged(nameof(TongTienFormatted));
                CalculateThanhTien();
            }
        }

        public string TongTienFormatted
        {
            get => tongTien.ToString("N0") + " VND";
        }

        public decimal GiamGia
        {
            get => giamGia;
            set
            {
                giamGia = value;
                OnPropertyChanged(nameof(GiamGia));
                OnPropertyChanged(nameof(GiamGiaFormatted));
                CalculateThanhTien();
            }
        }

        public string GiamGiaFormatted
        {
            get => giamGia.ToString("N0") + " VND";
        }

        public decimal ThanhTien
        {
            get => thanhTien;
            set
            {
                thanhTien = value;
                OnPropertyChanged(nameof(ThanhTien));
                OnPropertyChanged(nameof(ThanhTienFormatted));
            }
        }

        public string ThanhTienFormatted
        {
            get => thanhTien.ToString("N0") + " VND";
        }

        public string PhuongThuc
        {
            get => phuongThuc;
            set
            {
                phuongThuc = value;
                OnPropertyChanged(nameof(PhuongThuc));
            }
        }

        public List<string> PhuongThucList
        {
            get => phuongThucList;
            set
            {
                phuongThucList = value;
                OnPropertyChanged(nameof(PhuongThucList));
            }
        }

        public string GhiChu
        {
            get => ghiChu;
            set
            {
                ghiChu = value;
                OnPropertyChanged(nameof(GhiChu));
            }
        }

        public AddInvoiceViewModel()
        {
            _db = new QUANLYBENHVIENEntities();
            LoadBenhAnList();
            LoadPhuongThucList();
            
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
            ConfirmAddCommand = new ViewModelCommand(ExecuteConfirmAddCommand, CanExecuteConfirmAddCommand);
        }

        private void LoadBenhAnList()
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime tomorrow = today.AddDays(1);
                
                string query = "SELECT MABENHAN FROM HOADON WHERE MABENHAN IS NOT NULL";
                var benhAnCoHoaDon = _db.ExecuteStoreQuery<int>(query).ToList();
                
                var benhAnChuaCoHoaDon = (from ba in _db.BENHAN
                                         where !benhAnCoHoaDon.Contains(ba.MABENHAN)
                                         && ba.NGAYKHAM.HasValue
                                         && ba.NGAYKHAM >= today
                                         && ba.NGAYKHAM < tomorrow
                                         join bn in _db.BENHNHAN on ba.MABENHNHAN equals bn.MABENHNHAN
                                         orderby ba.NGAYKHAM descending
                                         select new { BenhAn = ba, BenhNhan = bn }).ToList();

                BenhAnList = benhAnChuaCoHoaDon.Select(ba => 
                    ba.BenhAn.SUB_ID + " - " + ba.BenhNhan.HOTEN + " (" + 
                    (ba.BenhAn.NGAYKHAM.HasValue ? ba.BenhAn.NGAYKHAM.Value.ToString("dd/MM/yyyy") : "") + ")"
                ).ToList();
            }
            catch
            {
                BenhAnList = new List<string>();
            }
        }

        private void LoadPhuongThucList()
        {
            PhuongThucList = new List<string> { "Tiền mặt", "Chuyển khoản", "Thẻ" };
            PhuongThuc = "Tiền mặt";
        }

        private void LoadBenhAnDetails()
        {
            if (string.IsNullOrEmpty(SelectedBenhAn))
            {
                TenBenhNhan = "";
                DichVu = "";
                GiaDichVu = 0;
                DichVuGhiChu = "";
                DonThuocGhiChu = "";
                ThuocList = new List<InvoiceDetailItem>();
                CalculateTotal();
                return;
            }

            try
            {
                string subId = SelectedBenhAn.Split('-')[0].Trim();
                currentBenhAn = _db.BENHAN.FirstOrDefault(ba => ba.SUB_ID == subId);

                if (currentBenhAn != null)
                {
                    DateTime today = DateTime.Today;
                    DateTime tomorrow = today.AddDays(1);
                    
                    if (!currentBenhAn.NGAYKHAM.HasValue || 
                        currentBenhAn.NGAYKHAM < today || 
                        currentBenhAn.NGAYKHAM >= tomorrow)
                    {
                        new MessageBoxCustom("Thông báo",
                            "Chỉ được chọn bệnh án có ngày khám là hôm nay!",
                            MessageType.Warning,
                            MessageButtons.OK).ShowDialog();
                        SelectedBenhAn = null;
                        TenBenhNhan = "";
                        DichVu = "";
                        GiaDichVu = 0;
                        DichVuGhiChu = "";
                        DonThuocGhiChu = "";
                        ThuocList = new List<InvoiceDetailItem>();
                        CalculateTotal();
                        return;
                    }

                    benhNhan = currentBenhAn.BENHNHAN;
                    TenBenhNhan = benhNhan?.HOTEN ?? "";

                    if (currentBenhAn.DICHVU != null)
                    {
                        DichVu = currentBenhAn.DICHVU.TENDICHVU;
                        GiaDichVu = currentBenhAn.DICHVU.GIATIEN ?? 0;
                    }
                    else
                    {
                        DichVu = "";
                        GiaDichVu = 0;
                    }

                    DichVuGhiChu = !string.IsNullOrEmpty(currentBenhAn.KETLUAN) ? currentBenhAn.KETLUAN : "";

                    LoadThuocList();
                    CalculateTotal();
                }
            }
            catch
            {
            }
        }

        private void LoadThuocList()
        {
            ThuocList = new List<InvoiceDetailItem>();
            List<string> allGhiChu = new List<string>();

            if (currentBenhAn?.DONTHUOC != null)
            {
                foreach (var donThuoc in currentBenhAn.DONTHUOC)
                {
                    string ghiChuDonThuoc = donThuoc.GHICHU ?? "";
                    if (!string.IsNullOrWhiteSpace(ghiChuDonThuoc))
                    {
                        allGhiChu.Add(ghiChuDonThuoc);
                    }
                    
                    if (donThuoc.CHITIETDONTHUOC != null)
                    {
                        foreach (var ct in donThuoc.CHITIETDONTHUOC)
                        {
                            if (ct.THUOC != null)
                            {
                                decimal donGia = ct.THUOC.GIATIEN ?? 0;
                                double soLuong = ct.SOLUONG ?? 0;
                                decimal thanhTien = donGia * (decimal)soLuong;

                                ThuocList.Add(new InvoiceDetailItem
                                {
                                    TenThuoc = ct.THUOC.TENTHUOC,
                                    DonGia = donGia,
                                    SoLuong = soLuong,
                                    ThanhTien = thanhTien,
                                    GhiChu = ghiChuDonThuoc
                                });
                            }
                        }
                    }
                }
            }

            DonThuocGhiChu = string.Join("\n\n", allGhiChu);
        }

        private void CalculateTotal()
        {
            decimal thuocTotal = ThuocList?.Sum(t => t.ThanhTien) ?? 0;
            TongTien = GiaDichVu + thuocTotal;
        }

        private void CalculateThanhTien()
        {
            ThanhTien = TongTien - GiamGia;
            if (ThanhTien < 0)
                ThanhTien = 0;
        }

        private bool CanExecuteConfirmAddCommand(object obj)
        {
            return currentBenhAn != null && TongTien > 0;
        }

        private void ExecuteCancelCommand(object obj)
        {
            Application.Current.MainWindow.Close();
        }

        private void ExecuteConfirmAddCommand(object obj)
        {
            try
            {
                string insertQuery = @"INSERT INTO HOADON (MABENHNHAN, MABENHAN, NGAYLAP, TONGTIEN, GIAMGIA, 
                                THANHTIEN, PHUONGTHUCTHANHTOAN, TRANGTHAI, GHICHU)
                                VALUES (@p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8)";
                
                _db.ExecuteStoreCommand(insertQuery,
                    currentBenhAn.MABENHNHAN,
                    currentBenhAn.MABENHAN,
                    DateTime.Now,
                    TongTien,
                    GiamGia,
                    ThanhTien,
                    PhuongThuc,
                    "Chưa thanh toán",
                    GhiChu ?? "");
                
                _db.SaveChanges();

                new MessageBoxCustom("Thành công",
                    "Đã tạo hóa đơn thành công!",
                    MessageType.Success,
                    MessageButtons.OK).ShowDialog();

                Application.Current.MainWindow.Close();
            }
            catch (Exception ex)
            {
                new MessageBoxCustom("Lỗi",
                    "Không thể tạo hóa đơn: " + ex.Message,
                    MessageType.Error,
                    MessageButtons.OK).ShowDialog();
            }
        }
    }
}
