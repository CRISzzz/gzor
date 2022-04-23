using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gzor
{
    public class SqlSeverHelper
    {
        public SqlSeverHelper()
        {

        }

        public static string ConnectString = JsonConvert.DeserializeObject<string>(Globalgzor.DefaultConnectString);

        public static int ExcuteNonQuery(string sqlText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    var cmd = new SqlCommand(sqlText, conn);
                    conn.Open();
                    cmd.CommandText = sqlText;
                    int row = cmd.ExecuteNonQuery();
                    conn.Close();
                    return row;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public static DataSet ExcuteQuery(string sqlText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectString))
                {
                    var adapter = new SqlDataAdapter(sqlText, conn);
                    conn.Open();
                    var ds = new DataSet();
                    int row = adapter.Fill(ds);
                    conn.Close();
                    return ds;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void ExcuteSqlTran(ArrayList sqlList)
        {
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        var cmd = new SqlCommand(sqlList[i].ToString());
                        cmd.ExecuteNonQuery();
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public static DataSet ExcuteSqlTran(IEnumerable<string> sqlArray)
        {
            DataSet ds = null;
            var sqlList = sqlArray == null ? new List<string>() : sqlArray.ToList();

            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    for (int i = 0; i < sqlList.Count; i++)
                    {
                        var adapter = new SqlDataAdapter(sqlList[i].ToString(), conn);
                        DataSet subDs = null;
                        adapter.Fill(subDs);
                        foreach (DataTable table in subDs.Tables)
                        {
                            ds.Tables.Add(table);
                        }
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
            return ds;
        }

        public static void ExcuteProc(string procName)
        {
            using (SqlConnection conn = new SqlConnection(ConnectString))
            {
                var cmd = new SqlCommand(procName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
