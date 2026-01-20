using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using LTTQ_DoAn.View;

namespace LTTQ_DoAn.ViewModel
{
    public class ChangeServicesViewModel : BaseViewModel
    {
        private DICHVU dichvu;
        QUANLYBENHVIENEntities _db = new QUANLYBENHVIENEntities();

        public ICommand CancelCommand { get; }
        public ICommand ConfirmChangeCommand { get; }

        public DICHVU Dichvu
        {
            get => dichvu; set
            {
                dichvu = value;
                OnPropertyChanged(nameof(Dichvu));
            }
        }

        private void update()
        {
            DICHVU updateDichvu = (from m in _db.DICHVU
                                       where m.MADICHVU == Dichvu.MADICHVU
                                       select m).Single();
            updateDichvu.TENDICHVU = Dichvu.TENDICHVU;
            updateDichvu.GIATIEN = Dichvu.GIATIEN;
            _db.SaveChanges();
        }
        public ChangeServicesViewModel()
        {
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
        }
        public ChangeServicesViewModel(DICHVU SelectedDichVu)
        {
            Dichvu = SelectedDichVu;
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
            ConfirmChangeCommand = new ViewModelCommand(ExecuteChangeCommand, CanExecuteChangeCommand);
        }
        private bool CanExecuteCancelCommand(object? obj)
        {
            return true; //ko điều kiện
        }
        private void ExecuteCancelCommand(object? obj)
        {
            Application.Current.MainWindow.Close();
        }
        private bool CanExecuteChangeCommand(object? obj)
        {
            return true; //dk: thay đổi xong không trùng với khoa đã có
        }
        private void ExecuteChangeCommand(object? obj)
        {
            try
            {
                update();
                //MessageBox.Show("Sửa thông tin y sĩ thành công!");
                new MessageBoxCustom("Thành công", "Sửa thông tin dịch vụ thành công!", MessageType.Success, MessageButtons.OK).ShowDialog();
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ

            }
            catch (Exception err)
            {
                new MessageBoxCustom("Lỗi", err.Message, MessageType.Error, MessageButtons.OKCancel).ShowDialog();
                //MessageBox.Show(err.Message);
                Application.Current.MainWindow.Close(); // sau khi thêm sẽ đóng cửa sổ
            }
        }
    }
}
