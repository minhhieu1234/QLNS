using HRMngt.Model;
using HRMngt.Models;
using HRMngt.View;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HRMngt._Repository
{
    public class LoginRepository : ILoginRepository
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=HR;Integrated Security=True;Encrypt=False;";

        public LoginRepository(string connectionString)
        {

        }
        public string Login(string username, string password)
        {
            string id = "";
            if (password != string.Empty || username != string.Empty)
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "select * from users where username='" + username + "' and password='" + password + "'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader[0].ToString();
                        }
                    }
                    connection.Close();
                }
            }
            return id;
        }
    }
}
      
