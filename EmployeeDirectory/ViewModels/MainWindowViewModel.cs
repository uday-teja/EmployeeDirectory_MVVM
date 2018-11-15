using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeDirectory.Data;
using DataModel = EmployeeDirectory.Data.Model;
using EmployeeDirectory.Models.Model;
using EmployeeDirectory.Views;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using GalaSoft.MvvmLight.Ioc;

namespace EmployeeDirectory.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private BaseViewModel currentView;

        public BaseViewModel CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        private string windowHeader;

        public string WindowHeader
        {
            get { return windowHeader; }
            set
            {
                windowHeader = value;
                OnPropertyChanged("WindowHeader");
            }
        }

        public MainWindowViewModel()
        {
            App.MainWindowInstance = this;
            this.CurrentView = new EmployeeHubViewModel();
            WindowHeader = Constants.EmployeeHubHeader;
        }
    }
}