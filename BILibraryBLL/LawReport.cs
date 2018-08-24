using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class LawReport
    {
        Conn con = new Conn();
        public DataTable LawReportArea(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MBL_LAW_REPORT_1 t where t.offcode ='"+ offcode+"'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable LawReportMth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_LAW_REPORT_2 t where t.offcode ='" + offcode+"'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }
    }
}