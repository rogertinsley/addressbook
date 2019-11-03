using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Contacts.Core.Data;
using Contacts.Core.Utilities;
using MediatR;

namespace Contacts.Core.Event.Contact
{
    public class GetContactsQuery
    {
        public class Query : IRequest<Result>
        {
            public int? PageNumber { get; set; } = 1;
            public int PageSize { get; set; }   = 20;
        }

        public class Result 
        {
            public PaginatedList<Model.Contact> Contacts { get; set; }
            public int PageNumber { get; set; }
        }

        public class GetContactsQueryHandler : IRequestHandler<Query, Result>
        {
            private readonly IRepository<Model.Contact, ContactContext> _repository;

            public GetContactsQueryHandler(IRepository<Model.Contact, ContactContext> repository)
            {
                this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                return new Result
                {
                    Contacts = null
                };
            }
        }
    }
}
