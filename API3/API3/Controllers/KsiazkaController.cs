using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KsiazkaController : ControllerBase
    {
        public List<Ksiazka> ksiazkaLista = new List<Ksiazka> { new Ksiazka { Id=1,Nazwa="Ksiazka 1",Autor="Autor 1",Rok=1223},
        new Ksiazka { Id=2,Nazwa="Ksiazka 2",Autor="Autor 2",Rok=2137},
        new Ksiazka { Id=3,Nazwa="Ksiazka 3",Autor="Autor 3",Rok=4200}
        };

        [HttpGet]
        public List<Ksiazka> GetKsiazki()
        {
            return ksiazkaLista;
        }

        [HttpGet("{id}")]
        public Ksiazka GetKsiazka(int id)
        {
            return ksiazkaLista.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("{id},{nazwa},{autor},{rok}")]
        public Ksiazka AddKsiazka(int id, string nazwa, string autor, int rok)
        {
            Ksiazka nowa = new Ksiazka { Id = id, Nazwa = nazwa, Autor = autor, Rok = rok };
            ksiazkaLista.Add(nowa);
            foreach (var ksizka in ksiazkaLista)
            {
                Console.WriteLine(ksizka.Id + "" + ksizka.Nazwa);
            }
            return nowa;
        }

        [HttpPut("{id},{nazwa}")]
        public Ksiazka UpdateKsiazka(int id,string nazwa)
        {
            ksiazkaLista.FirstOrDefault(x => x.Id == id).Nazwa = nazwa;
            Ksiazka edytowana = ksiazkaLista.FirstOrDefault(x=>x.Id==id);
            return edytowana;
        }

        [HttpDelete("{id}")]
        public Ksiazka DeleteKsiazka(int id)
        {
            Ksiazka usuwana = ksiazkaLista.FirstOrDefault(x=>x.Id==id);
            ksiazkaLista.Remove(usuwana);
            foreach (var ksizka in ksiazkaLista)
            {
                Console.WriteLine(ksizka.Id + "" + ksizka.Nazwa);
            }
            return usuwana;

        }

    }
}
