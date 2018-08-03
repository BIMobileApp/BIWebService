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
                string q = "Select * from CD_DAILY_DETAIL_FACT t Where rownum <= 100";
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