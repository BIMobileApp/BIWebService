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
        public DataTable TaxRegisterByOffcode(string offcode, string region, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select GROUP_DESC, SUM(IMP_REGISTER) AS IMP_REGISTER,SUM(IN_REGISTER) AS IN_REGISTER,
  SUM(IN_REGISTER) AS IN_REGISTER, SUM(TOTAL_REGISTER) AS TOTAL_REGISTER
                            from mbl_register_1 
                            where offcode = " + offcode + " ";
            sql += " and Region_Name like case when '" + region + "' = 'undefined' then Region_Name else '" + region + "' end";
            sql += " and province_name like case when '" + province + "' = 'undefined' then province_name else '" + province + "' end";
            sql += " group by GROUP_DESC";
            sql += @" UNION ALL  select 'รวม' , SUM(IMP_REGISTER) AS IMP_REGISTER,SUM(IN_REGISTER) AS IN_REGISTER,
      SUM(IN_REGISTER) AS IN_REGISTER, SUM(TOTAL_REGISTER) AS TOTAL_REGISTER
      from mbl_register_1 where offcode = " + offcode + " ";
            sql += " and Region_Name like case when '" + region + "' = 'undefined' then Region_Name else '" + region + "' end";
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