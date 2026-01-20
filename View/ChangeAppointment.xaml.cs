using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LTTQ_DoAn.ViewModel;

namespace LTTQ_DoAn.View
{
    /// <summary>
    /// Interaction logic for ChangeAppointment.xaml
    /// </summary>
    public partial class ChangeAppointment : Window
    {
        public ChangeAppointment()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void CaKhamComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as ChangeAppointmentViewModel;
            if (viewModel != null && NgayKhamDatePicker.SelectedDate.HasValue)
            {
                try
                {
                    if (sender is ComboBox comboBox && comboBox.SelectedItem is ComboBoxItem selectedItem && selectedItem.Tag != null)
                    {
                        string caValue = selectedItem.Tag.ToString();
                        if (!string.IsNullOrEmpty(caValue))
                        {
                            int ca = int.Parse(caValue);
                            int hour = 6 + ca;
                            DateTime selectedDate = NgayKhamDatePicker.SelectedDate.Value;
                            DateTime newDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, hour, 0, 0);
                            
                            if (viewModel.Lichkham != null)
                            {
                                viewModel.Lichkham.NGAYKHAM = newDateTime;
                            }
                        }
                    }
                }
                catch
                {
                    // Ignore errors
                }
            }
        }

        private void NgayKhamDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as ChangeAppointmentViewModel;
            if (viewModel != null && sender is DatePicker datePicker && datePicker.SelectedDate.HasValue)
            {
                try
                {
                    if (!string.IsNullOrEmpty(viewModel.Cakham))
                    {
                        int ca = int.Parse(viewModel.Cakham);
                        int hour = 6 + ca;
                        DateTime selectedDate = datePicker.SelectedDate.Value;
                        DateTime newDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, hour, 0, 0);
                        
                        if (viewModel.Lichkham != null)
                        {
                            viewModel.Lichkham.NGAYKHAM = newDateTime;
                        }
                    }
                }
                catch
                {
                    // Ignore errors
                }
            }
        }
    }
}
