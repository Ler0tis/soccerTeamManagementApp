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
        private string ConStr;

        public Functions()
        {
            // Makes the connection with the Server/Database
            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leroy\Documents\soccerTeamManagement.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConStr);
            Cmd = new SqlCommand();
            Cmd.Connection = Con;
        }

        public DataTable GetData(String query)
        {
            Dt = new DataTable();
            Sda = new SqlDataAdapter(query, ConStr);
            Sda.Fill(Dt);
            return Dt;
        }
        public int SetData(string query, params SqlParameter[] parameters)
        {
            int cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            Cmd.CommandText = query;

            if (parameters != null && parameters.Length > 0)
            {
                Cmd.Parameters.AddRange(parameters);
            }

            cnt = Cmd.ExecuteNonQuery();
            return cnt;
        }



        public DataTable GetTeams()
        {
            string query = "SELECT * FROM Team";
            return GetData(query);
        }

        public object GetSingleValue(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConStr)) // Use Constr as connectionseries
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.Parameters.AddRange(parameters);

                    return command.ExecuteScalar();
                }
            }
        }

    }
}
