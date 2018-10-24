using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class IncMasterData
    {
        Conn con = new Conn();
        public DataTable SelectionArea(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct region_name from mbl_lic_data_2_1 where offcode ='" + offcode + "' order by region_name asc";
            // string sql = @"select * from MBL_LAW_REPORT_1 t where t.offcode ='"+ offcode+"'";
            string sql = "";
            if (offcode.Equals("") || offcode.Equals("undefined") || offcode.Equals("000000"))
            {
                sql = @"select  region_cd ,region_name_mobile AS region_name
                             from IC_OFFICE_DIM_MBL 
                             where region_cd != 000000
                             group by  region_cd ,region_name_mobile order by region_cd";
            }
            else
            {

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

        public DataTable SelectionAllProvince(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct province_name from mbl_lic_data_2_1 where offcode ='" + offcode + "' order by province_name asc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable SelectionProvince(string offcode,string area)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct province_name from mbl_lic_data_2_1 where offcode ='" + offcode + "' and region_name = '" + area + "' order by province_name asc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection); 
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable SelectionGroupName(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct group_desc from mbl_lic_data_2_1 where offcode ='" + offcode + "' order by group_desc asc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable SelectionProvinceChange(string offcode, string region) {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct group_desc from mbl_lic_data_2_1 where offcode ='" + offcode + "'";
                    sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
                    sql += " order by group_desc asc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }



        public DataTable SelectionMthArea(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct region_name from mbl_lic_data_2_1 where offcode ='" + offcode + "' order by region_name asc";
            string sql = "";
            if (offcode.Equals("") || offcode.Equals("undefined") || offcode.Equals("000000"))
            {
                sql = @"select  region_cd ,region_name_mobile AS region_name
                             from IC_OFFICE_DIM_MBL 
                             where region_cd != 000000
                             group by  region_cd ,region_name_mobile order by region_cd";
            }
            else
            {

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

        public DataTable SelectionMthProvince(string offcode, string region)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct province_name from mbl_lic_data_2_1 ";
            //       sql += " where offcode ='" + offcode + "' and REGION_NAME = '"+ region + "' order by province_name asc";
            string sql = "";
            region = region == null ? "" : region;
            if ((offcode.Equals("") || offcode.Equals("000000") || offcode.Equals("undefined")) && (region.Equals("") || region.Equals("undefined")))
            {
                sql = @"  select  distinct province_cd,province_name
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
                             and region_name_mobile ='" + region + "' " +
                             "group by province_cd,province_name " +
                             "order by province_name";
            }

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable SelectionMthGroupName(string offcode, string group_name)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct TYPE_DESC from mbl_lic_data_2_1 where offcode ='" + offcode + "' and GROUP_DESC = '"+ group_name + "' order by TYPE_DESC asc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection); 
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


    }
}