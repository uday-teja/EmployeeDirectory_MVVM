using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using EmployeeDirectory.Views;

namespace EmployeeDirectory.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
        }
    }
}