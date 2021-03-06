﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using ClassLib;
using Oracle.DataAccess.Client;
using Oracle.DataAccess;

namespace BILibraryBLL
{
    public class TestSql
    {
        Conn con = new Conn();

        public DataTable Sql1() {

            DataTable dt = new DataTable();
            using (OleDbConnection thisConnection = new OleDbConnection(con.connection()))
            {
                string sql = "select * from CD_TIME_DIM t WHERE rownum <= 100";
                OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
                thisConnection.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dt);
                thisConnection.Close();
                return dt;
            }
        }

        public Dictionary<object, Record> arrayView() {

            
            OleDbConnection thisConnection = new OleDbConnection(con.connection());
            string sql = "select * from CD_TIME_DIM t WHERE rownum <= 100";
            OleDbCommand cmd = new OleDbCommand(sql, thisConnection);  //EDIT : change table name for Oracle
            thisConnection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

            var dict = new Dictionary<object, Record>();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    object key = reader[0];
                    Record rec = new Record(key);
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        rec.Fields.Add(reader[i]);
                    }
                    dict.Add(key, rec);
                }
            }
            thisConnection.Close();
            return dict;
        }

        public class Record
        {
            public Record(object key)
            {
                this.Key = key;
                Fields = new List<object>();
            }
            public object Key;
            public List<object> Fields;
        }

        public void callprocPost() {

            //  เรียก proc เพื่อ insert ข้อมูล//
            OleDbConnection conn = new OleDbConnection(con.connection());
            OleDbCommand cmd = new OleDbCommand("prc_test", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public DataTable callviewGet() {

            OleDbDataAdapter da = new OleDbDataAdapter();
            OleDbConnection conn = new OleDbConnection(con.connection());

            OleDbCommand objCmd = new OleDbCommand();
            objCmd.Connection = conn;
            objCmd.CommandType = CommandType.Text;
            objCmd.CommandText = "select * from VIEW_TEST_LIST";

            DataSet ds = new DataSet();
            OleDbDataAdapter oraDa = new OleDbDataAdapter(objCmd);

            da.SelectCommand = objCmd;
            DataTable dt = new DataTable();
            da.Fill(dt);

            conn.Close();

            return dt;
        }

        public void testInsertData(string id, string name) {

            OleDbConnection conn = new OleDbConnection(con.connection());
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "insert into TEST (id,name) values ('" +id+ "','" + name + "')";
            cmd.Connection = conn;
            
            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();

        }

        public void testUpdateData(string id, string name) {

            OleDbConnection conn = new OleDbConnection(con.connection());
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "UPDATE TEST  SET name = '" + name + "' WHERE id= '" + id + "' ";
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}