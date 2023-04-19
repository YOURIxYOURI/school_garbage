using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Strona_na_zajęcia.Pages.Models;

namespace Strona_na_zajęcia.Pages
{
    public class User_DBModel : PageModel
    {
        public User_DB user { get; set; }
        public IActionResult OnGet(string dane)
        {
            if (dane != null)
                user = JsonConvert.DeserializeObject<User_DB>(dane);

            if (user == null)
                return NotFound();

            return Page();
        }
    }
}
