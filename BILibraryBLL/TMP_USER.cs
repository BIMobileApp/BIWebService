using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class TMP_USER
    {
        Conn con = new Conn();
        public DataTable getUSER(string username, string password)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select t.u_username as username
                                 ,t.u_password as password
                                 ,t.offcode as offcode from TMP_USER_ROLE t 
                           where t.u_username = '" + username+"'";
                  sql += " and t.u_password = '"+password+"' and rownum <= 1";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}