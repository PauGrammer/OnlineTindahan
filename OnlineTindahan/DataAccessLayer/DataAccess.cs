using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace OnlineTindahan.DataAccessLayer
{
    public class DataAccess
    {
        protected string Command { get; set; }
        protected List<SqlParameter> Parameters { get; set; }

        public string ErrorMessage { get; set; }
        public bool IsSuccessful { get; set; }
        
        public DataAccess()
        {
            this.IsSuccessful = true;
            this.Parameters = new List<SqlParameter>();
        }

        protected bool ExecuteQuery()
        {
            bool IsSuccessful = true;
            using (var dbConnection = new SqlConnection(ConfigManager.Database.DatabaseConnection))
            {
                using (var dbCommand = new SqlCommand(this.Command, dbConnection))
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;

                    foreach (var parameter in this.Parameters)
                        dbCommand.Parameters.Add(parameter);

                    try
                    {
                        dbConnection.Open();
                        dbCommand.ExecuteNonQuery();
                    }
                    catch (Exception err)
                    {
                        _SetErrorMessage(err.Message, err.StackTrace);
                    }
                    finally
                    {
                        dbConnection.Close();
                    }
                }
            }
            return IsSuccessful;
        }

        protected DataTable GetDataTable()
        {
            var dataTable  = new DataTable();
            using (var dbConnection = new SqlConnection(ConfigManager.Database.DatabaseConnection))
            {
                using (var dbCommand = new SqlCommand(this.Command, dbConnection))
                {
                    dbCommand.CommandType = CommandType.StoredProcedure;

                    foreach (var parameter in this.Parameters)
                        dbCommand.Parameters.Add(parameter);

                    using (var dbAdapter = new SqlDataAdapter(dbCommand))
                    {
                        try
                        {
                            dbAdapter.Fill(dataTable);
                        }
                        catch (Exception err)
                        {
                            _SetErrorMessage(err.Message, err.StackTrace);
                        }
                    }
                }
            }

            return dataTable;
        }

        private void _SetErrorMessage(string message, string stackTrace)
        {
            this.IsSuccessful = false;
            this.ErrorMessage = String.Format("Error Message: {0}\nStack Trace: {1}", message, stackTrace);
        }
    }
}