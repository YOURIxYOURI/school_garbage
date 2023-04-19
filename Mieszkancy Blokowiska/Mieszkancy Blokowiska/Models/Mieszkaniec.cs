namespace Mieszkancy_Blokowiska.Models
{
    public class Mieszkaniec
    {
        public int id_mieszkaniec { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string plec { get; set; }
        public int nr_mieszkania { get; set; }
        public bool wlasciciel { get; set; }
    }
}
