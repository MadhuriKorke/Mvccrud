using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Mvccrud.Models
{
    public class BALuser
    {
     SqlConnection con=new SqlConnection("Data Source=LAPTOP-E8PFS26D;Initial Catalog=mvccrud;Integrated Security=True;Encrypt=False");

        public void save(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("mvccrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "save");
            cmd.Parameters.AddWithValue("@Name", obj.UName);
            cmd.Parameters.AddWithValue("@Address", obj.UAddress);
            cmd.ExecuteNonQuery();
            con.Close();
            

        }
        public void update(User obj) 
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("mvccrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "update");
            cmd.Parameters.AddWithValue("@id", obj.ID);
            cmd.Parameters.AddWithValue("@Name", obj.UName);
            cmd.Parameters.AddWithValue("@Address", obj.UAddress);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataSet GetUser()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("mvccrud", con);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "showdata");
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet dss = new DataSet();
            adpt.Fill(dss);
            return dss;
            con.Close();

        }

        public DataSet fetchrecord(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("mvccrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "fetchrecord");
            cmd.Parameters.AddWithValue("@id", obj.ID);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataSet dss = new DataSet();
            adpt.Fill(dss);
            return dss;
            con.Close();

        }

        public void delete(User obj)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("mvccrud", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "deleterecord");
            cmd.Parameters.AddWithValue("@id", obj.ID);
            cmd.ExecuteNonQuery();
        }


        



    }
}