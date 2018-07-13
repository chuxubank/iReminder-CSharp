using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iReminder
{
    class DBConnection
    {
        public string conn_str = null;
        public OleDbConnection conn = null;
        public OleDbCommand cmd = null;
        public OleDbDataAdapter adapter = null;

        public DBConnection()
        {
            conn_str = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source='iReminder.mdb'";
            conn = new OleDbConnection(conn_str);
        }

        public OleDbConnection open()
        {
            conn.Open();
            return conn;
        }

        public void close()
        {
            conn.Close();
        }

        public object SelectToObject(string SQL)
        {
            cmd = new OleDbCommand(SQL, conn);
            return cmd.ExecuteScalar();//返回第一列第一行
        }

        public DataTable SelectToDataTable(string SQL)
        {
            adapter = new OleDbDataAdapter();
            cmd = new OleDbCommand(SQL, conn);
            adapter.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataSet SelectToDataSet(string SQL, string tablename)
        {
            adapter = new OleDbDataAdapter();
            cmd = new OleDbCommand(SQL, conn);
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            ds.Tables.Add(tablename);
            adapter.Fill(ds, tablename);
            return ds;
        }

        public OleDbDataAdapter SelectToDataAdapter(string SQL)
        {
            adapter = new OleDbDataAdapter();
            cmd = new OleDbCommand(SQL, conn);
            adapter.SelectCommand = cmd;
            return adapter;
        }

        //参数化插入 主要是用于带有格式的文本的插入
        public bool ExecuteSql(string SQL, params OleDbParameter[] parameters)
        {
            bool result = false;
            OleDbCommand cmd = new OleDbCommand(SQL, conn);
            if (parameters != null)
            {
                foreach (OleDbParameter p in parameters)
                {
                    if ((p.Direction == ParameterDirection.Output) || p.Value == null)
                        p.Value = DBNull.Value;
                    cmd.Parameters.Add(p);
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }

        public bool ExecuteNonQuery(string SQL)
        {
            cmd = new OleDbCommand(SQL, conn);
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
