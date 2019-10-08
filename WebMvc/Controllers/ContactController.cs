using System;
using System.Threading.Tasks;
using Contacts.Core.Event.Contact;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<IActionResult> Index(int page = 0)
        {
            var query = new GetContactsQuery.Query { PageNumber = page };
            GetContactsQuery.Result result = await _mediator.Send(query);

            return View(result);
        }
    }
}