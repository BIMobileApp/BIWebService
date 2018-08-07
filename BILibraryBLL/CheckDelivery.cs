using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class CheckDelivery
    {
        Conn con = new Conn();
        public DataTable CheckDeliveryAllTaxPage(string st_date, string en_date)
        {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select b.sort as row_list,b.group_name as group_name, " +
                          " sum(a.tax_nettax_amt) as tax_nettax_amt, " +
                         " sum(a.last_tax_nettax_amt) as last_tax_nettax_amt, " +
       " nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.last_tax_nettax_amt), 0) as compare_nettax_amt, " +
      " case when sum(a.tax_nettax_amt) > 0 and sum(a.last_tax_nettax_amt) > 0 then " +
         " round(((nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.last_tax_nettax_amt), 0)) * 100) / " +
               " sum(a.last_tax_nettax_amt),2) else -100 " +
       " end as percents,sum(a.estimate) as estimates,nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.estimate), 0) as compare_tax_nettax_amt, " +
      " case when sum(a.tax_nettax_amt) > 0 and sum(a.estimate) > 0 then " +
          " round(((nvl(sum(a.tax_nettax_amt), 0) - nvl(sum(a.estimate), 0)) * 100) /sum(a.estimate),2) " +
        " else -100 end as estimate_percent " +
  " from ic_sum_allday_cube a, ic_product_grp_dim b " +
"  where a.product_grp_cd = b.group_id and a.time_id between  " + st_date + " and   " + en_date + " " +
   " group by b.sort, b.group_name order by b.sort";
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;

        }
    }
}