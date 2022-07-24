using DesafioImpar.Domain.Models;
using DesafioImpar.Infra.Context;

namespace DesafioImpar.Infra.Repositories
{
    public class PhotoRepository : Repository<Photo>
    {
        public PhotoRepository(ImparContext context)
            : base(context) { }
    }
}
