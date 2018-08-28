using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class GaugeProduct
    {
        Conn con = new Conn();

        public DataTable TaxPercentSura(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select 
                            case 
                              when nvl(sum(a.total_tax_amt) ,0) = 0  and nvl(sum(a.last_total_tax_amt),0)= 0 then 0  
                              when nvl(sum(a.total_tax_amt),0)>0  and nvl(sum(a.last_total_tax_amt),0) =0 then 100
                              when nvl(sum(a.total_tax_amt),0)=0  and nvl(sum(a.last_total_tax_amt),0) > 0 then -100    
                            else round((nvl(sum(a.total_tax_amt) ,0)/nvl(sum(a.last_total_tax_amt),0))*100)  end as TAX_PERCENT,  
                            case 
                              when nvl(sum(a.total_tax_amt) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                              when nvl(sum(a.total_tax_amt),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                              when nvl(sum(a.total_tax_amt),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.total_tax_amt) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as LAST_TAX_PERCENT,
                            100 AS   EST_PERCENT
                         from MBL_PRODUCT_SURA a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable QuantityPercentSura(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case when sum(a.total_volumn_capa) is not null then ROUND((nvl(sum(a.total_volumn_capa),0)/nvl(sum(a.last_total_volumn_capa),0))*100)
                           else 0 end as quan_percent
                         from MBL_PRODUCT_SURA a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxPercentCar(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select 
                            case 
                                when nvl(sum(a.total_tax_amt) ,0) = 0  and nvl(sum(a.last_total_tax_amt),0)= 0 then 0  
                                when nvl(sum(a.total_tax_amt),0)>0  and nvl(sum(a.last_total_tax_amt),0) =0 then 100
                                when nvl(sum(a.total_tax_amt),0)=0  and nvl(sum(a.last_total_tax_amt),0) > 0 then -100    
                            else round((nvl(sum(a.total_tax_amt) ,0)/nvl(sum(a.last_total_tax_amt),0))*100)  end as TAX_PERCENT,  
                            case 
                                when nvl(sum(a.total_tax_amt) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                                when nvl(sum(a.total_tax_amt),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                                when nvl(sum(a.total_tax_amt),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.total_tax_amt) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as LAST_TAX_PERCENT,
                            100 AS   EST_PERCENT
                         from MBL_PRODUCT_CAR a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable QuantityPercentCar(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case when sum(a.total_volumn_capa) is not null then ROUND((nvl(sum(a.total_volumn_capa),0)/nvl(sum(a.last_total_volumn_capa),0))*100)
                           else 0 end as quan_percent
                         from MBL_PRODUCT_CAR a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxPercentBeer(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case 
                              when nvl(sum(a.total_tax_amt) ,0) = 0  and nvl(sum(a.last_total_tax_amt),0)= 0 then 0  
                              when nvl(sum(a.total_tax_amt),0)>0  and nvl(sum(a.last_total_tax_amt),0) =0 then 100
                              when nvl(sum(a.total_tax_amt),0)=0  and nvl(sum(a.last_total_tax_amt),0) > 0 then -100    
                            else round((nvl(sum(a.total_tax_amt) ,0)/nvl(sum(a.last_total_tax_amt),0))*100)  end as TAX_PERCENT,  
                            case 
                              when nvl(sum(a.total_tax_amt) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                              when nvl(sum(a.total_tax_amt),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                              when nvl(sum(a.total_tax_amt),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.total_tax_amt) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as LAST_TAX_PERCENT,
                            100 AS   EST_PERCENT
                         from MBL_PRODUCT_BEER a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable QuantityPercentBeer(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case when sum(a.total_volumn_capa) is not null then ROUND((nvl(sum(a.total_volumn_capa),0)/nvl(sum(a.last_total_volumn_capa),0))*100)
                           else 0 end as quan_percent
                         from MBL_PRODUCT_BEER a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxPercentDrink(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select 
                            case 
                              when nvl(sum(a.total_tax_amt) ,0) = 0  and nvl(sum(a.last_total_tax_amt),0)= 0 then 0  
                              when nvl(sum(a.total_tax_amt),0)>0  and nvl(sum(a.last_total_tax_amt),0) =0 then 100
                              when nvl(sum(a.total_tax_amt),0)=0  and nvl(sum(a.last_total_tax_amt),0) > 0 then -100    
                            else round((nvl(sum(a.total_tax_amt) ,0)/nvl(sum(a.last_total_tax_amt),0))*100)  end as TAX_PERCENT,  
                            case 
                              when nvl(sum(a.total_tax_amt) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                              when nvl(sum(a.total_tax_amt),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                              when nvl(sum(a.total_tax_amt),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.total_tax_amt) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as LAST_TAX_PERCENT,
                            100 AS   EST_PERCENT
                         from MBL_PRODUCT_DRINK a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable QuantityPercentDrink(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case when sum(a.total_volumn_capa) is not null then ROUND((nvl(sum(a.total_volumn_capa),0)/nvl(sum(a.last_total_volumn_capa),0))*100)
                           else 0 end as quan_percent
                         from MBL_PRODUCT_DRINK a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}