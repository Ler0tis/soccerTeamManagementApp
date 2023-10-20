﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace soccerTeamManagementApp
{
    public partial class Match : Form
    {
        Functions Con;

        private List<string> teamNamesForTeamA;
        private List<string> teamNamesForTeamB;
        private List<int> teamIdsForTeamA;
        private List<int> teamIdsForTeamB;

        public Match()
        {
            InitializeComponent();
            Con = new Functions();
            ShowMatches();

            teamNamesForTeamA = new List<string>();
            teamNamesForTeamB = new List<string>();
            teamIdsForTeamA = new List<int>();
            teamIdsForTeamB = new List<int>();
        }

        private void ShowMatches()
        {
            string query = "SELECT M.MatchId, T1.TeamName AS HomeTeam, T2.TeamName AS AwayTeam, M.MatchDate " +
                           "FROM Match M " +
                           "INNER JOIN Team T1 ON M.HomeTeamId = T1.TeamId " +
                           "INNER JOIN Team T2 ON M.AwayTeamId = T2.TeamId";
            MatchList.DataSource = Con.GetData(query);
        }

        public void SetTeamNames(List<string> teamNames, List<int> teamIds)
        {
            teamNamesForTeamA = new List<string>(teamNames);
            teamNamesForTeamB = new List<string>(teamNames);
            teamIdsForTeamA = new List<int>(teamIds);
            teamIdsForTeamB = new List<int>(teamIds);

            // Selectionfields for Team A and B from DB
            SelectTeamA.DataSource = teamNamesForTeamA;
            SelectTeamB.DataSource = teamNamesForTeamB;
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Checks of selected index is within range
                if (SelectTeamA.SelectedIndex >= 0 && SelectTeamB.SelectedIndex >= 0 &&
                    SelectTeamA.SelectedIndex < teamIdsForTeamA.Count && SelectTeamB.SelectedIndex < teamIdsForTeamB.Count)
                {
                    int teamAId = teamIdsForTeamA[SelectTeamA.SelectedIndex];
                    int teamBId = teamIdsForTeamB[SelectTeamB.SelectedIndex];

                    // Validation
                    if (teamAId == teamBId)
                    {
                        MessageBox.Show("You selected the same team for a match. Please select two different teams");
                        return;
                    }

                    DateTime matchDate = matchDayTb.Value;

                    // Query to add new match into DB
                    string query = "INSERT INTO Match (HomeTeamId, AwayTeamId, MatchDate) VALUES (@TeamAId, @TeamBId, @MatchDate)";

                    // Add parameters to query
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@TeamAId", teamAId),
                        new SqlParameter("@TeamBId", teamBId),
                        new SqlParameter("@MatchDate", matchDate)
                    };

                    // Exectute query
                    int result = Con.SetData(query, parameters);

                    if (result > 0)
                    {
                        ShowMatches();
                        MessageBox.Show("Match added");
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the match");
                    }
                }
                else
                {
                    MessageBox.Show("Please select valid teams for Team A and Team B.");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }



        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();

            this.Close();
        }

        private void SelectTeamA_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Team A selected and set according TeamID
            int selectedIndex = SelectTeamA.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < teamIdsForTeamA.Count)
            {
                int selectedTeamId = teamIdsForTeamA[selectedIndex];
            }
        }
        private void SelectTeamB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Team B selected and set according TeamID
            int selectedIndex = SelectTeamB.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < teamIdsForTeamB.Count)
            {
                int selectedTeamId = teamIdsForTeamB[selectedIndex];
            }
        }


        int key = 0;
        private void MatchList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = MatchList.Rows[e.RowIndex];
                // Gets values for selected match
                SelectTeamA.Text = row.Cells[1].Value.ToString();
                SelectTeamB.Text = row.Cells[2].Value.ToString();

                // Sets Key with ID of Match
                key = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Checks if there is data selected in both comboboxes
                if (SelectTeamA.SelectedIndex >= 0 && SelectTeamB.SelectedIndex >= 0)
                {
                    // Get selected teams
                    string teamAName = SelectTeamA.Text;
                    string teamBName = SelectTeamB.Text;

                    // Find MatchId in DB of selected Teams
                    string query = "SELECT MatchId FROM Match WHERE HomeTeamId = '{0}' AND AwayTeamId = '{1}'";
                    query = string.Format(query, teamAName, teamBName);

                    DataTable result = Con.GetData(query);

                    if (result != null && result.Rows.Count > 0)
                    {
                        // Deletes match on found MatchId
                        int matchId = Convert.ToInt32(result.Rows[0]["MatchId"]);
                        string deleteQuery = "DELETE FROM Match WHERE MatchId = {0}";
                        deleteQuery = string.Format(deleteQuery, matchId);
                        Con.SetData(deleteQuery);

                        ShowMatches();
                        MessageBox.Show("Match deleted");
                    }
                    else
                    {
                        MessageBox.Show("No match found");
                    }

                    // Reset input fieldss
                    SelectTeamA.SelectedIndex = -1;
                    SelectTeamB.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Select valid teams to remove the match");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an error while deleting the match: " + ex.Message);
            }
        }

        
    }
}
