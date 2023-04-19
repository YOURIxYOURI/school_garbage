using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace Strona_na_zajęcia.Pages
{
    public class CiasteczkaModel : PageModel
    {
        readonly ILogger<CiasteczkaModel> logger;
        public string dane = "";
        public CiasteczkaModel(ILogger<CiasteczkaModel> logger) {
            this.logger = logger;
        }
        
        public void OnGet()
        {
            Response.Cookies.Append("Imie", "Janek", new CookieOptions()
            {
                Expires = DateTime.Now.AddHours(1),
                Path = "/"
            });

            Response.Cookies.Delete("Imie");

            logger.LogInformation(Request.Cookies["Imie"]);
        }

        public void OnPost()
        {
            FileStream file = new FileStream("Pliki/plik.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file);

            writer.Write(Request.Form["tekst"]);
            writer.Close();

            FileStream file_to_read = new FileStream("Pliki/plik.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(file_to_read);

            dane = reader.ReadToEnd();
            reader.Close();
        }
    }
}
