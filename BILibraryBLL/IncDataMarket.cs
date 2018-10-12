﻿using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class IncDataMarket
    {
        Conn con = new Conn();

        public DataTable IncDataMarketList(string offcode,string province,string region)
        {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = "select REGION_DESC,COUNT_REG,NUM_OF_LIC_SURA,NUM_OF_LIC_TOBBACO,NUM_OF_LIC_CARD,TOTAL_LIC";
            sql += " from mbl_lic_data_3 where offcode = " + offcode + " ";
            sql += " AND PROVINCE_NAME = case when '" + province + "'= 'undefined' then PROVINCE_NAME else '" + province + "' end ";
            sql += " AND REGION_NAME = case when '" + region + "' = 'undefined' then REGION_NAME else '" + region + "' end";
            sql += " order by REGION_DESC";

            /*select REGION_DESC, COUNT_REG, NUM_OF_LIC_SURA, NUM_OF_LIC_TOBBACO, NUM_OF_LIC_CARD, TOTAL_LIC
from mbl_lic_data_3 where offcode = 000000
union all
select 'รวม',SUM(COUNT_REG) AS COUNT_REG, SUM(NUM_OF_LIC_SURA) AS NUM_OF_LIC_SURA
 , SUM(NUM_OF_LIC_TOBBACO) AS NUM_OF_LIC_TOBBACO, SUM(NUM_OF_LIC_CARD) AS NUM_OF_LIC_CARD
   , SUM(TOTAL_LIC) AS TOTAL_LIC
from mbl_lic_data_3 where offcode = 000000*/

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable IncSumDataMarketList(string offcode)
        {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            
            string sql = @"select SUM(COUNT_REG)AS COUNT_REG,SUM(NUM_OF_LIC_SURA) AS NUM_OF_LIC_SURA
                        , SUM(NUM_OF_LIC_TOBBACO) AS NUM_OF_LIC_TOBBACO, SUM(NUM_OF_LIC_CARD) AS NUM_OF_LIC_CARD
                        , SUM(TOTAL_LIC) AS TOTAL_LIC ";
            sql += " from mbl_lic_data_3 where offcode = " + offcode + " ";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}