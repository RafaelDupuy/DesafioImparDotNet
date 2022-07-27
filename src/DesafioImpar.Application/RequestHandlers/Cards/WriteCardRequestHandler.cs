using AutoMapper;
using DesafioImpar.Application.Requests.Card;
using DesafioImpar.Application.Shared;
using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Interfaces;
using MediatR;

namespace DesafioImpar.Application.RequestHandlers.Cards
{
    public class WriteCardRequestHandler : BaseRequestHandler,
        IRequestHandler<PostCardRequest, OperationResult>,
        IRequestHandler<DeleteCardRequest, OperationResult>,
        IRequestHandler<UpdateCardWithPhotoRequest, OperationResult>
    {
        private readonly ICardRepository _cardRepo;
        private readonly IPhotoRepository _photoRepo;

        public WriteCardRequestHandler(ICardRepository cardRepo, IPhotoRepository photoRepo, IMapper mapper) : base(mapper)
            => (_cardRepo, _photoRepo) = (cardRepo, photoRepo);

        public async Task<OperationResult> Handle(PostCardRequest request, CancellationToken cancellationToken)
        {
            var photo = await _photoRepo.GetByIdAsync(request.PhotoId);
            var newCard = new Card();
            newCard.Name = request.Name;
            newCard.Status = request.Status;
            newCard.Photo = photo;
            var newCardId = await _cardRepo.InsertAsync(newCard);
            return Success(newCardId);

        }

        public async Task<OperationResult> Handle(UpdateCardWithPhotoRequest request, CancellationToken cancellationToken)
        {
            var currentCard = await _cardRepo.GetCardByIdWithPhoto(request.Id);
            if (currentCard is null)
                return NotFound();

            Photo currentPhoto = null;
            if (currentCard.PhotoId != request.PhotoId)
                currentPhoto = await _photoRepo.GetByIdAsync(currentCard.PhotoId);


            var newPhoto = await _photoRepo.GetByIdAsync(request.PhotoId);

            currentCard.Name = request.Name;
            currentCard.Status = request.Status;
            currentCard.Photo = newPhoto;
            await _cardRepo.UpdateAsync(currentCard);

            if (currentPhoto is not null)
                await _photoRepo.Delete(currentPhoto);

            return Success();

        }

        public async Task<OperationResult> Handle(DeleteCardRequest request, CancellationToken cancellationToken)
        {
            var card = await _cardRepo.GetCardByIdWithPhoto(request.Id);
            if (card is null)
                return NotFound();

            await _cardRepo.Delete(card);
            await _photoRepo.Delete(card.Photo);
            return Success();
        }
    }
}
