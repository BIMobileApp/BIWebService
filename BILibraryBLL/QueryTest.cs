using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class QueryTest
    {
        //get connectionString to connect Database
        ConnectionStringTest con = new ConnectionStringTest();

        //query out in dataTable
        public DataTable SQL1()
        {
            //create datatable format in 'dt'
            DataTable dt = new DataTable();
            //create connection to access database by OleDbConnection 
            using (OleDbConnection thisConnection = new OleDbConnection(con.connection()))
            {
                //string q = "select * from Ic_Sum_Allday_Cube";
                string q = "Select grp.group_name, sum(t.tax_amt) as amt from Ic_Sum_Allday_Cube t,Ic_Product_Grp_Dim grp Where t.product_grp_cd = grp.group_id and t.time_id between 20171001 and 20171031 and t.product_grp_cd in (0101,0501,8001,7002,0201) group by grp.group_name";
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