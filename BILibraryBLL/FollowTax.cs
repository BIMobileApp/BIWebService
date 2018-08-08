using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class FollowTax
    {
        Conn con = new Conn();

        public DataTable FollowTaxMth()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select o.region_name, sum(t.TAX_NETTAX_AMT) AS amt from Ic_Sum_Allday_Cube t,"+
                           " Ic_Office_Dim o where t.offcode_own = o.offcode and "+
                           " t.time_id between 20171001 and 20171031 group by o.region_name, o.region_cd "+
                           " order by o.region_cd";
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;

        }
    }
}