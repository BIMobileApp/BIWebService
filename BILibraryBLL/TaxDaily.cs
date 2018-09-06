using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class TaxDaily
    {
        Conn con = new Conn();

        public DataTable MRegion(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = "";
            if (offcode.Equals("") || offcode.Equals("undefined") || offcode.Equals("000000"))
            {
                sql = @"select  distinct region_name
                             from MBL_CD_DAILY_REPORT 
                             where OFFICODE != 000000
                             group by  region_name order by region_name";
            }
            else
            {

                sql = @"select  distinct region_name
                             from MBL_CD_DAILY_REPORT
                             where OFFICODE ='" + offcode + "' and OFFICODE != 000000" +
                               "group by  region_name order by region_name";
            }

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable MProvince(string offcode, string area)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = "";
            area = area == null ? "" : area;
            if ((offcode.Equals("") || offcode.Equals("000000") || offcode.Equals("undefined")) && (area.Equals("") || area.Equals("undefined")))
            {
                sql = @" select  distinct province_name
                        from MBL_CD_DAILY_REPORT
                        where  province_name not like 'ภาค%' 
                        group by  province_name
                        order by province_name";
            }
            else
            {

                sql = @"select  distinct province_name
                        from MBL_CD_DAILY_REPORT
                        where  province_name not like 'ภาค%'  and region_name = '" + area + "' ";
                sql += " group by  province_name order by province_name";
            }


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}