using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_first_task.Pages
{
    public class KontaktModel : PageModel
    {
        public bool IsPost { get; set; }

        public readonly IConfiguration Configuration;

        public KontaktModel(ILogger<KontaktModel> logger, IConfiguration ic)
        {
            Configuration = ic;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            IsPost = true;
        }
    }
}
