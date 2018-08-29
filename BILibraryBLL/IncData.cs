using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class IncData
    {
        Conn con = new Conn();

        public DataTable IncDataByArea(string offcode)
        {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

           string sql = "select REGION_DESC,NUM_OF_LIC_SURA,NUM_OF_LIC_TOBBACO,NUM_OF_LIC_CARD,AMT_OF_LIC_SURA, ";
                   sql += " AMT_OF_LIC_TOBBACO,AMT_OF_LIC_CARD ";
                   sql += " from MBL_LIC_DATA where  offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncProductByArea(string offcode, string region, string province, string group_desc) {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TYPE_DESC, SUM(LICENSE_AMT) AS amt, SUM(LICENSE_COUNT) count from mbl_lic_data_1_1 ";
            sql += " WHERE offcode = " + offcode + "  AND GROUP_DESC = '" + group_desc + "' ";
            sql += " AND PROVINCE_NAME = '" + province + "' and REGION_NAME = '" + region + "'";
            sql += " GROUP BY TYPE_DESC ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncProductByAreaAll(string offcode)
        {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TYPE_DESC, SUM(LICENSE_AMT) AS amt, SUM(LICENSE_COUNT) count from mbl_lic_data_1_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " GROUP BY TYPE_DESC ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncDataByMonth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select MONTH_DESC,NUM_OF_LIC_SURA,NUM_OF_LIC_TOBBACO,NUM_OF_LIC_CARD,AMT_OF_LIC_SURA, ";
                   sql += " AMT_OF_LIC_TOBBACO,AMT_OF_LIC_CARD ";
                   sql += " from MBL_LIC_DATA_2 where  offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncDataByAreaDetail(string offcode) {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select MONTH_DESC,NUM_OF_LIC_SURA,NUM_OF_LIC_TOBBACO,NUM_OF_LIC_CARD,AMT_OF_LIC_SURA, ";
            sql += " AMT_OF_LIC_TOBBACO,AMT_OF_LIC_CARD ";
            sql += " from MBL_LIC_DATA_2 where  offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncProductByMthAll(string offcode) {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TYPE_DESC,SUM(LICENSE_AMT) AS AMT,SUM(LICENSE_COUNT) AS COUNT from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " GROUP BY TYPE_DESC ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncProductByMth(string offcode, string region, string province, string group_desc,string mth)
        {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TYPE_DESC, SUM(LICENSE_AMT) AS amt, SUM(LICENSE_COUNT) count from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + "  AND GROUP_DESC = '" + group_desc + "' ";
            sql += " AND PROVINCE_NAME = '" + province + "' and REGION_NAME = '" + region + "' AND BUDGET_MONTH_DESC = "+ mth + "";
            sql += " GROUP BY TYPE_DESC ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}