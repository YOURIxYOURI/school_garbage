using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mieszkancy_Blokowiska.Models;

namespace Mieszkancy_Blokowiska.Pages
{
    public class MieszkancyModel : PageModel
    {
        public List<Mieszkaniec> mky = new List<Mieszkaniec>()
        {
            new Mieszkaniec{id_mieszkaniec = 1, imie = "Jaros³aw", nazwisko="dudek",plec="Mê¿czyzna", nr_mieszkania=1,wlasciciel=true},
            new Mieszkaniec{id_mieszkaniec = 2, imie = "Michalina", nazwisko="dudek",plec="Kobieta", nr_mieszkania=1,wlasciciel=false},
            new Mieszkaniec{id_mieszkaniec = 3, imie = "Konrad", nazwisko="dozorczyk",plec="Mê¿czyzna", nr_mieszkania=2,wlasciciel=true},
            new Mieszkaniec{id_mieszkaniec = 4, imie = "Krzysztof", nazwisko="Olgierd",plec="Mê¿czyzna", nr_mieszkania=3,wlasciciel=true},
            new Mieszkaniec{id_mieszkaniec = 5, imie = "Natalia", nazwisko="Olgierd",plec="Kobieta", nr_mieszkania=3,wlasciciel=false},
            new Mieszkaniec{id_mieszkaniec = 6, imie = "Daria", nazwisko="Ba³an",plec="Kobieta", nr_mieszkania=4,wlasciciel=true},


        }; 
        public void OnGet()
        {
        }
    }
}
