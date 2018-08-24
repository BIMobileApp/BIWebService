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

            string sql = @"select case when sum(a.Total_Tax_Amt) is not null then ROUND((nvl(sum(a.Total_Tax_Amt),0)/nvl(sum(a.Est_Amt),0))*100)
                            else 0 end as tax_percent,
                            case when sum(a.Last_Total_Tax_Amt) is not null then ROUND((nvl(sum(a.Last_Total_Tax_Amt),0)/nvl(sum(a.Est_Amt),0))*100) 
                            else 0 end as Last_tax_percent,
                            100 as Est_percent
                         from MBL_PRODUCT_SURA a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

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

            return dt;
        }

        public DataTable TaxPercentCar(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case when sum(a.Total_Tax_Amt) is not null then ROUND((nvl(sum(a.Total_Tax_Amt),0)/nvl(sum(a.Est_Amt),0))*100)
                            else 0 end as tax_percent,
                            case when sum(a.Last_Total_Tax_Amt) is not null then ROUND((nvl(sum(a.Last_Total_Tax_Amt),0)/nvl(sum(a.Est_Amt),0))*100) 
                            else 0 end as Last_tax_percent,
                            100 as Est_percent
                         from MBL_PRODUCT_CAR a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

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

            return dt;
        }

        public DataTable TaxPercentBeer(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case when sum(a.Total_Tax_Amt) is not null then ROUND((nvl(sum(a.Total_Tax_Amt),0)/nvl(sum(a.Est_Amt),0))*100)
                            else 0 end as tax_percent,
                            case when sum(a.Last_Total_Tax_Amt) is not null then ROUND((nvl(sum(a.Last_Total_Tax_Amt),0)/nvl(sum(a.Est_Amt),0))*100) 
                            else 0 end as Last_tax_percent,
                            100 as Est_percent
                         from MBL_PRODUCT_BEER a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

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

            return dt;
        }

        public DataTable TaxPercentDrink(string offcode)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select case when sum(a.Total_Tax_Amt) is not null then ROUND((nvl(sum(a.Total_Tax_Amt),0)/nvl(sum(a.Est_Amt),0))*100)
                            else 0 end as tax_percent,
                            case when sum(a.Last_Total_Tax_Amt) is not null then ROUND((nvl(sum(a.Last_Total_Tax_Amt),0)/nvl(sum(a.Est_Amt),0))*100) 
                            else 0 end as Last_tax_percent,
                            100 as Est_percent
                         from MBL_PRODUCT_DRINK a where a.offcode = " + offcode + "";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

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

            return dt;
        }
    }
}