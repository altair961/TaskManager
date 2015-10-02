
using System;
namespace TaskManager.Model
{
    public class ProcessEntity
    {
        // Fields
        private string _name;
        private int _id;
        private int _priority;

        // Properties
        public string Name
        {
            set
            {
                _name = value;
            }
            get
            {
                return _name;
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }
        public int Priority
        {
            get
            {
                return _priority;
            }
            private set
            {
                _priority = value;
            }
        }

        // Constructors
        public ProcessEntity(string name, int id, int priority)
        {
            Name = name;
            Id = id;
            Priority = priority;
        }

        public ProcessEntity()
        {

        }
    }
}
