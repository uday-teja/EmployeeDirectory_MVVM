using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace EmployeeDirectory.Convertors
{
    public class SalaryColorConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double salary = System.Convert.ToDouble(value);

            if (salary > 10000.00)
            {
                return Brushes.Brown;
            }
            else if (salary > 20000.00)
            {
                return Brushes.YellowGreen;
            }
            else if (salary > 30000.00)
            {
                return Brushes.Tomato;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}