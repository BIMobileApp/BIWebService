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

           string sql = "select * from(select REGION_DESC,NUM_OF_LIC_SURA,NUM_OF_LIC_TOBBACO,NUM_OF_LIC_CARD,AMT_OF_LIC_SURA, ";
                   sql += " AMT_OF_LIC_TOBBACO,AMT_OF_LIC_CARD ";
                   sql += " from MBL_LIC_DATA where  offcode = " + offcode + " ORDER BY REGION_DESC) ";
                sql += " union all select 'รวม',sum(NUM_OF_LIC_SURA),sum(NUM_OF_LIC_TOBBACO),sum(NUM_OF_LIC_CARD),sum(AMT_OF_LIC_SURA),sum(AMT_OF_LIC_TOBBACO),sum(AMT_OF_LIC_CARD)";
                sql += " from MBL_LIC_DATA where offcode = "+ offcode + "";
   

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncProductByArea(string offcode, string region, string province, string group_desc, string month) {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from (select TYPE_DESC, SUM(LICENSE_AMT) AS amt, SUM(LICENSE_COUNT) AS count from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " AND GROUP_DESC = case when '" + group_desc + "' = 'undefined' then GROUP_DESC else '" + group_desc + "' end   ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " AND budget_month_desc = case when '" + month + "' = 'undefined' then budget_month_desc else '" + month + "' end";
            sql += " GROUP BY TYPE_DESC ";
            sql += " ORDER BY TYPE_DESC )";
            sql += " union all select 'รวม',sum(LICENSE_AMT),sum(LICENSE_COUNT) from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " AND GROUP_DESC = case when '" + group_desc + "' = 'undefined' then GROUP_DESC else '" + group_desc + "' end ";
            sql += " AND PROVINCE_NAME = case when '" + province + "' = 'undefined' then PROVINCE_NAME else '" + province + "' end";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end" ;
            sql += " AND budget_month_desc = case when '" + month + "' = 'undefined' then budget_month_desc else '" + month + "' end";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncProductByAreaAll(string offcode, string group_name)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from (select TYPE_DESC, SUM(LICENSE_AMT) AS amt, SUM(LICENSE_COUNT) AS count from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " AND GROUP_DESC = case when '" + group_name + "' = 'undefined' then GROUP_DESC else '" + group_name + "' end   ";
            sql += " GROUP BY TYPE_DESC ";
            sql += " union all select 'รวม',sum(LICENSE_AMT),sum(LICENSE_COUNT) from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " AND GROUP_DESC = case when '" + group_name + "' = 'undefined' then GROUP_DESC else '" + group_name + "' end ) ";    

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
                   sql += " from MBL_LIC_DATA_2 where  offcode = " + offcode + " ORDER BY TIME_ID asc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable IncSumDataByMonth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select Sum(NUM_OF_LIC_SURA) AS NUM_OF_LIC_SURA,SUM(NUM_OF_LIC_TOBBACO) AS NUM_OF_LIC_TOBBACO
, SUM(NUM_OF_LIC_CARD) AS NUM_OF_LIC_CARD, SUM(AMT_OF_LIC_SURA) AS AMT_OF_LIC_SURA,
  SUM(AMT_OF_LIC_TOBBACO) AS AMT_OF_LIC_TOBBACO, SUM(AMT_OF_LIC_CARD) AS AMT_OF_LIC_CARD ";

            sql += " from MBL_LIC_DATA_2 where  offcode = " + offcode + " ORDER BY TIME_ID asc";

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
            sql += " from MBL_LIC_DATA_2 where  offcode = " + offcode + " ORDER BY TIME_ID asc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncProductByMthAll(string offcode,string group_name) {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select BUDGET_MONTH_DESC,TIME_ID,SUM(LICENSE_AMT) AS AMT,SUM(LICENSE_COUNT) AS COUNT from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + " and GROUP_DESC = '"+ group_name + "'";
            sql += " GROUP BY BUDGET_MONTH_DESC,TIME_ID ORDER BY TIME_ID ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncProductByMth(string offcode, string region, string province, string month, string group_name)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select * from (select TYPE_DESC, SUM(LICENSE_AMT) AS amt, SUM(LICENSE_COUNT) count from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " AND GROUP_DESC = case when '" + group_name + "' = 'undefined' then GROUP_DESC else '" + group_name + "' end   ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND BUDGET_MONTH_DESC = case when '" + month + "' = 'undefined' then BUDGET_MONTH_DESC else '" + month + "' end";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            //sql += " AND PROVINCE_NAME = nvl('" + province + "',PROVINCE_NAME) and REGION_NAME = nvl('" + region + "',REGION_NAME) AND BUDGET_MONTH_DESC = nvl('" + mth + "',BUDGET_MONTH_DESC)";
            sql += " GROUP BY TYPE_DESC order by TYPE_DESC)";
            sql += " union all";
            sql += " select 'รวม', SUM(LICENSE_AMT) AS amt, SUM(LICENSE_COUNT) count from mbl_lic_data_2_1 WHERE offcode = " + offcode + "";
            sql += " AND GROUP_DESC = case when '" + group_name + "' = 'undefined' then GROUP_DESC else '" + group_name + "' end   ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND BUDGET_MONTH_DESC = case when '" + month + "' = 'undefined' then BUDGET_MONTH_DESC else '" + month + "' end";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
          

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable IncSumProductByMth(string offcode, string region, string province, string type_name, string group_name)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select SUM(LICENSE_AMT) AS amt, SUM(LICENSE_COUNT) count from mbl_lic_data_2_1 ";
            sql += " WHERE offcode = " + offcode + " ";
            sql += " AND GROUP_DESC = case when '" + group_name + "' = 'undefined' then GROUP_DESC else '" + group_name + "' end   ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND TYPE_DESC = case when '" + type_name + "' = 'undefined' then TYPE_DESC else '" + type_name + "' end";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}