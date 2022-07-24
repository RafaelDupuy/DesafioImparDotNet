using AutoMapper;
using DesafioImpar.Application.Requests.Photo;
using DesafioImpar.Application.Shared;
using DesafioImpar.Application.ViewModels.Photo;
using DesafioImpar.Infra.Repositories;
using MediatR;

namespace DesafioImpar.Application.RequestHandlers.Photos
{
    internal class ReadPhotoRequestHandler : BaseRequestHandler, IRequestHandler<GetAllPhotosRequest, OperationResult>
    {
        private readonly PhotoRepository _photoRepo;

        public ReadPhotoRequestHandler(PhotoRepository photoRepo, IMapper mapper) : base(mapper)
            => _photoRepo = photoRepo;

        public async Task<OperationResult> Handle(GetAllPhotosRequest request, CancellationToken cancellationToken)
        {
            var photos = await _photoRepo.GetAllAsync();
            return Success(Mapper.Map<List<PhotoViewModel>>(photos));
        }
    }
}
