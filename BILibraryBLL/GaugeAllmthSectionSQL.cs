using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class GaugeAllmthSectionSQL
    {
        //get connectionString to connect Database
        Conn con = new Conn();

        //query out in dataTable
        public DataTable SQL1()
        {
            //create datatable format in 'dt'
            DataTable dt = new DataTable();
            //create connection to access database by OleDbConnection 
            using (OleDbConnection thisConnection = new OleDbConnection(con.connection()))
            {
                //string q = "select * from Ic_Sum_Allday_Cube";
                string q = "select t.budget_year,t.budget_month_cd,t.month_desc,region_name,sum(t.tax) as tax" +
                           " , sum(t.tax_ly) as tax_ly , case when sum(t.tax) > 0 and sum(t.estimate) > 0 then" +
                           " round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /sum(t.estimate),2)" +
                           " else -100 end as tax_percent , case" +
                           " when sum(t.tax_ly) > 0 and sum(t.estimate) > 0 then" +
                           " round(((nvl(sum(t.tax_ly), 0) - nvl(sum(t.estimate), 0)) * 100) / sum(t.estimate),2)" +
                           " else -100 end as tax_ly_percent, case when sum(t.tax) > 0 and sum(t.estimate) > 0 then" +
                           " round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /" +
                           " sum(t.estimate),2)" +
                           " else -100 end as estimate_percent" +
                           " from(select d.budget_year as budget_year," +
                           " d.budget_month_cd as budget_month_cd," +
                           " d.month_desc as month_desc," +
                           " c.region_name as region_name, b.sort, b.group_name, sum(a.tax_nettax_amt) as tax," +
                           " sum(a.last_tax_nettax_amt) as tax_ly, sum(a.estimate) as estimate" +
                           " from ic_sum_allday_cube a, ic_product_grp_dim b, ic_office_dim c, ic_time_dim d" +
                           " ,ic_time_dim d2 " +
                           " where a.product_grp_cd = b.group_id and a.offcode_own = c.offcode and a.time_id = d.time_id" +
                           " and d.budget_year = d2.budget_year and d2.time_id = to_number(to_char(sysdate, 'YYYYMMDD'))" +
                           " group by c.region_name, b.sort, b.group_name, d.budget_month_cd, d.budget_year,d.month_desc" +
                           " order by d.budget_month_cd, c.region_name, b.sort) t" +
                           " group by t.budget_year" +
                           " , t.budget_month_cd" +
                           " , t.month_desc" +
                           " , region_name" +
                           " order by t.month_desc" +
                           " , region_name";
                //prepare get q to use with thisconnection by command
                OleDbCommand cmd = new OleDbCommand(q, thisConnection);
                thisConnection.Open();
                //Execute q 
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                //get result to fill in 'dt'
                adapter.Fill(dt);

                return dt;
            }
        }

    }
}