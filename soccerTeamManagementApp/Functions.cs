using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace soccerTeamManagementApp
{
    class Functions
    {
        private SqlConnection Con;
        private SqlCommand Cmd;
        private DataTable Dt;
        private SqlDataAdapter Sda;
        public readonly string ConStr;

        // Plaats de verbindingssnaren hier
        private const string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leroy\Documents\soccerTeamManagement.mdf;Integrated Security=True;Connect Timeout=30";

        public Functions()
        {
            ConStr = ConnectionString;
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(string query, SqlParameter[] parameters)
        {
            Dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddRange(parameters);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(Dt);
                    }
                }
            }

            return Dt;
        }

        public DataTable GetData(string query)
        {
            Dt = new DataTable();
            Sda = new SqlDataAdapter(query, ConStr);
            Sda.Fill(Dt);
            return Dt;
        }


        public int SetData(string query, params SqlParameter[] parameters)
        {
            return SetData(query, null, parameters);
        }

        public int SetData(string query, SqlTransaction transaction, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Query is null or empty.", nameof(query));
            }

            int affectedRows = 0;

            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            using (SqlCommand cmd = new SqlCommand(query, Con, transaction))
            {
                try
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Voeg hier logging toe voor foutafhandeling.
                    Console.WriteLine($"An error occurred while executing the query: {ex.Message}");
                    throw; // Gooi de uitzondering opnieuw zodat deze wordt doorgegeven aan de aanroeper.
                }
            }

            return affectedRows;
        }


        public DataTable GetTeams()
        {
            string query = "SELECT * FROM Teams";
            return GetData(query);
        }

        public object GetSingleValue(string query, params SqlParameter[] parameters)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Query is null or empty.", nameof(query));
            }

            object result = null;

            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            using (SqlCommand cmd = new SqlCommand(query, Con))
            {
                try
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Voeg hier logging toe voor foutafhandeling.
                    Console.WriteLine($"An error occurred while executing the query: {ex.Message}");
                    throw; // Gooi de uitzondering opnieuw zodat deze wordt doorgegeven aan de aanroeper.
                }
            }

            return result;
        }
        

        public DataTable GetCoaches()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(ConStr))
                {
                    connection.Open();

                    string query = "SELECT * FROM Coaches";


                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Trow exception to triggered code
                throw ex;
            }

            return dt;
        }

        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConStr))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    return command.ExecuteScalar();
                }
            }
        }


    }
}
