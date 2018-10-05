using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class MBLRegister
    {
        Conn con = new Conn();
        public DataTable TaxRegisterByOffcode(string offcode, string region, string province, string month_from, string month_to)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select * from(select GROUP_DESC, SUM(IMP_REGISTER) AS IMP_REGISTER,
                           SUM(IN_REGISTER) AS IN_REGISTER, SUM(TOTAL_REGISTER) AS TOTAL_REGISTER,sort
                            from mbl_register_1 
                            where offcode = " + offcode + " ";
            sql += " and Region_Name like case when '" + region + "' = 'undefined' then Region_Name else '" + region + "' end";
            sql += " and province_name like case when '" + province + "' = 'undefined' then province_name else '" + province + "' end";
            if (month_from != "undefined" && month_to != "undefined")
            {
                sql += " and MONTH_CD between " + month_from + " and " + month_to + "";
            }
            sql += " group by GROUP_DESC,sort order by sort )";

            sql += @" UNION ALL  select 'รวม' , SUM(IMP_REGISTER) AS IMP_REGISTER,
                      SUM(IN_REGISTER) AS IN_REGISTER, SUM(TOTAL_REGISTER) AS TOTAL_REGISTER,null
                      from mbl_register_1 where offcode = " + offcode + " ";
            sql += " and Region_Name like case when '" + region + "' = 'undefined' then Region_Name else '" + region + "' end";
            sql += " and province_name like case when '" + province + "' = 'undefined' then province_name else '" + province + "' end";
            if (month_from != "undefined" && month_to != "undefined")
            {
                sql += " and MONTH_CD between " + month_from + " and " + month_to + "";
            }
            sql += " and province_name like case when '" + province + "' = 'undefined' then province_name else '" + province + "' end";
            // sql += @"order by offdesc asc";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}