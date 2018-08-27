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

        public DataTable IncomeList(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select goods as group_name, nettax_amt AS tax,trn_mth ,ROW_NUMBER() OVER (ORDER BY nettax_amt desc) as sort ";
                   sql += "  from MBL_INC_REAL_TIME where offcode = " + offcode + "";
            /*string sql = @"select ROW_NUMBER() OVER (ORDER BY  b.group_name) as sort,
                    b.group_name,sum(a.tax_nettax_amt) as tax,sum(a.last_tax_nettax_amt) as tax_ly
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
              and a.product_grp_cd in (0201, 0501, 7002, 7001)
             group by b.group_name
             order by b.group_name";*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;

        }
    }
}