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

        public DataTable ImcomeList()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select d.budget_year,d.budget_month_cd,d.month_desc,c.region_name
                        ,b.sort,b.group_name,sum(a.tax_nettax_amt) as tax,sum(a.last_tax_nettax_amt) as tax_ly
       ,nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.last_tax_nettax_amt), 0) as compare_tax_ly
       ,case when sum(a.tax_nettax_amt) > 0 and sum(a.last_tax_nettax_amt) > 0 then
          round(((nvl(sum(a.tax_nettax_amt), 0) -
                nvl(sum(a.last_tax_nettax_amt), 0)) * 100) /
                sum(a.last_tax_nettax_amt),
                2)
         else
          -100
       end as tax_percent
       ,sum(a.estimate) as estimate
       ,nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.estimate), 0) as compare_estimate_diff,
       case
         when sum(a.tax_nettax_amt) > 0 and sum(a.estimate) > 0 then
          round(((nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.estimate), 0)) * 100) /
                sum(a.estimate),
                2)
         else
          -100
       end as estimate_percent
  from ic_sum_allday_cube a
       ,ic_product_grp_dim b
       , ic_office_dim c
       ,ic_time_dim d
       , ic_time_dim d2
  where a.product_grp_cd = b.group_id
   and a.offcode_own = c.offcode
   --and a.time_id between 20180501 and 20180531
   and a.time_id = d.time_id
   and d.budget_year = d2.budget_year
   and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))
 --group by b.sort, b.group_name
 group by c.region_name,b.sort, b.group_name, d.budget_month_cd, d.budget_year, d.month_desc
 --order by b.sort
 order by d.budget_month_cd,c.region_name, b.sort";
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;

        }
    }
}