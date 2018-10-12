using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class DimansionTime
    {
        Conn con = new Conn();

        public DataTable DimansionTime03(string offcode, string region, string province, string month_from, string month_to)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select * from (select ROW_NUMBER() OVER(ORDER BY sort asc) as row_num, sort,GROUP_NAME,SUM(IN_TAX_AMT) AS IN_TAX_AMT,SUM(IMPORT_TAX_AMT) AS IMPORT_TAX_AMT,SUM(TAX) AS TAX,ROW_NUMBER() OVER(ORDER BY sort asc) as sort_by
                            from MBL_IN_OUT_MONTH_01 WHERE OFFCODE = " + offcode + " ";
            //sql += " and BUDGET_MONTH_DESC like case when '" + month + "' = 'undefined' then BUDGET_MONTH_DESC else '" + month + "' end";
            sql += " and REGION_NAME like case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " and PROVINCE_NAME like case when '" + province + "' = 'undefined' then PROVINCE_NAME else '" + province + "' end";
            if (month_from != "undefined" && month_to != "undefined")
            {
                sql += " and BUDGET_MONTH_CD between " + month_from + " and " + month_to + "";
            }
            sql += " group by GROUP_NAME,sort ";
            sql += " union all select null,null,'รวม',SUM(IN_TAX_AMT) AS IN_TAX_AMT,SUM(IMPORT_TAX_AMT) AS IMPORT_TAX_AMT,SUM(TAX) AS TAX,100000  AS sort_by";
            sql += " from MBL_IN_OUT_MONTH_01 WHERE OFFCODE = " + offcode + " ";
            if (month_from != "undefined" && month_to != "undefined")
            {
                sql += " and BUDGET_MONTH_CD between " + month_from + " and " + month_to + "";
            }
            //sql += " and BUDGET_MONTH_DESC like case when '" + month + "' = 'undefined' then BUDGET_MONTH_DESC else '" + month + "' end";
            sql += " and REGION_NAME like case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " and PROVINCE_NAME like case when '" + province + "' = 'undefined' then PROVINCE_NAME else '" + province + "' end  ) t order by sort_by";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}