using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UI_Testing_2
{

    class DB_connetions
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        private static string user_ID;
        private static string user_name;
        private static int Auth_level;
        int chk;

        public DB_connetions()
        {
            con = new SqlConnection("Data Source=DESKTOP-TF1RLQU;Initial Catalog=GAD_Testing;Integrated Security=True");

        }

        public int Check_Login(string user, string pass)
        {
            int chk;
            try
            {
                
                con.Open();
                da = new SqlDataAdapter();
                cmd = new SqlCommand("Select * from System_logins where User_name='" + user + "'  and User_Password='" + pass + "'", con);
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                DataSet data = new DataSet();
                da.Fill(data);
                if (data.Tables[0].Rows.Count > 0)
                {
                    chk = 1;
                    user_ID = data.Tables[0].Rows[0]["User_ID"].ToString();
                    user_name = data.Tables[0].Rows[0]["User_name"].ToString();
                    Auth_level = Convert.ToInt16(data.Tables[0].Rows[0]["Auth_Level"]);
                }
                else
                    chk = 0;
                con.Close();
            }
            catch (SqlException)
            {
                chk = 2;
            }
            catch (Exception)
            {
                chk = 3;
            }
            return chk;
        }

        public string username()
        {
            return user_name;
        }

        public string user()
        {
            return user_ID;
        }
        public int Auth()
        {
            return Auth_level;
        }

        /// <summary>
        /// This can use to extract a WHOLE TABLE
        /// Use getMessage to get errors. retuns int
        /// 2 - SQLExseption 3 - for Any Other error
        /// </summary>
        /// <param name="tablename(SQL)"></param>
        /// <returns></returns>
        public DataTable ConSelect(string table)
        {
            chk = 0;
            DataTable dt = new DataTable();
            try { 
                da = new SqlDataAdapter();
                con.Open();
                cmd = new SqlCommand("Select * from '" + table + "'", con);
                da.SelectCommand = cmd;
                da.Fill(dt);
                con.Close();
            }
            catch (SqlException)
            {
                chk = 1;
            }
            catch(Exception)
            {
                chk = 2;
            }
            return dt;
        }

        public int getMessage()
        {
            return chk;
        }
               
        /// <summary>
        /// This can use to extract a TABLE with filtered Data.
        /// Use getMessage to get errors. retuns int.
        /// 2 - SQLExseption 3 - for Any Other error
        /// </summary>
        /// <param name="tablename(SQL)"></param>
        /// <param name="selectby(SQL)"></param>
        /// <param name="selecttype(SQL)"></param>
        /// <returns></returns>
        public DataTable ConSelect(string table, string select1, string selecttype1)
        {
            DataTable dt = new DataTable();
            try
            {
                da = new SqlDataAdapter();
                con.Open();
                cmd = new SqlCommand("Select * from '" + table + "' where "+ selecttype1 + "='" + select1 + "'", con);
                da.SelectCommand = cmd;
                da.Fill(dt);
                con.Close();
                chk = 1;
            }
            catch (SqlException)
            {
                chk = 2;
            }
            catch(Exception)
            {
                chk = 3;
            }

            return dt;
        }

        /// <summary>
        /// Please Use '' before and after when adding details.
        /// </summary>
        /// <param name="tablename(SQL)"></param>
        /// <param name="alldetails(SQL)"></param>
        /// <returns></returns>
        public int ConSave(string table, string alldetails)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Insert into " + table + " values (" + alldetails + ")", con);
                chk = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException)
            {
                chk = 2;
            }
            catch (Exception)
            {
                chk = 3;
            }

            return chk;
        }

        /// <summary>
        /// This can only add one data for tables
        /// </summary>
        /// <param name="table"></param>
        /// <param name="detailtype_1"></param>
        /// <param name="detail_1"></param>
        /// <returns></returns>
        public int ConSave(string table, string detailtype_1, string detail_1)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Insert into " + table +" ('" + detailtype_1 + "') values ('"+ detail_1+"'); ", con);
                chk = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException)
            {
                chk = 2;
            }
            catch (Exception)
            {
                chk = 3;
            }

            return chk;
        }


        /// <summary>
        /// This can only add two data for tables
        /// </summary>
        /// <param name="table"></param>
        /// <param name="detailtype_1"></param>
        /// <param name="detail_1"></param>
        /// <returns></returns>
        public int ConSave(string table, string detailtype_1, string detail_1,string detailtype_2, string detail_2)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Insert into " + table + " ('" + detailtype_1 + "','" + detailtype_2 + "') values ('" + detail_1 + "','" + detail_2 + "'); ", con);
                chk = cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException)
            {
                chk = 2;
            }
            catch (Exception)
            {
                chk = 3;
            }

            return chk;
        }
    }
}
