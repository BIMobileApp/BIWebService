using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using ClassLib;

namespace BILibraryBLL
{ 
    public class CompareTax
    {
        Conn con = new Conn();
     /*   public DataTable CompareTaxByGroup(string group_name)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select 
                          b.sort
                           ,b.group_name 
                           ,sum(a.tax_nettax_amt) as tax
                           ,sum(a.last_tax_nettax_amt) as tax_ly
                           ,nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.last_tax_nettax_amt), 0) as compare_tax_ly
                           ,case
                             when sum(a.tax_nettax_amt) > 0 and sum(a.last_tax_nettax_amt) > 0 then
                              round(((nvl(sum(a.tax_nettax_amt), 0) -
                                    nvl(sum(a.last_tax_nettax_amt), 0)) * 100) /
                                    sum(a.last_tax_nettax_amt),
                                    2)
                             else
                              -100
                           end as tax_percent 
                           ,sum(a.estimate) as estimate 
                           ,nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.estimate), 0) as compare_estimate_diff 
                           ,case
                             when sum(a.tax_nettax_amt) > 0 and sum(a.estimate) > 0 then
                              round(((nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.estimate), 0)) * 100) /
                                    sum(a.estimate),
                                    2)
                             else
                              -100
                           end as estimate_percent 
                          ,d.budget_month_cd
                          ,d.budget_year
                          ,d.month_desc
                          ,p.type_name
                      from ic_sum_allday_cube a, ic_product_grp_dim b,
                      ic_time_dim d, ic_time_dim d2,ic_product_dim p
                     where a.product_grp_cd = b.group_id
                       and a.time_id = d.time_id
                       and d.budget_year = d2.budget_year
                       and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
                       and b.group_name = trim('" + group_name + "')";
                    sql  += @" and b.group_id = p.group_id
                       and rownum <= 100
                     group by b.sort, b.group_name, d.budget_month_cd, d.budget_year, d.month_desc,p.type_name
                     order by d.budget_month_cd, b.sort";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable CompareTaxLineGraph(string group_name,string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select * from mbl_tax_est where group_name = '"+ group_name + "' and offcode = "+ offcode + "";

            /*string sql = @"select c.month_short_desc
                            , c.budget_month_cd
                            ,nvl(sum(a.tax_nettax_amt), 0) as tax
                            ,nvl(sum(a.last_tax_nettax_amt), 0) as tax_ly
                            ,nvl(sum(a.estimate), 0) as est
                            ,nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.estimate), 0) as compare_estimate_diff
                           from ic_sum_allday_cube a
                            ,ic_product_grp_dim b
                            , ic_time_dim c
                           where a.product_grp_cd = b.group_id
                            and a.time_id = c.time_id
                            and a.time_id between 20171001 AND 20180931
                            and a.product_grp_cd = " + id;
                   sql += @"group by c.month_short_desc ,c.budget_month_cd
                           order by c.budget_month_cd";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        } */

