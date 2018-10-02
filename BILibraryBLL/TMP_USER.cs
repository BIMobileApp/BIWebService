using ClassLib;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class TMP_USER
    {
        Conn con = new Conn();
        public DataTable getUSER(string username)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select t.u_username as username
                                 ,t.u_password as password
                                 ,t.offdesc as offdesc
                                 ,t.username as name
                                 ,t.offcode as offcode
                                 ,trans_region(substr(to_char(t.offcode),0, 2)) AS region_desc
                                 ,trans_region_short(substr(to_char(t.offcode),0, 2)) AS region_shot
                                 ,get_last_data_date_mobile() as last_update_date
                           from TMP_USER_ROLE t 
                           where t.u_username = '" + username + "'";
            sql += " and rownum <= 1";




            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        /*public DataTable AuthenticateUser(string username, string password) {

            //OracleDataAdapter da = new OracleDataAdapter();

            OleDbConnection conn = new OleDbConnection(con.connection());
            OleDbCommand cmd = new OleDbCommand("check_user_authenticate_mobile", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Username", OracleType.VarChar).Value = username;
            cmd.Parameters.Add("password", OracleType.VarChar).Value = password;
            cmd.Parameters.Add("output", OracleType.VarChar).Direction = ParameterDirection.Output;

            //cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.ExecuteNonQuery();

           
            DataTable dt = new DataTable();
            //da.Fill(dt);


            conn.Close();

   

            return dt;
        }*/
        
        public string AuthenticateUser(string username, string password)
        {
            string resvalue = "";
            try
            {
                using (OleDbConnection conn = new OleDbConnection(con.connection()))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand("", conn))
                    {
                        cmd.CommandText = "check_user_authenticate_mobile";
                        cmd.CommandType = CommandType.StoredProcedure;
                        OleDbParameter retval = new OleDbParameter("retval", OleDbType.VarChar, 4000);

                        
                        retval.Direction = ParameterDirection.ReturnValue;

                        cmd.Parameters.Add(new OleDbParameter("Username", username));
                        cmd.Parameters.Add(new OleDbParameter("password", password));
                        cmd.Parameters.Add(retval);

                        //cmd.Parameters.AddWithValue("Username", "password");
                        cmd.ExecuteNonQuery();
                        Console.WriteLine(retval.Value.ToString());
                        resvalue = retval.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return resvalue;
        }
    }
}