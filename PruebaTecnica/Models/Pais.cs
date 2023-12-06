namespace PruebaTecnica.Models
{
    public class Pais
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? isoCode { get; set; }
        public int population { get; set;}
        public ICollection<Hotel> Hotel { get; set; }
        public ICollection<Restaurante> Restaurante { get; set;}
    }
}
