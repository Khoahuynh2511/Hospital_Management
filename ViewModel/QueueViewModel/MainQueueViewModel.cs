using LTTQ_DoAn.Model;
using LTTQ_DoAn.Repositories;
using LTTQ_DoAn.View;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace LTTQ_DoAn.ViewModel
{
    public class QueueViewModel : BaseViewModel
    {
        private readonly QueueRepository _queueRepo;
        private readonly QUANLYBENHVIENEntities _db;
        private ObservableCollection<QueueItemModel> _queueList;
        private ObservableCollection<QueueItemModel> _allQueueItems;
        private QueueItemModel _selectedItem;
        private string _searchText = "";
        private int _currentCallingNumber;
        private int _nextQueueNumber;
        private bool _addVisibility = true;
        private bool _callNextVisibility = true;

        public ICommand AddToQueueCommand { get; }
        public ICommand CallNextCommand { get; }
        public ICommand CompleteCommand { get; }
        public ICommand CancelCommand { get; }
        public ICommand RefreshCommand { get; }

        public ObservableCollection<QueueItemModel> QueueList
        {
            get => _queueList;
            set { _queueList = value; OnPropertyChanged(nameof(QueueList)); }
        }

        public QueueItemModel SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(nameof(SelectedItem)); }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                FilterQueue();
            }
        }

        public int CurrentNumber
        {
            get => _currentCallingNumber;
            set { _currentCallingNumber = value; OnPropertyChanged(nameof(CurrentNumber)); }
        }

        public bool AddVisibility
        {
            get => _addVisibility;
            set { _addVisibility = value; OnPropertyChanged(nameof(AddVisibility)); }
        }

        public bool CallNextVisibility
        {
            get => _callNextVisibility;
            set { _callNextVisibility = value; OnPropertyChanged(nameof(CallNextVisibility)); }
        }

        public QueueViewModel()
        {
            _queueRepo = new QueueRepository();
            _db = new QUANLYBENHVIENEntities();
            
            AddToQueueCommand = new ViewModelCommand(ExecuteAddToQueue);
            CallNextCommand = new ViewModelCommand(ExecuteCallNext);
            CompleteCommand = new ViewModelCommand(ExecuteComplete);
            CancelCommand = new ViewModelCommand(ExecuteCancel);
            RefreshCommand = new ViewModelCommand(ExecuteRefresh);

            SetPermission(MainViewModel._currentUserAccount.LOAITAIKHOAN);
            LoadQueueFromDatabase();
        }

        private void SetPermission(string userType)
        {
            switch (userType)
            {
                case "Admin":
                case "Staff":
                case "Le tan":
                    AddVisibility = true;
                    CallNextVisibility = true;
                    break;
                case "Doctor":
                case "Bac si":
                    AddVisibility = false;
                    CallNextVisibility = true;
                    break;
                default:
                    AddVisibility = false;
                    CallNextVisibility = false;
                    break;
            }
        }

        private void LoadQueueFromDatabase()
        {
            var queueData = _queueRepo.GetTodayQueue();
            _allQueueItems = new ObservableCollection<QueueItemModel>(queueData);
            _nextQueueNumber = _queueRepo.GetNextQueueNumber();

            UpdateCurrentNumber();
            FilterQueue();
        }

        private void UpdateCurrentNumber()
        {
            var currentPatient = _allQueueItems.FirstOrDefault(q => q.TrangThai == "Dang kham");
            CurrentNumber = currentPatient?.SoThuTu ?? 0;
        }

        private void FilterQueue()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                QueueList = new ObservableCollection<QueueItemModel>(
                    _allQueueItems.Where(q => q.TrangThai != "Da kham")
                );
            }
            else
            {
                string keyword = SearchText.ToLower();
                QueueList = new ObservableCollection<QueueItemModel>(
                    _allQueueItems.Where(q =>
                        q.TrangThai != "Da kham" &&
                        ((q.TenBenhNhan != null && q.TenBenhNhan.ToLower().Contains(keyword)) ||
                         (q.MaBenhNhanDisplay != null && q.MaBenhNhanDisplay.ToLower().Contains(keyword)) ||
                         q.SoThuTu.ToString().Contains(keyword))
                    )
                );
            }
        }

        private void ExecuteAddToQueue(object obj)
        {
            var addWindow = new AddToQueue();
            var viewModel = new AddToQueueViewModel();
            addWindow.DataContext = viewModel;
            addWindow.ShowDialog();

            if (viewModel.DialogResult && viewModel.SelectedPatientId.HasValue)
            {
                int patientId = viewModel.SelectedPatientId.Value;

                DateTime today = DateTime.Today;
                DateTime tomorrow = today.AddDays(1);
                
                bool hasAppointmentToday = _db.LICHKHAM
                    .Any(l => l.MABENHNHAN == patientId && 
                             l.NGAYKHAM >= today && 
                             l.NGAYKHAM < tomorrow);
                
                if (!hasAppointmentToday)
                {
                    new MessageBoxCustom("Thông báo",
                        "Bệnh nhân này không có lịch khám vào ngày hôm nay!\nChỉ những bệnh nhân có lịch khám hôm nay mới được thêm vào hàng đợi.",
                        MessageType.Warning,
                        MessageButtons.OK).ShowDialog();
                    return;
                }

                if (_queueRepo.IsPatientInQueue(patientId))
                {
                    new MessageBoxCustom("Thông báo",
                        "Bệnh nhân này đã có trong hàng đợi!",
                        MessageType.Info,
                        MessageButtons.OK).ShowDialog();
                    return;
                }

                int newQueueId = _queueRepo.AddToQueue(patientId, _nextQueueNumber);
                string subId = _queueRepo.GetQueueSubId(newQueueId);

                var patient = _db.BENHNHAN.FirstOrDefault(b => b.MABENHNHAN == patientId);
                
                var newItem = new QueueItemModel
                {
                    MaHangDoi = newQueueId,
                    SubId = subId,
                    MaBenhNhan = patientId,
                    SoThuTu = _nextQueueNumber,
                    MaBenhNhanDisplay = patient?.SUB_ID ?? "N/A",
                    TenBenhNhan = patient?.HOTEN ?? "N/A",
                    SoDienThoai = "N/A",
                    ThoiGianDangKy = DateTime.Now,
                    TrangThai = "Cho kham",
                    GhiChu = null
                };

                _allQueueItems.Add(newItem);
                _nextQueueNumber++;

                new MessageBoxCustom("Thông báo",
                    "Đã thêm vào hàng đợi.\nSố thứ tự: " + newItem.SoThuTu + "\nBệnh nhân: " + newItem.TenBenhNhan,
                    MessageType.Success,
                    MessageButtons.OK).ShowDialog();

                FilterQueue();
            }
        }

        private void ExecuteCallNext(object obj)
        {
            var currentPatient = _allQueueItems.FirstOrDefault(q => q.TrangThai == "Dang kham");
            if (currentPatient != null)
            {
                new MessageBoxCustom("Thông báo",
                    "Đang có bệnh nhân khám.\nVui lòng hoàn thành trước khi gọi tiếp.",
                    MessageType.Info,
                    MessageButtons.OK).ShowDialog();
                return;
            }

            var nextPatient = _allQueueItems
                .Where(q => q.TrangThai == "Cho kham")
                .OrderBy(q => q.SoThuTu)
                .FirstOrDefault();

            if (nextPatient != null)
            {
                nextPatient.TrangThai = "Dang kham";
                _queueRepo.UpdateStatus(nextPatient.MaHangDoi, "Dang kham");

                CurrentNumber = nextPatient.SoThuTu;

                new MessageBoxCustom("Gọi bệnh nhân",
                    "Số thứ tự: " + nextPatient.SoThuTu + "\nHọ tên: " + nextPatient.TenBenhNhan,
                    MessageType.Success,
                    MessageButtons.OK).ShowDialog();

                FilterQueue();
            }
            else
            {
                new MessageBoxCustom("Thông báo",
                    "Không còn bệnh nhân trong hàng đợi.",
                    MessageType.Info,
                    MessageButtons.OK).ShowDialog();
            }
        }

        private void ExecuteComplete(object obj)
        {
            var item = obj as QueueItemModel;
            if (item == null) return;

            item.TrangThai = "Da kham";
            _queueRepo.UpdateStatus(item.MaHangDoi, "Da kham");

            if (CurrentNumber == item.SoThuTu)
            {
                CurrentNumber = 0;
            }

            FilterQueue();
        }

        private void ExecuteCancel(object obj)
        {
            var item = obj as QueueItemModel;
            if (item == null) return;

            var result = new MessageBoxCustom("Xác nhận",
                "Bạn có chắc muốn hủy lượt khám của " + item.TenBenhNhan + "?",
                MessageType.Info,
                MessageButtons.OKCancel).ShowDialog();

            if (result == true)
            {
                _queueRepo.DeleteFromQueue(item.MaHangDoi);

                if (CurrentNumber == item.SoThuTu)
                {
                    CurrentNumber = 0;
                }

                _allQueueItems.Remove(item);
                FilterQueue();
            }
        }

        private void ExecuteRefresh(object obj)
        {
            LoadQueueFromDatabase();
        }
    }
}
