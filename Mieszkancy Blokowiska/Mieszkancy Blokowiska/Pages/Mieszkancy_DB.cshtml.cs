using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mieszkancy_Blokowiska.Models;
using MySql.Data.MySqlClient;

namespace Mieszkancy_Blokowiska.Pages
{
    public class Mieszkancy_DBModel : PageModel
    {
        public readonly IConfiguration Configuration;

        MySqlConnection con;

        public List<Mieszkaniec> mkyDB = new List<Mieszkaniec>();

        public Mieszkancy_DBModel(ILogger<Mieszkancy_DBModel> logger, IConfiguration ic)
        {
            ic = Configuration;
            con = new MySqlConnection(ic["database"]);
        }
        public void OnGet()
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT * FROM mieszkancy";
            cmd.ExecuteNonQuery();

            MySqlDataReader read = cmd.ExecuteReader();

            while (read.Read())
            {
                mkyDB.Add(new Mieszkaniec
                {
                    id_mieszkaniec = read.GetInt32("id_mieszkaniec"),
                    imie = read.GetString("imie"),
                    nazwisko = read.GetString("nazwisko"),
                    plec = read.GetString("plec"),
                    nr_mieszkania = read.GetInt32("nr_mieszkania"),
                    wlasciciel = read.GetBoolean("wlasciciel")
                });
            }
        }
    }
}

