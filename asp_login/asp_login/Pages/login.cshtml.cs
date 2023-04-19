using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace asp_login.Pages
{
    public class loginModel : PageModel
    {
        MySqlConnection con;
        public string info = "";

        public void OnGet()
        {

        }

        public void reg()
        {
            con = new MySqlConnection();
            con.ConnectionString = "server=localhost;port=3306;database=asp_first;uid=root;pwd=;";
            con.Open();
            if (Request.Form["reg_name"] != "" && Request.Form["reg_pass"] != "" && Request.Form["reg_pass_again"] != "")
            {
                if (Request.Form["reg_pass"] == Request.Form["reg_pass_again"]) 
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = $"INSERT INTO accounts VALUES('null','{Request.Form["reg_name"]}','{Request.Form["reg_pass"]}')";
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    info = "Pomyœlnie stowrzy³eœ konto";
                }
                else
                {
                    info = "rózne has³a";
                }
            }
            else
            {
                info = "Pole jest wymagane";
            }

            con.Close();
        }

        public void log()
        {
            con = new MySqlConnection();
            con.ConnectionString = "server=localhost;port=3306;database=asp_first;uid=root;pwd=;";
            con.Open();
            string pass = "";
            int id = 0;
            if (Request.Form["log_name"] != "" && Request.Form["log_pass"] != "")
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = $"SELECT * FROM accounts WHERE name = '{Request.Form["log_name"]}'";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pass = reader.GetString("pass");
                    id = reader.GetInt32("id");
                    
                }
                if (Request.Form["log_pass"] == pass)
                {
                    info = $"Witaj U¿ytkowniku o ID {id}";
                }
                else
                {
                    info = "nie poprawne has³o";
                }
            }
            else
            {
                info = "pola s¹ wymagane";
            }

            con.Close();
        }

        public IActionResult OnPost(string button)
        {
            switch (button)
            {
                case "reg":
                    reg(); return Page();
                case "log":
                    log(); return Page();
            }
            return Page();
        }
    }
}
