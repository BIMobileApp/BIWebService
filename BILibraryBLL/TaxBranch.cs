using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class TaxBranch
    {
        Conn con = new Conn();
        public DataTable TaxCurYearProvince(string offcode, string area, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from (select trans_province_shot_data(t.province_name) AS province_name,sum(t.Tax) as Tax,sum(t.Last_Tax) as Last_Tax
                            ,sum(t.estimate) as estimate,
                            case when sum(t.tax) > 0 and sum(t.estimate) > 0 then
                            round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /
                            sum(t.estimate),2)
                            else 0 end as PERCENT_TAX
                            from MBL_TAX_MONTH t
                            where t.region_name = '" + area + "' and t.province_name = '" + province + "' and t.offcode = " + offcode + " ";
                   sql += @" group by t.province_name  order by t.province_name)
                            union all
                            select 'รวม',sum(s.Tax) as Tax,sum(s.Last_Tax) as Last_Tax,sum(s.estimate) as estimate,
                            case
                            when sum(s.tax) > 0 and sum(s.estimate) > 0 then
                            round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) /
                            sum(s.estimate),2)
                            else 0 end as PERCENT_TAX
                            from MBL_TAX_MONTH s where s.region_name = '" + area + "' and s.province_name = '" + province + "' and s.offcode= " + offcode+"";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxCurMonth(string offcode, string area, string Province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());


            String sql = @"select * from (select TRANS_Short_month(t.budget_month_desc) as budget_month_desc,t.time_id,sum(t.tax) as TAX,sum(t.last_tax) as LAST_TAX,sum(t.estimate) as ESTIMATE,
                             case when sum(t.tax) > 0 and sum(t.estimate) > 0 then
                                      round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /sum(t.estimate),2)
                                      else 0 end as PERCENT_TAX
                              from MBL_TAX_MONTH_MON t where t.offcode = '" + offcode + "' AND t.region_name = '" + area + "' AND t.province_name = '" + Province + "' ";
            //sql += @" AND t.region_name = case when '" + area + "' = 'undefined' then t.region_name else '" + area + "' end   ";
            //sql += @" AND t.province_name = case when '" + Province + "' = 'undefined' then t.province_name else '" + Province + "' end ";
            sql += @" group by t.budget_month_desc, t.time_id order by t.time_id)
                            union all
                            select 'รวม',null,sum(s.tax),sum(s.last_tax),sum(s.estimate),
                                   case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate),2)
                                   else 0 end as percent_tax 
                            from MBL_TAX_MONTH_MON s where s.offcode = '" + offcode + "' and s.region_name = '" + area + "' and s.province_name = '" + Province + "'";
            //sql += @" AND s.region_name = case when '" + area + "' = 'undefined' then s.region_name else '" + area + "' end   ";
            //sql += @" AND s.province_name = case when '" + Province + "' = 'undefined' then s.province_name else '" + Province + "' end ";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable TaxCurProduct(string offcode, string area, string province)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from (
                           select t.group_name,t.sort, sum(t.tax) as TAX, sum(t.last_tax) as LAST_TAX,sum(t.estimate) as ESTIMATE,
                                  case when sum(t.tax) > 0 and sum(t.estimate) > 0 then
                                  round(((nvl(sum(t.tax), 0) - nvl(sum(t.estimate), 0)) * 100) /sum(t.estimate),2)
                                  else 0 end as PERCENT_TAX
                          from MBL_TAX_GOODS t where t.offcode = " + offcode + " AND t.region_name = '" + area + "' AND t.province_name = '" + province + "'";
            //sql += @" AND t.region_name = case when '" + area + "' = 'undefined' then t.region_name else '" + area + "' end ";
            //sql += @" AND t.province_name = case when '" + province + "' = 'undefined' then t.province_name else '" + province + "' end ";
            sql += @" group by t.group_name, t.sort order by t.sort)
                     union all
                     select 'รวม',null,sum(s.tax),sum(s.last_tax),sum(s.estimate),
                            case when sum(s.tax) > 0 and sum(s.estimate) > 0 then round(((nvl(sum(s.tax), 0) - nvl(sum(s.estimate), 0)) * 100) / sum(s.estimate),2)
                            else 0 end as percent_tax 
                     from MBL_TAX_GOODS s where s.offcode =  " + offcode + " and s.region_name = '" + area + "' and s.province_name= '" + province + "'";
            //sql += @" AND s.region_name = case when '" + area + "' = 'undefined' then s.region_name else '" + area + "' end  ";
            //sql += @" AND s.province_name = case when '" + province + "' = 'undefined' then s.province_name else '" + province + "' end ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }
    }
}