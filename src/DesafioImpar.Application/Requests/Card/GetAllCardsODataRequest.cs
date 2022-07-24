using DesafioImpar.Application.ViewModels.Card;
using MediatR;

namespace DesafioImpar.Application.Requests.Card
{
    public class GetAllCardsODataRequest: IRequest<IQueryable<CardWithPhotoViewModel>>
    {
    }
}
