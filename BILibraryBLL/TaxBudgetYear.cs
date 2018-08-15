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

        public DataTable TaxBudgetReg() {
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
                       and a.reg_sk = r1.reg_sk and rownum <= 10
                     group by  r1.reg_id,r1.reg_name
                     order by  r1.reg_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public string SumTaxBudgetReg() {

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
                           and rownum <= 10";

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

        public DataTable TaxBudgetRegByMth(int mth)
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
            sql += @"and a.reg_sk = r1.reg_sk and rownum <= 10
                     group by  r1.reg_id,r1.reg_name
                     order by  r1.reg_id";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
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
                           and rownum <= 10 and d.month_cd = " + mth + ""; 

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