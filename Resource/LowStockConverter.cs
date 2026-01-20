using System;
using System.Globalization;
using System.Windows.Data;

namespace LTTQ_DoAn.Resource
{
    public class LowStockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return false;
            
            double quantity;
            if (double.TryParse(value.ToString(), out quantity))
            {
                return quantity < 10;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
