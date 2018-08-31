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

        public DataTable CompareTaxSura(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_SURA t where t.offcode='"+ offcode + "' order by t.total_tax_amt desc";
            string sql = @"select *
                              from (select *
                              from MBL_PRODUCT_SURA t
                              where t.offcode = " + offcode + "" ;
                   sql += @" order by t.total_tax_amt desc)
                            union all
                            select null,
                                   'รวม',
                                   sum(TOTAL_TAX_AMT),
                                   sum(LAST_TOTAL_TAX_AMT),
                                   sum(EST_AMT),
                                   sum(TOTAL_VOLUMN_CAPA),
                                   sum(LAST_TOTAL_VOLUMN_CAPA),
                                   null
                              from MBL_PRODUCT_SURA
                              where offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxSuraMonth(string code,string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_SURA_MONTH t where t.i_type_code='" + code+"' and t.offcode='"+offcode+"' order by t.time_id";

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

            string sql = @"select distinct(t.i_type_desc), t.i_type_code from MBL_PRODUCT_SURA_MONTH t where t.offcode = "+ offcode +" order by t.i_type_code";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxBeer(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_BEER t order by t.total_tax_amt desc";
            string sql = @"select *
                              from (select * from MBL_PRODUCT_BEER t where offcode = " + offcode + " order by t.total_tax_amt desc )";
                  sql += @" union all
                            select null,
                                   'รวม',
                                   sum(TOTAL_TAX_AMT),
                                   sum(LAST_TOTAL_TAX_AMT),
                                   sum(EST_AMT),
                                   sum(TOTAL_VOLUMN_CAPA),
                                   sum(LAST_TOTAL_VOLUMN_CAPA),
                                   null
                              from MBL_PRODUCT_BEER
                             where offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxBeerMonth(string code, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_BEER_MONTH t where t.i_type_code='" + code + "' and t.offcode='" + offcode + "'  order by t.time_id";

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

            string sql = @"select distinct(t.i_type_desc), t.i_type_code from MBL_PRODUCT_BEER_MONTH t where t.offcode = " + offcode + " order by t.i_type_code";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxCar(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_CAR t order by t.total_tax_amt desc";
            string sql = @"select *
                              from (select * from MBL_PRODUCT_CAR t where offcode = " + offcode + " order by t.total_tax_amt desc )";
            sql += @" union all
                            select null,
                                   'รวม',
                                   sum(TOTAL_TAX_AMT),
                                   sum(LAST_TOTAL_TAX_AMT),
                                   sum(EST_AMT),
                                   sum(TOTAL_VOLUMN_CAPA),
                                   sum(LAST_TOTAL_VOLUMN_CAPA),
                                   null
                              from MBL_PRODUCT_CAR
                             where offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxCarMonth(string code, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_CAR_MONTH t where t.i_type_code='" + code + "' and t.offcode='" + offcode + "'  order by t.time_id";

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

            string sql = @"select distinct(t.i_type_desc), t.i_type_code from MBL_PRODUCT_CAR_MONTH t where t.offcode = " + offcode + " order by t.i_type_code";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxDrink(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @"select * from MBL_PRODUCT_DRINK t order by t.total_tax_amt desc";
            string sql = @"select *
                              from (select * from MBL_PRODUCT_DRINK t where offcode = " + offcode + " order by t.total_tax_amt desc )";
            sql += @" union all
                            select null,
                                   'รวม',
                                   sum(TOTAL_TAX_AMT),
                                   sum(LAST_TOTAL_TAX_AMT),
                                   sum(EST_AMT),
                                   sum(TOTAL_VOLUMN_CAPA),
                                   sum(LAST_TOTAL_VOLUMN_CAPA),
                                   null
                              from MBL_PRODUCT_DRINK
                             where offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxDrinkMonth(string code, string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select distinct(t.budget_month_desc),TRANS_Short_month(t.budget_month_desc) as month, t.* from MBL_PRODUCT_DRINK_MONTH t where t.i_type_code='" + code + "' and t.offcode='" + offcode + "'  order by t.time_id";

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

            string sql = @"select distinct(t.i_type_desc), t.i_type_code from MBL_PRODUCT_DRINK_MONTH t where t.offcode = " + offcode + " order by t.i_type_code";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        
        public DataTable CompareTaxVolSura(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from MBL_PRODUCT_SURA_MONTH t where t.offcode='" + offcode + "'group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxVolBeer(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from MBL_PRODUCT_BEER_MONTH t where t.offcode='" + offcode + "'group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxVolCar(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from MBL_PRODUCT_CAR_MONTH t where t.offcode='" + offcode + "'group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable CompareTaxVolDrink(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select TRANS_Short_month(t.budget_month_desc) as month,t.time_id, 
                            sum(t.total_tax_amt) as total_tax_amt,
                            sum(t.last_total_tax_amt) as last_total_tax_amt,
                            sum(t.total_volumn_capa) as total_volumn_capa,
                            sum(t.last_total_volumn_capa) as last_total_volumn_capa
                            from MBL_PRODUCT_DRINK_MONTH t where t.offcode='" + offcode + "'group by TRANS_Short_month(t.budget_month_desc),t.time_id order by t.time_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

    }
}