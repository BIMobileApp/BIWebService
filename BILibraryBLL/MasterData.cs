﻿using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class MasterData
    {
        Conn con = new Conn();
        public DataTable SelectionArea(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct region_name from mbl_lic_data_1_1 where offcode ='" + offcode + "' order by region_name asc";
            // string sql = @"select * from MBL_LAW_REPORT_1 t where t.offcode ='"+ offcode+"'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable SelectionProvince(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct province_name from mbl_lic_data_1_1 where offcode ='" + offcode + "' order by province_name asc";
            // string sql = @"select * from MBL_LAW_REPORT_1 t where t.offcode ='"+ offcode+"'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable SelectionGroupName(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct group_desc from mbl_lic_data_1_1 where offcode ='" + offcode + "' order by group_desc asc";
            // string sql = @"select * from MBL_LAW_REPORT_1 t where t.offcode ='"+ offcode+"'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }



    }
}