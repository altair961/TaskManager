using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TaskManager.ViewModel
{
    class ProgressBarRamViewModel : ViewModelBase
    {
        // Fields
        private float _availableRam;
        private Timer _timer;
        public float AvailableRam
        {
            get 
            { 
                return _availableRam;
            }
            private set 
            {
                _availableRam = value;
                OnPropertyChanged("AvailableRam");
            }
        }

        // Properties
        PerformanceCounter _ramCounter;

        // Methods
        void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            AvailableRam = _ramCounter.NextValue();
        }    

        // Constructors
        public ProgressBarRamViewModel()
        {
            _timer = new Timer();
            _timer.Elapsed+=_timer_Elapsed;
            _timer.Interval = (1000) * (1);
            _timer.Enabled = true;
            _timer.Start();

            _ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
    }
}
