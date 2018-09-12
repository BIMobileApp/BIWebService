using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class TaxRealtime
    {
        Conn con = new Conn();

        public DataTable FollowPayTaxRealtimeAll(string offcode, string region, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select DIM_DATA_DATE_ID, SUM(FZ_EXCISE_AMT) AS FZ_EXCISE_AMT,
                       SUM(IN_EXCISE_AMT) AS IN_EXCISE_AMT,
                       SUM(STAMP_AMT) AS STAMP_AMT,
                       SUM(EXCISE_AMT) AS EXCISE_AMT
                     from mbl_cd_daily_report where officode = " + offcode + " ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " AND PROVINCE_NAME = case when '" + province + "' = 'undefined' then PROVINCE_NAME else '" + province + "' end";
            sql += @" group by DIM_DATA_DATE_ID order by DIM_DATA_DATE_ID, FZ_EXCISE_AMT,IN_EXCISE_AMT,IN_EXCISE_AMT,STAMP_AMT,EXCISE_AMT desc";

            /*string sql = @"SELECT TB.TIME_ID,
                           cast (nvl(SUM(TB.A_krom_tax),0) as decimal (15,2)) AS cd_income,
                           cast (nvl(SUM(TB.A_in_tax),0) as decimal (15,2)) AS income,
                           cast (nvl(SUM(TB.A_outpay_tax),0) as decimal (15,2)) AS import,
                           cast (nvl(SUM(tb.total),0) as decimal (15,2)) AS sum_all
       
                      FROM (SELECT *
                              FROM (select c.time_id as time_id
                                           ,b.import_status as import_name
                                           ,b.import_status_code as cd
                                           ,nvl(sum(a.tax_nettax_amt),0) as tax
                                           ,nvl(sum(a.tax_nettax_amt),0) as total
                                    from Ic_Sum_Allday_Cube a
                                         ,ic_import_status_dim b
                                         ,ic_time_dim c
                    
                                     where a.time_id = c.time_id
                                           and a.import_status = b.import_status_code";
            sql += @"  and c.budget_year = " + year + "";
            sql += @"  group by c.time_id ,b.import_status,b.import_status_code
                                     ) PIVOT(sum(tax) as tax FOR cd in('1' AS A_in
                                                                      ,'2' AS A_krom
                                                                      ,'4' AS A_outpay))
        
                            ) TB
                     GROUP BY TB.time_id
                     order by TB.time_id";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable TaxRealtimeDaily(string offcode, string area, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @" select DIM_DATA_DATE_ID, SUM(FZ_EXCISE_AMT) AS FZ_EXCISE_AMT,
            //           SUM(IN_EXCISE_AMT) AS IN_EXCISE_AMT,
            //           SUM(STAMP_AMT) AS STAMP_AMT,
            //           SUM(EXCISE_AMT) AS EXCISE_AMT
            //         from mbl_cd_daily_report 
            //         where ";
            // sql += " officode like case when '" + offcode + "' = 'undefined' then officode else '" + offcode + "' end";
            // sql += " and Region_CD like case when '" + area + "' = 'undefined' then Region_CD else '" + area + "' end";
            // sql += " and province_CD like case when '" + province + "' = 'undefined' then province_CD else '" + province + "' end";
            // sql += " group by DIM_DATA_DATE_ID order by DIM_DATA_DATE_ID";

            string sql = @"select * from  (select to_char(DIM_DATA_DATE_ID) AS DIM_DATA_DATE_ID, SUM(FZ_EXCISE_AMT) AS FZ_EXCISE_AMT,
                            SUM(IN_EXCISE_AMT) AS IN_EXCISE_AMT,
                            SUM(STAMP_AMT) AS STAMP_AMT,
                            SUM(EXCISE_AMT) AS EXCISE_AMT
                            from mbl_cd_daily_report where officode = '" + offcode + "'";
                  sql += @" group by DIM_DATA_DATE_ID 
                            union all
                            select 'รวม', SUM(FZ_EXCISE_AMT) AS FZ_EXCISE_AMT,
                            SUM(IN_EXCISE_AMT) AS IN_EXCISE_AMT,
                            SUM(STAMP_AMT) AS STAMP_AMT,
                            SUM(EXCISE_AMT) AS EXCISE_AMT
                            from mbl_cd_daily_report where officode ='" + offcode + "') t order by DIM_DATA_DATE_ID";
           

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }



        public DataTable SumFollowPayTaxRealtime(string offcode, string region, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select  sum(FZ_EXCISE_AMT) AS FZ_EXCISE_AMT,SUM(IN_EXCISE_AMT) AS IN_EXCISE_AMT,SUM(STAMP_AMT) AS STAMP_AMT
                            ,SUM(EXCISE_AMT) AS EXCISE_AMT
                            from mbl_cd_daily_report where officode = " + offcode + " ";
                    sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
                    sql += " AND PROVINCE_NAME = case when '" + province + "' = 'undefined' then PROVINCE_NAME else '" + province + "' end";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

            public DataTable FollowPayTaxRealtime(string month,string year)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"SELECT TB.TIME_ID,
                           cast (nvl(SUM(TB.A_krom_tax),0) as decimal (15,2)) AS cd_income,
                           cast (nvl(SUM(TB.A_in_tax),0) as decimal (15,2)) AS income,
                           cast (nvl(SUM(TB.A_outpay_tax),0) as decimal (15,2)) AS import,
                           cast (nvl(SUM(tb.total),0) as decimal (15,2)) AS sum_all
       
                      FROM (SELECT *
                              FROM (select c.time_id as time_id
                                           ,b.import_status as import_name
                                           ,b.import_status_code as cd
                                           ,nvl(sum(a.tax_nettax_amt),0) as tax
                                           ,nvl(sum(a.tax_nettax_amt),0) as total
                                    from Ic_Sum_Allday_Cube a
                                         ,ic_import_status_dim b
                                         ,ic_time_dim c
                    
                                     where a.time_id = c.time_id
                                           and a.import_status = b.import_status_code";
            sql += @"  and c.month_cd = "+ month + "  and c.budget_year = "+ year + "";
            sql += @"  group by c.time_id ,b.import_status,b.import_status_code
                                     ) PIVOT(sum(tax) as tax FOR cd in('1' AS A_in
                                                                      ,'2' AS A_krom
                                                                      ,'4' AS A_outpay))
        
                            ) TB
                     GROUP BY TB.time_id
                     order by TB.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxRealtimeFreezoneAll(string year)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"SELECT TB.time_id,
                             cast (nvl(SUM(TB.A_in_tax),0) as decimal (15,2)) AS income,
                            cast (nvl(SUM(TB.A_out_tax),0) as decimal (15,2)) AS import,
                            cast (nvl(SUM(TB.A_free_tax),0) as decimal (15,2)) AS cd_income,
                            cast (nvl(SUM(TB.A_outpay_tax),0) as decimal (15,2)) AS free_zone
                          FROM (SELECT *
                                  FROM (select b.day_thai as time_id
                                               ,c.import_status_sub as import_name
                                               ,c.import_status_code as cd
                                               ,nvl(sum(a.excise_amt),0) as tax
                                        from cd_daily_detail_fact a
                                             ,cd_time_dim b
                                             ,ic_import_status_dim c
                                        where a.dim_data_date_id = b.time_id
                                              and a.import_status = c.import_status_code 
                                         and b.budget_year = "+ year + "";
                sql += @"    group by b.day_thai ,c.import_status_sub ,c.import_status_code
                                 ) PIVOT(sum(tax) as tax FOR cd in('1' AS A_in
                                                    ,'2' AS A_out
                                                    ,'3' AS A_free
                                                    ,'4' AS A_outpay))
        
                                ) TB
                         GROUP BY TB.time_id
                         order by TB.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxRealtimeFreezone(string month, string year) {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"SELECT TB.time_id,
                             cast (nvl(SUM(TB.A_in_tax),0) as decimal (15,2)) AS income,
                            cast (nvl(SUM(TB.A_out_tax),0) as decimal (15,2)) AS import,
                            cast (nvl(SUM(TB.A_free_tax),0) as decimal (15,2)) AS cd_income,
                            cast (nvl(SUM(TB.A_outpay_tax),0) as decimal (15,2)) AS free_zone
                          FROM (SELECT *
                                  FROM (select b.day_thai as time_id
                                               ,c.import_status_sub as import_name
                                               ,c.import_status_code as cd
                                               ,nvl(sum(a.excise_amt),0) as tax
                                        from cd_daily_detail_fact a
                                             ,cd_time_dim b
                                             ,ic_import_status_dim c
                                        where a.dim_data_date_id = b.time_id
                                              and a.import_status = c.import_status_code
                              and b.month_cd = "+ month + " and b.budget_year = "+ year + " ";
            sql += @" group by b.day_thai ,c.import_status_sub ,c.import_status_code
                                         ) PIVOT(sum(tax) as tax FOR cd in('1' AS A_in
                                                                          ,'2' AS A_out
                                                                          ,'3' AS A_free
                                                                          ,'4' AS A_outpay))
        
                                ) TB
                         GROUP BY TB.time_id
                         order by TB.time_id";

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
                             from MBL_INC_REAL_TIME 
                             where OFFCODE != 000000
                             group by  region_name order by region_name";
            }
            else
            {

                sql = @"select  distinct region_name
                             from MBL_INC_REAL_TIME
                             where OFFCODE ='" + offcode + "' and OFFCODE != 000000" +
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
                        from MBL_INC_REAL_TIME
                        where  province_name not like 'ภาค%' 
                        group by  province_name
                        order by province_name";
            }
            else
            {

                sql = @"select  distinct province_name
                        from MBL_INC_REAL_TIME
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