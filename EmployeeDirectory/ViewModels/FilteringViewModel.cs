using AutoMapper;
using EmployeeDirectory.Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.ViewModels
{
    public class FilteringViewModel : BaseViewModel
    {
        private string searchByName = "";

        public string SearchByName
        {
            get { return searchByName; }
            set
            {
                searchByName = value;
                OnPropertyChanged("SearchByName");
            }
        }

        private string searchByMobileNumber = "";

        public string SearchByMobileNumber
        {
            get { return searchByMobileNumber; }
            set
            {
                searchByMobileNumber = value;
                OnPropertyChanged("SearchByMobileNumber");
            }
        }

        public Command SearchCommand { get; set; }

        public FilteringViewModel()
        {
            SearchCommand = new Command(SearchEmployees);
        }

        private void SearchEmployees()
        {
            ((EmployeeHubViewModel)App.MainWindowInstance.CurrentView).SearchEmployees();
        }
    }
}