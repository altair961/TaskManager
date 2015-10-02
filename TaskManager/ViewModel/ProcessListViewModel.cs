using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using TaskManager.DataAccess;
using TaskManager.Model;

namespace TaskManager.ViewModel
{
    public class ProcessListViewModel : ViewModelBase
    {
        // Fields        
        private ProcessEntityPool _processEntityPool;
        RelayCommand _killProcessCommand;
        private ProcessEntity _selectedProcessEntity;

        // Properties
        public ObservableCollection<ProcessEntity> AllProcesses
        {
            get;
            private set; // we don't want this to be set from outside
        }
        public ProcessEntityPool ProcessEntityPool 
        {
            set
            {
                _processEntityPool = value;
            }
            get
            {
                return _processEntityPool;
            }
        }
        public ICommand KillProcessCommand
        {
            get 
            {
                if (_killProcessCommand == null)
                {
                    _killProcessCommand = new RelayCommand(param => this.KillProcessCommandExecute(), param => this.KillProcessCommandCanExecute);
                }
                return _killProcessCommand;
            }
        }
        public ProcessEntity SelectedProcessEntity
        {
            get
            {
                return _selectedProcessEntity;
            }
            set
            {
                _selectedProcessEntity = value;
                OnPropertyChanged("SelectedProcessEntity");
            }
        }
        bool KillProcessCommandCanExecute
        {
            get
            {
                return true;
            }
        }
        
        // Methods
        protected override void OnDispose()
        {
            this.AllProcesses.Clear();
        }
        void processEntityPool_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                ProcessEntity _prevSelection = SelectedProcessEntity;

                AllProcesses.Clear();
                foreach (var i in ProcessEntityPool.ProcessEntityList)
                {
                    AllProcesses.Add(i);
                }

                if (_prevSelection != null)
                {
                    foreach (ProcessEntity pe in AllProcesses)
                    {
                        if (pe.Id == _prevSelection.Id)
                        {
                            SelectedProcessEntity = pe;
                            break;
                        }
                    }
                }
            });
        }
        void KillProcessCommandExecute()
        {
            foreach (var processToKill in Process.GetProcessesByName(SelectedProcessEntity.Name))
            {
                processToKill.Kill();
            }
        }
        
        // Contructor
        public ProcessListViewModel(ProcessEntityPool processEntityPool)
        {
            ProcessEntityPool = processEntityPool;
            AllProcesses = new ObservableCollection<ProcessEntity>();
            ProcessEntityPool.PropertyChanged += processEntityPool_PropertyChanged;
        }
    }
}
