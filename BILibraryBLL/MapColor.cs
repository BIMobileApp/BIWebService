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

            string sql = @"select region_name,MAP_COLOR,SUM(tax) AS tax,SUM(estimate) AS estimate,SUM(last_tax) AS last_tax
                            ,SUM(PERCENT_TAX) AS PERCENT_TAX
                            from m_rep01_map_thailand
                            WHERE budget_year = '"+ budget_year + "' GROUP BY region_name,MAP_COLOR order by region_name";

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

            string sql = @"select BUDGET_YEAR,REGION_NAME,PROVINCE_NAME,TAX,ESTIMATE,LAST_TAX,PERCENT_TAX,MAP_COLOR,DEPT_FLAG,AREA_FLAG 
                            from M_REP01_MAP_REG t 
                            where area_flag = '"+ region + "' and budget_year = '"+ budget_year + "'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


    }
}