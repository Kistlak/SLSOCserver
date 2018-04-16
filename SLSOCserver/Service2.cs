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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in both code and config file together.
    public class Service2 : IService2
    {
        public Service2()
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
                cmd.CommandText = "INSERT INTO modules(modcode,modname,lecname,fac) VALUES (@mc,@mn,@l,'Computing')";
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
                cmd.CommandText = "SELECT id AS 'Explorer',modcode AS 'Mode Code',modname AS 'Mode Name',lecname AS 'Lec Name' FROM modules";
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
                cmd.CommandText = "UPDATE modules set modcode=@mc, modname=@mn, lecname=@ln, fac='Computing' WHERE modcode=@mc";
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

    } // Over Here
}
