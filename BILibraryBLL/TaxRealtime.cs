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

        public DataTable FollowPayTaxRealtimeAll(string year)
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
            sql += @"  and c.budget_year = " + year + "";
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

            return dt;
        }
    }
}