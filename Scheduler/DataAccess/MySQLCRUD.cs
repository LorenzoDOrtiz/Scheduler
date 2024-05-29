using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Scheduler.DataAccess
{
    internal class MySQLCRUD
    {
        public static DataTable GetDataTable(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            using (var cmd = new MySqlCommand(query, DBConnection.Conn))
            {
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }
                using (var adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        public static void ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while performing the following query: {query}.\nException message: {ex.Message}");
                throw;
            }
        }

        public static void ExecuteNonQuery(MySqlTransaction transaction, string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn, transaction))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while performing the following query: {query}.\nException message: {ex.Message}");
                throw;
            }
        }


        public static object ExecuteScalar(MySqlTransaction transaction, string query, Dictionary<string, object> parameters)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(query, DBConnection.Conn, transaction))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    return cmd.ExecuteScalar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while performing the following query: {query}.\nException message: {ex.Message}");
                throw;
            }
        }


        public static MySqlTransaction BeginTransaction(MySqlConnection conn)
        {
            return conn.BeginTransaction();
        }

        public static void Commit(MySqlTransaction transaction)
        {
            try
            {
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during transaction commit.\nException message: {ex.Message}");
                throw;
            }
            finally
            {
                transaction.Connection.Close();
            }
        }

        public static void Rollback(MySqlTransaction transaction)
        {
            try
            {
                transaction.Rollback();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during transaction rollback.\nException message: {ex.Message}");
                throw;
            }
            finally
            {
                transaction.Connection.Close();
            }
        }
    }
}
