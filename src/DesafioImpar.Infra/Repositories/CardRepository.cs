using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Context;
using DesafioImpar.Infra.Interfaces;

namespace DesafioImpar.Infra.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(ImparContext context)
            : base(context) { }
    }
}
