using AutoMapper;
using DesafioImpar.Application.Requests.Card;
using DesafioImpar.Application.Shared;
using DesafioImpar.Application.ViewModels.Card;
using DesafioImpar.Infra.Interfaces;
using MediatR;

namespace DesafioImpar.Application.RequestHandlers.Cards
{
    public class ReadCardRequestHandler : BaseRequestHandler, IRequestHandler<GetAllCardsWithPhotoRequest, OperationResult>
    {
        private readonly ICardRepository _cardRepo;
        public ReadCardRequestHandler(IMapper mapper, ICardRepository cardRepo) : base(mapper)
            => _cardRepo = cardRepo;

        public async Task<OperationResult> Handle(GetAllCardsWithPhotoRequest request, CancellationToken cancellationToken)
        {
            var cards = await _cardRepo.GetAllCardsWithPhoto();
            return Success(Mapper.Map<List<CardWithPhotoViewModel>>(cards));
        }
    }
}
