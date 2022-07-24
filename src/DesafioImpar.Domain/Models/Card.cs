namespace DesafioImpar.Domain.Models
{
    public class Card : Entity
    {
        public string Name { get; set; }

        public string Status { get; set; }

        public Photo Photo { get; set; }

        public int PhotoId { get; set; }
    }
}
