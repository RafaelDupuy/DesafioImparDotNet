using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Context;
using DesafioImpar.Infra.Interfaces;

namespace DesafioImpar.Infra.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(ImparContext context)
            : base(context) { }
    }
}
