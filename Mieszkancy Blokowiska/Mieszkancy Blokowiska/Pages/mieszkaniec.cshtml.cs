using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mieszkancy_Blokowiska.Models;
using Newtonsoft.Json;

namespace Mieszkancy_Blokowiska.Pages
{
    public class mieszkaniecModel : PageModel
    {
        public Mieszkaniec m { get; set; }

        public IActionResult OnGet(string dane)
        {
            if (dane != null)
                m = JsonConvert.DeserializeObject<Mieszkaniec>(dane);

            if (m == null)
                return NotFound();
            return Page();
        }
    }
}
