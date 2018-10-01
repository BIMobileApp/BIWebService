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
                            100 AS   EST_PERCENT, sum(a.total_tax_amt) AS tax, sum(a.last_total_tax_amt) AS tax_ly,sum(a.Est_Amt) AS est
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

            string sql = @"select case 
                            when nvl(sum(a.total_volumn_capa) ,0) = 0  and nvl(sum(a.last_total_volumn_capa),0)= 0 then 0  
                            when nvl(sum(a.total_volumn_capa),0)>0  and nvl(sum(a.last_total_volumn_capa),0) =0 then 100
                            when nvl(sum(a.total_volumn_capa),0)=0  and nvl(sum(a.last_total_volumn_capa),0) > 0 then -100    
                            else round((nvl(sum(a.total_volumn_capa) ,0)/nvl(sum(a.last_total_volumn_capa),0))*100)  end as quan_percent,
                            case 
                            when nvl(sum(a.last_total_volumn_capa) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                            when nvl(sum(a.last_total_volumn_capa),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                            when nvl(sum(a.last_total_volumn_capa),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.last_total_volumn_capa) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as last_quan_percent,
                            sum(a.total_volumn_capa) AS total_volumn_capa, sum(a.last_total_volumn_capa) AS last_total_volumn_capa  
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
                            100 AS   EST_PERCENT, sum(a.total_tax_amt) AS tax, sum(a.last_total_tax_amt) AS tax_ly,sum(a.Est_Amt) AS est
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

            string sql = @"select case 
                            when nvl(sum(a.total_volumn_capa) ,0) = 0  and nvl(sum(a.last_total_volumn_capa),0)= 0 then 0  
                            when nvl(sum(a.total_volumn_capa),0)>0  and nvl(sum(a.last_total_volumn_capa),0) =0 then 100
                            when nvl(sum(a.total_volumn_capa),0)=0  and nvl(sum(a.last_total_volumn_capa),0) > 0 then -100    
                            else round((nvl(sum(a.total_volumn_capa) ,0)/nvl(sum(a.last_total_volumn_capa),0))*100)  end as quan_percent,
                            case 
                            when nvl(sum(a.last_total_volumn_capa) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                            when nvl(sum(a.last_total_volumn_capa),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                            when nvl(sum(a.last_total_volumn_capa),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.last_total_volumn_capa) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as last_quan_percent,
                            sum(a.total_volumn_capa) AS total_volumn_capa, sum(a.last_total_volumn_capa) AS last_total_volumn_capa  
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
                            100 AS   EST_PERCENT, sum(a.total_tax_amt) AS tax, sum(a.last_total_tax_amt) AS tax_ly,sum(a.Est_Amt) AS est
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

            string sql = @"select case 
                            when nvl(sum(a.total_volumn_capa) ,0) = 0  and nvl(sum(a.last_total_volumn_capa),0)= 0 then 0  
                            when nvl(sum(a.total_volumn_capa),0)>0  and nvl(sum(a.last_total_volumn_capa),0) =0 then 100
                            when nvl(sum(a.total_volumn_capa),0)=0  and nvl(sum(a.last_total_volumn_capa),0) > 0 then -100    
                            else round((nvl(sum(a.total_volumn_capa) ,0)/nvl(sum(a.last_total_volumn_capa),0))*100)  end as quan_percent,
                            case 
                            when nvl(sum(a.last_total_volumn_capa) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                            when nvl(sum(a.last_total_volumn_capa),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                            when nvl(sum(a.last_total_volumn_capa),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.last_total_volumn_capa) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as last_quan_percent,
                            sum(a.total_volumn_capa) AS total_volumn_capa, sum(a.last_total_volumn_capa) AS last_total_volumn_capa  
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
                            100 AS   EST_PERCENT, sum(a.total_tax_amt) AS tax, sum(a.last_total_tax_amt) AS tax_ly,sum(a.Est_Amt) AS est
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

            string sql = @"select case 
                            when nvl(sum(a.total_volumn_capa) ,0) = 0  and nvl(sum(a.last_total_volumn_capa),0)= 0 then 0  
                            when nvl(sum(a.total_volumn_capa),0)>0  and nvl(sum(a.last_total_volumn_capa),0) =0 then 100
                            when nvl(sum(a.total_volumn_capa),0)=0  and nvl(sum(a.last_total_volumn_capa),0) > 0 then -100    
                            else round((nvl(sum(a.total_volumn_capa) ,0)/nvl(sum(a.last_total_volumn_capa),0))*100)  end as quan_percent,
                            case 
                            when nvl(sum(a.last_total_volumn_capa) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                            when nvl(sum(a.last_total_volumn_capa),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                            when nvl(sum(a.last_total_volumn_capa),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.last_total_volumn_capa) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as last_quan_percent,
                            sum(a.total_volumn_capa) AS total_volumn_capa, sum(a.last_total_volumn_capa) AS last_total_volumn_capa  
                         from MBL_PRODUCT_DRINK a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }


        public DataTable TaxPercentOil(string offcode)
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
                            100 AS   EST_PERCENT, sum(a.total_tax_amt) AS tax, sum(a.last_total_tax_amt) AS tax_ly,sum(a.Est_Amt) AS est
                         from MBL_PRODUCT_OIL a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable QuantityPercentOil(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case 
                            when nvl(sum(a.total_volumn_capa) ,0) = 0  and nvl(sum(a.last_total_volumn_capa),0)= 0 then 0  
                            when nvl(sum(a.total_volumn_capa),0)>0  and nvl(sum(a.last_total_volumn_capa),0) =0 then 100
                            when nvl(sum(a.total_volumn_capa),0)=0  and nvl(sum(a.last_total_volumn_capa),0) > 0 then -100    
                            else round((nvl(sum(a.total_volumn_capa) ,0)/nvl(sum(a.last_total_volumn_capa),0))*100)  end as quan_percent,
                            case 
                            when nvl(sum(a.last_total_volumn_capa) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                            when nvl(sum(a.last_total_volumn_capa),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                            when nvl(sum(a.last_total_volumn_capa),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.last_total_volumn_capa) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as last_quan_percent,
                            sum(a.total_volumn_capa) AS total_volumn_capa, sum(a.last_total_volumn_capa) AS last_total_volumn_capa  
                         from MBL_PRODUCT_OIL a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxPercentSica(string offcode)
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
                            100 AS   EST_PERCENT, sum(a.total_tax_amt) AS tax, sum(a.last_total_tax_amt) AS tax_ly,sum(a.Est_Amt) AS est
                         from MBL_PRODUCT_TOBACCO a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable QuantityPercentSica(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case 
                            when nvl(sum(a.total_volumn_capa) ,0) = 0  and nvl(sum(a.last_total_volumn_capa),0)= 0 then 0  
                            when nvl(sum(a.total_volumn_capa),0)>0  and nvl(sum(a.last_total_volumn_capa),0) =0 then 100
                            when nvl(sum(a.total_volumn_capa),0)=0  and nvl(sum(a.last_total_volumn_capa),0) > 0 then -100    
                            else round((nvl(sum(a.total_volumn_capa) ,0)/nvl(sum(a.last_total_volumn_capa),0))*100)  end as quan_percent,
                            case 
                            when nvl(sum(a.last_total_volumn_capa) ,0) = 0  and nvl(sum(a.Est_Amt),0)= 0 then 0  
                            when nvl(sum(a.last_total_volumn_capa),0)>0  and nvl(sum(a.Est_Amt),0) =0 then 100
                            when nvl(sum(a.last_total_volumn_capa),0)=0  and nvl(sum(a.Est_Amt),0) > 0 then -100    
                            else round((nvl(sum(a.last_total_volumn_capa) ,0)/nvl(sum(a.Est_Amt),0))*100)  end as last_quan_percent,
                            sum(a.total_volumn_capa) AS total_volumn_capa, sum(a.last_total_volumn_capa) AS last_total_volumn_capa  
                         from MBL_PRODUCT_TOBACCO a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}