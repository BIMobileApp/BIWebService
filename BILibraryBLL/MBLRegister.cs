using ClassLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace BILibraryBLL
{
    public class MBLRegister
    {
        Conn con = new Conn();
        public DataTable TaxRegisterByOffcode(string offcode, string region, string province, string type)
        {
            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //string sql = @" select * from(select GROUP_DESC, SUM(IMP_REGISTER) AS IMP_REGISTER,
            //               SUM(IN_REGISTER) AS IN_REGISTER, SUM(TOTAL_REGISTER) AS TOTAL_REGISTER,sort
            //                from mbl_register_1 
            //                where offcode = " + offcode + " ";

            //sql += " and Region_Name like case when '" + region + "' = 'undefined' then Region_Name else '" + region + "' end";
            //sql += " and province_name like case when '" + province + "' = 'undefined' then province_name else '" + province + "' end";
            //if (type != "undefined")
            //{
            //    sql += " and isic_code = '" + type + "'";
            //}

            //sql += " group by GROUP_DESC,sort order by sort )";

            string sql = @" select* from(select GROUP_DESC, SUM(IMP_REGISTER) AS IMP_REGISTER,
                            SUM(IN_REGISTER) AS IN_REGISTER, SUM(TOTAL_REGISTER) AS TOTAL_REGISTER, sort
                            from mbl_register_1
                            where offcode = " + offcode + "";
            if (region != "EEC")
            {
                sql += @" and Region_Name like case when '" + region + "' = 'undefined' then Region_Name else '" + region + "' end";
            }
            else
            {
                sql += " and eec_flag = 'EEC'";
            }

            sql += @" and province_name like case when '" + province + "' = 'undefined' then province_name else '" + province + "' end";
            //sql += @" and isic_desc like case when '" + type + "' = 'undefined' then isic_desc else '" + type + "' end";
            if (type != "undefined")
            {
                sql += " and isic_desc = '" + type + "'";
            }
            sql += @" group by GROUP_DESC, sort order by sort)
                        union all 
                        select 'รวม' group_desc,
                               count(distinct case when a.status_desc = 'นำเข้า' then a.newreg_id else null end) imp_register,
                               count(distinct case when a.status_desc != 'นำเข้า' then a.newreg_id else null end) in_register,
                               count(distinct a.newreg_id) total_register,
                               100000
                        from FCT_REGISTER  a,
                             ic_office_dim_mbl v
                        where a.offcode = v.offcode ";
            if (region != "EEC")
           {
                sql += " and v.region_name like case when '" + region + "' = 'undefined' then v.region_name else '" + region + "' end";
           }
           else
           {
                sql += " and a.eec_flag = 'EEC'";
           }
          
            sql += @"         and v.province_name like case when '" + province + "' = 'undefined' then v.province_name else '" + province + "' end";
            if (type != "undefined")
            {
                sql += " and a.isic_desc = '" + type + "'";
            }



            /*select 'รวม' group_desc
                       ,count(distinct case
                            when a.status_desc = 'นำเข้า' then a.newreg_id
                   else null end) imp_register,count(distinct case
              when a.status_desc != 'นำเข้า' then
               a.newreg_id
                          else
                           null
                        end) in_register,100000
                 ,count(distinct a.newreg_id) total_register
           from FCT_REGISTER  a
               ,ic_office_dim v
           where a.offcode = v.offcode ";

           if (region != "EEC")
           {
               sql += @"    and v.Region_Name like case when '" + region + "' = 'undefined' then v.Region_Name else '" + region + "' end";
           }
           else
           {
               sql += " and a.eec_flag = 'EEC'";
           }

           sql += @"  and v.province_name like case when '" + province + "' = 'undefined' then v.province_name else '" + province + "' end";
           sql += @" )order by sort asc";*/





            /*select 'รวม', SUM(IMP_REGISTER) AS IMP_REGISTER,
                                       SUM(IN_REGISTER) AS IN_REGISTER, SUM(TOTAL_REGISTER) AS TOTAL_REGISTER, 10000
                                        from mbl_register_1";
                        sql += @"    where offcode = " + offcode + "";
                        if (region != "EEC")
                        {
                            sql += @"    and Region_Name like case when '" + region + "' = 'undefined' then Region_Name else '" + region + "' end";
                        }
                        else
                        {
                            sql += " and eec_flag = 'EEC'";
                        }

                        sql += @"    and province_name like case when '" + province + "' = 'undefined' then province_name else '" + province + "' end";
                        if (type != "undefined")
                        {
                            sql += " and isic_desc = '" + type + "'";
                        }*/


            /*sql += @" UNION ALL  select 'รวม' , SUM(IMP_REGISTER) AS IMP_REGISTER,
                      SUM(IN_REGISTER) AS IN_REGISTER, SUM(TOTAL_REGISTER) AS TOTAL_REGISTER,null
                      from mbl_register_1 where offcode = " + offcode + " ";
            sql += " and Region_Name like case when '" + region + "' = 'undefined' then Region_Name else '" + region + "' end";
            sql += " and province_name like case when '" + province + "' = 'undefined' then province_name else '" + province + "' end";
            sql += " and isic_code like case when '" + type + "' = 'undefined' then isic_code else '" + type + "' end";*/


            // sql += @"order by offdesc asc";


            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;
        }

        public DataTable ddlRegister()
        {

            DataTable dt = new DataTable();
            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            string sql = @" select ISIC_CODE, ISIC_DESC AS type_name from ISIC_DIM order by ISIC_DESC";

            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            thisConnection.Close();
            return dt;

        }

        public DataTable SumRegister(string offcode, string region, string province, string type)
        {

            //            DataTable dt = new DataTable();
            //            OleDbConnection thisConnection = new OleDbConnection(con.connection());

            //            string sql = @" select 
            //'รวม' GROUP_DESC,
            //          count(distinct case
            //                   when a.status_desc = 'นำเข้า' then
            //                    a.newreg_id
            //                   else
            //                    null
            //                 end) IMP_REGISTER
            //          ,count(distinct case
            //                   when a.status_desc != 'นำเข้า' then
            //                    a.newreg_id
            //                   else
            //                    null
            //                 end) IN_REGISTER
            //          ,count(distinct a.newreg_id) TOTAL_REGISTER
            //    from FCT_REGISTER  a
            //        ,ic_office_dim_mbl v
            //    where a.offcode = v.offcode and 
            //          v.region_name =     nvl('" + region + "' ,v.region_name)  and ";
            //            sql += "     v.province_name =  nvl('" + province + "', v.province_name)  and ";
            //            sql += "       a.isic_desc  =  nvl('" + type+"', a.isic_desc)         ";

            //            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);
            //            thisConnection.Open();
            //            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            //            adapter.Fill(dt);
            //            thisConnection.Close();
            return null;
        }
    }
}