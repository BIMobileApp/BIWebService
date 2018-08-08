using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class OldBarAllTaxSQL
    { //get connectionString to connect Database
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
                string q = "select b.sort as no, b.group_name as grp_name" +
                    " ,nvl(sum(a.tax_nettax_amt), 0) as tax" +
                    " ,nvl(sum(a.last_tax_nettax_amt), 0) as tax_ly" +
                    " ,nvl(sum(a.estimate), 0) as est "+
                    " from ic_sum_allday_cube a, ic_product_grp_dim b" +
                    " where a.product_grp_cd = b.group_id" +
                    " and a.product_grp_cd in (0101, 0501, 7001, 8001, 7002, 0201, 1690)" +
                    " and a.time_id between 20180501 and 20180531" +
                    " group by b.sort, b.group_name" +
                    " order by b.sort";

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