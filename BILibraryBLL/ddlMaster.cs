using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class DDLMaster
    {
        Conn con = new Conn();
        public DataTable MRegion(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = "";
            if (offcode.Equals("") || offcode.Equals("undefined") || offcode.Equals("000000"))
            {
                sql = @"select  region_cd ,region_name_mobile AS region_name
                             from IC_OFFICE_DIM_MBL 
                             where region_cd != 000000
                             group by  region_cd ,region_name_mobile order by region_cd";
            }else {

                sql = @"select  region_cd ,region_name_mobile AS region_name
                             from IC_OFFICE_DIM_MBL
                             where offcode ='" + offcode + "' and region_cd != 000000" +
                               "group by  region_cd ,region_name_mobile order by region_cd"; 
            }

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection); 
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable MProvince(string offcode,string area)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = "";
            area = area == null ? "" : area ;
            if ((offcode.Equals("") || offcode.Equals("000000") || offcode.Equals("undefined")) &&  (area.Equals("")  || area.Equals("undefined")))
            {
                sql  = @"  select  distinct province_cd,province_name
                             from IC_OFFICE_DIM_MBL
                             where  province_name not like 'ภาค%' and province_cd != 000000 
                             group by province_cd,province_name
                             order by province_cd";
                                        }
            else
            {

                sql = @"select distinct province_cd,province_name
                             from IC_OFFICE_DIM_MBL
                             where  province_name not like 'ภาค%'  
                             and region_name_mobile ='" + area + "' " +
                             "group by province_cd,province_name "+
                             "order by province_name";
            }
            

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection); 
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable ddlBranch(string area, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select province_name, offdesc from IC_OFFICE_DIM_MBL WHERE region_name = '" + area+ "' and province_name = '" + province + "'";
            
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable MBrach(string offcode, string area)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = "";
            if ((offcode.Equals("") || offcode.Equals("000000") || offcode.Equals("undefined")) && (area.Equals("") || area.Equals("undefined")))
            {
                        sql = @"select offcode,offdesc
                                     from IC_OFFICE_DIM_MBL 
                                     where offdesc not like 'ภาค%' 
                                     group by offcode,offdesc
                                     order by length(offdesc),offcode";
            }
            else
            {

                sql = @"select offcode,offdesc
                                     from IC_OFFICE_DIM_MBL 
                                     where offdesc not like 'ภาค%'
                                     and  region_cd='" + offcode + "' and province_cd='"+ area + "' "+
                                     "group by offcode,offdesc "+
                                    " order by length(offdesc),offcode";
            }

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        
        public DataTable MMonth()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = @"SELECT DISTINCT(T.MONTH_CD), T.MONTH_DESC,T.BUDGET_MONTH_CD FROM IC_TIME_DIM T ORDER BY T.BUDGET_MONTH_CD";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}