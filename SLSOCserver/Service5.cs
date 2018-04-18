using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLSOCserver
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service5" in both code and config file together.
    public class Service5 : IService5
    {
        public Service5()
        {
            ConnectDb();
        }
        SqlConnection con;
        SqlCommand cmd;

        void ConnectDb()
        {
            String sourse = "Data Source=KISTLAK;Initial Catalog=slsoc;Integrated Security=True";

            con = new SqlConnection(sourse.ToString());
            cmd = con.CreateCommand();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        int ans;
        public int Login(Users ud)
        {
            try
            {

                cmd.CommandText = "SELECT * FROM users WHERE username=@user AND password=@pass";
                cmd.Parameters.AddWithValue("user", ud.Username);
                cmd.Parameters.AddWithValue("pass", ud.Password);

                con.Open();
                cmd.CommandType = CommandType.Text;
                SqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    ans = 1;
                }
            }
            catch (Exception)
            {
                ans = 0;
                throw;
            }
            finally
            {
                con.Close();
            }
            return ans;
        }

        public List<Timetablesc> GetComTimetables()
        {
            List<Timetablesc> studetails = new List<Timetablesc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',date AS 'Date',time AS 'Time',batch AS 'Batch',modcode AS 'Module Code',lecname AS 'Lec Name',lechall AS 'Lec Hall',lab AS 'Lab' FROM timetables WHERE fac='Computing'";
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Timetablesc lecgv = new Timetablesc()
                    {
                        Id = reader[0].ToString(),
                        Date = reader[1].ToString(),
                        Time = reader[2].ToString(),
                        Batch = reader[3].ToString(),
                        Modcode = reader[4].ToString(),
                        Lecname = reader[5].ToString(),
                        Lechall = reader[6].ToString(),
                        Lab = reader[7].ToString(),
                    };
                    studetails.Add(lecgv);

                }
                return studetails;

            }
            catch (Exception) { throw; }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public List<Timetablesc> GetBusTimetables()
        {
            List<Timetablesc> studetails = new List<Timetablesc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',date AS 'Date',time AS 'Time',batch AS 'Batch',modcode AS 'Module Code',lecname AS 'Lec Name',lechall AS 'Lec Hall',lab AS 'Lab' FROM timetables WHERE fac='Business'";
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Timetablesc lecgv = new Timetablesc()
                    {
                        Id = reader[0].ToString(),
                        Date = reader[1].ToString(),
                        Time = reader[2].ToString(),
                        Batch = reader[3].ToString(),
                        Modcode = reader[4].ToString(),
                        Lecname = reader[5].ToString(),
                        Lechall = reader[6].ToString(),
                        Lab = reader[7].ToString(),
                    };
                    studetails.Add(lecgv);

                }
                return studetails;

            }
            catch (Exception) { throw; }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public List<Timetablesc> GetEngTimetables()
        {
            List<Timetablesc> studetails = new List<Timetablesc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',date AS 'Date',time AS 'Time',batch AS 'Batch',modcode AS 'Module Code',lecname AS 'Lec Name',lechall AS 'Lec Hall',lab AS 'Lab' FROM timetables WHERE fac='Engineering'";
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Timetablesc lecgv = new Timetablesc()
                    {
                        Id = reader[0].ToString(),
                        Date = reader[1].ToString(),
                        Time = reader[2].ToString(),
                        Batch = reader[3].ToString(),
                        Modcode = reader[4].ToString(),
                        Lecname = reader[5].ToString(),
                        Lechall = reader[6].ToString(),
                        Lab = reader[7].ToString(),
                    };
                    studetails.Add(lecgv);

                }
                return studetails;

            }
            catch (Exception) { throw; }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public int AddFeedback(Feedbacksc fbd)
        {
            try
            {
                cmd.CommandText = "INSERT INTO feedbacks(username,fac,modcode,feedback) VALUES (@u,@fc,@mc,@fb)";
                cmd.Parameters.AddWithValue("u", fbd.Username);
                cmd.Parameters.AddWithValue("fc", fbd.Faculty);
                cmd.Parameters.AddWithValue("mc", fbd.Modcode);
                cmd.Parameters.AddWithValue("fb", fbd.Feedback);

                con.Open();
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception) { throw; }
            finally
            {
                con.Close();
            }
        }

    } // Over Here
}
