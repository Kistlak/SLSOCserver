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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service3" in both code and config file together.
    public class Service3 : IService3
    {
        public Service3()
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

        public int AddModules(Modulesc md)
        {
            try
            {
                cmd.CommandText = "INSERT INTO modules(modcode,modname,lecname,fac) VALUES (@mc,@mn,@l,'Business')";
                cmd.Parameters.AddWithValue("mc", md.Modcode);
                cmd.Parameters.AddWithValue("mn", md.Modname);
                cmd.Parameters.AddWithValue("l", md.Lecname);

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

        public Modulesc SearchModules(string Modcode)
        {
            cmd.CommandText = "SELECT * FROM modules WHERE modcode=@mc";
            try
            {

                cmd.Parameters.AddWithValue("mc", Modcode);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Modulesc u = new Modulesc();
                    while (reader.Read())
                    {
                        u.Modcode = reader["modcode"].ToString();
                        u.Modname = reader["modname"].ToString();
                        u.Lecname = reader["lecname"].ToString();
                    }

                    return u;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Modulesc> GetComModules()
        {
            List<Modulesc> studetails = new List<Modulesc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',modcode AS 'Mode Code',modname AS 'Mode Name',lecname AS 'Lec Name' FROM modules WHERE fac='Business'";
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Modulesc lecgv = new Modulesc()
                    {
                        Id = reader[0].ToString(),
                        Modcode = reader[1].ToString(),
                        Modname = reader[2].ToString(),
                        Lecname = reader[3].ToString(),
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

        public int UpdateComModules(Modulesc cmu)
        {

            try
            {
                cmd.CommandText = "UPDATE modules set modcode=@mc, modname=@mn, lecname=@ln, fac='Business' WHERE modcode=@mc";
                cmd.Parameters.AddWithValue("mc", cmu.Modcode);
                cmd.Parameters.AddWithValue("mn", cmu.Modname);
                cmd.Parameters.AddWithValue("ln", cmu.Lecname);
                con.Open();
                return cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public int DeleteComModules(Modulesc cmdel)
        {
            try
            {
                cmd.CommandText = "DELETE modules WHERE modcode=@mc";
                cmd.Parameters.AddWithValue("mc", cmdel.Modcode);
                cmd.CommandType = CommandType.Text;
                con.Open();

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        // Lec Halls

        public int AddLecHalls(Lechallsc lhd)
        {
            try
            {
                cmd.CommandText = "INSERT INTO lechalls(lechallcode,numstu,fac) VALUES (@lhc,@ns,'Business')";
                cmd.Parameters.AddWithValue("lhc", lhd.Lechallcode);
                cmd.Parameters.AddWithValue("ns", lhd.Numstu);

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

        public Lechallsc SearchLecHalls(string Lechallcode)
        {
            cmd.CommandText = "SELECT * FROM lechalls WHERE lechallcode=@lhc";
            try
            {

                cmd.Parameters.AddWithValue("lhc", Lechallcode);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Lechallsc u = new Lechallsc();
                    while (reader.Read())
                    {
                        u.Lechallcode = reader["lechallcode"].ToString();
                        u.Numstu = reader["numstu"].ToString();
                    }

                    return u;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Lechallsc> GetComLecHalls()
        {
            List<Lechallsc> studetails = new List<Lechallsc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',lechallcode AS 'Hall Code',numstu AS 'Stu Number' FROM lechalls WHERE fac='Business'";
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lechallsc lecgv = new Lechallsc()
                    {
                        Id = reader[0].ToString(),
                        Lechallcode = reader[1].ToString(),
                        Numstu = reader[2].ToString(),
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

        public int UpdateComlecHalls(Lechallsc clhu)
        {

            try
            {
                cmd.CommandText = "UPDATE lechalls set lechallcode=@lhc, numstu=@ns, fac='Business' WHERE lechallcode=@lhc";
                cmd.Parameters.AddWithValue("lhc", clhu.Lechallcode);
                cmd.Parameters.AddWithValue("ns", clhu.Numstu);
                con.Open();
                return cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public int DeleteComLecHalls(Lechallsc clhdel)
        {
            try
            {
                cmd.CommandText = "DELETE lechalls WHERE lechallcode=@lhc";
                cmd.Parameters.AddWithValue("lhc", clhdel.Lechallcode);
                cmd.CommandType = CommandType.Text;
                con.Open();

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        // Labs

        public int AddLabs(Labsc lbd)
        {
            try
            {
                cmd.CommandText = "INSERT INTO labs(labcode,numstu,fac) VALUES (@lbc,@ns,'Business')";
                cmd.Parameters.AddWithValue("lbc", lbd.Labcode);
                cmd.Parameters.AddWithValue("ns", lbd.Numstu);

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

        public Labsc SearchLabs(string Labcode)
        {
            cmd.CommandText = "SELECT * FROM labs WHERE labcode=@lbc";
            try
            {

                cmd.Parameters.AddWithValue("lbc", Labcode);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    Labsc u = new Labsc();
                    while (reader.Read())
                    {
                        u.Labcode = reader["labcode"].ToString();
                        u.Numstu = reader["numstu"].ToString();
                    }

                    return u;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Labsc> GetComLabs()
        {
            List<Labsc> studetails = new List<Labsc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',labcode AS 'Lab Code',numstu AS 'Stu Number' FROM labs WHERE fac='Business'";
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Labsc lecgv = new Labsc()
                    {
                        Id = reader[0].ToString(),
                        Labcode = reader[1].ToString(),
                        Numstu = reader[2].ToString(),
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

        public int UpdateComLabs(Labsc clbu)
        {

            try
            {
                cmd.CommandText = "UPDATE labs set labcode=@lbc, numstu=@ns, fac='Business' WHERE labcode=@lbc";
                cmd.Parameters.AddWithValue("lbc", clbu.Labcode);
                cmd.Parameters.AddWithValue("ns", clbu.Numstu);
                con.Open();
                return cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public int DeleteComLabs(Labsc clbdel)
        {
            try
            {
                cmd.CommandText = "DELETE labs WHERE labcode=@lbc";
                cmd.Parameters.AddWithValue("lbc", clbdel.Labcode);
                cmd.CommandType = CommandType.Text;
                con.Open();

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        // Timetables

        public int AddTimetables(Timetablesc td)
        {
            try
            {
                cmd.CommandText = "INSERT INTO timetables(date,time,batch,modcode,lecname,lechall,lab,fac) VALUES (@d,@t,@b,@mc,@ln,@lh,@lb,'Business')";
                cmd.Parameters.AddWithValue("d", td.Date);
                cmd.Parameters.AddWithValue("t", td.Time);
                cmd.Parameters.AddWithValue("b", td.Batch);
                cmd.Parameters.AddWithValue("mc", td.Modcode);
                cmd.Parameters.AddWithValue("ln", td.Lecname);
                cmd.Parameters.AddWithValue("lh", td.Lechall);
                cmd.Parameters.AddWithValue("lb", td.Lab);

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

        public List<Timetablesc> GetComTimetables()
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

        public List<Lecturersc> GetBusinessLecturers()
        {
            List<Lecturersc> lecdetails = new List<Lecturersc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',fname AS 'First Name',lname AS 'Last Name',adone AS 'Address One',adtwo AS 'Address Two',city AS 'City',num AS 'Mobile Number',fac AS 'Faculty',modone AS 'Module One',modtwo AS 'Module Two',modthree AS 'Module Three',jdate AS 'Joined Date',rdate AS 'Resigned Date',username AS 'Username',password AS 'Password' FROM lecturers WHERE fac='Business'";
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Lecturersc lecgv = new Lecturersc()
                    {
                        Id = reader[0].ToString(),
                        Fname = reader[1].ToString(),
                        Lname = reader[2].ToString(),
                        Adone = reader[3].ToString(),
                        Adtwo = reader[4].ToString(),
                        City = reader[5].ToString(),
                        Number = reader[6].ToString(),
                        Faculty = reader[7].ToString(),
                        Moduleone = reader[8].ToString(),
                        Moduletwo = reader[9].ToString(),
                        Modulethree = reader[10].ToString(),
                        Jdate = reader[11].ToString(),
                        Rdate = reader[12].ToString(),
                        Username = reader[13].ToString(),
                        Password = reader[14].ToString()
                    };
                    lecdetails.Add(lecgv);

                }
                return lecdetails;

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

        public List<Studentsc> GetBusinessStudents()
        {
            List<Studentsc> studetails = new List<Studentsc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',fname AS 'First Name',lname AS 'Last Name',adone AS 'Address One',adtwo AS 'Address Two',city AS 'City',num AS 'Mobile Number',byear AS 'Birth Year',nic AS 'NIC',fac AS 'Faculty',jdate AS 'Joined Date',username AS 'Username',password AS 'Password' FROM students WHERE fac='Business'";
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Studentsc lecgv = new Studentsc()
                    {
                        Id = reader[0].ToString(),
                        Fname = reader[1].ToString(),
                        Lname = reader[2].ToString(),
                        Adone = reader[3].ToString(),
                        Adtwo = reader[4].ToString(),
                        City = reader[5].ToString(),
                        Number = reader[6].ToString(),
                        Byear = reader[7].ToString(),
                        Nic = reader[8].ToString(),
                        Faculty = reader[9].ToString(),
                        Jdate = reader[10].ToString(),
                        Username = reader[11].ToString(),
                        Password = reader[12].ToString()
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

        public Lecturersc SearchLecturers(Lecturersc r)
        {
            Lecturersc ld = new Lecturersc();
            try
            {
                cmd.CommandText = "SELECT * FROM lecturers WHERE username=@u AND fac='Business'";
                cmd.Parameters.AddWithValue("u", r.Username);
                cmd.CommandType = CommandType.Text;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ld.Fname = reader[0].ToString();
                    ld.Lname = reader[1].ToString();
                    ld.Adone = reader[2].ToString();
                    ld.Adtwo = reader[3].ToString();
                    ld.City = reader[4].ToString();
                    ld.Number = reader[5].ToString();
                    ld.Faculty = reader[6].ToString();
                    ld.Moduleone = reader[7].ToString();
                    ld.Moduletwo = reader[8].ToString();
                    ld.Modulethree = reader[9].ToString();
                    ld.Jdate = reader[10].ToString();
                    ld.Rdate = reader[11].ToString();
                    ld.Username = reader[12].ToString();
                }
                return ld;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

        public Studentsc SearchStudents(Studentsc p)
        {
            Studentsc ld = new Studentsc();
            try
            {
                cmd.CommandText = "SELECT * FROM students WHERE username=@u AND fac='Business'";
                cmd.Parameters.AddWithValue("u", p.Username);
                cmd.CommandType = CommandType.Text;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ld.Fname = reader[0].ToString();
                    ld.Lname = reader[1].ToString();
                    ld.Adone = reader[2].ToString();
                    ld.Adtwo = reader[3].ToString();
                    ld.City = reader[4].ToString();
                    ld.Number = reader[5].ToString();
                    ld.Byear = reader[6].ToString();
                    ld.Nic = reader[7].ToString();
                    ld.Faculty = reader[9].ToString();
                    ld.Jdate = reader[10].ToString();
                    ld.Username = reader[11].ToString();
                }
                return ld;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }

    } // Over Here
}
