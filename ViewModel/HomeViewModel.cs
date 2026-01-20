using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LTTQ_DoAn.ViewModel
{
    public class HomeViewModel : BaseViewModel
    {
        public string DateTimeFormat = "dd/MM/yyyy";
        public static int divide_number = 5;
        
        private int victim_count;
        private int field_count;
        private int service_count;
        private int benhan_count;
        private int donthuoc_count;
        private int medicine_sold_count;
        
        // Dashboard quick stats
        private int todayPatientCount;
        private int todayAppointmentCount;
        private int lowStockMedicineCount;
        private decimal todayRevenue;
        
        private DateTime chart_startdate = new DateTime(2020, 1, 1);
        private DateTime chart_enddate = DateTime.Now;
        
        //Victim
        private DateTime[] victimDateTime;
        private SeriesCollection victim_series_collections;
        private string[] victimTimeLabels;

        //BenhAn
        private DateTime[] benhanDateTime;
        private SeriesCollection benhan_collections;
        private string[] benhanTimeLabels;

        //DonThuoc
        private DateTime[] donthuocDateTime;
        private SeriesCollection donthuoc_collections;
        private string[] donthuocTimeLabels;

        //Medicine
        private DateTime[] medicineDateTime;
        private SeriesCollection medicine_collections;
        private string[] medicineTimeLabels;
        private List<ThuocBanChay> listThuocBanChay;

        //Service
        private DateTime[] serviceDateTime;
        private SeriesCollection service_collections;
        private string[] serviceTimeLabels;
        private List<DichVu> listDichVu;

        QUANLYBENHVIENEntities _db = new QUANLYBENHVIENEntities();

        public class DichVu
        {
            public string Ten { get; set; }
            public string Doanhthu { get; set; }
        }
        public class ThuocBanChay
        {
            public string Ten { get; set; }
            public string Soluong { get; set; }
            public string Doanhthu { get; set; }
        }
        public int Victim_count
        {
            get => victim_count; set
            {
                victim_count = value;
                OnPropertyChanged(nameof(Victim_count));
            }
        }
        public int Field_count { get => field_count; set => field_count = value; }
        public int Service_count
        {
            get => service_count; set
            {
                service_count = value;
                OnPropertyChanged(nameof(Service_count));
            }
        }
        public int Benhan_count
        {
            get => benhan_count; set
            {
                benhan_count = value;
                OnPropertyChanged(nameof(Benhan_count));
            }
        }
        public int Donthuoc_count
        {
            get => donthuoc_count; set
            {
                donthuoc_count = value;
                OnPropertyChanged(nameof(Donthuoc_count));
            }
        }
        public int Medicine_sold_count
        {
            get => medicine_sold_count; set
            {
                medicine_sold_count = value;
                OnPropertyChanged(nameof(Medicine_sold_count));
            }
        }

        public SeriesCollection Victim_series_collections
        {
            get => victim_series_collections; set
            {
                victim_series_collections = value;
                OnPropertyChanged(nameof(Victim_series_collections));
            }
        }
        public string[] VictimTimeLabels
        {
            get => victimTimeLabels; set
            {
                victimTimeLabels = value;
                OnPropertyChanged(nameof(VictimTimeLabels));
            }
        }
        public Func<double, string> YFormatter { get; set; }

        public Func<double, string> VNDFormatter { get; set; }

        public DateTime Chart_startdate
        {
            get => chart_startdate; set
            {
                chart_startdate = value;
                OnPropertyChanged(nameof(Chart_startdate));
                LoadChart();
            }
        }
        public DateTime Chart_enddate
        {
            get => chart_enddate; set
            {
                chart_enddate = value;
                OnPropertyChanged(nameof(Chart_enddate));
                LoadChart();
            }
        }

        public DateTime[] VictimDateTime
        {
            get => victimDateTime; set
            {
                victimDateTime = value;
                OnPropertyChanged(nameof(VictimDateTime));
            }
        }

        public DateTime[] BenhanDateTime
        {
            get => benhanDateTime; set
            {
                benhanDateTime = value;
                OnPropertyChanged(nameof(BenhanDateTime));
            }
        }
        public SeriesCollection Benhan_collections
        {
            get => benhan_collections; set
            {
                benhan_collections = value;
                OnPropertyChanged(nameof(Benhan_collections));
            }
        }
        public string[] BenhanTimeLabels
        {
            get => benhanTimeLabels; set
            {
                benhanTimeLabels = value;
                OnPropertyChanged(nameof(BenhanTimeLabels));
            }
        }
        public DateTime[] DonthuocDateTime
        {
            get => donthuocDateTime; set
            {
                donthuocDateTime = value;
                OnPropertyChanged(nameof(DonthuocDateTime));
            }
        }
        public SeriesCollection Donthuoc_collections
        {
            get => donthuoc_collections; set
            {
                donthuoc_collections = value;
                OnPropertyChanged(nameof(Donthuoc_collections));
            }
        }
        public string[] DonthuocTimeLabels
        {
            get => donthuocTimeLabels; set
            {
                donthuocTimeLabels = value;
                OnPropertyChanged(nameof(DonthuocTimeLabels));
            }
        }
        public DateTime[] MedicineDateTime
        {
            get => medicineDateTime; set
            {
                medicineDateTime = value;
                OnPropertyChanged(nameof(MedicineDateTime));
            }
        }
        public SeriesCollection Medicine_collections
        {
            get => medicine_collections; set
            {
                medicine_collections = value;
                OnPropertyChanged(nameof(Medicine_collections));
            }
        }
        public string[] MedicineTimeLabels
        {
            get => medicineTimeLabels; set
            {
                medicineTimeLabels = value;
                OnPropertyChanged(nameof(MedicineTimeLabels));
            }
        }
        public List<ThuocBanChay> ListThuocBanChay
        {
            get => listThuocBanChay; set
            {
                listThuocBanChay = value;
                OnPropertyChanged(nameof(ListThuocBanChay));
            }
        }

        public DateTime[] ServiceDateTime
        {
            get => serviceDateTime; set
            {
                serviceDateTime = value;
                OnPropertyChanged(nameof(ServiceDateTime));
            }
        }
        public SeriesCollection Service_collections
        {
            get => service_collections; set
            {
                service_collections = value;
                OnPropertyChanged(nameof(Service_collections));
            }
        }
        public string[] ServiceTimeLabels
        {
            get => serviceTimeLabels; set
            {
                serviceTimeLabels = value;
                OnPropertyChanged(nameof(ServiceTimeLabels));
            }
        }

        public List<DichVu> ListDichVu
        {
            get => listDichVu; set
            {
                listDichVu = value;
                OnPropertyChanged(nameof(ListDichVu));
            }
        }

        // Dashboard quick stats properties
        public int TodayPatientCount
        {
            get => todayPatientCount;
            set
            {
                todayPatientCount = value;
                OnPropertyChanged(nameof(TodayPatientCount));
            }
        }
        public int TodayAppointmentCount
        {
            get => todayAppointmentCount;
            set
            {
                todayAppointmentCount = value;
                OnPropertyChanged(nameof(TodayAppointmentCount));
            }
        }
        public int LowStockMedicineCount
        {
            get => lowStockMedicineCount;
            set
            {
                lowStockMedicineCount = value;
                OnPropertyChanged(nameof(LowStockMedicineCount));
            }
        }
        public decimal TodayRevenue
        {
            get => todayRevenue;
            set
            {
                todayRevenue = value;
                OnPropertyChanged(nameof(TodayRevenue));
            }
        }
        public string TodayRevenueFormatted
        {
            get => todayRevenue.ToString("N0") + " VNĐ";
        }

        private void LoadQuickStats()
        {
            DateTime today = DateTime.Today;
            DateTime tomorrow = today.AddDays(1);

            // Today patients
            TodayPatientCount = _db.BENHNHAN
                .Count(p => p.NGAYNHAPVIEN >= today && p.NGAYNHAPVIEN < tomorrow);

            // Today appointments
            TodayAppointmentCount = _db.LICHKHAM
                .Count(l => l.NGAYKHAM >= today && l.NGAYKHAM < tomorrow);

            // Low stock medicines (less than 10)
            LowStockMedicineCount = _db.THUOC
                .Count(t => t.SOLUONG < 10);

            // Today revenue - including service and medicine
            decimal revenue = 0;
            var benhAnToday = _db.BENHAN
                .Where(b => b.NGAYKHAM >= today && b.NGAYKHAM < tomorrow)
                .ToList();
            
            foreach (var ba in benhAnToday)
            {
                decimal dichVuTien = ba.DICHVU?.GIATIEN ?? 0;
                decimal thuocTien = 0;
                
                if (ba.DONTHUOC != null)
                {
                    foreach (var dt in ba.DONTHUOC)
                    {
                        if (dt.CHITIETDONTHUOC != null)
                        {
                            foreach (var ctdt in dt.CHITIETDONTHUOC)
                            {
                                if (ctdt.THUOC != null)
                                {
                                    decimal donGia = ctdt.THUOC.GIATIEN ?? 0;
                                    double soLuong = ctdt.SOLUONG ?? 0;
                                    thuocTien += donGia * (decimal)soLuong;
                                }
                            }
                        }
                    }
                }
                
                revenue += dichVuTien + thuocTien;
            }
            
            TodayRevenue = revenue;
            OnPropertyChanged(nameof(TodayRevenueFormatted));
        }

        public void LoadDoanhThuTheoService(DateTime startdate, DateTime enddate)
        {
            List<DICHVU> default_listService = _db.DICHVU.ToList();
            List<DichVu> listService = new List<DichVu>();
            foreach (var item in default_listService)
            {
                string doanhthu = "0";
                decimal? sumDoanhThu = item.BENHAN
                    .Where(m => m.NGAYKHAM >= startdate && m.NGAYKHAM <= enddate)
                    .Sum(i => i.DICHVU.GIATIEN + i.DONTHUOC
                           .Sum(k => k.CHITIETDONTHUOC
                           .Sum(l => l.THUOC.GIATIEN * (((decimal)((int)(l.SOLUONG * 10000))) / 10000))
                           )
                           );
                if (sumDoanhThu != null)
                {
                    doanhthu = ((decimal)sumDoanhThu).ToString();
                }
                DichVu dichvu = new DichVu() { 
                    Ten = item.TENDICHVU,
                    Doanhthu = doanhthu
                };
                listService.Add(dichvu);
            }
            ListDichVu = listService;
        }

        public void divideTime(int ammount, DateTime startDate, DateTime endDate)
        {
            //int divide = 5;
            //DateTime startDate = new DateTime(2024, 1, 12);
            //DateTime endDate = new DateTime(2024, 3, 30);

            // Tính số ngày cách nhau
            TimeSpan difference = endDate - startDate;

            // Lấy số ngày từ đối tượng TimeSpan
            int numberOfDays = difference.Days;
            DateTime seriesDay = startDate;
            int ammountSpace = numberOfDays / ammount;
            DateTime[] timeLable = new DateTime[ammount + 1];
            for (int i = 0; i <= ammount; i++)
            {
                //Console.WriteLine(seriesDay + "\n");
                timeLable.SetValue(seriesDay, i);
                seriesDay = seriesDay.AddDays(ammountSpace);
            }
            VictimDateTime = timeLable;
            BenhanDateTime = timeLable;
            DonthuocDateTime = timeLable;
            MedicineDateTime = timeLable;
            ServiceDateTime = timeLable;
            string[] timeStringLable = new string[ammount];
            for (int i = 0; i < ammount; i++)
            {
                if (i == ammount - 1)
                {
                    timeStringLable.SetValue(VictimDateTime[i].ToString("yyyy/MM/dd") + "-" + Chart_enddate.ToString("yyyy/MM/dd"), i);
                    break;
                }
               
                timeStringLable.SetValue(VictimDateTime[i].ToString("yyyy/MM/dd") +"-" + VictimDateTime[i+1].ToString("yyyy/MM/dd"), i);
            }
            VictimTimeLabels = timeStringLable;
            BenhanTimeLabels = timeStringLable;
            DonthuocTimeLabels = timeStringLable;
            MedicineTimeLabels = timeStringLable;
            ServiceTimeLabels = timeStringLable;
        }
        private int findVictimNumbers(DateTime start_day, DateTime end_date)
        {
            int numbers = (from m in _db.BENHNHAN
                                where m.NGAYNHAPVIEN >= start_day && m.NGAYNHAPVIEN <= end_date
                                select m).Count();
            return numbers;
        }
        private int findBenhanNumbers(DateTime start_day, DateTime end_date)
        {
            DateTime configEnd = end_date.AddDays(1);
            int numbers = (from m in _db.BENHAN
                           where m.NGAYKHAM >= start_day && m.NGAYKHAM <= configEnd
                           select m).Count();
            return numbers;
        }
        private int findDonthuocNumbers(DateTime start_day, DateTime end_date)
        {
            DateTime configEnd = end_date.AddDays(1);
            int numbers = (from m in _db.BENHAN
                           join dt in _db.DONTHUOC on m.MABENHAN equals dt.MABENHAN
                           where m.NGAYKHAM >= start_day && m.NGAYKHAM <= configEnd
                           select dt).Count();
            return numbers;
        }
        private double findMedicineSoldNumbers(DateTime start_day, DateTime end_date)
        {
            DateTime configEnd = end_date.AddDays(1);
            double? numbers = (from m in _db.BENHAN
                               join dt in _db.DONTHUOC on m.MABENHAN equals dt.MABENHAN
                               join ctdt in _db.CHITIETDONTHUOC on dt.MADONTHUOC equals ctdt.MADONTHUOC
                               where m.NGAYKHAM >= start_day && m.NGAYKHAM <= configEnd
                               select ctdt.SOLUONG).Sum();
            return numbers ?? 0;
        }
        private int calServiceNumbers(DateTime start_day, DateTime end_date)
        {
            decimal numbers = 0;
            //Config this because if not, the new that add to now date will not show 
            DateTime configEnd = end_date.AddDays(1);
            decimal? what_numbers = (from m in _db.BENHAN
                           where m.NGAYKHAM >= start_day && m.NGAYKHAM <= configEnd
                           select m)
                           .Sum(i => i.DICHVU.GIATIEN + i.DONTHUOC
                           .Sum(k => k.CHITIETDONTHUOC
                           .Sum(l => l.THUOC.GIATIEN * (((decimal)((int)(l.SOLUONG * 10000))) / 10000))
                           )
                           );
            /* int test = (from m in _db.BENHAN
                                     where m.NGAYKHAM >= start_day && m.NGAYKHAM <= end_date
                                     select m).Count(); */

            if (what_numbers != null)
            {
                numbers = (decimal)what_numbers;
            }
            return Decimal.ToInt32(numbers);
        }
        void Load_Victim_Axis_Y()
        {
            ChartValues<int> chartValues = new ChartValues<int>();
            foreach (var item in VictimTimeLabels)
            {
                DateTime start_date = DateTime.ParseExact(item.Split('-')[0], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                DateTime end_date = DateTime.ParseExact(item.Split('-')[1], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                int count = findVictimNumbers(start_date, end_date);
                chartValues.Add(count);
            }
            Victim_series_collections = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Số bệnh nhân",
                    Values = chartValues
                }
            };


        }
        void Load_Benhan_Axis_Y()
        {
            ChartValues<int> chartValues = new ChartValues<int>();
            foreach (var item in BenhanTimeLabels)
            {
                DateTime start_date = DateTime.ParseExact(item.Split('-')[0], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                DateTime end_date = DateTime.ParseExact(item.Split('-')[1], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                int count = findBenhanNumbers(start_date, end_date);
                chartValues.Add(count);
            }
            Benhan_collections = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Số bệnh án",
                    Values = chartValues
                }
            };
        }
        void Load_Donthuoc_Axis_Y()
        {
            ChartValues<int> chartValues = new ChartValues<int>();
            foreach (var item in DonthuocTimeLabels)
            {
                DateTime start_date = DateTime.ParseExact(item.Split('-')[0], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                DateTime end_date = DateTime.ParseExact(item.Split('-')[1], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                int count = findDonthuocNumbers(start_date, end_date);
                chartValues.Add(count);
            }
            Donthuoc_collections = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Số đơn thuốc",
                    Values = chartValues
                }
            };
        }
        void Load_Medicine_Axis_Y()
        {
            ChartValues<double> chartValues = new ChartValues<double>();
            foreach (var item in MedicineTimeLabels)
            {
                DateTime start_date = DateTime.ParseExact(item.Split('-')[0], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                DateTime end_date = DateTime.ParseExact(item.Split('-')[1], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                double count = findMedicineSoldNumbers(start_date, end_date);
                chartValues.Add(count);
            }
            Medicine_collections = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Số lượng thuốc bán ra",
                    Values = chartValues
                }
            };
        }
        public void LoadThuocBanChay(DateTime startdate, DateTime enddate)
        {
            DateTime configEnd = enddate.AddDays(1);
            var rawData = (from ctdt in _db.CHITIETDONTHUOC
                          join dt in _db.DONTHUOC on ctdt.MADONTHUOC equals dt.MADONTHUOC
                          join ba in _db.BENHAN on dt.MABENHAN equals ba.MABENHAN
                          join t in _db.THUOC on ctdt.MATHUOC equals t.MATHUOC
                          where ba.NGAYKHAM >= startdate && ba.NGAYKHAM <= configEnd
                          select new
                          {
                              Ten = t.TENTHUOC,
                              Soluong = ctdt.SOLUONG ?? 0,
                              Giatien = t.GIATIEN ?? 0
                          }).ToList();

            var thuocData = rawData
                .GroupBy(x => x.Ten)
                .Select(g => new
                {
                    Ten = g.Key,
                    Soluong = g.Sum(x => x.Soluong),
                    Doanhthu = g.Sum(x => (decimal)x.Soluong * x.Giatien)
                })
                .OrderByDescending(x => x.Soluong)
                .Take(10)
                .ToList();

            List<ThuocBanChay> listThuoc = new List<ThuocBanChay>();
            foreach (var item in thuocData)
            {
                listThuoc.Add(new ThuocBanChay()
                {
                    Ten = item.Ten,
                    Soluong = item.Soluong.ToString("F0"),
                    Doanhthu = item.Doanhthu.ToString("N0") + " VNĐ"
                });
            }
            ListThuocBanChay = listThuoc;
        }

        void Load_Service_Axis_Y()
        {
            ChartValues<int> chartValues = new ChartValues<int>();
            foreach (var item in ServiceTimeLabels)
            {
                DateTime start_date = DateTime.ParseExact(item.Split('-')[0], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                DateTime end_date = DateTime.ParseExact(item.Split('-')[1], "yyyy/MM/dd", CultureInfo.InvariantCulture);
                int count = calServiceNumbers(start_date, end_date);
                chartValues.Add(count);
            }
            Service_collections = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Doanh thu",
                    Values = chartValues
                }
            };
        }
        /*
        void Load_Victim_Chart()
        {
            divideTime(divide_number, Chart_startdate, Chart_enddate);
            Load_Victim_Axis_Y();
        }
        */

        void LoadChart()
        {
            divideTime(divide_number, Chart_startdate, Chart_enddate);
            Victim_count = findVictimNumbers(Chart_startdate, Chart_enddate);
            Benhan_count = findBenhanNumbers(Chart_startdate, Chart_enddate);
            Donthuoc_count = findDonthuocNumbers(Chart_startdate, Chart_enddate);
            Medicine_sold_count = (int)findMedicineSoldNumbers(Chart_startdate, Chart_enddate);
            Service_count = calServiceNumbers(Chart_startdate, Chart_enddate);
            Load_Victim_Axis_Y();
            Load_Benhan_Axis_Y();
            Load_Donthuoc_Axis_Y();
            Load_Medicine_Axis_Y();
            Load_Service_Axis_Y();
            LoadDoanhThuTheoService(Chart_startdate, Chart_enddate);
            LoadThuocBanChay(Chart_startdate, Chart_enddate);
        }
        public HomeViewModel()
        {
            LoadQuickStats();
            LoadChart();
            LoadDoanhThuTheoService(Chart_startdate, Chart_enddate);
            LoadThuocBanChay(Chart_startdate, Chart_enddate);
            YFormatter = value => value.ToString("F0");
            VNDFormatter = value => value.ToString("C");
        }
    }
}
