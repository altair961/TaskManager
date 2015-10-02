using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Serialization;
using TaskManager.Model;

namespace TaskManager.DataAccess
{
    public class ProcessEntityPool : INotifyPropertyChanged
    {
        // Fields
        private Timer _timer;
        private List<ProcessEntity> _processEntityList;
        public event PropertyChangedEventHandler PropertyChanged;

        // Properties
        public string SearchedWord { get; set; }
        public List<ProcessEntity> ProcessEntityList
        {
            set
            {
                _processEntityList = value;
            }
            get
            {
                return _processEntityList;
            }
        }

        // Methods
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ProcessEntityList = new List<ProcessEntity>();
            
            foreach (Process p in Process.GetProcesses().Where(pro => pro.ProcessName.Contains("" + SearchedWord)))
            {
                ProcessEntityList.Add(new ProcessEntity(p.ProcessName, p.Id, p.Threads.Count));
            }
            OnPropertyChanged("_processItemList");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // Constructors
        public ProcessEntityPool()
        {
            _timer = new Timer();
            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = (3500) * (1);
            _timer.Enabled = true;
            _timer.Start();
        }
    }
}
