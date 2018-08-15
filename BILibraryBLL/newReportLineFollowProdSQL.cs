using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class newReportLineFollowProdSQL
    {
        //get connectionString to connect Database
        Conn con = new Conn();

        //query out in dataTable
        public DataTable SQL1(string id)
        {
            //create datatable format in 'dt'
            DataTable dt = new DataTable();
            //create connection to access database by OleDbConnection 
            using (OleDbConnection thisConnection = new OleDbConnection(con.connection()))
            {
                //string q = "select * from Ic_Sum_Allday_Cube";
                string q = "select b.sort as no" +
                    " ,b.group_name as grp_name" +
                    " ,t.month_short_desc as month" +
                    " ,t.budget_month_cd" +
                    " ,sum(a.tax_nettax_amt) as tax" +
                    " ,sum(a.last_tax_nettax_amt) as tax_ly" +
                    " ,sum(a.estimate) as est" +
                    " from ic_sum_allday_cube a, ic_product_grp_dim b, ic_time_dim t" +
                    " where a.product_grp_cd = b.group_id" +
                    " and a.product_grp_cd = "+ id +
                    " and a.time_id between 20180501 and 20180531" +
                    " group by b.sort, b.group_name,t.month_short_desc,t.budget_month_cd" +
                    " order by b.sort,t.budget_month_cd ";
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

       public DataTable getProduct()
        {
            //create datatable format in 'dt'
            DataTable dt = new DataTable();
            //create connection to access database by OleDbConnection 
            using (OleDbConnection thisConnection = new OleDbConnection(con.connection()))
            {
                //string q = "select * from Ic_Sum_Allday_Cube";
                string q = @"select 
                             b.group_name as grp_name,
                             b.group_id as grp_id
                             from ic_product_grp_dim b
                             where b.sort != 0";
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