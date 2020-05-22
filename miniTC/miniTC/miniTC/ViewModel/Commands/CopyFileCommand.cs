using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace miniTC.ViewModel.Commands
{
    class CopyFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel != null)
            {
                DirectoryInfo dLeft = new DirectoryInfo(viewModel.Left.SelectedPath);
                DirectoryInfo dRight = new DirectoryInfo(viewModel.Right.SelectedPath);
                //if left selected path is not a directory
                if ((!dLeft.Exists) && dRight.Exists)
                    return true;
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as MainViewModel;
            if (viewModel != null)
            {
                try
                {
                    var tmpPath = viewModel.Right.SelectedPath + $"\\{viewModel.Left.SelectedPath.Split('\\').Last()}";
                    File.Copy(viewModel.Left.SelectedPath, tmpPath);
                    viewModel.Right.GetFiles.Execute(viewModel.Right);
                    viewModel.Error = "";
                }
                catch(Exception e)
                {
                    viewModel.Error = e.Message;
                }
            }
        }
    }
}
