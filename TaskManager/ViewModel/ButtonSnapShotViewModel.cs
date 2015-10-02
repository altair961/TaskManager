using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
using TaskManager.DataAccess;
using TaskManager.Model;

namespace TaskManager.ViewModel
{
    public class ButtonSnapShotViewModel : ViewModelBase
    {
        // Fields
        RelayCommand _snapShotCommand;
        ProcessEntityPool _processEntityPool;

        // Properties
        public ICommand SnapShotCommand
        {
            get
            {
                if (_snapShotCommand == null)
                {
                    _snapShotCommand = new RelayCommand(param => this.SnapShotCommandExecute(), param => this.SnapShotCommandCanExecute);
                }
                return _snapShotCommand;
            }
        }
        bool SnapShotCommandCanExecute
        {
            get
            {
                return true;
            }
        }

        // Methods
        void SnapShotCommandExecute()
        {
            Console.WriteLine("vjhbfvhbe");


            // Create a new instance of the class that contains a list
            ProcessItemPool processItemPool = new ProcessItemPool();

            foreach (Process p in Process.GetProcesses())
            {
                processItemPool.Settings.Add(new ProcessItem(p.ProcessName, p.Id, p.Threads.Count));
            }

            // Create a new XmlSerializer instance with the type of the class that contains the list
            XmlSerializer SerializerObj = new XmlSerializer(typeof(ProcessItemPool));

            // Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter("test.xml");
            SerializerObj.Serialize(WriteFileStream, processItemPool);

            // Cleanup
            WriteFileStream.Close();

        }

        // Constructors
        public ButtonSnapShotViewModel(ProcessEntityPool processEntityPool)
        {
            _processEntityPool = processEntityPool;
        }
    }
}
