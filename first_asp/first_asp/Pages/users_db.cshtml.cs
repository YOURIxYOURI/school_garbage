using first_asp.Pages.modele;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace first_asp.Pages
{
    public class users_dbModel : PageModel
    {
        public readonly IConfiguration Configuration;

        MySqlConnection con;
        
        public List<users_db> users = new List<users_db>();

        public users_dbModel(ILogger<KontaktModel> logger, IConfiguration ic)
        {
            Configuration = ic;
            con = new MySqlConnection(Configuration["database"]);
        }

        public void Dane()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM users";
            cmd.ExecuteNonQuery();

            MySqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                users.Add(new users_db
                {
                    id = read.GetInt32("iduser"),
                    firstname = read.GetString("firstname"),
                    email = read.GetString("email"),
                    description = read.GetString("description")
                });
            }
            con.Close();
        }

        public void OnGet()
        {
            Dane();
        }
        public void OnPost()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = $"INSERT INTO users(firstname, email, description)VALUES('{Request.Form["firstname"]}','{Request.Form["email"]}','{Request.Form["description"]}')";
            cmd.ExecuteNonQuery();
            con.Close();
            Dane();
        }
    }
}
