using first_asp.Pages.modele;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text.Json;

namespace first_asp.Pages
{
    public class userModel : PageModel
    {
        public users user { get; set; }

        public IActionResult OnGet(string dane)
        {
            if (dane != null)
                user = JsonConvert.DeserializeObject<users>(dane);

            if (user == null)
                return NotFound();
            return Page();
        }
    }
}
