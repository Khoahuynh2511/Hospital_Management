using System;
using System.Globalization;
using System.Windows.Data;

namespace LTTQ_DoAn.Resource
{
    public class VndCurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return string.Empty;
            }

            try
            {
                decimal number;
                
                if (value is decimal)
                {
                    number = Math.Truncate((decimal)value);
                }
                else if (value is decimal?)
                {
                    decimal? nullableDecimal = (decimal?)value;
                    if (nullableDecimal.HasValue)
                    {
                        number = Math.Truncate(nullableDecimal.Value);
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else
                {
                    string valueStr = value.ToString();
                    if (string.IsNullOrWhiteSpace(valueStr))
                    {
                        return string.Empty;
                    }

                    valueStr = valueStr.Replace(".", "").Replace(",", "").Trim();
                    if (string.IsNullOrEmpty(valueStr))
                    {
                        return string.Empty;
                    }

                    if (!decimal.TryParse(valueStr, NumberStyles.Any, CultureInfo.InvariantCulture, out number))
                    {
                        return valueStr;
                    }
                    number = Math.Truncate(number);
                }

                return FormatVnd(number);
            }
            catch
            {
                return value != null ? value.ToString() : string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                if (targetType == typeof(decimal?))
                {
                    return null;
                }
                if (targetType == typeof(string))
                {
                    return string.Empty;
                }
                return 0m;
            }

            string valueStr = value.ToString();
            if (string.IsNullOrWhiteSpace(valueStr))
            {
                if (targetType == typeof(decimal?))
                {
                    return null;
                }
                if (targetType == typeof(string))
                {
                    return string.Empty;
                }
                return 0m;
            }

            try
            {
                valueStr = valueStr.Replace(".", "").Replace(",", "").Trim();
                if (string.IsNullOrEmpty(valueStr))
                {
                    if (targetType == typeof(decimal?))
                    {
                        return null;
                    }
                    if (targetType == typeof(string))
                    {
                        return string.Empty;
                    }
                    return 0m;
                }

                if (decimal.TryParse(valueStr, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal number))
                {
                    number = Math.Truncate(number);
                    if (targetType == typeof(decimal?))
                    {
                        return number;
                    }
                    if (targetType == typeof(decimal))
                    {
                        return number;
                    }
                    if (targetType == typeof(string))
                    {
                        return number.ToString("F0");
                    }
                    return number;
                }
                
                if (targetType == typeof(decimal?))
                {
                    return null;
                }
                if (targetType == typeof(string))
                {
                    return valueStr;
                }
                return 0m;
            }
            catch
            {
                if (targetType == typeof(decimal?))
                {
                    return null;
                }
                if (targetType == typeof(string))
                {
                    return string.Empty;
                }
                return 0m;
            }
        }

        private string FormatVnd(decimal amount)
        {
            string amountStr = amount.ToString("F0");
            string result = "";
            int count = 0;
            for (int i = amountStr.Length - 1; i >= 0; i--)
            {
                if (count > 0 && count % 3 == 0)
                {
                    result = "." + result;
                }
                result = amountStr[i] + result;
                count++;
            }
            return result;
        }
    }
}
