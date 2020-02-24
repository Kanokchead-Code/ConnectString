using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectString.Models
{
    public class StudyContext
    {
        public string ConnectionString { get; set; }

        public StudyContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Study> GetAllPatient()
        {
            List<Study> Study = new List<Study>();

            using (MySqlConnection conn = GetConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand cmd = new MySqlCommand("Select * from patient", conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                    {

                        Study.Add(new Study()
                        {
                            
                        });

                    }

                }

            }
            return Study;
        }


    }
}
