using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LTTQ_DoAn.Model;
using LTTQ_DoAn.Repositories;
using LTTQ_DoAn.View;

namespace LTTQ_DoAn.ViewModel
{
    public class ChangeNurseAndDoctorViewModel : BaseViewModel
    {
        private YSI ysi = null;
        private string phong_subid;
        private string khoa = null;
        private string chihuy = null;
        private List<String> gender = new List<string>() { "Nam", "Nữ" };
        private List<String> khoaList;
        private List<String> phonglist;
        private List<String> loaiYsiList;
        
        private string hoTen;
        private string gioiTinh;
        private DateTime? ngaySinh;
        private DateTime? ngayVaoLam;
        private string loaiYsi;
        private int tuoi;
        private string subId;

        public string HoTen
        {
            get => hoTen;
            set
            {
                hoTen = value;
                OnPropertyChanged(nameof(HoTen));
            }
        }

        public string GioiTinh
        {
            get => gioiTinh;
            set
            {
                gioiTinh = value;
                OnPropertyChanged(nameof(GioiTinh));
            }
        }

        public DateTime? NgaySinh
        {
            get => ngaySinh;
            set
            {
                ngaySinh = value;
                OnPropertyChanged(nameof(NgaySinh));
                CalculateTuoi();
            }
        }

        public DateTime? NgayVaoLam
        {
            get => ngayVaoLam;
            set
            {
                ngayVaoLam = value;
                OnPropertyChanged(nameof(NgayVaoLam));
            }
        }

        public string LoaiYsi
        {
            get => loaiYsi;
            set
            {
                loaiYsi = value;
                OnPropertyChanged(nameof(LoaiYsi));
            }
        }

        public int Tuoi
        {
            get => tuoi;
            set
            {
                tuoi = value;
                OnPropertyChanged(nameof(Tuoi));
            }
        }

        public string SubId
        {
            get => subId;
            set
            {
                subId = value;
                OnPropertyChanged(nameof(SubId));
            }
        }

        private void CalculateTuoi()
        {
            if (NgaySinh.HasValue)
            {
                Tuoi = DateTime.Now.Year - NgaySinh.Value.Year;
            }
        }

        public List<String> KhoaList
        {
            get => khoaList; set
            {
                khoaList = value;
                OnPropertyChanged(nameof(KhoaList));
            }
        }
        private List<String> ysiList;
        public void loadKhoa()
        {
            List<KHOA> khoa = _db.KHOA.ToList();
            List<String> subID = new List<String>();
            foreach (var item in khoa)
            {
                subID.Add(item.SUB_ID + ": " + item.TENKHOA);
                if (item.MAKHOA == Ysi.MAKHOA)
                {
                    Khoa = item.SUB_ID + ": " + item.TENKHOA;
                }
            }
            this.KhoaList = subID;
        }
        public void loadYsi()
        {
            List<YSI> ysi = _db.YSI.ToList();
            List<String> subID = new List<String>();
            foreach (var item in ysi)
            {
                subID.Add(item.SUB_ID + ": " + item.HOTEN);
                if (item.MAYSI == Ysi.MACHIHUY && Ysi.MACHIHUY != null)
                {
                    Chihuy = item.SUB_ID + ": " + item.HOTEN;
                }
            }
            if (Ysi.MACHIHUY == null)
            {
                Chihuy = "Không có cấp trên";
            }
            subID.Add("Không có cấp trên");
            this.YsiList = subID;
        }
        QUANLYBENHVIENEntities _db = new QUANLYBENHVIENEntities();
        public ICommand CancelCommand { get; }
        public ICommand ConfirmChangeCommand { get; }
        public YSI Ysi { get => ysi; set
            {
                ysi = value;
                OnPropertyChanged(nameof(Ysi));
            }
        }

        public string Phong_subid { get => phong_subid; set
            {
                phong_subid = value;
                OnPropertyChanged(nameof(Phong_subid));
            }
        }

        public string Khoa { get => khoa; set
            {
                khoa = value;
                OnPropertyChanged(nameof(Khoa));
            }
        }

        public List<string> YsiList { get => ysiList; set
            {
                ysiList = value;
            }
        }

        public string Chihuy { get => chihuy; set
            {
                chihuy = value;
                OnPropertyChanged(nameof(Chihuy));
            }
        }

