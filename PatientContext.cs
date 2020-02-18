using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data;


namespace ConnectString.Models
{
    public class PatientContext
    {
        public string ConnectionString { get; set; }

        public PatientContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Patient> GetAllPatient()
        {
            List<Patient> list = new List<Patient>();
            
            using (MySqlConnection conn = GetConnection())
            {
                if(conn.State != System.Data.ConnectionState.Open)
                conn.Open();
                
                MySqlCommand cmd = new MySqlCommand("Select * from patient",conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                { while (reader.Read())
                    {

                        list.Add(new Patient()
                        {
                            Patient_id = reader["pat_id"].ToString(),
                            Patient_Name = reader["pat_name"].ToString(),
                            Patient_sex =  reader["pat_sex"].ToString()
                        });
                        
                    }
                        
                }
                
            }
            return list;
        }

    }
}
