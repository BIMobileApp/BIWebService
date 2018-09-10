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
                sql = @"select  region_cd ,region_name
                             from ic_office_dim 
                             where region_cd != 000000
                             group by  region_cd ,region_name order by region_cd";
            }else {

                sql = @"select  region_cd ,region_name
                             from ic_office_dim
                             where offcode ='" + offcode + "' and region_cd != 000000" +
                               "group by  region_cd ,region_name order by region_cd"; 
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
                sql  = @"  select  province_cd,province_name
                             from ic_office_dim
                             where  province_name not like 'ภาค%' and province_cd != 000000 
                             group by province_cd,province_name
                             order by province_cd";
                                        }
            else
            {

                sql = @"select province_cd,province_name
                             from ic_office_dim
                             where  province_name not like 'ภาค%'  
                             and region_name='" + area + "' " +
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


        public DataTable MBrach(string offcode, string area)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = "";
            if ((offcode.Equals("") || offcode.Equals("000000") || offcode.Equals("undefined")) && (area.Equals("") || area.Equals("undefined")))
            {
                        sql = @"select offcode,offdesc
                                     from ic_office_dim 
                                     where offdesc not like 'ภาค%' 
                                     group by offcode,offdesc
                                     order by length(offdesc),offcode";
            }
            else
            {

                sql = @"select offcode,offdesc
                                     from ic_office_dim 
                                     where offdesc not like 'ภาค%'
                                     and  region_cd='"+ offcode + "' and province_cd='"+ area + "' "+
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
      

    }
}