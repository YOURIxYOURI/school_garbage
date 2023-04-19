using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Strona_na_zajęcia.Pages.Models;

namespace Strona_na_zajęcia.Pages
{
    public class UserModel : PageModel
    {
        public User user { get; set; }
        public IActionResult OnGet(string dane)
        {
            if (dane != null)
                user = JsonConvert.DeserializeObject<User>(dane);

            if(user == null)
                return NotFound();

            return Page();
        }
    }
}
