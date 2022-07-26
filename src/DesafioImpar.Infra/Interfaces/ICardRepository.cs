using DesafioImpar.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioImpar.Infra.Interfaces
{
    public interface ICardRepository : IRepository<Card>
    {
        Task<IEnumerable<Card>> GetAllCardsWithPhoto();

        Task<Card> GetCardByIdWithPhoto(int id);
    }
}
