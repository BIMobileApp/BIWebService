using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class MapColor
    {
        Conn con = new Conn();
        public DataTable MapColorThailand(string budget_year)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select region_name,region_name_en,MAP_COLOR,SUM(tax) AS tax,SUM(estimate) AS estimate,SUM(last_tax) AS last_tax
                            ,SUM(PERCENT_TAX) AS PERCENT_TAX
                            from vw_mbl_map
                            WHERE budget_year = '" + budget_year + "' and dept_flag  = 0 GROUP BY region_name,MAP_COLOR,region_name_en order by region_name";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable MapColorRegion(string budget_year, string region)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select BUDGET_YEAR,REGION_NAME,PROVINCE_NAME,TAX,ESTIMATE,LAST_TAX,PERCENT_TAX,MAP_COLOR,DEPT_FLAG,AREA_FLAG ,PROVINCE_NAME_EN
                            from vw_mbl_region t 
                            where area_flag = '" + region + "' and budget_year = '"+ budget_year + "'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


    }
}