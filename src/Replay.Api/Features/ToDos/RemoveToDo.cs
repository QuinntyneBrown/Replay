using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using Replay.Api.Models;
using Replay.Api.Core;
using Replay.Api.Interfaces;

namespace Replay.Api.Features
{
    public class RemoveToDo
    {
        public class Request: IRequest<Response>
        {
            public Guid ToDoId { get; set; }
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
                var toDo = await _context.ToDos.SingleAsync(x => x.ToDoId == request.ToDoId);
                
                _context.ToDos.Remove(toDo);
                
                await _context.SaveChangesAsync(cancellationToken);
                
                return new Response()
                {
                    ToDo = toDo.ToDto()
                };
            }
            
        }
    }
}
