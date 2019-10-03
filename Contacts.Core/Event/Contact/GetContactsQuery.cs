using System;
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
            private readonly CosmosRepository<Model.Contact, ContactContext> _repository;

            public GetContactsQueryHandler(CosmosRepository<Model.Contact, ContactContext> cosmosRepository)
            {
                this._repository = cosmosRepository ?? throw new ArgumentNullException(nameof(cosmosRepository));
            }

            public async Task<Result> Handle(Query request, CancellationToken cancellationToken)
            {
                var contacts = _repository.GetAsQueryable();
                var contactList = await PaginatedList<Model.Contact>.CreateAsync(
                    source: contacts, 
                    pageIndex:request.PageNumber ?? 1, 
                    pageSize:request.PageSize
                );

                return new Result
                {
                    Contacts = contactList
                };
            }
        }
    }
}
