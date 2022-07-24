using DesafioImpar.Application.Requests.Card;
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

        [HttpGet]
        public async Task<ActionResult> GetAllCards() 
            => await SendCommand(new GetAllCardsWithPhotoRequest());

        [HttpPost]
        public async Task<ActionResult> PostCardWithImage([FromForm] PostCardRequest request, IFormFile file)
        {
            if (file.Length == 0)
                return BadRequest();

            var fileAsString = IFormFileToString(file);
            return await SendCommand(new PostCardWithImageRequest(request.Name, request.Status, fileAsString));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => await SendCommand(new DeleteCardRequest(id));
        
    }
}
