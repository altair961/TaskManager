using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Model
{
    public class ProcessItem
    {
        // Fields
        public string Name;
        public  int Id;
        public  int Priority;

        // Constructors
        public ProcessItem(string name, int id, int priority)
        {
            Name = name;
            Id = id;
            Priority = priority;
        }

        public ProcessItem()
        {

        }
    }
}
