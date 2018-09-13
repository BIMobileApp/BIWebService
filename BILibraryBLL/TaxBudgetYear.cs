using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class TaxBudgetYear
    {
        Conn con = new Conn();
        public DataTable TaxBudgetOnYear()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select 
                            d.budget_month_cd
                           ,d.month_short_desc
                           ,sum(a.tax_nettax_amt) as tax
                           ,sum(a.last_tax_nettax_amt) as tax_ly
                           ,sum(a.estimate) as estimate
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
                     group by d.budget_month_cd, d.month_short_desc
                     order by d.budget_month_cd";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxCurYearAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            /*string sql = @"select 
                            d.budget_month_cd
                           ,d.month_short_desc
                           ,sum(a.tax_nettax_amt) as tax
                           ,sum(a.last_tax_nettax_amt) as tax_ly
                           ,sum(a.estimate) as estimate
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
                     group by d.budget_month_cd, d.month_short_desc
                     order by d.budget_month_cd";*/

            /*string sql = @"select * from  mbl_month_01 where offcode = '"+offcode+"'";*/

            /*String sql = @"select distinct(a.budget_month_desc), a.time_id, a.tax ,a.last_tax,a.estimate,a.percent_tax,a.map_color 
                            from mbl_month_01 a where offcode ='"+offcode+"' order by a.time_id";*/

            String sql = @"select * from (select TRANS_Short_month(a.budget_month_desc) as budget_month_desc,
                            sum(a.tax) AS tax,
                            sum(a.last_tax) AS last_tax,
                            sum(a.estimate) AS estimate,
                            sum(a.percent_tax) AS percent_tax,
                            a.time_id,
                            min(a.map_color) as map_color1
                           from mbl_month_01 a
                           where a.offcode = '" + offcode + "'";
                sql += @" group by a.budget_month_desc, a.time_id 
                          order by a.time_id asc )
                                    union all
                                    select 'รวม',
                                           sum(s.tax),
                                           sum(s.last_tax),
                                           sum(s.estimate),
                                           case
                                           when sum(s.tax) > 0 and sum(s.estimate) > 0 then
                                              round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) /sum(s.estimate),2)
                                              else -100 end as percent_tax,
                                           null,
                                           null
                                      from mbl_month_01 s where s.offcode= '" + offcode + "'";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxCurYearbyYear(string offcode,string year)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            

            String sql = @"select *
                              from (select TRANS_Short_month(a.budget_month_desc) as budget_month_desc,
                                           sum(a.tax) AS tax,
                                           sum(a.last_tax) AS last_tax,
                                           sum(a.estimate) AS estimate,
                                           sum(a.percent_tax) AS percent_tax,
                                           a.time_id,
                                           min(a.map_color) as map_color1
                                      from mbl_month_01 a
                                     where a.offcode = '" + offcode + "' and a.budget_year = '"+ year + "'";
            sql += @" group by a.budget_month_desc, a.time_id
                                    union all
                                    select 'รวม',
                                           sum(s.tax),
                                           sum(s.last_tax),
                                           sum(s.estimate),
                                           null,
                                           null,
                                           null
                                      from mbl_month_01 s where s.offcode= '" + offcode + "'  and s.budget_year = '" + year + "') tb order by tb.time_id asc";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getTaxCurYear()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            
            String sql = @"select distinct(t.budget_year) from mbl_month_01 t";
            
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getAreaTaxCurYear(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            String sql = @"select distinct(t.region_name) as reg, case when t.region_name = 'N/A' then 'ไม่ระบุภาค' else t.region_name end AS region_name
                            from MBL_TAX_MONTH t where t.offcode = " + offcode+" order by case when t.region_name = 'N/A' then 'ไม่ระบุภาค' else t.region_name end";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getProvinceTaxCurYear(string offcode,string area)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            String sql = @"select distinct(t.province_name) from MBL_TAX_MONTH t where t.offcode = " + offcode + " and t.region_name = trim('"+ area + "') order by t.province_name";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxCurYearByAreaProvince(string offcode, string area, string Province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //String sql = @"select * from (select TRANS_Short_month(t.budget_month_desc) as budget_month_desc,t.time_id,sum(t.tax) as TAX,sum(t.last_tax) as LAST_TAX,sum(t.estimate) as ESTIMATE,

            //                  ((sum(tax) - sum(estimate)) / sum(estimate)) * 100 as PERCENT_TAX
            //                  from MBL_TAX_MONTH t where t.offcode = '" + offcode + "'";
            //      sql += @" AND t.region_name = case when '" + area + "' = 'undefined' then t.region_name else '" + area + "' end   ";
            //      sql += @" AND t.province_name = case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            //      sql += @" group by t.budget_month_desc, t.time_id order by t.time_id)
            //                union all
            //                select 'รวม',null,sum(s.tax),sum(s.last_tax),sum(s.estimate),
            //                       case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate),2)
            //                       else -100 end as percent_tax 
            //                from MBL_TAX_MONTH s where s.offcode = '" + offcode +"'";
            //      sql += @" AND s.region_name = case when '" + area + "' = 'undefined' then s.region_name else '" + area + "' end   ";
            //      sql += @" AND s.province_name = case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";

            String sql = @"select * from (select TRANS_Short_month(t.budget_month_desc) as budget_month_desc,t.time_id,sum(t.tax) as TAX,sum(t.last_tax) as LAST_TAX,sum(t.estimate) as ESTIMATE,
                             case when sum(t.tax) > 0 and sum(t.estimate) > 0 then
                                      round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /sum(t.estimate),2)
                                      else -100 end as PERCENT_TAX
                              from MBL_TAX_MONTH t where t.offcode = '" + offcode + "'";
            sql += @" AND t.region_name = case when '" + area + "' = 'undefined' then t.region_name else '" + area + "' end   ";
            sql += @" AND t.province_name = case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            sql += @" group by t.budget_month_desc, t.time_id order by t.time_id)
                            union all
                            select 'รวม',null,sum(s.tax),sum(s.last_tax),sum(s.estimate),
                                   case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate),2)
                                   else -100 end as percent_tax 
                            from MBL_TAX_MONTH s where s.offcode = '" + offcode + "'";
            sql += @" AND s.region_name = case when '" + area + "' = 'undefined' then s.region_name else '" + area + "' end   ";
            sql += @" AND s.province_name = case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxCurYearOverviewAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            String sql = @"select * from (select TRANS_Short_month(t.budget_month_desc) as budget_month_desc,t.time_id,sum(t.tax) as TAX,sum(t.last_tax) as LAST_TAX,sum(t.estimate) as ESTIMATE,
                             case when sum(t.tax) > 0 and sum(t.estimate) > 0 then
                                      round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /sum(t.estimate),2)
                                      else -100 end as PERCENT_TAX
                              from MBL_TAX_MONTH t where t.offcode = " + offcode+"";
                   sql += @" group by t.budget_month_desc, t.time_id order by t.time_id)
                             union all
                              select 'รวม',null,sum(s.tax),sum(s.last_tax),sum(s.estimate),
                                   case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate),2)
                                   else -100 end as percent_tax 
                            from MBL_TAX_MONTH s where s.offcode = " + offcode + "";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxProductYearByAreaProvince(string offcode, string area, string Province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //String sql = @"select * from (select TRANS_Short_month(t.budget_month_desc) as budget_month_desc,t.time_id,sum(t.tax) as TAX,sum(t.last_tax) as LAST_TAX,sum(t.estimate) as ESTIMATE,

            //                  ((sum(tax) - sum(estimate)) / sum(estimate)) * 100 as PERCENT_TAX
            //                  from MBL_TAX_MONTH t where t.offcode = '" + offcode + "'";
            //      sql += @" AND t.region_name = case when '" + area + "' = 'undefined' then t.region_name else '" + area + "' end   ";
            //      sql += @" AND t.province_name = case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            //      sql += @" group by t.budget_month_desc, t.time_id order by t.time_id)
            //                union all
            //                select 'รวม',null,sum(s.tax),sum(s.last_tax),sum(s.estimate),
            //                       case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate),2)
            //                       else -100 end as percent_tax 
            //                from MBL_TAX_MONTH s where s.offcode = '" + offcode +"'";
            //      sql += @" AND s.region_name = case when '" + area + "' = 'undefined' then s.region_name else '" + area + "' end   ";
            //      sql += @" AND s.province_name = case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";

            string sql = @"select * from (
                           select t.group_name,t.sort, sum(t.tax) as TAX, sum(t.last_tax) as LAST_TAX,sum(t.estimate) as ESTIMATE,
                                  case when sum(t.tax) > 0 and sum(t.estimate) > 0 then
                                  round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /sum(t.estimate),2)
                                  else -100 end as PERCENT_TAX
                          from MBL_TAX_GOODS t where t.offcode = " + offcode + "";
            sql += @" AND t.region_name = case when '" + area + "' = 'undefined' then t.region_name else '" + area + "' end ";
            sql += @" AND t.province_name = case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            sql += @" group by t.group_name, t.sort order by t.sort)
                     union all
                     select 'รวม',null,sum(s.tax),sum(s.last_tax),sum(s.estimate),
                            case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate),2)
                            else -100 end as percent_tax 
                     from MBL_TAX_GOODS s where s.offcode =  " + offcode + "";
            sql += @" AND s.region_name = case when '" + area + "' = 'undefined' then s.region_name else '" + area + "' end  ";
            sql += @" AND s.province_name = case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxProductCurYearAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select *
                              from (select distinct(t.group_name), t.tax ,t.last_tax,t.estimate,t.percent_tax,t.map_color,t.sort 
                                    from MBL_TAX_GOODS t where offcode = '" + offcode + "'";
            sql += @"order by t.sort)
                                    union all
                                    select 'รวม',
                                           sum(s.tax),
                                           sum(s.last_tax),
                                           sum(s.estimate),
                                           case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate),2)
                                                else -100 end as percent_tax,
                                           null,
                                           null
                                      from MBL_TAX_GOODS s where s.offcode = '" + offcode + "'";
            
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxProductCurYearOverviewAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select * from (select t.group_name,t.sort,sum(t.tax) as TAX,sum(t.last_tax) as LAST_TAX,sum(t.estimate) as ESTIMATE,
                           case when sum(t.tax) > 0 and sum(t.estimate) > 0 then round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /
                           sum(t.estimate),2) else -100 end as PERCENT_TAX
                           from MBL_TAX_GOODS t where t.offcode = " + offcode + " group by t.group_name, t.sort order by t.sort)";
                   sql += @" union all select 'รวม', null,sum(s.tax),sum(s.last_tax),sum(s.estimate), case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate), 2) else -100 end as percent_tax from MBL_TAX_GOODS s where s.offcode = "+offcode+"";



            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable TaxProductCurYearbyYear(string offcode, string year)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select *
                              from (select distinct(t.group_name), t.tax ,t.last_tax,t.estimate,t.percent_tax,t.map_color 
                                    from MBL_TAX_GOODS t where t.offcode = '" + offcode + "' and t.budget_year = '" + year + "'";
            sql += @"order by t.tax desc)
                                    union all
                                    select 'รวม',
                                           sum(s.tax),
                                           sum(s.last_tax),
                                           sum(s.estimate),
                                           null,
                                           null
                                      from MBL_TAX_GOODS s where s.offcode = '" + offcode + "' and s.budget_year = '" + year + "'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getProductCurYear()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            String sql = @"select distinct(t.budget_year) from MBL_TAX_GOODS t";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxProvinceCurYear(string area)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from (select t.province_name,sum(t.Tax) as Tax,sum(t.Last_Tax) as Last_Tax,sum(t.estimate) as estimate,
                                   case when sum(t.tax) > 0 and sum(t.estimate) > 0 then
                                      round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /
                                            sum(t.estimate),2)
                                     else -100
                                   end as PERCENT_TAX
                              from MBL_TAX_MONTH t
                             where t.region_name = '" + area + "'";
                  sql += @" group by t.province_name  order by t.province_name)
                           union all
                                select 'รวม',sum(s.Tax) as Tax,sum(s.Last_Tax) as Last_Tax,sum(s.estimate) as estimate,
                                       case
                                         when sum(s.tax) > 0 and sum(s.estimate) > 0 then
                                          round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) /
                                                sum(s.estimate),2)
                                         else -100 end as PERCENT_TAX
                                  from MBL_TAX_MONTH s where s.region_name = '" + area + "'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxBudgetProduct()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select 
                           b.group_id
                           ,b.group_name   
                           ,sum(a.tax_nettax_amt) as tax
                           ,sum(a.last_tax_nettax_amt) as tax_ly
                           ,sum(a.estimate) as estimate       
                      from ic_sum_allday_cube a
                           ,ic_product_grp_dim b
                           ,ic_office_dim c
                           ,ic_time_dim d
                           ,ic_time_dim d2
                     where a.product_grp_cd = b.group_id
                       and a.offcode_own = c.offcode
                       and a.time_id = d.time_id
                       and d.budget_year = d2.budget_year
                       and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                     group by b.group_id,b.group_name
                     order by b.group_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxBudgetRegAll(string offcode, string group_id, string region,string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());


            string sql = @"select reg_name AS reg_name,TAX_NETTAX_AMT AS tax,ROW_NUMBER() OVER (ORDER BY myrank ) AS sort 
                            from mbl_top_product_10 
                            where offcode = " + offcode + " and group_name = '" + group_id + "' ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            //sql += " AND BUDGET_YEAR = case when '" + year + "' = 'undefined' then BUDGET_YEAR else '" + year + "' end";
            sql += @" and myrank between '1' and '10' ";
            sql += @" union all select 'รวม' ,SUM(TAX_NETTAX_AMT) AS tax,null
                        from mbl_top_product_10 
                        where offcode = " + offcode + " and group_name = '" + group_id + "' ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            //sql += " AND BUDGET_YEAR = case when '" + year + "' = 'undefined' then BUDGET_YEAR else '" + year + "' end";
            sql += @"  and myrank between '1' and '10'";


            /*string sql = @"select
                            r1.reg_id
                           ,r1.reg_name
                           , ROW_NUMBER() OVER (ORDER BY  r1.reg_id) as sort
                           ,sum(a.tax_nettax_amt) as tax
                           ,sum(a.last_tax_nettax_amt) as tax_ly
                           ,sum(a.estimate) as estimate       
                      from ic_sum_allday_cube a
                           ,ic_product_grp_dim b
                           ,ic_office_dim c
                           ,ic_time_dim d
                           ,ic_time_dim d2
                           ,ic_register_dim r1
                     where a.product_grp_cd = b.group_id
                       and a.offcode_own = c.offcode
                       and a.time_id = d.time_id
                       and d.budget_year = d2.budget_year
                       and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                       and a.reg_sk = r1.reg_sk and rownum <=10
                     group by  r1.reg_id,r1.reg_name
                     order by  r1.reg_id";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxBudgetReg(string offcode, string group_id, string year)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());


            string sql = @"select reg_name AS reg_name,TAX_NETTAX_AMT AS tax,myrank AS sort 
                            from mbl_top_product_10 
                            where offcode = " + offcode + " and group_name = '" + group_id + "' and budget_year = " + year + "";
            sql += @" and myrank between '1' and '10' ";

            sql += @" union all select 'รวม' ,SUM(TAX_NETTAX_AMT) AS tax,null
                        from mbl_top_product_10 
                        where offcode = " + offcode + " and group_name = '" + group_id + "' ";
            sql += @"  and myrank between '1' and '10'";


            /* string sql = @"select
                             r1.reg_id
                            ,r1.reg_name
                            , ROW_NUMBER() OVER (ORDER BY  r1.reg_id) as sort
                            ,sum(a.tax_nettax_amt) as tax
                            ,sum(a.last_tax_nettax_amt) as tax_ly
                            ,sum(a.estimate) as estimate       
                       from ic_sum_allday_cube a
                            ,ic_product_grp_dim b
                            ,ic_office_dim c
                            ,ic_time_dim d
                            ,ic_time_dim d2
                            ,ic_register_dim r1
                      where a.product_grp_cd = b.group_id
                        and a.offcode_own = c.offcode
                        and a.time_id = d.time_id
                        and d.budget_year = d2.budget_year
                        and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                        and a.reg_sk = r1.reg_sk and d.budget_year = "+ year + "";
             sql += @" and rownum <=10 group by  r1.reg_id,r1.reg_name
                      order by  r1.reg_id";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxTopRegSegment(string offcode, string group_id, string area, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = @"select t.reg_name AS reg_name,t.TAX_NETTAX_AMT AS tax,myrank AS sort
                        from mbl_top_product_10 t
                        where
                        t.offcode like case when '" + offcode + "' = 'undefined' then t.offcode else '" + offcode + "' end";
            sql += " and t.Region_Name like case when '" + area + "' = 'undefined' then t.Region_Name else '" + area + "' end";
            sql += " and t.province_name like case when '" + province + "' = 'undefined' then t.province_name else '" + province + "' end";
            sql += " and t.group_name = '" + group_id + "' and t.myrank between '1' and '10'";
            sql += " union all select 'รวม' ,sum(s.TAX_NETTAX_AMT) AS tax,null from mbl_top_product_10 s where ";
            sql += " s.offcode like case when '" + offcode + "' = 'undefined' then s.offcode else '" + offcode + "' end";
            sql += " and s.Region_Name like case when '" + area + "' = 'undefined' then s.Region_Name else '" + area + "' end";
            sql += " and s.province_name like case when '" + province + "' = 'undefined' then s.province_name else '" + province + "' end";
            sql += " and s.group_name = '" + group_id + "' and s.myrank between '1' and '10'";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public string SumTaxBudgetRegAll()
        {

            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select sum(a.tax_nettax_amt) as sum_tax   
                          from ic_sum_allday_cube a
                               ,ic_product_grp_dim b
                               ,ic_office_dim c
                               ,ic_time_dim d
                               ,ic_time_dim d2
                               ,ic_register_dim r1
                         where a.product_grp_cd = b.group_id
                           and a.offcode_own = c.offcode
                           and a.time_id = d.time_id
                           and d.budget_year = d2.budget_year
                           and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                           and a.reg_sk = r1.reg_sk";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();

            string result = "";
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.ToString();
                }
            }
            thisConnection.Close();
            return result;
        }

        public string SumTaxBudgetReg(string year)
        {

            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select sum(a.tax_nettax_amt) as sum_tax   
                          from ic_sum_allday_cube a
                               ,ic_product_grp_dim b
                               ,ic_office_dim c
                               ,ic_time_dim d
                               ,ic_time_dim d2
                               ,ic_register_dim r1
                         where a.product_grp_cd = b.group_id
                           and a.offcode_own = c.offcode
                           and a.time_id = d.time_id
                           and d.budget_year = d2.budget_year
                           and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                           and a.reg_sk = r1.reg_sk and rownum <=10
                           and d.budget_year = " + year + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();

            string result = "";
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.ToString();
                }
            }
            thisConnection.Close();
            return result;
        }

        public DataTable TaxBudgetRegByMthAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select ROW_NUMBER() OVER (ORDER BY myrank) as sort,
                            reg_name AS reg_name, tax_nettax_amt AS tax from mbl_top10_register_mth ";
            sql += @" where offcode = " + offcode + "  and myrank between 1 and 10 ";
            sql += @" order by tax_nettax_amt";

            /*string sql = @"select
                            r1.reg_id
                           ,r1.reg_name
                           , ROW_NUMBER() OVER (ORDER BY  r1.reg_id) as sort
                           ,sum(a.tax_nettax_amt) as tax
                           ,sum(a.last_tax_nettax_amt) as tax_ly
                           ,sum(a.estimate) as estimate       
                      from ic_sum_allday_cube a
                           ,ic_product_grp_dim b
                           ,ic_office_dim c
                           ,ic_time_dim d
                           ,ic_time_dim d2
                           ,ic_register_dim r1
                     where a.product_grp_cd = b.group_id
                       and a.offcode_own = c.offcode
                       and a.time_id = d.time_id
                       and d.budget_year = d2.budget_year
                       and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                       and rownum <=10
                       and a.reg_sk = r1.reg_sk
                     group by  r1.reg_id,r1.reg_name
                     order by  r1.reg_id";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxBudgetRegByMth(string offcode, string month)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select reg_name AS reg_name, tax_nettax_amt AS tax,myrank as sort from mbl_top10_register_mth ";
            sql += @" where offcode = " + offcode + " ";
            sql += @" and to_char(month_cd) = case when '" + month + "' = 'undefined' then '0' else to_char('" + month + "') end and myrank between 1 and 10 ";

            sql += @" union all select 'รวม' , SUM(TAX_NETTAX_AMT) ,null from mbl_top10_register_mth ";
            sql += @" where offcode = " + offcode + " ";
            sql += @" and to_char(month_cd) = case when '" + month + "' = 'undefined' then '0' else to_char('" + month + "') end ";
            sql += @" and myrank between '1' and '10' ";


            //string sql = @"select reg_name AS reg_name, tax_nettax_amt AS tax,myrank as sort from mbl_top10_register_mth ";
            //sql += @" where offcode = " + offcode + " ";
            //sql += @" and to_char(month_cd) = case when '" + month + "' = 'undefined' then '0' else to_char('" + month + "') end and myrank between 1 and 10 ";


            //sql += @" union all select 'รวม' , SUM(TAX_NETTAX_AMT) ,null from mbl_top10_register_mth ";
            //sql += @" where offcode = " + offcode + " ";
            //sql += @" and to_char(month_cd) = case when '" + month + "' = 'undefined' then '0' else to_char('" + month + "') end ";
            //sql += @" and myrank between '1' and '10' ";


            //string sql = @"select myrank as sort,
            //                reg_name AS reg_name, tax_nettax_amt AS tax from mbl_top10_register_mth ";
            //sql += @" where offcode = " + offcode + " and month_cd = " + month + " and myrank between 1 and 10 ";
            //sql += @" order by tax_nettax_amt desc";

            /*string sql = @"select
                            r1.reg_id
                           ,r1.reg_name
                           , ROW_NUMBER() OVER (ORDER BY  r1.reg_id) as sort
                           ,sum(a.tax_nettax_amt) as tax
                           ,sum(a.last_tax_nettax_amt) as tax_ly
                           ,sum(a.estimate) as estimate       
                      from ic_sum_allday_cube a
                           ,ic_product_grp_dim b
                           ,ic_office_dim c
                           ,ic_time_dim d
                           ,ic_time_dim d2
                           ,ic_register_dim r1
                     where a.product_grp_cd = b.group_id
                       and a.offcode_own = c.offcode
                       and a.time_id = d.time_id
                       and d.budget_year = d2.budget_year
                       and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                       and d.month_cd = " + mth + "";
            sql += @" and a.reg_sk = r1.reg_sk and rownum <=10
                     group by  r1.reg_id,r1.reg_name
                     order by  r1.reg_id";*/

            /*string sql = @"select myrank as sort,
                            reg_name AS reg_name, tax_nettax_amt AS tax from mbl_top10_register_mth ";
            sql += @" where offcode = " + offcode + " ";
            sql += @" and to_char(month_cd) = case when '" + month + "' = 'undefined' then '0' else to_char('" + month + "') end and myrank between 1 and 10 ";
            sql += @" order by tax_nettax_amt desc";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public string SumTaxBudgetRegByMthAll()
        {
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select sum(a.tax_nettax_amt) as sum_tax   
                          from ic_sum_allday_cube a
                               ,ic_product_grp_dim b
                               ,ic_office_dim c
                               ,ic_time_dim d
                               ,ic_time_dim d2
                               ,ic_register_dim r1
                         where a.product_grp_cd = b.group_id
                           and a.offcode_own = c.offcode
                           and a.time_id = d.time_id
                           and d.budget_year = d2.budget_year
                           and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                           and a.reg_sk = r1.reg_sk and rownum <=10";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();

            string result = "";
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.ToString();
                }
            }
            thisConnection.Close();
            return result;
        }

        public string SumTaxBudgetRegByMth(int mth)
        {
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select sum(a.tax_nettax_amt) as sum_tax   
                          from ic_sum_allday_cube a
                               ,ic_product_grp_dim b
                               ,ic_office_dim c
                               ,ic_time_dim d
                               ,ic_time_dim d2
                               ,ic_register_dim r1
                         where a.product_grp_cd = b.group_id
                           and a.offcode_own = c.offcode
                           and a.time_id = d.time_id
                           and d.budget_year = d2.budget_year
                           and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                           and a.reg_sk = r1.reg_sk 
                           and d.month_cd = " + mth + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();

            string result = "";
            using (OleDbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    result = reader.ToString();
                }
            }
            thisConnection.Close();
            return result;
        }
    }
}