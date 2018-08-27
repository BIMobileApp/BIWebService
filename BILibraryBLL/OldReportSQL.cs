using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class OldReportSQL
    {
        Conn con = new Conn();
        public DataTable REPORT_BI_1_MONTH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select ROW_NUMBER() OVER(ORDER BY t.group_name) as sort, t.*
                              from MB_BI_MONTHLY t
                                union all
                                select null,
                                       null,
                                       null,
                                       'รวมทั้งหมด',
                                       sum(s.tax_nettax_amt),
                                       sum(s.estimate),
                                       sum(s.last_tax_nettax_amt),
                                       sum(s.compare_estimate),
                                       case
                                         when sum(s.tax_nettax_amt) > 0 and sum(s.estimate) > 0 then
                                          round(((nvl(sum(s.tax_nettax_amt), 0) - nvl(sum(s.estimate), 0)) * 100) /
                                                sum(s.estimate),
                                                2)
                                         else
                                          -100
                                       end,
                                       sum(s.compare_tax),
                                       case
                                         when sum(s.last_tax_nettax_amt) > 0 and sum(s.tax_nettax_amt) > 0 then
                                          round(((nvl(sum(s.last_tax_nettax_amt), 0) -
                                                nvl(sum(s.tax_nettax_amt), 0)) * 100) /
                                                sum(s.last_tax_nettax_amt),
                                                2)
                                         else
                                          -100
                                       end as LAST_TAX_PERCENTAGE,
                                       null
                                  from MB_BI_MONTHLY s";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_1_MONTH_GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select get_convert_short_group_name(t.group_name_new,'PRO') as group_name, t.* from MB_BI_MONTHLY_GRAPH t";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_1_MONTH_GRAPH_RATIO()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select get_convert_short_group_name(t.group_name_new,'PRO') as group_name,t.* from MB_BI_MONTHLY_RATIO t";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_2_YEAR()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select ROW_NUMBER() OVER(ORDER BY t.group_name) as sort, t.*
                              from MB_BI_SUM_MONTH t
                            union all
                            select null,
                                   null,
                                   'รวมทั้งหมด',
                                   sum(s.tax_nettax_amt),
                                   sum(s.estimate),
                                   sum(s.last_tax_nettax_amt),
                                   sum(s.compare_estimate),
                                   case
                                     when sum(s.tax_nettax_amt) > 0 and sum(s.estimate) > 0 then
                                      round(((nvl(sum(s.tax_nettax_amt), 0) - nvl(sum(s.estimate), 0)) * 100) /
                                            sum(s.estimate),
                                            2)
                                     else
                                      -100
                                   end,
                                   sum(s.compare_tax),
                                   case
                                     when sum(s.last_tax_nettax_amt) > 0 and sum(s.tax_nettax_amt) > 0 then
                                      round(((nvl(sum(s.last_tax_nettax_amt), 0) -
                                            nvl(sum(s.tax_nettax_amt), 0)) * 100) /
                                            sum(s.last_tax_nettax_amt),
                                            2)
                                     else
                                      -100
                                   end as LAST_TAX_PERCENTAGE,
                                   null
                              from MB_BI_SUM_MONTH s";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_1_12MONTH_GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select get_convert_short_group_name(t.group_name_new,'PRO') as group_name,t.* from MB_BI_SUM_MONTH_GRAPH t";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_1_12MONTH_GRAPH2()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select get_convert_short_group_name(t.group_name_new,'PRO') as group_name,t.* from MB_BI_SUM_MONTH_RATIO t";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_3_12MONTH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_ALL_MONTH";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_3_12GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_ALL_MONTH_GRAPH";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_3_12MONTH_LAST()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_LAST_YEAR";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_5_10YEAR()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_COMPARE_8YEAR";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_MOBILE1_6_YEAR()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_MONTHLY_OBJ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_Domestic2_1()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_D_MONTHLY";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_Domestic2_1_GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_D_MONTHLY_RATIO";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_Domestic2_1_12Month()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_D_SUM_MONTH";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_Domestic2_1_12GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_D_SUM_MONTH_RATIO";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_1_10_4_1ALL()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_REGION1TO10";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_1_10_4_1ALL_GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_REGION1TO10_GRAPH";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_1_10_4_6()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_MONTHLYOF59_OBJ";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }


        /// ///////////////////////////////////////////////////////////////////////////////////

        public DataTable REPORT_BI_REGION_4_1()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_REGION";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_REGION_4_1_GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_REGION_GRAPH";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }
        //////////////////////////////////////////////////////////////////////////////////
        public DataTable REPORT_BI_Law2_1()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_LAW";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_Law2_1_GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_LAW_GRAPH";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_Law3_1_GRAPH()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_LAW_MAP";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

        public DataTable REPORT_BI_Law3_1()
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @"select * from MB_BI_LAW_FINES";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }

    }
}