using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DataAccessLayer.Helper
{
    public class DataHelper
    {
        string connectionStr = @"Data Source =LAPTOP-C3HMM5D6\SQLEXPRESS;Initial Catalog = ananas_shoes; Integrated Security = True";
        SqlConnection connection;

        public DataHelper()
        {
            connection = new SqlConnection(connectionStr);
        }
        public DataHelper(string connectionStr)
        {
            this.connectionStr = connectionStr;
        }

        public bool Open()
        {
            try
            {
                if(connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                return true;
            }catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Close()
        {
            if(connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        public DataTable ExcuteReaderReturnDataTable(out string errStr, string procedureName, params object[] param_list)
        {
            errStr = "";
            DataTable tb = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = procedureName, CommandType = CommandType.StoredProcedure, Connection = connection };
                Open();
                int paramInput = (param_list.Length) / 2;
                for (int i = 0; i < paramInput; i++)
                {
                    string paramKey = param_list[i].ToString();
                    object paramValue = param_list[i + paramInput];
                    if (paramKey.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter { ParameterName = paramKey, Value = paramValue, SqlDbType = SqlDbType.NVarChar });
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramKey, paramValue ?? DBNull.Value));
                    }
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                dataAdapter.Fill(tb);
                dataAdapter.Dispose();
                cmd.Dispose();
                connection.Dispose();
            }
            catch(Exception ex)
            {
                errStr = ex.ToString();
                tb = null;
            }finally { Close(); }
            return tb;
        }
        public string ExcuteNonQuery(string procedureName, params object[] param_list)
        {
            string errStr = "";
            try
            {
                SqlCommand cmd = new SqlCommand { CommandText = procedureName, CommandType = CommandType.StoredProcedure, Connection = connection };
                Open();
                int paramInput = (param_list.Length) / 2;
                for (int i = 0; i < paramInput; i++)
                {
                    string paramKey = param_list[i].ToString();
                    object paramValue = param_list[i + paramInput];
                    if (paramKey.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new SqlParameter { ParameterName =  paramKey, Value =  paramValue, SqlDbType = SqlDbType.NVarChar});
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter(paramKey, paramValue ?? DBNull.Value));
                    }
                }
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                connection.Dispose();
            }catch(Exception ex)
            {
                errStr = ex.Message;
            }
            finally
            {
                Close();
            }
            return errStr;
        }
    }
}
