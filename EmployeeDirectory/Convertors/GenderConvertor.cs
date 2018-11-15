using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using EmployeeDirectory.Models.Model;

namespace EmployeeDirectory.Convertors
{
    public class GenderConvertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value == int.Parse(parameter.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return parameter;
        }
    }
}