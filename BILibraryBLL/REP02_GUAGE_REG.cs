using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class REP02_GUAGE_REG
    {
        Conn con = new Conn();

        public DataTable GUAGE_REG(string area)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select 
                            case 
                              when nvl(sum(a.tax) ,0) = 0  and nvl(sum(a.last_tax),0)= 0 then 0  
                              when nvl(sum(a.tax),0)>0  and nvl(sum(a.last_tax),0) =0 then 100
                              when nvl(sum(a.tax),0)=0  and nvl(sum(a.last_tax),0) > 0 then -100    
                            else round((nvl(sum(a.tax) ,0)/nvl(sum(a.last_tax),0))*100)  end as TAX_PERCENT,  
                            case 
                              when nvl(sum(a.tax) ,0) = 0  and nvl(sum(a.estimate),0)= 0 then 0  
                              when nvl(sum(a.tax),0)>0  and nvl(sum(a.estimate),0) =0 then 100
                              when nvl(sum(a.tax),0)=0  and nvl(sum(a.estimate),0) > 0 then -100    
                            else round((nvl(sum(a.tax) ,0)/nvl(sum(a.estimate),0))*100)  end as LAST_TAX_PERCENT,
                              100 AS   EST_PERCENT
                            from M_REP02_GUAGE_REG a where a.area_flag = "+ area + " ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }
    }
}