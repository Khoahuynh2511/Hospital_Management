using System;
using System.ComponentModel;

namespace LTTQ_DoAn.Model
{
    public class QueueItemModel : INotifyPropertyChanged
    {
        private int maHangDoi;
        private string subId;
        private int? maBenhNhan;
        private int soThuTu;
        private string maBenhNhanDisplay;
        private string tenBenhNhan;
        private string soDienThoai;
        private DateTime thoiGianDangKy;
        private string trangThai;
        private string ghiChu;

        public int MaHangDoi
        {
            get => maHangDoi;
            set { maHangDoi = value; OnPropertyChanged(nameof(MaHangDoi)); }
        }

        public string SubId
        {
            get => subId;
            set { subId = value; OnPropertyChanged(nameof(SubId)); }
        }

        public int? MaBenhNhan
        {
            get => maBenhNhan;
            set { maBenhNhan = value; OnPropertyChanged(nameof(MaBenhNhan)); }
        }

        public int SoThuTu
        {
            get => soThuTu;
            set { soThuTu = value; OnPropertyChanged(nameof(SoThuTu)); }
        }

        public string MaBenhNhanDisplay
        {
            get => maBenhNhanDisplay;
            set { maBenhNhanDisplay = value; OnPropertyChanged(nameof(MaBenhNhanDisplay)); }
        }

        public string TenBenhNhan
        {
            get => tenBenhNhan;
            set { tenBenhNhan = value; OnPropertyChanged(nameof(TenBenhNhan)); }
        }

        public string SoDienThoai
        {
            get => soDienThoai;
            set { soDienThoai = value; OnPropertyChanged(nameof(SoDienThoai)); }
        }

        public DateTime ThoiGianDangKy
        {
            get => thoiGianDangKy;
            set { thoiGianDangKy = value; OnPropertyChanged(nameof(ThoiGianDangKy)); }
        }

        public string TrangThai
        {
            get => trangThai;
            set 
            { 
                trangThai = value; 
                OnPropertyChanged(nameof(TrangThai));
                OnPropertyChanged(nameof(TrangThaiDisplay));
            }
        }

        public string TrangThaiDisplay
        {
            get
            {
                switch (trangThai)
                {
                    case "Cho kham": return "Chờ khám";
                    case "Dang kham": return "Đang khám";
                    case "Da kham": return "Đã khám";
                    default: return trangThai;
                }
            }
        }

        public string GhiChu
        {
            get => ghiChu;
            set { ghiChu = value; OnPropertyChanged(nameof(GhiChu)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
