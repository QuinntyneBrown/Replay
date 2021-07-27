using Replay.Api.Models;
using System;

namespace Replay.Api.Features
{
    public class ToDoDto
    {
        public Guid? ToDoId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ToDoStatus Status { get; set; } = ToDoStatus.Defualt;
    }
}
