using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LTTQ_DoAn.Model;
using LTTQ_DoAn.Repositories;
using System.Windows.Input;
using LTTQ_DoAn.View;
using System.Globalization;

namespace LTTQ_DoAn.ViewModel
{
    public class ChangeAppointmentViewModel : BaseViewModel
    {
        QUANLYBENHVIENEntities _db = new QUANLYBENHVIENEntities();
        private string benhnhan;
        private string dichvu;
        private string ngaylenlich;
        private string ngaykham;
        private string cakham;
        private List<String> benhnhanList;
        private List<String> dichvuList;

        private LICHKHAM lichkham;
        public ICommand CancelCommand { get; }
        public ICommand ConfirmChangeCommand { get; }
        public string Cakham
        {
            get => cakham; set
            {
                cakham = value;
                OnPropertyChanged(nameof(Cakham));
            }
        }
        public LICHKHAM Lichkham { get => lichkham; set
            {
                lichkham = value;
                OnPropertyChanged(nameof(Lichkham));
            }
        }

        public string Benhnhan { get => benhnhan; set
            {
                benhnhan = value;
                OnPropertyChanged(nameof(Benhnhan));
            }
        }
        public string Dichvu { get => dichvu; set
            {
                dichvu = value;
                OnPropertyChanged(nameof(Dichvu));
            }
        }
        public string Ngaylenlich
        {
            get => ngaylenlich; set
            {
                ngaylenlich = value;
                OnPropertyChanged(nameof(Ngaylenlich));
            }
        }
        public string Ngaykham
        {
            get => ngaykham; set
            {
                ngaykham = value;
                OnPropertyChanged(nameof(Ngaykham));
            }
        }
        public List<string> BenhnhanList { get => benhnhanList; set => benhnhanList = value; }
        public List<string> DichvuList { get => dichvuList; set => dichvuList = value; }

        public void checkCaKham()
        {
            return;
        }

        public void loadBenhnhan()
        {
            List<BENHNHAN> benhnhan = _db.BENHNHAN.ToList();
            List<String> subID = new List<String>();
            foreach (var item in benhnhan)
            {
                subID.Add(item.HOTEN + ": " + item.SUB_ID);
                if (item.MABENHNHAN == Lichkham.MABENHNHAN)
                {
                    Benhnhan = item.HOTEN + ": " + item.SUB_ID;
                }
            }
            this.BenhnhanList = subID;
        }
        public void loadCakham()
        {
            Cakham = Lichkham.CAKHAM.ToString();
        }

        public void loadDichvu()
        {
            List<DICHVU> dichvu = _db.DICHVU.ToList();
            List<String> subID = new List<String>();
            foreach (var item in dichvu)
            {
                subID.Add(item.SUB_ID + ": " + item.TENDICHVU);
                if (item.MADICHVU == Lichkham.MADICHVU)
                {
                    Dichvu = item.SUB_ID + ": " + item.TENDICHVU;
                }
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
        private int GetHourByCaKham(int caKham)
        {
            return 6 + caKham;
        }

        private void update()
        {
            int update_Ca = int.Parse(Cakham);
            checkCaKham();
            LICHKHAM updateLichkham = (from m in _db.LICHKHAM
                                       where m.MALICHKHAM == Lichkham.MALICHKHAM
                                       select m).Single();
            updateLichkham.MABENHNHAN = convertBenhnhanSub_ID(Benhnhan);
            updateLichkham.MADICHVU = convertDichvuSub_ID(Dichvu);
            updateLichkham.NGAYLENLICH = Lichkham.NGAYLENLICH;
            
            DateTime ngayKhamDate = Lichkham.NGAYKHAM.HasValue ? Lichkham.NGAYKHAM.Value.Date : DateTime.Today;
            int hour = GetHourByCaKham(update_Ca);
            DateTime newNgayKham = new DateTime(ngayKhamDate.Year, ngayKhamDate.Month, ngayKhamDate.Day, hour, 0, 0);
            updateLichkham.NGAYKHAM = newNgayKham;
            updateLichkham.CAKHAM = update_Ca;
            _db.SaveChanges();
        }

        public ChangeAppointmentViewModel(LICHKHAM SelectedLichKham)
        {
            Lichkham = SelectedLichKham;
            loadBenhnhan();
            loadDichvu();
            loadCakham();
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmChangeCommand = new ViewModelCommand(ExecuteConfirmChangeCommand, CanExecuteConfirmChangeCommand);
        }
        public ChangeAppointmentViewModel()
        {
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmChangeCommand = new ViewModelCommand(ExecuteConfirmChangeCommand, CanExecuteConfirmChangeCommand);
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
                new MessageBoxCustom("Thành công", "Sửa thông tin lịch khám thành công!", MessageType.Success, MessageButtons.OK).ShowDialog();
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
