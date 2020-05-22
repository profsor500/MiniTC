using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace miniTC.ViewModel.Commands
{
    class UpdateDrivesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as PanelViewModel;
            if (viewModel != null)
            {
                viewModel.Drives = Directory.GetLogicalDrives();
            }
        }
    }
}
