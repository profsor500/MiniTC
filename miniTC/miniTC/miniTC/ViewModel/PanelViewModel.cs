using miniTC.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace miniTC.ViewModel
{
    class PanelViewModel : BasicViewModel
    {
        public PanelViewModel()
        {
            this.UpdateDrives.Execute(this);
            if (drives.Length != 0)
            {
                SelectedPath = drives[0];
                GetFiles.Execute(this);
            }
        }

        string[] drives;
        public string[] Drives
        {
            get { return drives; }
            set
            {
                if (drives != value)
                {
                    drives = value;
                    OnPropertyChange(nameof(Drives));
                }
            }
        }

        string selectedPath;
        public string SelectedPath
        {
            get { return selectedPath; }
            set
            {
                if (selectedPath != value)
                {
                    selectedPath = value;
                    OnPropertyChange(nameof(SelectedPath));
                    if(GetFiles.CanExecute(this))
                        GetFiles.Execute(this);
                }
            }
        }

        Stack<string> previousPath = new Stack<string>();
        public Stack<string> PreviousPath
        {
            get { return previousPath; }
            set
            {
                if (previousPath != value)
                {
                    previousPath = value;
                }
            }
        }

        List<string> files;
        public List<string> Files
        {
            get { return files; }
            set
            {
                if (files != value)
                {
                    files = value;
                    OnPropertyChange(nameof(Files));
                }
            }
        }

        List<string> filesPath;
        public List<string> FilesPath
        {
            get { return filesPath; }
            set
            {
                if (filesPath != value)
                {
                    filesPath = value;
                }
            }
        }

        string selectedFile;
        public string SelectedFile
        {
            get { return selectedFile; }
            set
            {
                if (selectedFile != value)
                {
                    selectedFile = value;
                    OnPropertyChange(nameof(SelectedFile));
                    if(!String.IsNullOrEmpty(selectedFile))
                        SelectedPath = FilesPath[Files.IndexOf(selectedFile)];
                }
            }
        }

        ICommand updateDrivesCommand;
        public ICommand UpdateDrives
        {
            get
            {
                if (updateDrivesCommand == null) updateDrivesCommand = new UpdateDrivesCommand();
                return updateDrivesCommand;
            }
        }

        ICommand getFilesCommand;
        public ICommand GetFiles
        {
            get
            {
                if (getFilesCommand == null) getFilesCommand = new GetFilesCommand();
                return getFilesCommand;
            }
        }
    }
}
