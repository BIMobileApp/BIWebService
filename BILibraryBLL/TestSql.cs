using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using ClassLib;

namespace BILibraryBLL
{
    public class TestSql
    {
        Conn con = new Conn();

        public DataTable Sql1() {

            DataTable dt = new DataTable();
            using (OleDbConnection thisConnection = new OleDbConnection(con.connection()))
            {
                string sql = "select TIME_ID,DAY_NAME from cd_time_dim where rownum <= 100";

                OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
                thisConnection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}