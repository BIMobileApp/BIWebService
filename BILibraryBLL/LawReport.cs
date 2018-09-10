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
            thisConnection.Close();
            return dt;
        }

        public DataTable LawProductAreaAll(string offcode,string group_name)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from ( select TYPE_DESC, SUM(LAW_QTY) AS LAW_QTY, SUM(TARGET_QTY) AS TARGET_QTY,SUM(LAW_AMT) AS LAW_AMT
                        , SUM(TARGET_AMT) AS TARGET_AMT,SUM(TREASURY_MONEY) AS TREASURY_MONEY from MBL_LAW_REPORT_1_1 ";
                   sql += " where offcode ='" + offcode + "' and GROUP_DESC = '"+ group_name + "' GROUP BY TYPE_DESC";

            sql += " union all select 'รวม',SUM(LAW_QTY) AS LAW_QTY,SUM(TARGET_QTY) AS TARGET_QTY,SUM(LAW_AMT) AS LAW_AMT, ";
            sql += " SUM(TARGET_AMT) AS TARGET_AMT,SUM(TREASURY_MONEY) AS TREASURY_MONEY from MBL_LAW_REPORT_1_1 ";
            sql += " where offcode = '" + offcode + "' and GROUP_DESC = '" + group_name + "') t ORDER BY t.TYPE_DESC";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable LawProductByArea(string offcode, string region, string province, string group_desc)
        {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TYPE_DESC, SUM(LAW_QTY) AS LAW_QTY, SUM(TARGET_QTY) AS TARGET_QTY,SUM(LAW_AMT) AS LAW_AMT
                        , SUM(TARGET_AMT) AS TARGET_AMT,SUM(TREASURY_MONEY) AS TREASURY_MONEY from MBL_LAW_REPORT_1_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " AND GROUP_DESC = case when '" + group_desc + "' = 'undefined' then GROUP_DESC else '" + group_desc + "' end   ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " GROUP BY TYPE_DESC ";
            sql += " ORDER BY TYPE_DESC";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
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
            thisConnection.Close();
            return dt;
        }

        public DataTable LawProductByMthAll(string offcode, string group_name)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from (select TYPE_DESC, SUM(LAW_QTY) AS LAW_QTY, SUM(TARGET_QTY) AS TARGET_QTY";
            sql += " , SUM(LAW_AMT) AS LAW_AMT,SUM(TARGET_AMT) AS TARGET_AMT,SUM(TREASURY_MONEY) AS TREASURY_MONEY from MBL_LAW_REPORT_2_1 ";
            sql += " WHERE offcode = " + offcode + " and GROUP_DESC = '" + group_name + "' GROUP BY TYPE_DESC ";
            sql += " union all select 'รวม', SUM(LAW_QTY) AS LAW_QTY, SUM(TARGET_QTY) AS TARGET_QTY";
            sql += " , SUM(LAW_AMT) AS LAW_AMT,SUM(TARGET_AMT) AS TARGET_AMT,SUM(TREASURY_MONEY) AS TREASURY_MONEY";
            sql += " from MBL_LAW_REPORT_2_1  WHERE offcode = " + offcode + "  and GROUP_DESC = '" + group_name + "' )  t  ";
            sql += " ORDER BY t.TYPE_DESC";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable LawProductByMth(string offcode, string region, string province, string group_desc)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from (select TYPE_DESC, SUM(LAW_QTY) AS LAW_QTY, SUM(TARGET_QTY) AS TARGET_QTY ";
            sql += " , SUM(LAW_AMT) AS LAW_AMT,SUM(TARGET_AMT) AS TARGET_AMT,SUM(TREASURY_MONEY) AS TREASURY_MONEY ";
            sql += " from MBL_LAW_REPORT_2_1  ";
            sql += " WHERE offcode = 000000  and GROUP_DESC = 'สุรา' ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " GROUP BY TYPE_DESC ";
            sql += " union all select 'รวม', SUM(LAW_QTY) AS LAW_QTY, SUM(TARGET_QTY) AS TARGET_QTY";
            sql += " , SUM(LAW_AMT) AS LAW_AMT, SUM(TARGET_AMT) AS TARGET_AMT, SUM(TREASURY_MONEY) AS TREASURY_MONEY";
            sql += " from MBL_LAW_REPORT_2_1 ";
            sql += " WHERE offcode = 000000 ";
            sql += " AND PROVINCE_NAME = case when '" + province + "' = 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end ";
            sql += " and GROUP_DESC = 'สุรา' )  t ORDER BY t.TYPE_DESC ";

           OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


    }
}