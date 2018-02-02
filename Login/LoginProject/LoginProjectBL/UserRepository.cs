using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginProjectBL
{
    public class UserRepository
    {
        private List<int> m_userIds;

        public async Task<bool> CheckIfExist(string p_id)
        {
            return await Task.Run(async() =>
            {
                await ReadUserIdsFromDB();
                bool isFound = false;
                if (!(Regex.IsMatch(p_id, @"^[0-9]+$"))) return isFound;

                var CheckedId = Convert.ToInt32(p_id);

                foreach(var id in m_userIds)
                {
                    if (id == CheckedId) return true;
                }

                return isFound;
            });
        }

        public async Task<string> RestorePassword(string p_id, string p_un)
        {
            return await Task.Run(() =>
            {
                var users = new List<User>();
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

                using (var conn = new SqlConnection(connectionString))
                {
                    string command = ConfigurationManager.AppSettings["RestorePasswordProcedure"];

                    using (var cmd = new SqlCommand(command, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        var row = cmd.ExecuteReader();

                        while (row.Read())
                        {
                            users.Add(new User(row["UserId"].ToString(),row["UserName"].ToString(),
                                row["Password"].ToString()));
                        }
                        conn.Close();
                    }
                }

                foreach(var user in users)
                {
                    if (p_id == user.Id && p_un == user.Account.UserName)
                        return user.Account.Password + ConfigurationManager.AppSettings["RESTOR_SUCCESSED"];
                }

                return ConfigurationManager.AppSettings["RESTOR_ERROR"];
            });
        } 

        public async void BackUp(User p_user)
        {
            await Task.Run(() =>
            {
                //Connect to DB
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                var connection = new SqlConnection(connectionString);
                connection.Open();

                //Get Save command
                string saveString = ConfigurationManager.AppSettings["BackUpCommand"];
                var command = new SqlCommand(saveString, connection);

                //Add new record to DB and to m_records
                command.Parameters.AddWithValue("UserId", p_user.Id);
                command.Parameters.AddWithValue("FirstName", p_user.FirstName);
                command.Parameters.AddWithValue("LastName", p_user.LastName);
                command.Parameters.AddWithValue("Address", p_user.Address);
                command.Parameters.AddWithValue("PhoneNumber", p_user.PhoneNumber);
                command.Parameters.AddWithValue("Email", p_user.Email);
                command.Parameters.AddWithValue("UserName", p_user.Account.UserName);
                command.Parameters.AddWithValue("Password", p_user.Account.Password);

                command.ExecuteNonQuery();

                connection.Close();
            });
        } 

        private async Task ReadUserIdsFromDB()
        {
            await Task.Run(() =>
            {
                m_userIds = new List<int>();
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];

                using (var conn = new SqlConnection(connectionString))
                {
                    string command = ConfigurationManager.AppSettings["RetriveUserIdsProcedure"];

                    using (var cmd = new SqlCommand(command, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        conn.Open();
                        var row = cmd.ExecuteReader();

                        while (row.Read())
                        {
                            m_userIds.Add(Convert.ToInt32(row["UserId"].ToString()));
                        }
                        conn.Close();
                    }
                }
            });
        }
    }
}
