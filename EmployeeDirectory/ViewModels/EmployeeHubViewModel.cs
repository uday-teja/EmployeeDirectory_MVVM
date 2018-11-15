using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AutoMapper;
using EmployeeDirectory.Data;
using EmployeeDirectory.Models.Model;
using EmployeeDirectory.Views;
using DataModel = EmployeeDirectory.Data.Model;

namespace EmployeeDirectory.ViewModels
{
    public class EmployeeHubViewModel : BaseViewModel
    {
        public List<Employee> RawEmployees { get; set; }

        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get { return employees; }
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }

        public EmployeeService employeeService;
        public Command AddEmployeeViewCommand { get; set; }
        public Command EditEmployeeCommand { get; set; }
        public Command DeleteEmployeeCommand { get; set; }
        public Command FirstPageCommand { get; set; }
        public Command LastPageCommand { get; set; }
        public Command NextPageCommand { get; set; }
        public Command PrevPageCommand { get; set; }

        private Employee selectedEmployee;

        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private Visibility noEmployeesFound = Visibility.Collapsed;

        public Visibility NoEmployeesFound
        {
            get { return noEmployeesFound; }
            set
            {
                noEmployeesFound = value;
                OnPropertyChanged("NoEmployeesFound");
            }
        }

        private string pageInformation;

        public string PageInformation
        {
            get { return pageInformation; }
            set
            {
                pageInformation = value;
                OnPropertyChanged("PageInformation");
            }
        }

        private ItemsPerPage selectedRecord;

        public ItemsPerPage SelectedRecord
        {
            get { return selectedRecord; }
            set
            {
                selectedRecord = value;
                OnSelectionChanged();
                OnPropertyChanged("SelectedRecord");
            }
        }

        public List<Employee> pagerEmployees;
        public int pageCount;
        public int totalPages;
        public int empCountPerPage;

        private FilteringViewModel filterView;

        public FilteringViewModel FilterView
        {
            get { return filterView; }
            set { filterView = value; }
        }

        public EmployeeHubViewModel()
        {
            employeeService = new EmployeeService();
            LoadEmployees();
            InitializeCommands();
            SelectedRecord = ItemsPerPage.Three;
            Navigate(0, RawEmployees.ToList());
            FilterView = new FilteringViewModel();
            App.MainWindowInstance.WindowHeader = "Employee HUB";
        }

        public void OnSelectionChanged()
        {
            Employees = Mapper.Map<ObservableCollection<Employee>>(employeeService.GetEmployees());
            Navigate(0, RawEmployees.ToList());
        }

        public void InitializeCommands()
        {
            AddEmployeeViewCommand = new Command(AddEmployeee);
            EditEmployeeCommand = new Command(EditEmployee);
            DeleteEmployeeCommand = new Command(DeleteEmployee);
            FirstPageCommand = new Command(FirstPage);
            NextPageCommand = new Command(NextPage);
            PrevPageCommand = new Command(PrevPage);
            LastPageCommand = new Command(LastPage);
        }

        public void SearchEmployees()
        {
            Employees = Mapper.Map<ObservableCollection<Employee>>(RawEmployees.Where(emp => (string.IsNullOrEmpty(emp.FirstName) || emp.FirstName.Contains(FilterView.SearchByName)) && (string.IsNullOrEmpty(emp.MobileNumber) || emp.MobileNumber.Contains(FilterView.SearchByMobileNumber))).ToList());
            Navigate(0, Employees.ToList());
        }

        public void LoadEmployees()
        {
            RawEmployees = Mapper.Map<List<Employee>>(employeeService.GetEmployees());
        }

        private void AddEmployeee()
        {
            App.MainWindowInstance.CurrentView = new AddEmployeeViewModel(null);
        }

        public void EditEmployee(object parameter)
        {
            Employee employee = parameter as Employee;
            App.MainWindowInstance.CurrentView = new AddEmployeeViewModel(employee);
        }

        public void DeleteEmployee(object parameter)
        {
            Employee employee = parameter as Employee;
            employeeService.DeleteEmployee(employee.Id);
            MessageBox.Show(Constants.DeletedMesage);
            RawEmployees.Remove(employee);
            Navigate(0, RawEmployees);
        }

        private void FirstPage()
        {
            if (pageCount > 1)
                Navigate(0, pagerEmployees);
        }

        private void NextPage()
        {
            if (pageCount < (totalPages))
                Navigate(pageCount, pagerEmployees);
        }

        private void PrevPage()
        {
            if (pageCount > 1)
                Navigate(pageCount - 2, pagerEmployees);
        }

        private void LastPage()
        {
            if (pageCount < totalPages)
                Navigate(totalPages - 1, pagerEmployees);
        }

        private int GetNoOfRecordsPerPage()
        {
            return (int)SelectedRecord;
        }

        public void Navigate(int pageNo, List<Employee> employees)
        {
            pagerEmployees = employees;
            int noOfRecords = GetNoOfRecordsPerPage();
            totalPages = (int)Math.Ceiling((decimal)pagerEmployees.Count / noOfRecords);
            NoEmployeesFound = pagerEmployees.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
            if (employees.Count > totalPages)
            {
                pageCount = pageNo + 1;
                Employees = Mapper.Map<ObservableCollection<Employee>>(RawEmployees.Skip((pageNo) * noOfRecords).Take(noOfRecords));
                SetPageNumber(pageCount, pagerEmployees);
            }
        }

        public void SetPageNumber(int pageInformation, List<Employee> employees)
        {
            PageInformation = pageCount + " of " + totalPages;
        }
    }
}