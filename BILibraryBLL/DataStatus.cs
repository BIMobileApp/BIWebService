using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class DataStatus
    {
        Conn con = new Conn();
        public DataTable getDataStatus()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select SYSTEM_NAME AS GROP_NAME, 'ข้อมูล ณ วันที '||lpad(to_char(LAST_UPD_DATE, 'FMDD'), 2, 0) || ' ' ||
                to_char(LAST_UPD_DATE, 'FMMonth', 'NLS_DATE_LANGUAGE=THAI') || ' ' ||
                to_char(to_number(to_char(LAST_UPD_DATE, 'YYYY')) + 543)  AS DATE_AS_OF from mbl_status_data";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable DateTitle(string startMonth, string endMonth)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select  get_date_title('"+ startMonth + "','"+ endMonth + "') as date_title  from dual ";
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}