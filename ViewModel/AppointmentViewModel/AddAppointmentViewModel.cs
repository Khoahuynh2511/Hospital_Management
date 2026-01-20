using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//thêm 3 thư viện mới này
using System.Windows;
using LTTQ_DoAn.Model;
using LTTQ_DoAn.Repositories;
using System.Globalization;
using LTTQ_DoAn.View;

namespace LTTQ_DoAn.ViewModel
{
    public class AddAppointmentViewModel : BaseViewModel
    {
        public ICommand CancelCommand { get; }

        public ICommand ConfirmChangeCommand { get; }
        public ICommand ConfirmAddApointmentCommand { get; }
        public string Benhnhan { get => benhnhan; set
            {
                benhnhan = value;
                OnPropertyChanged(nameof(Benhnhan));
            }
        }
        public string Dichvu { get => dichvu; set {
                dichvu = value;
                OnPropertyChanged(nameof(Dichvu));
            } }
        public string Ngaylenlich { get => ngaylenlich; set {
                ngaylenlich = value;
                OnPropertyChanged(nameof(Ngaylenlich));
            } }
        public string Ngaykham { get => ngaykham; set {
                ngaykham = value;
                OnPropertyChanged(nameof(Ngaykham));
            } }

        public List<string> BenhnhanList { get => benhnhanList; set => benhnhanList = value; }
        public List<string> DichvuList { get => dichvuList; set => dichvuList = value; }
        public string Cakham
        {
            get => cakham; set
            {
                cakham = value;
                OnPropertyChanged(nameof(Cakham));
                UpdateNgayKhamWithCaKham();
            }
        }

        private string benhnhan;
        private string dichvu;
        private string ngaylenlich;
        private string ngaykham;
        private string cakham;
        private List<String> benhnhanList;
        QUANLYBENHVIENEntities _db = new QUANLYBENHVIENEntities();
        private List<String> dichvuList;

        public DateTime TodayDate
        {
            get => DateTime.Today;
        }

        private int GetHourByCaKham(int caKham)
        {
            // Ca 1: 7:00, Ca 2: 8:00, Ca 3: 9:00, ..., Ca 12: 18:00
            return 6 + caKham;
        }

        private void UpdateNgayKhamWithCaKham()
        {
            // This method is called when Cakham changes
            // The actual update will be handled in the code-behind when both date and ca are selected
        }

        public void checkCaKham()
        {
            if (string.IsNullOrEmpty(Cakham))
            {
                throw new Exception("Vui lòng chọn ca khám!");
            }
            if (string.IsNullOrEmpty(Ngaykham))
            {
                throw new Exception("Vui lòng chọn ngày khám!");
            }
            if (string.IsNullOrEmpty(Ngaylenlich))
            {
                throw new Exception("Vui lòng chọn ngày lên lịch!");
            }
            
            int Ca = int.Parse(Cakham);
            DateTime new_NgayKham;
            DateTime new_NgayLenLich;
            
            try
            {
                new_NgayKham = DateTime.ParseExact(Ngaykham, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            }
            catch
            {
                DateTime ngayKhamDate = DateTime.Parse(Ngaykham);
                int hour = GetHourByCaKham(Ca);
                new_NgayKham = new DateTime(ngayKhamDate.Year, ngayKhamDate.Month, ngayKhamDate.Day, hour, 0, 0);
            }
            
            try
            {
                new_NgayLenLich = DateTime.ParseExact(Ngaylenlich, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            }
            catch
            {
                new_NgayLenLich = DateTime.Parse(Ngaylenlich);
            }
            
            DateTime today = DateTime.Today;
            if (new_NgayKham.Date < today)
            {
                throw new Exception("Ngày khám không được là ngày trong quá khứ!");
            }
            if (new_NgayLenLich.Date < today)
            {
                throw new Exception("Ngày lên lịch không được là ngày trong quá khứ!");
            }
            return;
        }

        public void deleteExpiredAppointments()
        {
            try
            {
                DateTime today = DateTime.Today;
                var expiredAppointments = _db.LICHKHAM.Where(l => l.NGAYKHAM < today).ToList();
                
                if (expiredAppointments.Count > 0)
                {
                    foreach (var appointment in expiredAppointments)
                    {
                        _db.LICHKHAM.DeleteObject(appointment);
                    }
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log error but don't throw to prevent blocking form opening
                System.Diagnostics.Debug.WriteLine("Error deleting expired appointments: " + ex.Message);
            }
        }

        public void loadBenhnhan()
        {
                List<BENHNHAN> benhnhan = _db.BENHNHAN.ToList();
                List<String> subID = new List<String>();
                foreach (var item in benhnhan)
                {
                    subID.Add(item.HOTEN + ": " + item.SUB_ID);
                }
                this.BenhnhanList = subID;
            
        }

        public void loadDichvu()
        {
            List<DICHVU> dichvu = _db.DICHVU.ToList();
            List<String> subID = new List<String>();
            foreach (var item in dichvu)
            {
                subID.Add(item.SUB_ID + ": " + item.TENDICHVU);
            }
            this.DichvuList = subID;
        }
        public int convertBenhnhanSub_ID(string inputString)
        {
            // Tách chuỗi sử dụng phương thức Split
            string[] parts = inputString.Split(new[] { ':' }, 2);
            string k1 = parts[1].Substring(3);
            return int.Parse(k1);
        }
        public int convertDichvuSub_ID(string inputString)
        {
            // Tách chuỗi sử dụng phương thức Split
            string[] parts = inputString.Split(new[] { ':' }, 2);
            string k1 = parts[0].Substring(2);
            return int.Parse(k1);
        }
        public void insert()
        {
            int insert_Ca = int.Parse(Cakham);
            checkCaKham();
            
            DateTime ngayKhamDate;
            DateTime ngayLenLichDate;
            
            try
            {
                ngayKhamDate = DateTime.ParseExact(Ngaykham, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            }
            catch
            {
                DateTime parsedDate = DateTime.Parse(Ngaykham);
                int hour = GetHourByCaKham(insert_Ca);
                ngayKhamDate = new DateTime(parsedDate.Year, parsedDate.Month, parsedDate.Day, hour, 0, 0);
            }
            
            try
            {
                ngayLenLichDate = DateTime.ParseExact(Ngaylenlich, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            }
            catch
            {
                ngayLenLichDate = DateTime.Parse(Ngaylenlich);
            }
            
            LICHKHAM newLichkham = new LICHKHAM()
            {
                MABENHNHAN = convertBenhnhanSub_ID(Benhnhan),
                MADICHVU = convertDichvuSub_ID(Dichvu),
                NGAYKHAM = ngayKhamDate,
                NGAYLENLICH = ngayLenLichDate,
                CAKHAM  = insert_Ca,
            };
            _db.LICHKHAM.AddObject(newLichkham);
            _db.SaveChanges();
        }
        public AddAppointmentViewModel()
        {
            deleteExpiredAppointments();
            loadBenhnhan();
            loadDichvu();
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmAddApointmentCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
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
                new MessageBoxCustom("Thông báo", "Thêm lịch khám mới thành công!", MessageType.Success, MessageButtons.OK).ShowDialog();
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ

            }
            catch (Exception err)
            {
                new MessageBoxCustom("Lỗi", err.Message,
                    MessageType.Error,
                    MessageButtons.OK)
                    .ShowDialog();
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
