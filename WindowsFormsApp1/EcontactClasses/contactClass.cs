using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;

namespace WindowsFormsApp1.EcontactClasses
{
    public class contactClass
    {
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;


        public DataTable Search(string keyword)
        {
            // Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstring);
            // response type
            DataTable dt = new DataTable();
            try
            {
                // Writing SQL COmmand
                string sql = "SELECT * FROM tbl_contact WHERE Name LIKE '%"+keyword+ "%' OR  Address LIKE '%" + keyword + "%' OR  ContactNo LIKE '%" + keyword + "%'";
                // Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Creating Sql Aapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }
        public DataTable Select()
        {
            // Creating Database Connection
            SqlConnection conn = new SqlConnection(myconnstring);
            // response type
            DataTable dt = new DataTable();
            try
            {
                // Writing SQL COmmand
                string sql = "SELECT * FROM tbl_contact";
                // Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Creating Sql Aapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        public bool Insert(contactClass input)
        {
            bool isSuccess = false;

            // Create Database Conection

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                // sql query
                string sql = "INSERT INTO tbl_contact (Name, ContactNo, Address, Gender) VALUES (@Name, @ContactNo,@Address, @Gender)";

                // Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Create Parameters to add data

                cmd.Parameters.AddWithValue("@Name", input.Name);
                cmd.Parameters.AddWithValue("@ContactNo", input.ContactNo);
                cmd.Parameters.AddWithValue("@Address", input.Address);
                cmd.Parameters.AddWithValue("@Gender", input.Gender);

                // Open sq connection
                conn.Open();

                // Execute
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;

        }

        public bool Update(contactClass input)
        {
            bool isSuccess = false;

            // Create Database Conection

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                // sql query
                string sql = "UPDATE tbl_contact SET Name=@Name, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactId=@ContactID";

                // Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Create Parameters to add data

                cmd.Parameters.AddWithValue("@Name", input.Name);
                cmd.Parameters.AddWithValue("@ContactNo", input.ContactNo);
                cmd.Parameters.AddWithValue("@Address", input.Address);
                cmd.Parameters.AddWithValue("@Gender", input.Gender);
                cmd.Parameters.AddWithValue("@ContactId", input.ContactID);

                // Open sq connection
                conn.Open();

                // Execute
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;

        }
        public bool Delete(contactClass input)
        {
            bool isSuccess = false;

            // Create Database Conection

            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                // sql query
                string sql = "DELETE FROM tbl_contact WHERE ContactId=@ContactId";

                // Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Create Parameters to add data

                cmd.Parameters.AddWithValue("@ContactId", input.ContactID);
          
                // Open sq connection
                conn.Open();

                // Execute
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return isSuccess;

        }

    }
}
