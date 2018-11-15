using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeeDirectory.Data;
using EmployeeDirectory.Models.Model;
using EmployeeDirectory.Views;
using AutoMapper;
using DataModel = EmployeeDirectory.Data.Model;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EmployeeDirectory.ViewModels
{
    public class AddEmployeeViewModel : BaseViewModel
    {
        private Employee employee;

        public Employee Employee
        {
            get { return employee; }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        private DataModel.Designation selectedDesignation;

        public DataModel.Designation SelectedDesignation
        {
            get { return selectedDesignation; }
            set
            {
                selectedDesignation = value;
                OnPropertyChanged("SelectedDesignation");
            }
        }

        private bool isButtonVisible;

        public bool IsButtonVisible
        {
            get { return isButtonVisible; }
            set
            {
                isButtonVisible = value;
                OnPropertyChanged("ButtonState");
            }
        }

        public List<DataModel.Designation> EmployeeDesignations { get; set; }
        public string ButtonContent { get; set; }
        public EmployeeService employeeService;
        public Command AddEmployeeeCommand { get; set; }
        public Command ChangeImageCommand { get; set; }
        public Command DispalyEmployeesCommand { get; set; }

        public AddEmployeeViewModel(Employee employee)
        {
            employeeService = new EmployeeService();
            SetDesignations();
            InitializeCommands();
            if (employee != null)
            {
                ButtonContent = Constants.UpdateButton;
                this.Employee = employee;
                this.SelectedDesignation = this.EmployeeDesignations.FirstOrDefault(s => s.DesignationId == employee.DesignationId);
                App.MainWindowInstance.WindowHeader = Constants.EditEmployeeHeader;
            }
            else
            {
                ButtonContent = Constants.AddButton;
                App.MainWindowInstance.WindowHeader = Constants.AddEmployeeHeader;
                Employee = new Employee();
                this.SelectedDesignation = this.EmployeeDesignations.FirstOrDefault(s => s.DesignationId == 0);
                Employee.JoiningData = System.DateTime.Now;
            }
            SetEmployeeImage();
        }

        private void SetEmployeeImage()
        {
            if (string.IsNullOrEmpty(Employee.ImagePath))
                Employee.ImagePath = Constants.DefaultImage;
        }

        private void SetDesignations()
        {
            employeeService = new EmployeeService();
            EmployeeDesignations = employeeService.GetDesignations();
        }

        private void InitializeCommands()
        {
            AddEmployeeeCommand = new Command(AddEmployee);
            DispalyEmployeesCommand = new Command(DisplayEmployees);
            ChangeImageCommand = new Command(ChangeImage);
        }

        public void AddEmployee()
        {
            if (SelectedDesignation != null)
                Employee.DesignationId = SelectedDesignation.DesignationId;
            employeeService.AddOrUpdateEmployee(Mapper.Map<DataModel.Employee>(Employee));
            DisplayEmployees();
        }

        private void DisplayEmployees()
        {
            App.MainWindowInstance.CurrentView = new EmployeeHubViewModel();
        }

        private void ChangeImage()
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Title = Constants.SelectPicture,
                Filter = Constants.ImageTypesToFilter
            };

            if ((bool)open.ShowDialog())
            {
                Employee.ImagePath = open.FileName;
                OnPropertyChanged("Employee");
            }
        }
    }
}