using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioImpart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ImparBaseController
    {
        public CardController(IMediator mediator)
            : base(mediator) { }
        
    }
}
