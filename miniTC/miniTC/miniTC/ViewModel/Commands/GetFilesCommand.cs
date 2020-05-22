using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace miniTC.ViewModel.Commands
{
    class GetFilesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            var viewModel = parameter as PanelViewModel;
            if(viewModel !=null)
            {
                DirectoryInfo d = new DirectoryInfo(viewModel.SelectedPath);
                
                if(d.Exists)
                    return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            var viewModel = parameter as PanelViewModel;
            if (viewModel != null )
            {
                if (viewModel.SelectedPath == "..")
                {
                    var splitedPath = viewModel.PreviousPath.Pop().Split('\\');
                    var tmpSelectedPath = String.Join("\\", splitedPath.Take(splitedPath.Length-1).ToArray());
                    if (splitedPath.Length == 2)
                        tmpSelectedPath += "\\";
                    viewModel.SelectedPath = tmpSelectedPath;
                }
                else
                {
                    if (!String.IsNullOrEmpty(viewModel.SelectedPath) && viewModel.SelectedPath != "..")
                        viewModel.PreviousPath.Push(viewModel.SelectedPath);
                }
                try
                {
                    string[] tmpDir = Directory.GetDirectories(viewModel.SelectedPath);
                    string[] tmpFiles = Directory.GetFiles(viewModel.SelectedPath);

                    List<String> FilesPath = new List<string>();
                    List<String> Files = new List<string>();
                    if (viewModel.SelectedPath.Split('\\')[1] != "")
                    {
                        FilesPath.Add("..");
                        Files.Add("..");
                    }
                    FilesPath.AddRange(tmpDir);
                    FilesPath.AddRange(tmpFiles);

                    Files.AddRange(tmpDir.Select(file => "<D>" + file.Split('\\').Last()).ToList());
                    Files.AddRange(tmpFiles.Select(file => file.Split('\\').Last()).ToArray());

                    viewModel.Files = Files;
                    viewModel.FilesPath = FilesPath;
                    viewModel.SelectedFile = null;
                }
                catch
                {
                }
            }
        }
    }
}
