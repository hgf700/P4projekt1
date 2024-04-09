using System;
using System.Data;
using System.Data.SqlClient;

namespace p4_projekt.SavingData
{
    public class SqlConnectionManager
    {
        public static int ExecuteQuery(string query, string lastname, string email, string password)
        {
            int rowCount = 0;
            string connectionString = "Data Source=LAPTOP-RNG4KAQI\\SQLEXPRESS;Initial Catalog=p4.BloggingContext;Integrated Security=SSPI";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Lastname", lastname);
                    sqlCommand.Parameters.AddWithValue("@Email", email);
                    sqlCommand.Parameters.AddWithValue("@Password", password);

                    try
                    {
                        sqlConnection.Open();
                        rowCount = sqlCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Obsługa błędu.
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }

            return rowCount;
        }
    }
}
