using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Replay.Api.Models;
using Replay.Api.Core;
using Replay.Api.Interfaces;

namespace Replay.Api.Features
{
    public class CreateToDo
    {
        public class Validator: AbstractValidator<Request>
        {
            public Validator()
            {
                RuleFor(request => request.ToDo).NotNull();
                RuleFor(request => request.ToDo).SetValidator(new ToDoValidator());
            }
        
        }

        public class Request: IRequest<Response>
        {
            public ToDoDto ToDo { get; set; }
        }

        public class Response: ResponseBase
        {
            public ToDoDto ToDo { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IReplayDbContext _context;
        
            public Handler(IReplayDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var toDo = new ToDo(
                    request.ToDo.Type,
                    request.ToDo.Name,
                    request.ToDo.Description
                    );
                
                _context.ToDos.Add(toDo);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    ToDo = toDo.ToDto()
                };
            }
            
        }
    }
}
