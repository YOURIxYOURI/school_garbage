using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace asp_first_task.Pages
{
    public class IndexModel : PageModel
    {
        public readonly IConfiguration Configuration;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration ic)
        {
            _logger = logger;
            Configuration = ic;
        }

        public void OnGet()
        {

        }
    }
}