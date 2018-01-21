using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookBL
{
    public class RecordRepository
    {
        public RecordRepository()
        {
            m_records = new ObservableCollection<Record>();
        }

        #region readRecordsFromDB

        private void readRecordsFromDB()
        {
            var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            var table = new DataTable(ConfigurationManager.AppSettings["RecordTable"]);

            using (var conn = new SqlConnection(connectionString))
            {
                //Console.WriteLine("connection created successfuly");

                string command = ConfigurationManager.AppSettings["RecordCommand"];

                using (var cmd = new SqlCommand(command, conn))
                {
                    //Console.WriteLine("command created successfuly");

                    SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                    conn.Open();
                    //Console.WriteLine("connection opened successfuly");
                    adapt.Fill(table);

                    int i = 0;
                    foreach (DataRow row in table.Rows)
                    {
                        m_records.Add(new Record());
                        m_records[i].Id = row["Id"].ToString();
                        m_records[i].FirstName = row["FirstName"].ToString();
                        m_records[i].LastName = row["LastName"].ToString();
                        m_records[i].Address = row["Address"].ToString();
                        m_records[i].PhoneNumber = row["PhoneNumber"].ToString();
                        m_records[i].Image = row["Image"].ToString();
                        i++;
                    }

                    conn.Close();
                    //Console.WriteLine("connection closed successfuly");
                }
            }
        }

        #endregion

        #region BeckUpToDB

        public async Task BeckUpToDB(ObservableCollection<Record> p_records)
        {
            await Task.Run(() =>
            {
                //Connect to DB
                var connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                var connection = new SqlConnection(connectionString);
                connection.Open();
                
                //Get Save command
                string saveString = ConfigurationManager.AppSettings["SaveCommand"];
                var command = new SqlCommand(saveString, connection);

                //Get all the new records
                var records = new ObservableCollection<Record>();
                foreach(var record in p_records)
                {
                    if (!m_records.Contains(record))
                        records.Add(record);
                }

                //Add new records to DB and to m_records
                foreach (var record in records)
                {
                    m_records.Add(record);
                    command.Parameters.AddWithValue("FirstName", record.FirstName);
                    command.Parameters.AddWithValue("LastName", record.LastName);
                    command.Parameters.AddWithValue("Address", record.Address);
                    command.Parameters.AddWithValue("PhoneNumber", record.PhoneNumber);
                    command.Parameters.AddWithValue("Image", record.Image);
                    command.ExecuteNonQuery();
                }

                //Get Delete command
                string DeleteString = ConfigurationManager.AppSettings["DeleteCommand"];
                command = new SqlCommand(DeleteString, connection);

                //Get all the new records
                records = new ObservableCollection<Record>();
                foreach (var record in m_records)
                {
                    if (!p_records.Contains(record))
                        records.Add(record);
                }

                //Delete records from DB and from m_records
                foreach (var record in records)
                {
                    m_records.Remove(record);
                    command.Parameters.AddWithValue("@Id", record.Id);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            });
        }

        #endregion

        #region Mehodes

        public async Task<ObservableCollection<Record>> DeleteRecords(ObservableCollection<object> p_deletedRecords,
                                                        ObservableCollection<Record> p_records)
        {
            return await Task.Run(() =>
            {
                var records = new ObservableCollection<Record>();
                foreach (var r in p_records)
                    records.Add(r);

                foreach (var delR in p_deletedRecords)
                {
                    if (records.Contains((Record)delR))
                        records.Remove((Record)delR);
                }
                return records;
            }
            );
        }

        public async Task<ObservableCollection<Record>> SortRecords(ObservableCollection<Record> p_records)
        {
            return await Task.Run(() =>
            {
                var records = new ObservableCollection<Record>();
                foreach (var r in p_records)
                    records.Add(r);

                var query = records.OrderBy(r => r.FirstName)
                                    .ThenBy(r => r.LastName);

                records = new ObservableCollection<Record>();
                foreach (var q in query)
                    records.Add(q);

                return records;
            });
        }

        public ObservableCollection<Record> Retrive()
        {
            if (isToInit)
            {
                readRecordsFromDB();
                isToInit = false;
            }

            var query = m_records.OrderBy(r => r.FirstName)
                                    .ThenBy(r => r.LastName);

            var records = new ObservableCollection<Record>();
            foreach (var q in query)
                records.Add(q);

            Length = records.Count();


            return records;
        }

        #endregion

        #region Field

        private ObservableCollection<Record> m_records;
        private bool isToInit = true;

        public static int Length { get; set; }

        #endregion
    }
}
