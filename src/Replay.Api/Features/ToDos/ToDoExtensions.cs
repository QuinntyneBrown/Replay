using Replay.Api.Models;

namespace Replay.Api.Features
{
    public static class ToDoExtensions
    {
        public static ToDoDto ToDto(this ToDo toDo)
        {
            return new ()
            {
                ToDoId = toDo.ToDoId,
                Type = toDo.Type,
                Name = toDo.Name,
                Description = toDo.Description,
                Status = toDo.Status
            };
        }        
    }
}
