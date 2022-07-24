using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Context;

namespace DesafioImpar.Infra.Repositories
{
    public class CardRepository : Repository<Card>
    {
        public CardRepository(ImparContext context)
            : base(context) { }
    }
}
