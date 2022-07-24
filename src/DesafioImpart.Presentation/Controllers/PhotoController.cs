using DesafioImpar.Application.Requests.Photo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DesafioImpart.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ImparBaseController
    {
        public PhotoController(IMediator mediator)
            : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult> GetAll()
            => await SendCommand(new GetAllPhotosRequest());

        [HttpPost]
        public async Task<ActionResult> Post(IFormFile photo)
        {
            if (photo.Length == 0)
                return BadRequest();

            var fileAsString = IFormFileToString(photo);
            return await SendCommand(new UploadPhotoRequest(fileAsString));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => await SendCommand(new DeletePhotoRequest(id));

    }
}
