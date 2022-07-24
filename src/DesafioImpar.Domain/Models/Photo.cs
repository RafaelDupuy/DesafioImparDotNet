using System.Collections.Generic;

namespace DesafioImpar.Domain.Models
{
    public class Photo : Entity
    {
        public string Base64 { get; set; }

        public Card Card { get; set; }
    }
}
