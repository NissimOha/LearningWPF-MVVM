using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LoginProjectBL
{
    public class AccountRepository
    {
        private List<Account> m_account;

        public async Task<Account> GetRememberMeAccount()
        {
            return await Task.Run(() =>
            {
                Account account = new Account(string.Empty, string.Empty);
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

                using (var conn = new SqlConnection(connectionString))
                {
                    string command = ConfigurationManager.AppSettings["RememberMeProcedure"];

                    using (var cmd = new SqlCommand(command, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        var row = cmd.ExecuteReader();
                        while (row.Read())
                            account = new Account(row["UserName"].ToString(), row["Password"].ToString());
                        conn.Close();
                    }
                }

                return account;
            });
        }

        public async Task SetRememberMeAccount(Account p_account)
        {
            await Task.Run(() =>
            {
                //Connect to DB
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                var connection = new SqlConnection(connectionString);
                connection.Open();

                //Delete last account
                string deleteString = ConfigurationManager.AppSettings["DeleteAccount"];
                var delCmd = new SqlCommand(deleteString, connection);
                delCmd.ExecuteNonQuery();

                //Save new account
                string saveString = ConfigurationManager.AppSettings["SaveAccount"];
                var saveCmd = new SqlCommand(saveString, connection);

                saveCmd.Parameters.AddWithValue("UserName", p_account.UserName);
                saveCmd.Parameters.AddWithValue("Password", p_account.Password);
                saveCmd.ExecuteNonQuery();

                connection.Close();

            });
                
        }

        public async Task<bool> CheckIfExist(Account p_account)
        {
            return await Task.Run(async() =>
            {
                await ReadAccountsFromDB();
                bool isFound = false;

                foreach (var account in m_account)
                {
                    if (account.UserName == p_account.UserName && account.Password == p_account.Password)
                        return true;
                }

                return isFound;
            });
        }

        private async Task ReadAccountsFromDB()
        {
            await Task.Run(() =>
            {
                m_account = new List<Account>();
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

                using (var conn = new SqlConnection(connectionString))
                {
                    string command = ConfigurationManager.AppSettings["RetriveAccountsProcedure"];

                    using (var cmd = new SqlCommand(command, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        var row = cmd.ExecuteReader();

                        while (row.Read())
                        {
                            m_account.Add(new Account(row["UserName"].ToString(),
                                                    row["Password"].ToString()));
                        }
                        conn.Close();
                    }
                }
            });
        }
    }
}
