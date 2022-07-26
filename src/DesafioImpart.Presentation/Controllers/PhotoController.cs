using DesafioImpar.Application.Requests.Photo;
using DesafioImpar.Application.ViewModels.Photo;
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
        [ProducesResponseType(typeof(IEnumerable<PhotoViewModel>),200)]
        public async Task<ActionResult> GetAll()
            => await SendCommand(new GetAllPhotosRequest());

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(byte[]), 200)]
        public async Task<ActionResult> GetPhotoAsFileById(int id)
            => await SendFileCommand(new GetPhotoAsFileByIdRequest(id));

        [HttpPost]
        public async Task<ActionResult> Post(IFormFile photo)
        {
            if (photo is null || photo.Length == 0)
                return BadRequest();

            var fileAsString = IFormFileToString(photo);
            return await SendCommand(new UploadPhotoRequest(fileAsString));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
            => await SendCommand(new DeletePhotoRequest(id));

    }
}