        public void loadPhong()
        {
            List<PHONG> phong = _db.PHONG.ToList();
            List<String> subID = new List<String>();
            foreach (var item in phong)
            {
                subID.Add(item.SUB_ID + ": " + item.TENPHONG);
            }
            Phonglist = subID;
        }
        public int? convertPhongSUB_ID(string Sub_id)
        {
            if (string.IsNullOrEmpty(Sub_id))
            {
                return null;
            }
            // Chuoi can tach
            string[] parts = Sub_id.Split(new[] { ':' }, 2);
            if (parts.Length == 0 || parts[0].Length < 4)
            {
                return null;
            }
            // Tach cac ky tu con lai thanh mot chuoi rieng
            string remainingCharacters = parts[0].Substring(3);
            if (int.TryParse(remainingCharacters, out int result))
            {
                return result;
            }
            return null;
        }

        public List<string> Gender { get => gender; set => gender = value; }
        public List<string> Phonglist { get => phonglist; set => phonglist = value; }
        
        public List<string> LoaiYsiList
        {
            get => loaiYsiList;
            set
            {
                loaiYsiList = value;
                OnPropertyChanged(nameof(LoaiYsiList));
            }
        }

        public void loadLoaiYsi()
        {
            var distinctLoaiYsi = _db.YSI.Select(y => y.LOAIYSI).Distinct().ToList();
            LoaiYsiList = distinctLoaiYsi;
        }

        public ChangeNurseAndDoctorViewModel()
        {
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmChangeCommand = new ViewModelCommand(ExecuteConfirmChangeCommand, CanExecuteConfirmChangeCommand);
        }
        public ChangeNurseAndDoctorViewModel(YSI SelectedYSi)
        {
            loadPhong();
            loadLoaiYsi();
            Ysi = SelectedYSi;
            
            HoTen = SelectedYSi.HOTEN;
            GioiTinh = SelectedYSi.GIOITINH;
            NgaySinh = SelectedYSi.NGAYSINH;
            NgayVaoLam = SelectedYSi.NGAYVAOLAM;
            LoaiYsi = SelectedYSi.LOAIYSI;
            SubId = SelectedYSi.SUB_ID;
            CalculateTuoi();
            
            Phong_subid = "PHG" + SelectedYSi.MAPHONG.ToString() + ": " + SelectedYSi.PHONG.TENPHONG;
            loadKhoa();
            loadYsi();
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmChangeCommand = new ViewModelCommand(ExecuteConfirmChangeCommand, CanExecuteConfirmChangeCommand);
        }
        public int convertKhoaSub_ID(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return 0;
            }
            // Tach chuoi su dung phuong thuc Split
            string[] parts = inputString.Split(new[] { ':' }, 2);
            if (parts.Length == 0 || parts[0].Length < 2)
            {
                return 0;
            }
            string k1 = parts[0].Substring(1);
            if (int.TryParse(k1, out int result))
            {
                return result;
            }
            return 0;
        }
        public int? convertChiHuySUB_ID(string Sub_id)
        {
            if (string.IsNullOrEmpty(Sub_id) || Sub_id == "Không có cấp trên")
            {
                return null;
            }
            // Chuoi can tach
            string[] parts = Sub_id.Split(new[] { ':' }, 2);
            if (parts.Length == 0 || parts[0].Length < 2)
            {
                return null;
            }
            string k1 = parts[0].Substring(1);
            if (int.TryParse(k1, out int result))
            {
                return result;
            }
            return null;
        }
        private void update()
        {
            YSI updateYsi = (from m in _db.YSI
                                       where m.MAYSI == Ysi.MAYSI
                                       select m).Single();
            updateYsi.HOTEN = HoTen;
            updateYsi.MAPHONG = convertPhongSUB_ID(Phong_subid);
            updateYsi.GIOITINH = GioiTinh;
            updateYsi.NGAYSINH = NgaySinh;
            updateYsi.NGAYVAOLAM = NgayVaoLam;
            updateYsi.MAKHOA = convertKhoaSub_ID(Khoa);
            updateYsi.LOAIYSI = LoaiYsi;
            updateYsi.MACHIHUY = convertChiHuySUB_ID(Chihuy);
            _db.SaveChanges();
        }
        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }
        //điều kiện để lệnh hủy bỏ được thực hiện: k có điều kiện
        private bool CanExecuteCancelCommand(object? obj)
        {
            return true;
        }
        //---------------------------------------------
        private void ExecuteConfirmChangeCommand(object? obj)
        {
            try
            {
                update();
                //MessageBox.Show("Sửa thông tin y sĩ thành công!");
                new MessageBoxCustom("Thành công", "Sửa thông tin y sĩ thành công!", MessageType.Success, MessageButtons.OK).ShowDialog();
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ

            }
            catch (Exception err)
            {
                new MessageBoxCustom("Lỗi", err.Message, MessageType.Error, MessageButtons.OKCancel).ShowDialog();
                //MessageBox.Show(err.Message);
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ
            }
        }
        private bool CanExecuteConfirmChangeCommand(object? obj)
        {
            return true;
        }

    }
}
