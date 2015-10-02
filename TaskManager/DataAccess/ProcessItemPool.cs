using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Model;

namespace TaskManager.DataAccess
{
    [Serializable()]
    public class ProcessItemPool
    {
        // Fields
        private List<ProcessItem> settings;

        // Properties
        public List<ProcessItem> Settings
        {
            get { return settings; }
            set { settings = value; }
        }

        // Constructors
        public ProcessItemPool()
        {
            settings = new List<ProcessItem>();
        }
    }
}
