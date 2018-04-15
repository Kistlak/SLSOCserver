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
                cmd.CommandText = "INSERT INTO modules(modcode,modname,lecname) VALUES (@mc,@mn,@l)";
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


    } // Over Here
}
