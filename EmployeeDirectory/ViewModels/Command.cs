using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeeDirectory.ViewModels
{
    public class Command : ICommand
    {
        private Action loadCommand;
        private Action<object> loadEmployee;

        public Command(Action executeMethod)
        {
            this.loadCommand = executeMethod;
        }

        public Command(Action<object> loadEmployee)
        {
            this.loadEmployee = loadEmployee;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
                loadEmployee(parameter);
            else
                loadCommand();
        }
    }
}