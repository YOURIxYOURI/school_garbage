using first_asp.Pages.modele;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace first_asp.Pages
{
    public class usersModel : PageModel
    {
        public List<users> users = new List<users>() 
        {
            new users{id = 1, name = "bogdan", email = "wp@", description = "opis"},
            new users{id = 2, name = "jan", email = "kowal@", description = "to jest opis"},
            new users{id = 3, name = "maria", email = "email@", description = "to jest opis uzytkownka"},
        };

        readonly ILogger<usersModel> logs;

        public usersModel(ILogger<usersModel> log)
        {
            logs = log;
        }

        public void OnGet()
        {
            HttpContext.Session.SetString("userss", JsonSerializer.Serialize(users));
            logs.LogInformation(HttpContext.Session.GetString("userss"));
        }

        public void OnPost() 
        {
            List<users> userssesion = JsonSerializer.Deserialize(users);  
        }
    }
}
