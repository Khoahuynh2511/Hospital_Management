using LTTQ_DoAn.Model;
using LTTQ_DoAn.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LTTQ_DoAn.ViewModel
{
    public class PatientSelectItem
    {
        public int MaBenhNhan { get; set; }
        public string SubId { get; set; }
        public string HoTen { get; set; }
        public string DisplayText { get; set; }

        public override string ToString()
        {
            return DisplayText;
        }
    }

    public class AddToQueueViewModel : BaseViewModel
    {
        private readonly QUANLYBENHVIENEntities _db;
        private ObservableCollection<PatientSelectItem> _patientList;
        private PatientSelectItem _selectedPatient;

        public bool DialogResult { get; private set; }
        public int? SelectedPatientId { get; private set; }

        public ICommand CancelCommand { get; }
        public ICommand ConfirmCommand { get; }

        public ObservableCollection<PatientSelectItem> PatientList
        {
            get => _patientList;
            set { _patientList = value; OnPropertyChanged(nameof(PatientList)); }
        }

        public PatientSelectItem SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public AddToQueueViewModel()
        {
            _db = new QUANLYBENHVIENEntities();
            DialogResult = false;
            SelectedPatientId = null;

            LoadPatients();

            CancelCommand = new ViewModelCommand(ExecuteCancel);
            ConfirmCommand = new ViewModelCommand(ExecuteConfirm, CanExecuteConfirm);
        }

        private void LoadPatients()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);
            
            var patientsWithAppointmentToday = _db.LICHKHAM
                .Where(l => l.NGAYKHAM >= today && l.NGAYKHAM < tomorrow)
                .Select(l => l.MABENHNHAN)
                .Distinct()
                .ToList();
            
            var patients = _db.BENHNHAN
                .Where(p => patientsWithAppointmentToday.Contains(p.MABENHNHAN))
                .ToList();
            
            PatientList = new ObservableCollection<PatientSelectItem>(
                patients.Select(p => new PatientSelectItem
                {
                    MaBenhNhan = p.MABENHNHAN,
                    SubId = p.SUB_ID,
                    HoTen = p.HOTEN,
                    DisplayText = p.SUB_ID + " - " + p.HOTEN
                })
            );
        }

        private void ExecuteCancel(object obj)
        {
            DialogResult = false;
            CloseWindow();
        }

        private void ExecuteConfirm(object obj)
        {
            if (SelectedPatient == null)
            {
                new MessageBoxCustom("Lỗi", 
                    "Vui lòng chọn bệnh nhân",
                    MessageType.Info, 
                    MessageButtons.OK).ShowDialog();
                return;
            }

            SelectedPatientId = SelectedPatient.MaBenhNhan;
            DialogResult = true;
            CloseWindow();
        }

        private bool CanExecuteConfirm(object obj)
        {
            return SelectedPatient != null;
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is AddToQueue)
                {
                    window.Close();
                    break;
                }
            }
        }
    }
}
