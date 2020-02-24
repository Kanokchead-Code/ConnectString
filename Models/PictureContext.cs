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

                MySqlCommand cmd = new MySqlCommand("SELECT patient.pk, pat_id, pat_name,study.patient_fk, study_iuid, study.study_desc," +
                    "series.study_fk, series_iuid, instance.series_fk, sop_iuid FROM (((patient INNER JOIN study ON patient.pk = study.patient_fk)" +
                    "INNER JOIN series ON study.patient_fk = series.study_fk)" +
                    "INNER JOIN instance ON study.patient_fk = instance.series_fk) ORDER BY patient.pk ", conn); 
                    //concat('http://192.168.2.10:8080/wado/wado?requestType=WADO&studyUID=' , study_iuid , '&seriesUID=' , study_iuid , '&objectUID=' , study_iuid ,  '&contentType=image/jpeg') as url 

                MySqlDataReader reader = cmd.ExecuteReader();
                {
                    while (reader.Read())
                  

                        pic.Add(new Picture()
                        {
                            P_ID = reader["pat_id"].ToString(),
                            PPic_ID = reader["study_iuid"].ToString(),
                            PPic_Name = reader["pat_name"].ToString(),
                            PPic_Case = reader["study_desc"].ToString(),
                            PPic_url = string.Format("http://192.168.2.10:8080/wado/wado?requestType=WADO&studyUID={0}&seriesUID={1}&objectUID={2}&contentType=image/jpeg" , reader["study_iuid"].ToString() , reader["series_iuid"].ToString() , reader["sop_iuid"].ToString() )

                        }); 

                }

            }
            return pic;
        }

    }
}
