using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory
{
    public static class Constants
    {
        public const string Email = @"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
        public const string DefaultImage = "pack://application:,,,/EmployeeDirectory.Data;component/Images/default_picture.png";
        public const string AddEmployeeHeader = "Add Employee";
        public const string UpdateButton = "Update";
        public const string AddButton = "Add";
        public const string EditEmployeeHeader = "Edit Employee";
        public const string EmployeeHubHeader = "Employee HUB";
        public const string SelectPicture = "Select a picture";
        public const string ImageTypesToFilter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (*.png)|*.png";
        public const string DeletedMesage = "Employee Deleted Successfully..!!";
        public const string ValidName = "Name cannot be empty!";
        public const string ValidMobileNumber = "Please enter valid mobile number!";
        public const string ValidEmail = "Please enter valid email address!";
        public const string ChooseImage = "Choose Image";
        public const string ChangeImage = "Change Image";
        public const string MobileValidator = "[^0-9]+";
        public const string DisplayDetailsHeader = "Employee Details";
        public const string DeleteConfirmation = "Are you sure to delete the contact?";
        public const string DeleteContact = "Delete Contact";
    }
}
