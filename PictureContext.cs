using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectString.Models
{
    public class PictureContext
    {
        public string ConnectionString2 { get; set; }

        public PictureContext(string connectionString)
        {
            this.ConnectionString2 = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString2);
        }
        public List<Picture> GetAllPicture()
        {
            List<Picture> pic = new List<Picture>();

            using (MySqlConnection conn = GetConnection())
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT pat_id, study_iuid, pat_name, " +
                    "study_desc, concat('http://192.168.2.10:8080/wado/wado?requestType=WADO&studyUID=' , study_iuid , '&seriesUID=' , study_iuid , '&objectUID=' , study_iuid ,  '&contentType=image/jpeg') as url FROM patient AS p JOIN study AS s ON p.pk = s.pk", conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())

                        pic.Add(new Picture()
                        {
                            P_ID = reader["pat_id"].ToString(),
                            PPic_ID = reader["study_iuid"].ToString(),
                            PPic_Name = reader["pat_name"].ToString(),
                            PPic_Case = reader["study_desc"].ToString(),
                            PPic_url = reader["url"].ToString()

                        }) ;

                }

            }
            return pic;
        }

    }
}
