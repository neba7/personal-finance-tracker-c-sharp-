using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace personal_finance_tracker_c_sharp_
{
    internal class db
    {
        private string conn = "Server=localhost;Database=finance;User ID=neba;Password=1995777828";

        public bool login(string nameOrEmail, string password)
        {
            using (MySqlConnection connection = new MySqlConnection(conn)) 
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Users WHERE (name = @nameOrEmail OR email = @nameOrEmail) AND Password = @password";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@nameOrEmail", nameOrEmail);
                        cmd.Parameters.AddWithValue("@password", password);

                        
                        int userCount = Convert.ToInt32(cmd.ExecuteScalar());
                        if (userCount > 0) {
                            return true;
                        }
                    }
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);                
                }
            }

                return false;
        }

        public bool user_check_by_name(string name)
        {
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE name = @name";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@name", name);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return false;
        }

        public bool user_check_by_email(string email)
        {
            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE email = @email";
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@email", email);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0) 
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return false;
        }

        public int insert(string name, string password, string email)
        {
            int row = 0;

            using (MySqlConnection connection = new MySqlConnection(conn))
            {
                try
                {
                    connection.Open();

                    string query = "INSERT INTO users(name,password,email) VALUES(@name,@password,@email)";

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@email", email);

                    row = cmd.ExecuteNonQuery();

                    return row;
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"unable to open db: {ex.Message}");
                }
            }

            return row;
        }
    }
}
