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

        public Lecturersc SearchLecturers(Lecturersc ls) 
        {
            Lecturersc ld = new Lecturersc();
            try
            {
                cmd.CommandText = "SELECT * FROM lecturers WHERE username=@u";
                cmd.Parameters.AddWithValue("u", ld.Username);
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
                    //ld.Username = reader[12].ToString();
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
                cmd.CommandText = "UPDATE lecturers set fname=@fname WHERE username=@u";
                cmd.Parameters.AddWithValue("u", lu.Username);
                cmd.Parameters.AddWithValue("fname", lu.Fname);
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





    } // Over Here
}
