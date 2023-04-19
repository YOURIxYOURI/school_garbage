using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace first_asp.Pages
{
    public class KontaktModel : PageModel
    {
        private MySqlConnection con;
        public bool IsPost { get; set; }

        public readonly IConfiguration Configuration;

        public KontaktModel(ILogger<KontaktModel> logger, IConfiguration ic)
        {
            ic = Configuration;
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