        public DataTable CompareTaxSura(string area, string Province,string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select * from (select t.i_type_desc
                        ,sum(t.total_tax_amt) as total_tax_amt
                        ,sum(t.last_total_tax_amt) as last_total_tax_amt
                        ,sum(t.est_amt) as est_amt 
                        ,sum(t.total_volumn_capa) as total_volumn_capa
                        ,sum(t.last_total_volumn_capa) as last_total_volumn_capa
                        from MBL_PRODUCT_SURA t  where 1=1  ";
            sql += " and t.offcode like case when '" + offcode + "' = 'undefined' then t.offcode else '" + offcode + "' end ";
            sql += " and t.Region_Name like case when '" + area + "' = 'undefined' then t.Region_Name else '" + area + "' end ";
            sql += " and t.province_name like case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            sql += @" group by t.i_type_desc 
                        order by t.i_type_desc) union all select 
                                         'รวม',
                                          sum(s.TOTAL_TAX_AMT),
                                          sum(s.LAST_TOTAL_TAX_AMT),
                                          sum(s.EST_AMT),
                                          sum(s.TOTAL_VOLUMN_CAPA),
                                          sum(s.LAST_TOTAL_VOLUMN_CAPA)
                                    from MBL_PRODUCT_SURA s where ";
            sql += " s.offcode like case when '" + offcode + "' = 'undefined' then s.offcode else '" + offcode + "' end";
            sql += " and s.Region_Name like case when '" + area + "' = 'undefined' then s.Region_Name else '" + area + "' end ";
            sql += " and s.province_name like case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";
            

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxProduct(string area, string Province, string offcode, string month_from, string month_to, string dbtable)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select * from (select t.i_type_desc
                        ,sum(t.total_tax_amt) as total_tax_amt
                        ,sum(t.last_total_tax_amt) as last_total_tax_amt
                        ,sum(t.est_amt) as est_amt 
                        ,sum(t.total_volumn_capa) as total_volumn_capa
                        ,sum(t.last_total_volumn_capa) as last_total_volumn_capa
                        from "+ dbtable + " t  where 1=1  ";
            if (month_from != "undefined" && month_to != "undefined")
            {
                sql += " and t.MONTH_CD between " + month_from + " and " + month_to + "";
            }
            sql += " and t.offcode like case when '" + offcode + "' = 'undefined' then t.offcode else '" + offcode + "' end ";
            sql += " and t.Region_Name like case when '" + area + "' = 'undefined' then t.Region_Name else '" + area + "' end ";
            sql += " and t.province_name like case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            sql += @" group by t.i_type_desc 
                        order by t.i_type_desc) union all select 
                                         'รวม',
                                          sum(s.TOTAL_TAX_AMT),
                                          sum(s.LAST_TOTAL_TAX_AMT),
                                          sum(s.EST_AMT),
                                          sum(s.TOTAL_VOLUMN_CAPA),
                                          sum(s.LAST_TOTAL_VOLUMN_CAPA)
                                    from " + dbtable + " s where ";
            sql += " s.offcode like case when '" + offcode + "' = 'undefined' then s.offcode else '" + offcode + "' end";
            if (month_from != "undefined" && month_to != "undefined")
            {
                sql += " and s.MONTH_CD between " + month_from + " and " + month_to + "";
            }
            sql += " and s.Region_Name like case when '" + area + "' = 'undefined' then s.Region_Name else '" + area + "' end ";
            sql += " and s.province_name like case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxSuraMonth(string TYPE_DESC, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_SURA_MONTH t where t.i_type_code='" + code+"' and t.offcode='"+offcode+"' order by t.time_id";

            string sql = @"SELECT TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC) AS MONTH,
                               SUM(T.TOTAL_TAX_AMT) AS TOTAL_TAX_AMT,
                               SUM(T.LAST_TOTAL_TAX_AMT) AS LAST_TOTAL_TAX_AMT,
                               SUM(T.EST_AMT) AS EST_AMT,
                               SUM(T.TOTAL_VOLUMN_CAPA) AS TOTAL_VOLUMN_CAPA,
                               SUM(T.LAST_TOTAL_VOLUMN_CAPA) AS LAST_TOTAL_VOLUMN_CAPA,
                               T.TIME_ID
                          FROM MBL_PRODUCT_SURA_MONTH T
                          WHERE T.I_TYPE_DESC = '" + TYPE_DESC + "' AND T.OFFCODE = '" + offcode + "'";
                  sql += " GROUP BY TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC), T.TIME_ID ORDER BY T.TIME_ID";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxSuraMonthAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month
                            ,sum(t.total_tax_amt) as TOTAL_TAX_AMT
                            ,sum(t.last_total_tax_amt) as LAST_TOTAL_TAX_AMT
                            ,t.time_id
                            from MBL_PRODUCT_SURA_MONTH t 
                            where t.offcode = " + offcode + " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getTypeNameSuraMonth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.i_type_desc) from MBL_PRODUCT_SURA_MONTH t where t.offcode = "+ offcode + " order by t.i_type_desc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxBeer(string area, string Province, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_BEER t order by t.total_tax_amt desc";
         string  sql = @" select * from (select t.i_type_desc
                        ,sum(t.total_tax_amt) as total_tax_amt
                        ,sum(t.last_total_tax_amt) as last_total_tax_amt
                        ,sum(t.est_amt) as est_amt 
                        ,sum(t.total_volumn_capa) as total_volumn_capa
                        ,sum(t.last_total_volumn_capa) as last_total_volumn_capa
                        from MBL_PRODUCT_BEER t  where 1=1  ";
                    sql += " and t.offcode like case when '" + offcode + "' = 'undefined' then t.offcode else '" + offcode + "' end ";
                    sql += " and t.Region_Name like case when '" + area + "' = 'undefined' then t.Region_Name else '" + area + "' end ";
                    sql += " and t.province_name like case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
                    sql += @" group by t.i_type_desc 
                        order by t.i_type_desc) union all select 
                                         'รวม',
                                          sum(s.TOTAL_TAX_AMT),
                                          sum(s.LAST_TOTAL_TAX_AMT),
                                          sum(s.EST_AMT),
                                          sum(s.TOTAL_VOLUMN_CAPA),
                                          sum(s.LAST_TOTAL_VOLUMN_CAPA)
                                    from MBL_PRODUCT_BEER s where ";
            sql += "   s.offcode like case when '" + offcode + "' = 'undefined' then s.offcode else '" + offcode + "' end";
            sql += " and s.Region_Name like case when '" + area + "' = 'undefined' then s.Region_Name else '" + area + "' end ";
            sql += " and s.province_name like case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxBeerMonth(string TYPE_DESC, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_BEER_MONTH t where t.i_type_code='" + code + "' and t.offcode='" + offcode + "'  order by t.time_id";
            //string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,
            //               sum(t.total_tax_amt),
            //               t.time_id,
            //               t.offcode
            //               from MBL_PRODUCT_BEER_MONTH t
            //               where t.i_type_code = '"+ code + "'";
            //     sql += @" and t.offcode = '"+ offcode + "'";
            //     sql += @" group by TRANS_Short_month(t.budget_month_desc),
            //                      t.time_id,
            //                      t.offcode
            //               order by t.time_id";
            string sql = @"SELECT TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC) AS MONTH,
                               SUM(T.TOTAL_TAX_AMT) AS TOTAL_TAX_AMT,
                               SUM(T.LAST_TOTAL_TAX_AMT) AS LAST_TOTAL_TAX_AMT,
                               SUM(T.EST_AMT) AS EST_AMT,
                               SUM(T.TOTAL_VOLUMN_CAPA) AS TOTAL_VOLUMN_CAPA,
                               SUM(T.LAST_TOTAL_VOLUMN_CAPA) AS LAST_TOTAL_VOLUMN_CAPA,
                               T.TIME_ID
                          FROM MBL_PRODUCT_BEER_MONTH T
                          WHERE T.I_TYPE_DESC = '" + TYPE_DESC + "' AND T.OFFCODE = '" + offcode + "'";
            sql += " GROUP BY TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC), T.TIME_ID ORDER BY T.TIME_ID";
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxBeerMonthAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month
                            ,sum(t.total_tax_amt) as TOTAL_TAX_AMT
                            ,sum(t.last_total_tax_amt) as LAST_TOTAL_TAX_AMT
                            ,t.time_id
                            from MBL_PRODUCT_BEER_MONTH t 
                            where t.offcode = " + offcode + " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getTypeNameBeerMonth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.i_type_desc) from MBL_PRODUCT_BEER_MONTH t where t.offcode = " + offcode + " order by t.i_type_desc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxCar(string area, string Province, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_CAR t order by t.total_tax_amt desc";
            string sql = @" select * from (select t.i_type_desc
                        ,sum(t.total_tax_amt) as total_tax_amt
                        ,sum(t.last_total_tax_amt) as last_total_tax_amt
                        ,sum(t.est_amt) as est_amt 
                        ,sum(t.total_volumn_capa) as total_volumn_capa
                        ,sum(t.last_total_volumn_capa) as last_total_volumn_capa
                        from MBL_PRODUCT_CAR t  where 1=1  ";
            sql += " and t.offcode like case when '" + offcode + "' = 'undefined' then t.offcode else '" + offcode + "' end ";
            sql += " and t.Region_Name like case when '" + area + "' = 'undefined' then t.Region_Name else '" + area + "' end ";
            sql += " and t.province_name like case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            sql += @" group by t.i_type_desc 
                        order by t.i_type_desc) union all select 
                                         'รวม',
                                          sum(s.TOTAL_TAX_AMT),
                                          sum(s.LAST_TOTAL_TAX_AMT),
                                          sum(s.EST_AMT),
                                          sum(s.TOTAL_VOLUMN_CAPA),
                                          sum(s.LAST_TOTAL_VOLUMN_CAPA)
                                    from MBL_PRODUCT_CAR s where ";
            sql += " s.offcode like case when '" + offcode + "' = 'undefined' then s.offcode else '" + offcode + "' end";
            sql += " and s.Region_Name like case when '" + area + "' = 'undefined' then s.Region_Name else '" + area + "' end ";
            sql += " and s.province_name like case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable CompareTaxOil(string area, string Province, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_CAR t order by t.total_tax_amt desc";
            string sql = @" select * from (select t.i_type_desc
                        ,sum(t.total_tax_amt) as total_tax_amt
                        ,sum(t.last_total_tax_amt) as last_total_tax_amt
                        ,sum(t.est_amt) as est_amt 
                        ,sum(t.total_volumn_capa) as total_volumn_capa
                        ,sum(t.last_total_volumn_capa) as last_total_volumn_capa
                        from MBL_PRODUCT_OIL t  where 1=1  ";
            sql += " and t.offcode like case when '" + offcode + "' = 'undefined' then t.offcode else '" + offcode + "' end ";
            sql += " and t.Region_Name like case when '" + area + "' = 'undefined' then t.Region_Name else '" + area + "' end ";
            sql += " and t.province_name like case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            sql += @" group by t.i_type_desc 
                        order by t.i_type_desc) union all select 
                                         'รวม',
                                          sum(s.TOTAL_TAX_AMT),
                                          sum(s.LAST_TOTAL_TAX_AMT),
                                          sum(s.EST_AMT),
                                          sum(s.TOTAL_VOLUMN_CAPA),
                                          sum(s.LAST_TOTAL_VOLUMN_CAPA)
                                    from MBL_PRODUCT_OIL s where ";
            sql += " s.offcode like case when '" + offcode + "' = 'undefined' then s.offcode else '" + offcode + "' end";
            sql += " and s.Region_Name like case when '" + area + "' = 'undefined' then s.Region_Name else '" + area + "' end ";
            sql += " and s.province_name like case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxSica(string area, string Province, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_CAR t order by t.total_tax_amt desc";
            string sql = @" select * from (select t.i_type_desc
                        ,sum(t.total_tax_amt) as total_tax_amt
                        ,sum(t.last_total_tax_amt) as last_total_tax_amt
                        ,sum(t.est_amt) as est_amt 
                        ,sum(t.total_volumn_capa) as total_volumn_capa
                        ,sum(t.last_total_volumn_capa) as last_total_volumn_capa
                        from MBL_PRODUCT_TOBACCO t  where 1=1  ";
            sql += " and t.offcode like case when '" + offcode + "' = 'undefined' then t.offcode else '" + offcode + "' end ";
            sql += " and t.Region_Name like case when '" + area + "' = 'undefined' then t.Region_Name else '" + area + "' end ";
            sql += " and t.province_name like case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            sql += @" group by t.i_type_desc 
                        order by t.i_type_desc) union all select 
                                         'รวม',
                                          sum(s.TOTAL_TAX_AMT),
                                          sum(s.LAST_TOTAL_TAX_AMT),
                                          sum(s.EST_AMT),
                                          sum(s.TOTAL_VOLUMN_CAPA),
                                          sum(s.LAST_TOTAL_VOLUMN_CAPA)
                                    from MBL_PRODUCT_TOBACCO s where ";
            sql += " s.offcode like case when '" + offcode + "' = 'undefined' then s.offcode else '" + offcode + "' end";
            sql += " and s.Region_Name like case when '" + area + "' = 'undefined' then s.Region_Name else '" + area + "' end ";
            sql += " and s.province_name like case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxCarMonth(string TYPE_DESC, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_CAR_MONTH t where t.i_type_code='" + code + "' and t.offcode='" + offcode + "'  order by t.time_id";
            string sql = @"SELECT TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC) AS MONTH,
                               SUM(T.TOTAL_TAX_AMT) AS TOTAL_TAX_AMT,
                               SUM(T.LAST_TOTAL_TAX_AMT) AS LAST_TOTAL_TAX_AMT,
                               SUM(T.EST_AMT) AS EST_AMT,
                               SUM(T.TOTAL_VOLUMN_CAPA) AS TOTAL_VOLUMN_CAPA,
                               SUM(T.LAST_TOTAL_VOLUMN_CAPA) AS LAST_TOTAL_VOLUMN_CAPA,
                               T.TIME_ID
                          FROM MBL_PRODUCT_CAR_MONTH T
                          WHERE T.I_TYPE_DESC = '" + TYPE_DESC + "' AND T.OFFCODE = '" + offcode + "'";
            sql += " GROUP BY TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC), T.TIME_ID ORDER BY T.TIME_ID";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxCarMonthAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month
                            ,sum(t.total_tax_amt) as TOTAL_TAX_AMT
                            ,sum(t.last_total_tax_amt) as LAST_TOTAL_TAX_AMT
                            ,t.time_id
                            from MBL_PRODUCT_CAR_MONTH t 
                            where t.offcode = " + offcode + " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getTypeNameCarMonth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.i_type_desc) from MBL_PRODUCT_CAR_MONTH t where t.offcode = " + offcode + " order by t.i_type_desc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxDrink(string area, string Province, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_DRINK t order by t.total_tax_amt desc";
            

            string sql = @" SELECT * FROM (SELECT T.I_TYPE_DESC
                                ,SUM(T.TOTAL_TAX_AMT) AS TOTAL_TAX_AMT
                                ,SUM(T.LAST_TOTAL_TAX_AMT) AS LAST_TOTAL_TAX_AMT
                                ,SUM(T.EST_AMT) AS EST_AMT 
                                ,SUM(T.TOTAL_VOLUMN_CAPA) AS TOTAL_VOLUMN_CAPA
                                ,SUM(T.LAST_TOTAL_VOLUMN_CAPA) AS LAST_TOTAL_VOLUMN_CAPA
                                FROM MBL_PRODUCT_DRINK T  WHERE 1=1   
                                AND T.OFFCODE LIKE CASE WHEN '" + offcode + "' = 'undefined' THEN T.OFFCODE ELSE '" + offcode + "' END  ";
                      sql += " AND T.REGION_NAME LIKE CASE WHEN '" + area + "' = 'undefined' THEN T.REGION_NAME ELSE '" + area + "' END  ";
                      sql += " AND T.PROVINCE_NAME LIKE CASE WHEN '" + Province + "' = 'undefined' THEN T.PROVINCE_NAME ELSE '" + Province + "' END  ";
                      sql += " GROUP BY T.I_TYPE_DESC ORDER BY T.I_TYPE_DESC) UNION ALL SELECT ";
                      sql += @" 'รวม',
                                  SUM(S.TOTAL_TAX_AMT),
                                  SUM(S.LAST_TOTAL_TAX_AMT),
                                  SUM(S.EST_AMT),
                                  SUM(S.TOTAL_VOLUMN_CAPA),
                                  SUM(S.LAST_TOTAL_VOLUMN_CAPA)
                                FROM MBL_PRODUCT_DRINK S ";
                      sql += " WHERE  S.OFFCODE LIKE CASE WHEN '" + offcode + "' = 'undefined' THEN S.OFFCODE ELSE '" + offcode + "' END";
                      sql += " AND S.REGION_NAME LIKE CASE WHEN '" + area + "' = 'undefined' THEN S.REGION_NAME ELSE '" + area + "' END  ";
                      sql += " AND S.PROVINCE_NAME LIKE CASE WHEN '" + Province + "' = 'undefined' THEN S.PROVINCE_NAME ELSE '" + Province + "' END ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxDrinkMonth(string TYPE_DESC, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_DRINK_MONTH t where t.i_type_code='" + code + "' and t.offcode='" + offcode + "'  order by t.time_id";
            string sql = @"SELECT TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC) AS MONTH,
                               SUM(T.TOTAL_TAX_AMT) AS TOTAL_TAX_AMT,
                               SUM(T.LAST_TOTAL_TAX_AMT) AS LAST_TOTAL_TAX_AMT,
                               SUM(T.EST_AMT) AS EST_AMT,
                               SUM(T.TOTAL_VOLUMN_CAPA) AS TOTAL_VOLUMN_CAPA,
                               SUM(T.LAST_TOTAL_VOLUMN_CAPA) AS LAST_TOTAL_VOLUMN_CAPA,
                               T.TIME_ID
                          FROM MBL_PRODUCT_DRINK_MONTH T
                          WHERE T.I_TYPE_DESC = '" + TYPE_DESC + "' AND T.OFFCODE = '" + offcode + "'";
            sql += " GROUP BY TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC), T.TIME_ID ORDER BY T.TIME_ID";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxDrinkMonthAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month
                            ,sum(t.total_tax_amt) as TOTAL_TAX_AMT
                            ,sum(t.last_total_tax_amt) as LAST_TOTAL_TAX_AMT
                            ,t.time_id
                            from MBL_PRODUCT_DRINK_MONTH t 
                            where t.offcode = " + offcode + " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getTypeNameDrinkMonth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.i_type_desc) from MBL_PRODUCT_DRINK_MONTH t where t.offcode = " + offcode + " order by t.i_type_desc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
        public DataTable CompareTaxVolProduct(string offcode, string region, string province, string month_from, string month_to, string dbtable)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from "+ dbtable + " t where t.offcode='" + offcode + "' ";
            if (month_from != "undefined" && month_to != "undefined")
            {
                sql += " and t.MONTH_CD between " + month_from + " and " + month_to + "";
            }
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxVolSura(string offcode, string region, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from MBL_PRODUCT_SURA_MONTH t where t.offcode='" + offcode + "' ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxVolBeer(string offcode, string region, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from MBL_PRODUCT_BEER_MONTH t where t.offcode='" + offcode + "' ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxVolCar(string offcode, string region, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from MBL_PRODUCT_CAR_MONTH t where t.offcode='" + offcode + "' ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxVolDrink(string offcode, string region, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from MBL_PRODUCT_DRINK_MONTH t where t.offcode='" + offcode + "' ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getTypeNameOilMonth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.i_type_desc) from MBL_PRODUCT_OIL_MONTH t where t.offcode = " + offcode + " order by t.i_type_desc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable getTypeNameSicaMonth(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.i_type_desc) from MBL_PRODUCT_TOBACCO_MONTH t where t.offcode = " + offcode + " order by t.i_type_desc";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxOilMonth(string TYPE_DESC, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_CAR_MONTH t where t.i_type_code='" + code + "' and t.offcode='" + offcode + "'  order by t.time_id";
            string sql = @"SELECT TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC) AS MONTH,
                               SUM(T.TOTAL_TAX_AMT) AS TOTAL_TAX_AMT,
                               SUM(T.LAST_TOTAL_TAX_AMT) AS LAST_TOTAL_TAX_AMT,
                               SUM(T.EST_AMT) AS EST_AMT,
                               SUM(T.TOTAL_VOLUMN_CAPA) AS TOTAL_VOLUMN_CAPA,
                               SUM(T.LAST_TOTAL_VOLUMN_CAPA) AS LAST_TOTAL_VOLUMN_CAPA,
                               T.TIME_ID
                          FROM MBL_PRODUCT_OIL_MONTH T
                          WHERE T.I_TYPE_DESC = '" + TYPE_DESC + "' AND T.OFFCODE = '" + offcode + "'";
            sql += " GROUP BY TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC), T.TIME_ID ORDER BY T.TIME_ID";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxSicaMonth(string TYPE_DESC, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_CAR_MONTH t where t.i_type_code='" + code + "' and t.offcode='" + offcode + "'  order by t.time_id";
            string sql = @"SELECT TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC) AS MONTH,
                               SUM(T.TOTAL_TAX_AMT) AS TOTAL_TAX_AMT,
                               SUM(T.LAST_TOTAL_TAX_AMT) AS LAST_TOTAL_TAX_AMT,
                               SUM(T.EST_AMT) AS EST_AMT,
                               SUM(T.TOTAL_VOLUMN_CAPA) AS TOTAL_VOLUMN_CAPA,
                               SUM(T.LAST_TOTAL_VOLUMN_CAPA) AS LAST_TOTAL_VOLUMN_CAPA,
                               T.TIME_ID
                          FROM MBL_PRODUCT_TOBACCO_MONTH T
                          WHERE T.I_TYPE_DESC = '" + TYPE_DESC + "' AND T.OFFCODE = '" + offcode + "'";
            sql += " GROUP BY TRANS_SHORT_MONTH(T.BUDGET_MONTH_DESC), T.TIME_ID ORDER BY T.TIME_ID";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxSicaMonthAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month
                            ,sum(t.total_tax_amt) as TOTAL_TAX_AMT
                            ,sum(t.last_total_tax_amt) as LAST_TOTAL_TAX_AMT
                            ,t.time_id
                            from MBL_PRODUCT_TOBACCO_MONTH t 
                            where t.offcode = " + offcode + " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxOilMonthAll(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month
                            ,sum(t.total_tax_amt) as TOTAL_TAX_AMT
                            ,sum(t.last_total_tax_amt) as LAST_TOTAL_TAX_AMT
                            ,t.time_id
                            from MBL_PRODUCT_OIL_MONTH t 
                            where t.offcode = " + offcode + " group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

    }
}