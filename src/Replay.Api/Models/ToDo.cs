using System;

namespace Replay.Api.Models
{
    public class ToDo
    {
        public Guid ToDoId { get; private set; }
        public string Type { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public ToDoStatus Status { get; set; } = ToDoStatus.Defualt;

        public ToDo(string type, string name, string description)
        {
            Type = type;
            Name = name;
            Description = description;
        }

        private ToDo()
        {

        }

        public ToDo Defer()
        {
            Status = ToDoStatus.Deferred;
            return this;
        }

        public ToDo Complete()
        {
            Status = ToDoStatus.Completed;
            return this;
        }

        public ToDo Update(string name, string description)
        {
            Name = name;
            Description = description;
            return this;
        }
    }
}
