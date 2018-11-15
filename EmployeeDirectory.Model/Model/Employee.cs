using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Models.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoiningData { get; set; }
        public decimal Salary { get; set; }
        public Gender Gender { get; set; }
        public int DesignationId { get; set; }
        public string MobileNumber { get; set; }
        public string DesignationName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        private string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set
            {
                imagePath = value;
                OnPropertyChanged("ImagePath");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string value)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(value));
        }
    }
}