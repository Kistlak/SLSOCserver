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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public Service1()
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

        public int SaveLecturers(Lecturersc ld)
        {
            try
            {
                cmd.CommandText = "INSERT INTO lecturers(fname,lname,adone,adtwo,city,num,fac,modone,modtwo,modthree,jdate,rdate,username,password) VALUES (@fn,@ln,@ao,@at,@ct,@nm,@fc,@mo,@mtw,@mtr,@jd,@rd,@u,@p)";
                cmd.Parameters.AddWithValue("fn", ld.Fname);
                cmd.Parameters.AddWithValue("ln", ld.Lname);
                cmd.Parameters.AddWithValue("ao", ld.Adone);
                cmd.Parameters.AddWithValue("at", ld.Adtwo);
                cmd.Parameters.AddWithValue("ct", ld.City);
                cmd.Parameters.AddWithValue("nm", ld.Number);
                cmd.Parameters.AddWithValue("fc", ld.Faculty);
                cmd.Parameters.AddWithValue("mo", ld.Moduleone);
                cmd.Parameters.AddWithValue("mtw", ld.Moduletwo);
                cmd.Parameters.AddWithValue("mtr", ld.Modulethree);
                cmd.Parameters.AddWithValue("jd", ld.Jdate);
                cmd.Parameters.AddWithValue("rd", ld.Rdate);
                cmd.Parameters.AddWithValue("u", ld.Username);
                cmd.Parameters.AddWithValue("p", ld.Password);

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

        public List<Lecturersc> GetLecturersDetails()
        {
            List<Lecturersc> lecdetails = new List<Lecturersc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',fname AS 'First Name',lname AS 'Last Name',adone AS 'Address One',adtwo AS 'Address Two',city AS 'City',num AS 'Mobile Number',fac AS 'Faculty',modone AS 'Module One',modtwo AS 'Module Two',modthree AS 'Module Three',jdate AS 'Joined Date',rdate AS 'Resigned Date',username AS 'Username',password AS 'Password' FROM lecturers";
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

        public Lecturersc SearchLecturers(Lecturersc r)
        {
            Lecturersc ld = new Lecturersc();
            try
            {
                cmd.CommandText = "SELECT * FROM lecturers WHERE username=@u";
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

        public int UpdateLecturers(Lecturersc lu)
        {

            try
            {
                cmd.CommandText = "UPDATE lecturers set fname=@fname, lname=@lname, adone=@ao, adtwo=@at, city=@ct, num=@nm, modone=@mo, modtwo=@mtw, modthree=@mtr, rdate=@rd, username=@u, password=@p WHERE username=@u";
                cmd.Parameters.AddWithValue("u", lu.Username);
                cmd.Parameters.AddWithValue("fname", lu.Fname);
                cmd.Parameters.AddWithValue("lname", lu.Lname);
                cmd.Parameters.AddWithValue("ao", lu.Adone);
                cmd.Parameters.AddWithValue("at", lu.Adtwo);
                cmd.Parameters.AddWithValue("ct", lu.City);
                cmd.Parameters.AddWithValue("nm", lu.Number);
                cmd.Parameters.AddWithValue("mo", lu.Moduleone);
                cmd.Parameters.AddWithValue("mtw", lu.Moduletwo);
                cmd.Parameters.AddWithValue("mtr", lu.Modulethree);
                cmd.Parameters.AddWithValue("rd", lu.Rdate);
                cmd.Parameters.AddWithValue("p", lu.Password);
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

        public int DeleteLecturers(Lecturersc ldel)
        {
            try
            {
                cmd.CommandText = "DELETE lecturers WHERE username=@u";
                cmd.Parameters.AddWithValue("u", ldel.Username);
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

        // Students Section

        public int SaveStudents(Studentsc sd)
        {
            try
            {
                cmd.CommandText = "INSERT INTO students(fname,lname,adone,adtwo,city,num,byear,nic,fac,jdate,username,password) VALUES (@fn,@ln,@ao,@at,@ct,@nm,@by,@n,@fc,@jd,@u,@p)";
                cmd.Parameters.AddWithValue("fn", sd.Fname);
                cmd.Parameters.AddWithValue("ln", sd.Lname);
                cmd.Parameters.AddWithValue("ao", sd.Adone);
                cmd.Parameters.AddWithValue("at", sd.Adtwo);
                cmd.Parameters.AddWithValue("ct", sd.City);
                cmd.Parameters.AddWithValue("nm", sd.Number);
                cmd.Parameters.AddWithValue("by", sd.Byear);
                cmd.Parameters.AddWithValue("n", sd.Nic);
                cmd.Parameters.AddWithValue("fc", sd.Faculty);
                cmd.Parameters.AddWithValue("jd", sd.Jdate);
                cmd.Parameters.AddWithValue("u", sd.Username);
                cmd.Parameters.AddWithValue("p", sd.Password);

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

        public List<Studentsc> GetStudentsDetails()
        {
            List<Studentsc> lecdetails = new List<Studentsc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',fname AS 'First Name',lname AS 'Last Name',adone AS 'Address One',adtwo AS 'Address Two',city AS 'City',num AS 'Mobile Number',byear AS 'Birth Year',nic AS 'NIC',fac AS 'Faculty',jdate AS 'Joined Date',username AS 'Username',password AS 'Password' FROM students";
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

        public Studentsc SearchStudents(Studentsc p)
        {
            Studentsc ld = new Studentsc();
            try
            {
                cmd.CommandText = "SELECT * FROM students WHERE username=@u";
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
                    ld.Faculty = reader[8].ToString();
                    ld.Jdate = reader[10].ToString();
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

        public int UpdateStudents(Studentsc lu)
        {

            try
            {
                cmd.CommandText = "UPDATE students set fname=@fname, lname=@lname, adone=@ao, adtwo=@at, city=@ct, num=@nm, nic=@nic, username=@u, password=@p WHERE username=@u";
                cmd.Parameters.AddWithValue("u", lu.Username);
                cmd.Parameters.AddWithValue("fname", lu.Fname);
                cmd.Parameters.AddWithValue("lname", lu.Lname);
                cmd.Parameters.AddWithValue("ao", lu.Adone);
                cmd.Parameters.AddWithValue("at", lu.Adtwo);
                cmd.Parameters.AddWithValue("ct", lu.City);
                cmd.Parameters.AddWithValue("nm", lu.Number);
                cmd.Parameters.AddWithValue("nic", lu.Nic);
                cmd.Parameters.AddWithValue("p", lu.Password);
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

        public int DeleteStudents(Studentsc sdel)
        {
            try
            {
                cmd.CommandText = "DELETE students WHERE username=@u";
                cmd.Parameters.AddWithValue("u", sdel.Username);
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

        // Computing Lecs And Stu

        public List<Lecturersc> GetComputingLecturers()
        {
            List<Lecturersc> lecdetails = new List<Lecturersc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',fname AS 'First Name',lname AS 'Last Name',adone AS 'Address One',adtwo AS 'Address Two',city AS 'City',num AS 'Mobile Number',fac AS 'Faculty',modone AS 'Module One',modtwo AS 'Module Two',modthree AS 'Module Three',jdate AS 'Joined Date',rdate AS 'Resigned Date',username AS 'Username',password AS 'Password' FROM lecturers WHERE fac='Computing'";
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

        public List<Studentsc> GetComputingStudents()
        {
            List<Studentsc> studetails = new List<Studentsc>();
            try
            {
                cmd.CommandText = "SELECT id AS 'Explorer',fname AS 'First Name',lname AS 'Last Name',adone AS 'Address One',adtwo AS 'Address Two',city AS 'City',num AS 'Mobile Number',byear AS 'Birth Year',nic AS 'NIC',fac AS 'Faculty',jdate AS 'Joined Date',username AS 'Username',password AS 'Password' FROM students WHERE fac='Computing'";
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

    } // Over Here
}
