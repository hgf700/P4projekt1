using System;

namespace p4_projekt.SavingData
{
    public class InsertingData
    {
        public static void SaveInfo(string lastname, string email, string password)
        {
            try
            {
                string query = "INSERT INTO [UserRegisters] (Lastname, Email, Password) VALUES (@Lastname, @Email, @Password)";

                // Execute.
                SqlConnectionManager.ExecuteQuery(query, lastname, email, password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
