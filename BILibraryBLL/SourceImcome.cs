using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using ClassLib;
using System.Data;

namespace BILibraryBLL
{
    public class SourceImcome
    {
        Conn con = new Conn();

        public DataTable IncomeList(string offcode,string region, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select * from (select goods as group_name,SUM(nettax_amt) AS tax,ROW_NUMBER() OVER (ORDER BY sort) as sort ";
                   sql += "  from MBL_INC_REAL_TIME where offcode = " + offcode + "";
                    if (region != "EEC")
                    {
                        sql += " and REGION_NAME like case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
                    }
                    else
                    {
                        sql += " and eec_flag = 'EEC'";
                    }
                   
                    sql += " AND PROVINCE_NAME = case when '" + province + "' = 'undefined' then PROVINCE_NAME else '" + province + "' end group by goods,sort";
                    sql += @" union all select 'รวม', SUM(nettax_amt) AS tax,null from MBL_INC_REAL_TIME where offcode = " + offcode + " ";
                    if (region != "EEC")
                    {
                        sql += " and REGION_NAME like case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
                    }
                    else
                    {
                        sql += " and eec_flag = 'EEC'";
                    }
                    sql += " AND PROVINCE_NAME = case when '" + province + "' = 'undefined' then PROVINCE_NAME else '" + province + "' end";
                    sql += " ) t order by sort";
            /*string sql = @"select ROW_NUMBER() OVER (ORDER BY  b.group_name) as sort,
                    b.group_name,sum(a.tax_nettax_amt) as tax,sum(a.last_tax_nettax_amt) as tax_ly
             from ic_sum_allday_cube a
                  ,ic_product_grp_dim b
                  , ic_office_dim c
                  ,ic_time_dim d
                  , ic_time_dim d2
             where a.product_grp_cd = b.group_id
              and a.offcode_own = c.offcode
              and a.time_id = d.time_id
              and d.budget_year = d2.budget_year
              and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
              and a.product_grp_cd in (0201, 0501, 7002, 7001)
             group by b.group_name
             order by b.group_name";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;

        }

        public DataTable SumIncomeList(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select sum(nettax_amt) AS sum_tax from MBL_INC_REAL_TIME where offcode = " + offcode + " ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

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