﻿using System;
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
        public int SetData(String Query)
        {
            int cnt = 0;
            if(Con.State == ConnectionState.Closed)
            {
                Con.Open();            
            }

            Cmd.CommandText = Query;
            cnt = Cmd.ExecuteNonQuery();
            return cnt;
        }

        public DataTable GetTeams()
        {
            string query = "SELECT * FROM Team";
            return GetData(query);
        }

        public object GetSingleValue(string query)
        {
            object result = null;

            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }

            Cmd.CommandText = query;
            result = Cmd.ExecuteScalar();

            Con.Close();

            return result;
        }

    }
}
