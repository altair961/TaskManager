using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.DataAccess;

namespace TaskManager.ViewModel
{
    public class SearchBoxViewModel : ViewModelBase
    {
        // Fields
        private ProcessEntityPool _processEntityPool;
        private string _myText;

        // Properties
        public string MyText
        {
            get { return _myText; }
            set
            {
                _myText = value;
                OnPropertyChanged("MyText");
            }
        }

        // Methods
        void SearchBoxViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine(_myText);
            _processEntityPool.SearchedWord = MyText;
        }

        // Constructors
        public SearchBoxViewModel(ProcessEntityPool processEntityPool)
        {
            _processEntityPool = processEntityPool;
            this.PropertyChanged += SearchBoxViewModel_PropertyChanged;
        }
    }
}