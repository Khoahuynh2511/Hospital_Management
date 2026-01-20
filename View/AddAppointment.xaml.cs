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

namespace LTTQ_DoAn.View
{
    /// <summary>
    /// Interaction logic for AddAppointment.xaml
    /// </summary>
    public partial class AddAppointment : Window
    {
        public AddAppointment()
        {
            InitializeComponent();
        }

        private void bt_minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void NgayKhamDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                datePicker.DisplayDateStart = DateTime.Today;
            }
        }

        private void NgayLenLichDatePicker_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                datePicker.DisplayDateStart = DateTime.Today;
            }
        }

        private void NgayKhamDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is DatePicker datePicker && datePicker.SelectedDate.HasValue)
            {
                var viewModel = DataContext as ViewModel.AddAppointmentViewModel;
                if (viewModel != null && !string.IsNullOrEmpty(viewModel.Cakham))
                {
                    try
                    {
                        int ca = int.Parse(viewModel.Cakham);
                        int hour = 6 + ca;
                        DateTime selectedDate = datePicker.SelectedDate.Value;
                        DateTime newDateTime = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, hour, 0, 0);
                        viewModel.Ngaykham = newDateTime.ToString("M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                    }
                    catch
                    {
                        // Ignore errors
                    }
                }
            }
        }

        private void CaKhamComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var viewModel = DataContext as ViewModel.AddAppointmentViewModel;
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
                            viewModel.Ngaykham = newDateTime.ToString("M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
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
