using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class TaxProduct
    {
        Conn con = new Conn();
        public DataTable TaxBudgetProductByYearAll(string offcode) {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select ROW_NUMBER() OVER (ORDER BY tb.group_name ) as sort, tb.group_name,tb.oct_tax AS oct,tb.nov_tax AS nov,tb.dec_tax AS dec,tb.jan_tax,
                          tb.feb_tax AS feb, tb.mar_tax AS mar, tb.apl_tax AS apl,tb.may_tax AS may,tb.jun_tax AS jun,
                          tb.jul_tax AS jul, tb.aug_tax AS aug, tb.sep_tax As sep
                        from(
                        select group_name, tax, budget_month_desc
                        from mbl_budg_inc ";
            sql += "   where  offcode = "+ offcode + " ";
            sql += @" order by group_name, time_id asc) PIVOT(sum(tax) as tax FOR budget_month_desc in ('ตุลาคม' AS oct,
                         'พฤศจิกายน' AS nov,
                         'ธันวาคม' AS dec,
                         'มกราคม' AS jan,
                         'กุมภาพันธ์' AS feb,
                         'มีนาคม' AS mar,
                         'เมษายน' AS apl,
                         'พฤษภาคม' AS may,
                         'มิถุนายน' AS jun,
                         'กรกฏาคม' AS jul,
                         'สิงหาคม' AS aug,
                         'กันยายน' AS sep
                         )) TB";

            /*string sql = @"SELECT ROW_NUMBER() OVER (ORDER BY  TB.group_name) as sort,  TB.group_name,
                            nvl(SUM(TB.a1_est), 0) AS oct,
                            nvl(SUM(TB.a2_est), 0) AS nov,
                                nvl(SUM(TB.a3_est), 0) AS dec,
                                nvl(SUM(TB.a4_est), 0) AS jan,
                                nvl(SUM(TB.a5_est), 0) AS feb,
                                nvl(SUM(TB.a6_est), 0) AS mar,
                                    nvl(SUM(TB.a7_est), 0) AS apl,
                                    nvl(SUM(TB.a8_est), 0) AS may,
                                    nvl(SUM(TB.a9_est), 0) AS jun,
                                    nvl(SUM(TB.a10_est), 0) AS jul,
                                        nvl(SUM(TB.a11_est), 0) AS aug,
                                        nvl(SUM(TB.a12_est), 0) AS sep
                              FROM(SELECT *
                                      FROM(select b.group_name as group_name
                                                   , b.group_id as group_id
                                                   , c.budget_month_desc as month_name
                                                   , c.budget_month_cd as month_CD
                                                   , nvl(sum(a.estimate), 0) as est
                                            from ic_sum_allday_cube a
                                                 , ic_product_grp_dim b
                                                 , ic_time_dim c
                                            where a.product_grp_cd = b.group_id
                                                  and a.time_id = c.time_id
                                                  and a.product_grp_cd in (0201, 0501, 7002, 7001)
                                             group by c.budget_month_desc, b.group_name, c.budget_month_cd, group_id
                                             order by b.group_name, c.budget_month_cd)
                                             PIVOT(sum(est) as est FOR month_CD in ('1' AS a1
                                                                          , '2' AS a2
                                                                          , '3' AS a3
                                                                          , '4' AS a4
                                                                          , '5' AS a5
                                                                          , '6' AS a6
                                                                          , '7' AS a7
                                                                          , '8' AS a8
                                                                          , '9' AS a9
                                                                          , '10' AS a10
                                                                          , '11' AS a11
                                                                          , '12' AS a12))
        
                                    ) TB
                             GROUP BY TB.group_name,TB.group_id
                             ORDER BY TB.group_id";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable TaxBudgetProductByYear(string offcode,string year) {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());


            string sql = @"select ROW_NUMBER() OVER (ORDER BY tb.group_name ) as sort,tb.group_name,tb.oct_tax AS oct,tb.nov_tax AS nov,tb.dec_tax AS dec,tb.jan_tax,
                          tb.feb_tax AS feb, tb.mar_tax AS mar, tb.apl_tax AS apl,tb.may_tax AS may,tb.jun_tax AS jun,
                          tb.jul_tax AS jul, tb.aug_tax AS aug, tb.sep_tax As sep
                        from(
                        select group_name, tax, budget_month_desc
                        from mbl_budg_inc ";
            sql += "   where budget_year = "+ year + " and offcode = "+ offcode + " ";
            sql += @" order by group_name, time_id asc) PIVOT(sum(tax) as tax FOR budget_month_desc in ('ตุลาคม' AS oct,
                         'พฤศจิกายน' AS nov,
                         'ธันวาคม' AS dec,
                         'มกราคม' AS jan,
                         'กุมภาพันธ์' AS feb,
                         'มีนาคม' AS mar,
                         'เมษายน' AS apl,
                         'พฤษภาคม' AS may,
                         'มิถุนายน' AS jun,
                         'กรกฏาคม' AS jul,
                         'สิงหาคม' AS aug,
                         'กันยายน' AS sep
                         )) TB";

            /*string sql = @"SELECT ROW_NUMBER() OVER (ORDER BY  TB.group_name) as sort, TB.group_name,
                            nvl(SUM(TB.a1_est), 0) AS oct,
                            nvl(SUM(TB.a2_est), 0) AS nov,
                                nvl(SUM(TB.a3_est), 0) AS dec,
                                nvl(SUM(TB.a4_est), 0) AS jan,
                                nvl(SUM(TB.a5_est), 0) AS feb,
                                nvl(SUM(TB.a6_est), 0) AS mar,
                                    nvl(SUM(TB.a7_est), 0) AS apl,
                                    nvl(SUM(TB.a8_est), 0) AS may,
                                    nvl(SUM(TB.a9_est), 0) AS jun,
                                    nvl(SUM(TB.a10_est), 0) AS jul,
                                        nvl(SUM(TB.a11_est), 0) AS aug,
                                        nvl(SUM(TB.a12_est), 0) AS sep
                              FROM(SELECT *
                                      FROM(select b.group_name as group_name
                                                   , b.group_id as group_id
                                                   , c.budget_month_desc as month_name
                                                   , c.budget_month_cd as month_CD
                                                   , nvl(sum(a.estimate), 0) as est
                                            from ic_sum_allday_cube a
                                                 , ic_product_grp_dim b
                                                 , ic_time_dim c
                                            where a.product_grp_cd = b.group_id
                                                  and a.time_id = c.time_id
                                                  and a.product_grp_cd in (0201, 0501, 7002, 7001)
                                                  and c.budget_year = " + year + "";
            sql += @" group by c.budget_month_desc, b.group_name, c.budget_month_cd, group_id
                                             order by b.group_name, c.budget_month_cd)
                                             PIVOT(sum(est) as est FOR month_CD in ('1' AS a1
                                                                          , '2' AS a2
                                                                          , '3' AS a3
                                                                          , '4' AS a4
                                                                          , '5' AS a5
                                                                          , '6' AS a6
                                                                          , '7' AS a7
                                                                          , '8' AS a8
                                                                          , '9' AS a9
                                                                          , '10' AS a10
                                                                          , '11' AS a11
                                                                          , '12' AS a12))
        
                                    ) TB
                             GROUP BY TB.group_name,TB.group_id
                             ORDER BY TB.group_id";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable TaxProductGroupSource() {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"SELECT TB.group_name,
                           cast (nvl(SUM(TB.A_in_tax),0) as decimal (15,2)) AS income,
                           cast (nvl(SUM(TB.A_out_tax),0) as decimal (15,2)) AS import,
                           cast (nvl(SUM(tb.total),0) as decimal (15,2)) AS sum_all
       
                      FROM (SELECT *
                              FROM (select c.group_name as group_name
                                           ,b.import_status as import_name
                                           ,b.import_status_grp_code as cd
                                           ,nvl(sum(a.tax_nettax_amt),0) as tax
                                           ,nvl(sum(a.tax_nettax_amt),0) as total
                                    from Ic_Sum_Allday_Cube a
                                         ,ic_import_status_dim b
                                         ,ic_product_grp_dim c
                                     where a.product_grp_cd = c.group_id
                                           and a.import_status = b.import_status_code
                                           and a.product_grp_cd in (0201,0501,7002,7001)
                                           and a.time_id between 20170601 and 20170630
                                     group by c.group_name,b.import_status,b.import_status_grp_code
                                     ) PIVOT(sum(tax) as tax FOR cd in('1' AS A_in
                                                                      ,'2' AS A_out))
        
                            ) TB
                     GROUP BY TB.group_name";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable TaxBudgetProductByMthAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select group_name,  sum(tax) AS tax, sum(last_tax) AS last_tax,sum(estimate) AS estimate
                            ,ROW_NUMBER() OVER (ORDER BY sum(tax) desc)  as sort
                            from mbl_month_inc 
                            where  offcode = " + offcode + " group by group_name";
                    sql += " order by  tax desc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;

        }

        public DataTable TaxBudgetProductByMth(string offcode,string month)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select group_name,  sum(tax) AS tax, sum(last_tax) AS last_tax,sum(estimate) AS estimate
                            ,ROW_NUMBER() OVER (ORDER BY sum(tax) desc)  as sort
                            from mbl_month_inc 
                            where budget_month_desc = trim('" + month + "') and offcode = "+ offcode + "";
                    sql += " group by group_name order by  tax desc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;

        }

    }
}