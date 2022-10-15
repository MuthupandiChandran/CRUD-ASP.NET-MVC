using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using System.Data;

namespace Nivi.Models.Repository
{
    public class Dal
    {
       private readonly SqlConnection con = new SqlConnection("data source=az-east-misql001-devtest.30b14f905684.database.windows.net;initial catalog=Trainee;User ID=appuserdev;Password=Dev@pps@2019");
       
       public List<Customer> GetDataList()
        {
            List<Customer> lst = new List<Customer>();
            SqlCommand cmd = new SqlCommand("sp_selectt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                lst.Add(new Customer{
                    id = Convert.ToInt32(dr[0]),
                    FirstName = Convert.ToString(dr[1]),
                    LastName = Convert.ToString(dr[2]),
                    DOB = Convert.ToDateTime(dr[3]),
                    Gender = Convert.ToString(dr[4]),
                    Email = Convert.ToString(dr[5]),
                    occupation =Convert.ToString(dr[6]),
                });
            }

            return lst;
        }
        public bool InsertData(Customer ur)
        {
            int i;
                SqlCommand cmd = new SqlCommand("sp_insertt", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ur.id);
                cmd.Parameters.AddWithValue("@FirstName", ur.FirstName);
                cmd.Parameters.AddWithValue("@LastName", ur.LastName);
                cmd.Parameters.AddWithValue("@DOB", ur.DOB);
                cmd.Parameters.AddWithValue("@Gender", ur.Gender);
                cmd.Parameters.AddWithValue("@Email", ur.Email);
                cmd.Parameters.AddWithValue("@occupation", ur.occupation);

                con.Open();
                i = cmd.ExecuteNonQuery();
                con.Close();
            if(i>=1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateData(Customer ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_update", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            cmd.Parameters.AddWithValue("@FirstName", ur.FirstName);
            cmd.Parameters.AddWithValue("@LastName", ur.LastName);
            cmd.Parameters.AddWithValue("@DOB", ur.DOB);
            cmd.Parameters.AddWithValue("@Gender", ur.Gender);
            cmd.Parameters.AddWithValue("@Email", ur.Email);
            cmd.Parameters.AddWithValue("@occupation", ur.occupation);
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteData(Customer ur)
        {
            int i;
            SqlCommand cmd = new SqlCommand("sp_delete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ur.id);
            
            con.Open();
            i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
 }
