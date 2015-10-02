using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;

namespace TaskManager.ViewModel
{
    public class ProgressBarCpuViewModel : ViewModelBase
    {
        // Fields
        private Timer _timer;
        private float _currentCpuUsage;
        private PerformanceCounter _cpuCounter;
        
        // Properties
        public float CurrentCpuUsage
        {
            get
            {
                return _currentCpuUsage;
            }
            private set
            {
                _currentCpuUsage = value;
                OnPropertyChanged("CurrentCpuUsage");
            }
        }
        
        // Methods
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CurrentCpuUsage = _cpuCounter.NextValue();
        }

        // Constructors
        public ProgressBarCpuViewModel()
        {
            _timer = new Timer();
            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = (1000) * (1);
            _timer.Enabled = true;
            _timer.Start();

            _cpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
        }
    }
}
