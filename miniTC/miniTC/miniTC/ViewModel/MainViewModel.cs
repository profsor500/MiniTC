using miniTC.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace miniTC.ViewModel
{
    class MainViewModel : BasicViewModel
    {
        public MainViewModel()
        {
            this.Left = new PanelViewModel();
            this.Right = new PanelViewModel();            
        }

        PanelViewModel left;         
        public PanelViewModel Left
        {
            get { return left; }
            set
            {
                if (left != value)
                {
                    left = value;
                    OnPropertyChange(nameof(Left));
                }
            }
        }

        PanelViewModel right;
        public PanelViewModel Right
        {
            get { return right; }
            set
            {
                if (right != value)
                {
                    right = value;
                    OnPropertyChange(nameof(Right));
                }
            }
        }

        string error;
        public string Error
        {
            get { return error; }
            set
            {
                if (error != value)
                {
                    error = value;
                    OnPropertyChange(nameof(Error));
                }
            }
        }

        ICommand copyCommand;
        public ICommand Copy
        {
            get
            {
                if (copyCommand == null) copyCommand = new CopyFileCommand();
                return copyCommand;
            }
        }

    }
}
