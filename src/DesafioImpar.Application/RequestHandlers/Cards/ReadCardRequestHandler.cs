using AutoMapper;
using DesafioImpar.Application.Requests.Card;
using DesafioImpar.Application.ViewModels.Card;
using DesafioImpar.Infra.Interfaces;
using MediatR;

namespace DesafioImpar.Application.RequestHandlers.Cards
{
    public class ReadCardRequestHandler : BaseRequestHandler,
        IRequestHandler<GetAllCardsODataRequest, IQueryable<CardWithPhotoViewModel>>
    {
        private readonly ICardRepository _cardRepo;

        public ReadCardRequestHandler(IMapper mapper, ICardRepository cardRepo) : base(mapper)
            => _cardRepo = cardRepo;

        public Task<IQueryable<CardWithPhotoViewModel>> Handle(GetAllCardsODataRequest request, CancellationToken cancellationToken)
        {
            var cards = Mapper.ProjectTo<CardWithPhotoViewModel>(_cardRepo.Query());
            return Task.FromResult(cards);
        }
    }
}
