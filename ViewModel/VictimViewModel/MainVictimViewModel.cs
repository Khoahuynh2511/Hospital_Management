using LTTQ_DoAn.Model;
using LTTQ_DoAn.View;
using LTTQ_DoAn.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Forms;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;
using System.Data.Entity.Infrastructure;

namespace LTTQ_DoAn.ViewModel
{
    public class VictimViewModel : BaseViewModel
    {
        public bool viewHealthRecordVisibility = true;
        public bool changeVisibility = true;
        public bool addVisibility = true;
        public bool deleteVisibility = true;
        public ICommand ViewCommand { get; }
        public ICommand ViewHealthRecordCommand { get; }
        public ICommand ChangeCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        private List<BENHNHAN> victims;
        private List<BENHNHAN> allVictims;
        private BENHNHAN selectedItem = null;
        private string searchText = "";

        QUANLYBENHVIENEntities _db;
        public List<BENHNHAN> Victims { get => victims; set
            {
                victims = value;
                OnPropertyChanged(nameof(Victims));
            }
        }
        public BENHNHAN SelectedItem { get => selectedItem; set 
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
                FilterVictims();
            }
        }
        private void FilterVictims()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Victims = allVictims;
            }
            else
            {
                string keyword = SearchText.ToLower();
                Victims = allVictims.Where(v =>
                    (v.HOTEN != null && v.HOTEN.ToLower().Contains(keyword)) ||
                    (v.SUB_ID != null && v.SUB_ID.ToLower().Contains(keyword)) ||
                    (v.MABHYT != null && v.MABHYT.ToLower().Contains(keyword)) ||
                    (v.DIACHI != null && v.DIACHI.ToLower().Contains(keyword))
                ).ToList();
            }
        }
        public bool ViewHealthRecordVisibility
        {
            get => viewHealthRecordVisibility; set
            {
                viewHealthRecordVisibility = value;
                OnPropertyChanged(nameof(ViewHealthRecordVisibility));
            }
        }
        public bool AddVisibility
        {
            get => addVisibility; set
            {
               addVisibility = value;
                OnPropertyChanged(nameof(AddVisibility));
            }
        }
        public bool ChangeVisibility
        {
            get => changeVisibility; set
            {
                changeVisibility = value;
                OnPropertyChanged(nameof(ChangeVisibility));
            }
        }
        public bool DeleteVisibility
        {
            get => deleteVisibility; set
            {
                deleteVisibility = value;
                OnPropertyChanged(nameof(DeleteVisibility));
            }
        }
        private void Load()
        {
            _db = new QUANLYBENHVIENEntities();
            allVictims = _db.BENHNHAN.ToList();
            Victims = allVictims;
        }

        public VictimViewModel()
        {
            Load();
            Set_permission(MainViewModel._currentUserAccount.LOAITAIKHOAN);
            AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
            ViewCommand = new ViewModelCommand(ExecuteViewCommand, CanExecuteViewCommand);
            ChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
            ViewHealthRecordCommand = new ViewModelCommand(ExecuteViewHealthRecordCommand, CanExecuteViewHealthRecordCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteCommand, CanExecuteDeleteCommand);
        }
        void Set_permission(string type)
        {
            // Phong mach tu nhan - full quyen
            viewHealthRecordVisibility = true;
            changeVisibility = true;
            addVisibility = true;
            deleteVisibility = true;
        }
        private bool CanExecuteAddCommand(object? obj)
        {
            return true;
        }
        //tham số thứ 2 là hành động
        private void ExecuteAddCommand(object? obj)
        {
            //MessageBox.Show(this.selectedItem.SUB_ID.ToString());
            AddVictim wd = new AddVictim();
            wd.Closed += AddVictim_Closed;
            //cài mainwindow thành cửa số mới mở này để chút nữa đóng lại thì ta chỉ cần dùng lệnh close cho mainwindow
            // vi dụ nút cancel ở trong AddAppointmentViewModel.cs
            Application.Current.MainWindow = wd;
            wd.ShowDialog();
        }
        private void AddVictim_Closed(object sender, EventArgs e)
        {
            /*
            if (BaseViewModel.global_db.BENHNHAN.Count() > 0)
            {
                _db = BaseViewModel.global_db;
                // Xử lý sau khi cửa sổ AddVictim đã đóng
                // Điều này có thể là nơi bạn thực hiện các hành động sau khi cửa sổ đã đóng
                Victims = BaseViewModel.global_db.BENHNHAN.ToList();
            }*/
            Load();
        }

        private bool CanExecuteViewCommand(object? obj)
        {
            return true;
        }
        //tham số thứ 2 là hành động
        private void ExecuteViewCommand(object? obj)
        {
            ViewVictim wd = new ViewVictim();
            if (SelectedItem != null)
            {
                wd.DataContext = new ViewVictimViewModel(SelectedItem);
                Application.Current.MainWindow = wd;
                wd.ShowDialog();
            }
            //cài mainwindow thành cửa số mới mở này để chút nữa đóng lại thì ta chỉ cần dùng lệnh close cho mainwindow
            // vi dụ nút cancel ở trong AddAppointmentViewModel.cs

        }
        private bool CanExecuteChangeCommand(object? obj)
        {
            return true;
        }
        //tham số thứ 2 là hành động
        private void ExecuteChangeCommand(object? obj)
        {
            ChangeVictim wd = new ChangeVictim();
            wd.Closed += ChangeVictim_Closed;
            if (SelectedItem != null)
            {
                wd.DataContext = new ChangeVictimViewModel(SelectedItem);
                //cài mainwindow thành cửa số mới mở này để chút nữa đóng lại thì ta chỉ cần dùng lệnh close cho mainwindow
                // vi dụ nút cancel ở trong AddAppointmentViewModel.cs
                Application.Current.MainWindow = wd;
                wd.ShowDialog();
            }
        }

        private void ChangeVictim_Closed(object sender, EventArgs e)
        {
            Load();
        }

        private bool CanExecuteViewHealthRecordCommand(object? obj)
        {
            return true;
        }

        private void ExecuteViewHealthRecordCommand(object? obj)
        {
            
            HealthRecordAndPrescription wd = new HealthRecordAndPrescription();
            if (SelectedItem != null)
            {
                wd.DataContext = new HealthRecordAndPrescriptionViewModel(SelectedItem, wd, MainViewModel._currentUserAccount);
                //cài mainwindow thành cửa số mới mở này để chút nữa đóng lại thì ta chỉ cần dùng lệnh close cho mainwindow
                // vi dụ nút cancel ở trong AddAppointmentViewModel.cs
                Application.Current.MainWindow = wd;
                wd.ShowDialog();
            }
        }

        private bool CanExecuteDeleteCommand(object? obj)
        {
            return SelectedItem != null;
        }

        private void ExecuteDeleteCommand(object? obj)
        {
            if (SelectedItem != null)
            {
                var result = new MessageBoxCustom("Xác nhận", 
                    "Bạn có chắc chắn muốn xóa bệnh nhân này?", 
                    MessageType.Info, 
                    MessageButtons.OKCancel).ShowDialog();
                
                if (result == true)
                {
                    try
                    {
                        var benhnhan = _db.BENHNHAN.FirstOrDefault(b => b.MABENHNHAN == SelectedItem.MABENHNHAN);
                        if (benhnhan != null)
                        {
                            _db.BENHNHAN.DeleteObject(benhnhan);
                            _db.SaveChanges();
                            new MessageBoxCustom("Thông báo", 
                                "Xóa bệnh nhân thành công!", 
                                MessageType.Success, 
                                MessageButtons.OK).ShowDialog();
                            Load();
                        }
                    }
                    catch (Exception ex)
                    {
                        new MessageBoxCustom("Lỗi", 
                            "Không thể xóa bệnh nhân. Bệnh nhân có thể đang có lịch khám hoặc bệnh án liên quan.", 
                            MessageType.Error, 
                            MessageButtons.OK).ShowDialog();
                    }
                }
            }
        }
    }
}