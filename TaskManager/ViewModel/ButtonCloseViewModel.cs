using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TaskManager.ViewModel
{
    class ButtonCloseViewModel : ViewModelBase
    {
        // Fields
        RelayCommand _buttonCloseCommand;

        // Properties
        public ICommand ButtonCloseCommand
        {
            get
            {
                if (_buttonCloseCommand == null)
                {
                    _buttonCloseCommand = new RelayCommand(param => this.ButtonCloseCommandExecute(), param => this.ButtonCloseCommandCanExecute);
                }
                return _buttonCloseCommand;
            }
        }
        bool ButtonCloseCommandCanExecute
        {
            get
            {
                return true;
            }
        }

        // Methods
        void ButtonCloseCommandExecute()
        {
            Application.Current.Shutdown();
        }

        // Constructors
        public ButtonCloseViewModel()
        {
        }
    }
}
