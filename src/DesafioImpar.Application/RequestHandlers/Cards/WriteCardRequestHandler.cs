using AutoMapper;
using DesafioImpar.Application.Requests.Card;
using DesafioImpar.Application.Shared;
using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Interfaces;
using MediatR;

namespace DesafioImpar.Application.RequestHandlers.Cards
{
    public class WriteCardRequestHandler : BaseRequestHandler,
        IRequestHandler<PostCardWithImageRequest, OperationResult>,
        IRequestHandler<DeleteCardRequest, OperationResult>
    {
        private readonly ICardRepository _cardRepo;
        private readonly IPhotoRepository _photoRepo;

        public WriteCardRequestHandler(ICardRepository cardRepo, IPhotoRepository photoRepo, IMapper mapper) : base(mapper)
            => (_cardRepo, _photoRepo) = (cardRepo, photoRepo);

        public async Task<OperationResult> Handle(PostCardWithImageRequest request, CancellationToken cancellationToken)
        {
            var newPhoto = new Photo() { Base64 = request.PhotoBase64 };
            var photoId = await _photoRepo.InsertAsync(newPhoto);

            var newCard = new Card();
            newCard.Name = request.Name;
            newCard.Status = request.Status;
            newCard.PhotoId = photoId;
            var newCardId = await _cardRepo.InsertAsync(newCard);
            return Success(newCardId);

        }

        public async Task<OperationResult> Handle(DeleteCardRequest request, CancellationToken cancellationToken)
        {
            var card = await _cardRepo.GetByIdAsync(request.Id);
            if (card is null)
                return NotFound();

            await _cardRepo.Delete(card);
            return Success();
        }
    }
}
