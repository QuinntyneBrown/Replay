using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Replay.Api.Core;
using Replay.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Replay.Api.Features
{
    public class UpdateToDo
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
                var toDo = await _context.ToDos.SingleAsync(x => x.ToDoId == request.ToDo.ToDoId);

                toDo.Update(request.ToDo.Name, request.ToDo.Description);

                await _context.SaveChangesAsync(cancellationToken);
                
                return new ()
                {
                    ToDo = toDo.ToDto()
                };
            }
            
        }
    }
}
