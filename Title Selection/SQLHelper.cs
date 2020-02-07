using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Title_Selection
{
    public static class SQLHelper
    {
        public const string connectionString = "Data Source=.\\SQL2008R2;Initial Catalog=dbTitleSelection;Integrated Security=True";
        //public const string connectionString = "Server=IT-Dep03;Initial Catalog = dbTitleSelection; User ID = TitleSelector; Password=xMr{Km8<sWc#7a]B;Persist Security Info=False;Encrypt=True;TrustServerCertificate=True";

        public static DataTable ListOfThemes()
        {
            try
            {
                DataTable dt = default(DataTable);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from dbTitleSelection.dbo.GetListOfThemes()";
                        //cmd.CommandText = "EXEC Client.FindUnExistanceInECR @ID_List";
                        //cmd.Parameters.Add("ID_List", SqlDbType.NVarChar).Value = idList;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                        cnn.Close();
                    }
                }
                return dt;
            }
            catch
            {
                return null;
            }
        }

        public static void SelectTheme(int id, string firstName, string lastName, string middleName, DateTime date)
        {
            //try
            {
                //DataTable dt = default(DataTable);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "dbo.SelectTheme";
                        //cmd.CommandText = "EXEC Client.FindUnExistanceInECR @ID_List";
                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                        cmd.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstName;
                        cmd.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastName;
                        cmd.Parameters.Add("@middleName", SqlDbType.NVarChar).Value = middleName;
                        cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
                        cmd.ExecuteNonQuery();
                        //using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        //{
                        //    dt = new DataTable();
                        //    da.Fill(dt);
                        //}
                    }
                }

            }
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    throw;
            //}
        }

        public static bool CheckIPExistance(string ip)
        {
            try
            {
                DataTable dt = default(DataTable);
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = cnn;
                        cmd.CommandType = CommandType.Text;
                        //cmd.CommandText = "select * from dbTitleSelection.dbo.GetListOfThemes()";
                        cmd.CommandText = "EXEC CheckIPExistance @ip";
                        cmd.Parameters.Add("IP", SqlDbType.VarChar).Value = ip;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            dt = new DataTable();
                            da.Fill(dt);
                        }
                        cnn.Close();
                    }
                }
                return Convert.ToBoolean(dt);
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
