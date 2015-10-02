using System.Collections.ObjectModel;
using TaskManager.DataAccess;

namespace TaskManager.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        // Fields
        ObservableCollection<ViewModelBase> _viewModels;
        private ProcessEntityPool _processEntityPool;

        // Properties
        public ObservableCollection<ViewModelBase> ViewModels
        {
            get
            {
                if (_viewModels == null)
                {
                    _viewModels = new ObservableCollection<ViewModelBase>();
                }
                return _viewModels;
            }
        }
        
        // Constructor
        public MainWindowViewModel()
        {
            _processEntityPool = new ProcessEntityPool();
            // cr inst of ViewModel add it to our collection
            ButtonCloseViewModel buttonCloseViewModel = new ButtonCloseViewModel();
            SearchBoxViewModel searchBoxViewModel = new SearchBoxViewModel(_processEntityPool);
            ProcessListViewModel processListViewModel = new ProcessListViewModel(_processEntityPool);
            ProgressBarRamViewModel progressBarRamViewModel = new ProgressBarRamViewModel();
            ProgressBarCpuViewModel progressBarCpuViewModel = new ProgressBarCpuViewModel();
            SliderViewModel sliderViewModel = new SliderViewModel();
            ButtonSnapShotViewModel buttonSnapShotViewModel = new ButtonSnapShotViewModel(_processEntityPool);

            this.ViewModels.Add(buttonCloseViewModel);
            this.ViewModels.Add(searchBoxViewModel);
            this.ViewModels.Add(processListViewModel);
            this.ViewModels.Add(progressBarRamViewModel);
            this.ViewModels.Add(progressBarCpuViewModel);
            this.ViewModels.Add(sliderViewModel);
            this.ViewModels.Add(buttonSnapShotViewModel);
        }
    }
}
