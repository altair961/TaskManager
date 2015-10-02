using System;
using System.ComponentModel;

namespace TaskManager.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        // Fields
        public event PropertyChangedEventHandler PropertyChanged;
        
        // Methods
        protected virtual void OnPropertyChanged(string propertyName) 
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null) 
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        public void Dispose()
        {
            this.OnDispose();
        }
        protected virtual void OnDispose()
        {
        }
        
        // Constructors
        protected ViewModelBase()
        {
        }
    }
}
