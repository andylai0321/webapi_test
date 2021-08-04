using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Reflection;

/// <summary>
/// dataconn 的摘要描述
/// </summary>

public class dataconn
    {
        public dataconn()
        {
            //
            // TODO: 在此加入建構函式的程式碼
            //
        }

        private SqlConnection g_dbconn, g_dbconn_spm;
        private SqlCommand g_objDC = new SqlCommand();
        private SqlCommand g_objDC_spm = new SqlCommand();
        private SqlDataReader g_objDR, g_objDR_spm;
        private SqlDataAdapter g_objDA;
        private DataSet g_objDS = new DataSet();
        private DataTable g_objDT = new DataTable();
       
        public void connectstring()
        {
            string connectionstring = @"server=(local)\SQLExpress;Integrated Security=SSPI;database=northwind";
            g_dbconn = new SqlConnection(connectionstring);
        }

        private void openconn()
        {
            connectstring();
            g_dbconn.Open();
        }

        public void closeconn()
        {
            this.connectstring();
            g_dbconn.Dispose();
            g_dbconn.Close();
        }

        public DataSet getdataset(string sqltxt, string tablename)
        {
            openconn();
            g_objDA = new SqlDataAdapter(sqltxt, g_dbconn);
            g_objDA.Fill(g_objDS, tablename);
            return g_objDS;
        }

        public int sqlcommand(string sqltxt)
        {
            openconn();
            g_objDC = new SqlCommand(sqltxt, g_dbconn);
            int returnnum = g_objDC.ExecuteNonQuery();
            return returnnum;
        }

        public List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj,dr[column.ColumnName].ToString(), null);
                    else
                        continue;
                }
            }
            return obj;
        }
}
