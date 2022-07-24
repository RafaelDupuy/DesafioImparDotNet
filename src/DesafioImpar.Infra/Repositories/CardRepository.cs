using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Context;
using DesafioImpar.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioImpar.Infra.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(ImparContext context)
            : base(context) { }

        public async Task<IEnumerable<Card>> GetAllCardsWithPhoto()
            => await _currentSet
                .Include(c => c.Photo)
                .ToListAsync();
    }
}
