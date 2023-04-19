using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Strona_na_zajęcia.Pages.Models;
using System.Text.Json;

namespace Strona_na_zajęcia.Pages
{
    public class UsersModel : PageModel
    {
        public List<User> users = new List<User>
        {
            new User{ Id = 1, Name = "Stefan", Email = "stefan@poczta.pl", Description = "Szary człowieczek" },
            new User{ Id = 2, Name = "Marta", Email = "marta@poczta.pl", Description = "Ktoś"},
            new User{ Id = 3, Name = "Krystian", Email = "krystian@poczta.pl", Description = "Sprzedawca pizzy" },
            new User{ Id = 4, Name = "Weronika", Email = "weronika@poczta.pl", Description = "Bibliotekarka"}
        };
        readonly ILogger<UsersModel> logs;

        public UsersModel(ILogger<UsersModel> logger)
        {
            logs = logger;
        }

        public void OnGet()
        {
            if(HttpContext.Session.GetString("Użytkownicy") == null || HttpContext.Session.GetString("Użytkownicy") == "")
                HttpContext.Session.SetString("Użytkownicy", JsonSerializer.Serialize(users));

            logs.LogInformation(HttpContext.Session.GetString("Użytkownicy"));
        }

        public void OnPost()
        {
            List<User> users = JsonSerializer.Deserialize<List<User>>(HttpContext.Session.GetString("Użytkownicy"));
            int newid = users.Count + 1;
            users.Add(
                new User { Id = newid, Name = Request.Form["imie"], Email = Request.Form["email"], Description = Request.Form["opis"] }
            );
            HttpContext.Session.SetString("Użytkownicy", JsonSerializer.Serialize(users));
            logs.LogInformation(HttpContext.Session.GetString("Użytkownicy"));
        }
    }
}