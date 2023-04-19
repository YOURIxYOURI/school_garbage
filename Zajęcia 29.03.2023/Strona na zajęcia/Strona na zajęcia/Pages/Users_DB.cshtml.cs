using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Strona_na_zajęcia.Pages.Models;

namespace Strona_na_zajęcia.Pages
{
    public class Users_DBModel : PageModel
    {
        readonly IConfiguration config;
        MySqlConnection database;
        public List<User_DB> users = new List<User_DB>();

        public Users_DBModel(IConfiguration configuration)
        {
            config = configuration;
            database = new MySqlConnection(config["ConnectionStrings"]);
        }

        public void Dane()
        {
            database.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = database;

            command.CommandText = "SELECT * FROM users";
            command.ExecuteNonQuery();

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User_DB
                {
                    id_user = reader.GetInt32("id_user"),
                    imie = reader.GetString("imie"),
                    nazwisko = reader.GetString("nazwisko")
                });
            }

            database.Close();
        }

        public void OnGet()
        {
            Dane();
        }

        public void OnPost()
        {
            database.Open();

            MySqlCommand command = new MySqlCommand();
            command.Connection = database;

            command.CommandText = "INSERT INTO users(imie, nazwisko) VALUES('" + Request.Form["imie"] + "', '" + Request.Form["nazwisko"] + "')";
            command.ExecuteNonQuery();

            database.Close();

            Dane();
        }
    }
}
