using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LTTQ_DoAn.Model;
using LTTQ_DoAn.Repositories;
using System.Windows.Input;

namespace LTTQ_DoAn.ViewModel
{
    public class ViewAppointmentViewModel : BaseViewModel
    {
        private LICHKHAM lichkham;
        private DICHVU dichvu;
        private BENHNHAN benhnhan;
        public ICommand CancelCommand { get; }
        public LICHKHAM Lichkham { get => lichkham; set => lichkham = value; }
        public DICHVU Dichvu { get => dichvu; set => dichvu = value; }
        public BENHNHAN Benhnhan { get => benhnhan; set => benhnhan = value; }

        public ViewAppointmentViewModel(LICHKHAM SeletedLichKham, DICHVU SelectedDichVu, BENHNHAN SelectedBenhNhan)
        {
            Lichkham = SeletedLichKham;
            Dichvu = SelectedDichVu;
            Benhnhan = SelectedBenhNhan;
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
        }
        public ViewAppointmentViewModel()
        {
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand, CanExecuteCancelCommand);
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
    }
}
