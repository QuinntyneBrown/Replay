using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Replay.Api.Extensions;
using Replay.Api.Core;
using Replay.Api.Interfaces;
using Replay.Api.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Replay.Api.Features
{
    public class GetToDosPage
    {
        public class Request: IRequest<Response>
        {
            public int PageSize { get; set; }
            public int Index { get; set; }
        }

        public class Response: ResponseBase
        {
            public int Length { get; set; }
            public List<ToDoDto> Entities { get; set; }
        }

        public class Handler: IRequestHandler<Request, Response>
        {
            private readonly IReplayDbContext _context;
        
            public Handler(IReplayDbContext context)
                => _context = context;
        
            public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
            {
                var query = from toDo in _context.ToDos
                    select toDo;
                
                var length = await _context.ToDos.CountAsync();
                
                var toDos = await query.Page(request.Index, request.PageSize)
                    .Select(x => x.ToDto()).ToListAsync();
                
                return new()
                {
                    Length = length,
                    Entities = toDos
                };
            }
            
        }
    }
}
