using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class AddNurseAndDoctorViewModel : BaseViewModel
    {
        public ICommand CancelCommand { get; }
        public ICommand ConfirmAddCommand { get; }
        public string Ten { get => ten; set
            {
                ten = value;
                OnPropertyChanged(nameof(Ten));
            }
        }
        public string Gioitinh { get => gioitinh; set
            {
                gioitinh = value;
                OnPropertyChanged(nameof(Gioitinh));
            }
            }
        public string Ngaysinh { get => ngaysinh; set {
                ngaysinh = value;
                OnPropertyChanged(nameof(Ngaysinh));
            } }
        public string Khoa { get => khoa; set {
                khoa = value;
                OnPropertyChanged(nameof(Khoa));
            } }
        public string Chucvu { get => chucvu; set {
                chucvu = value;
                OnPropertyChanged(nameof(Chucvu));
            } }
        public string Ngayvaolam { get => ngayvaolam; set {
                ngayvaolam = value;
                OnPropertyChanged(nameof(Ngayvaolam));
            } }
        public string Chihuy { get => chihuy; set {
                chihuy = value;
                OnPropertyChanged(nameof(Chihuy));
            } }

        public string Maphong { get => maphong; set
            {
                maphong = value;
                OnPropertyChanged(nameof(Maphong));
            }
        }

        private string ten;
        private string gioitinh;
        private string ngaysinh;
        private string khoa;
        private string chucvu;
        private string ngayvaolam;
        private string chihuy;
        private string maphong;
        QUANLYBENHVIENEntities _db = new QUANLYBENHVIENEntities();
        private List<String> khoaList;
        private List<String> phonglist;
        public List<String> KhoaList
        {
            get => khoaList; set
            {
                khoaList = value;
                OnPropertyChanged(nameof(KhoaList));
            }
        }

        public List<string> Phonglist { get => phonglist; set => phonglist = value; }

        public void loadKhoa()
        {
            _db = new QUANLYBENHVIENEntities();
            List<KHOA> khoa = _db.KHOA.ToList();
            List<String> subID = new List<String>();
            foreach (var item in khoa)
            {
                subID.Add(item.SUB_ID + ": " + item.TENKHOA);
            }
            this.KhoaList = subID;
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
        public void insert()
        {
            YSI newYsi = new YSI()
            {
                HOTEN = Ten,
                GIOITINH = Gioitinh,
                NGAYSINH = DateTime.ParseExact(Ngaysinh, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                MAPHONG = this.convertPhongSUB_ID(Maphong),
                NGAYVAOLAM = DateTime.ParseExact(Ngayvaolam, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                MACHIHUY = this.convertChiHuySUB_ID(Chihuy),
                MAKHOA = this.convertKhoaSub_ID(Khoa),
                LOAIYSI = this.Chucvu
            };
            _db.YSI.AddObject(newYsi);
            _db.SaveChanges();
        }
        public AddNurseAndDoctorViewModel()
        {
            loadKhoa();
            loadPhong();
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmAddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
        }
        //hành động của nút hủy bỏ: đóng cửa sổ
        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }
        //điều kiện để lệnh hủy bỏ được thực hiện: k có điều kiện
        private bool CanExecuteCancelCommand(object? obj)
        {
            return true;
        }

        //hành động thêm vào
        private void ExecuteAddCommand(object? obj)
        {
            //câu lệnh thêm ở đây
            try
            {
                insert();
                //MessageBox.Show("Thêm y sĩ mới thành công!");
                new MessageBoxCustom(
                    "Thông báo",
                    "Thêm y sĩ mới thành công!",
                    MessageType.Success,
                    MessageButtons.OK
                    ).ShowDialog();
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ

            }
            catch (Exception err)
            {
                //MessageBox.Show(err.Message);
                new MessageBoxCustom(
                "Lỗi",
                err.Message,
                MessageType.Error,
                MessageButtons.OK
                ).ShowDialog();
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ
            }
        }
        //điều kiện để lệnh thêm được thực hiện: lich khám không có sẵn trong database
        private bool CanExecuteAddCommand(object? obj)
        {
            // những điều kiện cần xét

            // nếu không thỏa sẽ show messagebox rằng đã có trong lịch khám và return false
            return true; // khi nào thỏa điều kiện sẽ chấp nhận
        }
    }
}
