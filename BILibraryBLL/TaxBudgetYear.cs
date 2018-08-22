﻿using ClassLib;
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

            return dt;
        }

        public DataTable TaxCurYear(string offcode)
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

            string sql = @"select * from  mbl_month_01 where offcode = '"+offcode+"'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable TaxProductCurYear(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from mbl_goods_01 where offcode = '" + offcode + "'";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable TaxBudgetProduct() {
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

            return dt;
        }

        public DataTable TaxBudgetRegAll(string offcode,string group_id) {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());


            string sql = @"select reg_name AS reg_name,TAX_NETTAX_AMT AS tax,myrank AS sort 
                            from mbl_top_product_10 
                            where offcode = " + offcode + " and group_id = "+ group_id + " ";
                  sql += @" and myrank between '1' and '10' order by tax_nettax_amt desc";

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

            return dt;
        }

        public DataTable TaxBudgetReg(string offcode, string group_id, string year)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select reg_name AS reg_name,TAX_NETTAX_AMT AS tax,myrank AS sort 
                            from mbl_top_product_10 
                            where offcode = " + offcode + " and group_id = " + group_id + " and budget_year = "+ year + "";
            sql += @" and myrank between '1' and '10' order by tax_nettax_amt desc";

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

            return result;
        }

        public string SumTaxBudgetReg(string year) {

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

            return result;
        }

        public DataTable TaxBudgetRegByMthAll()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select
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
                     order by  r1.reg_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable TaxBudgetRegByMth(string mth)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select
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
                     order by  r1.reg_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

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

            return result;
        }
    }
}