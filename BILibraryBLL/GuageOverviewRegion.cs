﻿using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class GuageOverviewRegion
    {
        Conn con = new Conn();
        public DataTable GuageMonth_Region(String offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from mbl_guadge_01 where offcode = '"+offcode+"'";
            string sql = "select sum(t.tax) as tax, sum(t.last_tax) as last_tax, sum(t.estimate) as estimate from MBL_GUADGE_01 t where offcode = '" + offcode + "'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}