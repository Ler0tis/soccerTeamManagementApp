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
using Newtonsoft.Json;

namespace soccerTeamManagementApp
{

    public class MatchData
    {
        public int MatchID { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public DateTime MatchDate { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public List<Goal> HomeTeamGoals { get; set; } = new List<Goal>();
        public List<Goal> AwayTeamGoals { get; set; } = new List<Goal>();
    }

    public class Goal
    {
        public int GoalID { get; set; }
        public int PlayerID { get; set; }
        public int GoalMinute { get; set; }
        public int TeamID { get; set; }

    }


    public partial class Match : Form
    {
        Functions Con;

        private List<int> teamIdsForTeamA;
        private List<int> teamIdsForTeamB;

        private List<string> teamNamesForTeamA;
        private List<string> teamNamesForTeamB;
        
        private List<MatchData> matchDataList;

        
        public Match()
        {

            InitializeComponent();
            Con = new Functions();
            

            teamIdsForTeamA = new List<int>();
            teamIdsForTeamB = new List<int>();

            teamNamesForTeamA = new List<string>();
            teamNamesForTeamB = new List<string>();

            matchDataList = new List<MatchData>();

            ShowMatches();
        }

        private void ShowMatches()
        {
            try
            {
                string query = "SELECT M.MatchID, T1.TeamName AS HomeTeam, T2.TeamName AS AwayTeam, M.MatchDate, M.HomeTeamScore, M.AwayTeamScore " +
                               "FROM Matches M " +
                               "INNER JOIN Teams T1 ON M.HomeTeamID = T1.TeamID " +
                               "INNER JOIN Teams T2 ON M.AwayTeamID = T2.TeamID";

                DataTable matchesTable = Con.GetData(query);

                //Clear matchDataList before adding DATA (JSON)
                matchDataList.Clear();

                //Error handeling: check if there are matchID present
                //MessageBox.Show($"Matching MatchIDs: {string.Join(", ", matchesTable.Rows.Cast<DataRow>().Select(row => row["MatchID"]))}");

                foreach (DataRow row in matchesTable.Rows)
                {
                    MatchData matchData = new MatchData
                    {
                        MatchID = Convert.ToInt32(row["MatchID"]),
                        HomeTeam = row["HomeTeam"].ToString(),
                        AwayTeam = row["AwayTeam"].ToString(),
                        MatchDate = Convert.ToDateTime(row["MatchDate"]),
                        HomeTeamScore = Convert.ToInt32(row["HomeTeamScore"]),
                        AwayTeamScore = Convert.ToInt32(row["AwayTeamScore"])
                    };

                    
                    matchDataList.Add(matchData);
                }

                // Set matchDataList as datasource for MatchList
                MatchList.DataSource = null;
                MatchList.DataSource = matchDataList;
                MatchList.ResetBindings();

                // Error handeling:   check lenght of matchDataList
                //MessageBox.Show($"Number of items in matchDataList: {matchDataList.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching match data: {ex.Message}");
            }
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
                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();

                    if (SelectTeamA.SelectedIndex >= 0 && SelectTeamB.SelectedIndex >= 0 &&
                        SelectTeamA.SelectedIndex < teamIdsForTeamA.Count && SelectTeamB.SelectedIndex < teamIdsForTeamB.Count)
                    {
                        int homeTeamID = teamIdsForTeamA[SelectTeamA.SelectedIndex];
                        int awayTeamID = teamIdsForTeamB[SelectTeamB.SelectedIndex];
                        int homeTeamScore = 0;
                        int awayTeamScore = 0;

                        DateTime matchDate = matchDayTb.Value;

                        if (homeTeamID == awayTeamID)
                        {
                            MessageBox.Show("You selected the same team for a match. Please select two different teams.");
                        }
                        else
                        {
                            // Checks if there is already a match between the teams on the same date (only date, no time specified)
                            string checkQuery = "SELECT COUNT(*) FROM Matches " +
                                                "WHERE ((HomeTeamID = @HomeTeamID AND AwayTeamID = @AwayTeamID) OR (HomeTeamID = @AwayTeamID AND AwayTeamID = @HomeTeamID)) " +
                                                "AND CONVERT(DATE, MatchDate) = CONVERT(DATE, @MatchDate)";

                            int existingMatches = (int)Con.GetSingleValue(checkQuery,
                                new SqlParameter("@HomeTeamID", homeTeamID),
                                new SqlParameter("@AwayTeamID", awayTeamID),
                                new SqlParameter("@MatchDate", matchDate));

                            if (existingMatches > 0)
                            {
                                MessageBox.Show("There already exists a match between these teams on the selected date. Please select different teams or a different date.");
                            }
                            else
                            {
                                string query = "INSERT INTO Matches (HomeTeamID, AwayTeamID, MatchDate, HomeTeamScore, AwayTeamScore) " +
                                                "VALUES (@HomeTeamID, @AwayTeamID, @MatchDate, @HomeTeamScore, @AwayTeamScore)";

                                int result = Con.SetData(query,
                                    new SqlParameter("@HomeTeamID", homeTeamID),
                                    new SqlParameter("@AwayTeamID", awayTeamID),
                                    new SqlParameter("@MatchDate", matchDate),
                                    new SqlParameter("@HomeTeamScore", homeTeamScore),
                                    new SqlParameter("@AwayTeamScore", awayTeamScore));

                                if (result > 0)
                                {
                                    MatchList.Refresh();
                                    MessageBox.Show("Match added");

                                    ShowMatches();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to add the match");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select valid teams for Team A and Team B.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }




        private int GetSelectedMatchID()
        {
            if (MatchList.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = MatchList.SelectedRows[0];
                return Convert.ToInt32(selectedRow.Cells["MatchID"].Value);
            }
            return -1;
        }

        private void EditMatch_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectTeamA.SelectedIndex >= 0 && SelectTeamB.SelectedIndex >= 0 &&
                    SelectTeamA.SelectedIndex < teamIdsForTeamA.Count && SelectTeamB.SelectedIndex < teamIdsForTeamB.Count)
                {
                    int homeTeamID = teamIdsForTeamA[SelectTeamA.SelectedIndex];
                    int awayTeamID = teamIdsForTeamB[SelectTeamB.SelectedIndex];
                    DateTime matchDate = matchDayTb.Value;

                    if (homeTeamID == awayTeamID)
                    {
                        MessageBox.Show("You selected the same team for a match. Please select two different teams.");
                    }
                    else
                    {
                        // Get matchID from selected row ( match)
                        int selectedMatchID = GetSelectedMatchID();

                        if (selectedMatchID != -1)
                        {
                            // check for same team on same date
                            string checkQuery = "SELECT COUNT(*) FROM Matches " +
                                                "WHERE ((HomeTeamID = @HomeTeamID AND AwayTeamID = @AwayTeamID) OR (HomeTeamID = @AwayTeamID AND AwayTeamID = @HomeTeamID)) " +
                                                "AND CONVERT(DATE, MatchDate) = CONVERT(DATE, @MatchDate)";

                            int existingMatches = (int)Con.GetSingleValue(checkQuery,
                                new SqlParameter("@HomeTeamID", homeTeamID),
                                new SqlParameter("@AwayTeamID", awayTeamID),
                                new SqlParameter("@MatchDate", matchDate));

                            if (existingMatches > 0)
                            {
                                MessageBox.Show("There already exists a match between these teams on the selected date. Please select different teams or a different date.");
                            }
                            else
                            {
                                
                                string query = "UPDATE Matches SET HomeTeamID = @HomeTeamID, AwayTeamID = @AwayTeamID, MatchDate = @MatchDate WHERE MatchID = @MatchID";

                                int result = Con.SetData(query,
                                    new SqlParameter("@MatchID", selectedMatchID),
                                    new SqlParameter("@HomeTeamID", homeTeamID),
                                    new SqlParameter("@AwayTeamID", awayTeamID),
                                    new SqlParameter("@MatchDate", matchDate));

                                if (result > 0)
                                {
                                    MessageBox.Show("Match updated");
                                    RefreshData();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to update the match");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Selecteer eerst een wedstrijd om bij te werken.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select valid teams for Team A and Team B.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        
        


        private void SelectTeamA_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Team A selected and set according TeamID
            int selectedIndex = SelectTeamA.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < teamIdsForTeamA.Count)
            {
                int selectedTeamId = teamIdsForTeamA[selectedIndex];
                // Doe hier iets met selectedTeamId als dat nodig is
            }
        }

        private void SelectTeamB_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Team B selected and set according TeamID
            int selectedIndex = SelectTeamB.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < teamIdsForTeamB.Count)
            {
                int selectedTeamId = teamIdsForTeamB[selectedIndex];
                // Doe hier iets met selectedTeamId als dat nodig is
            }
        }




        private int key = 0;
        private void MatchList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = MatchList.Rows[e.RowIndex];

                // Gets values for selected match
                SelectTeamA.Text = row.Cells[1].Value.ToString();
                SelectTeamB.Text = row.Cells[2].Value.ToString();
                matchDayTb.Text = row.Cells["MatchDate"].Value.ToString();

                // Sets Key with ID of Match
                key = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void MatchDetailsBtn_Click(object sender, EventArgs e)
        {
            if (key != 0)
            {
                MatchDetails matchDetailsForm = new MatchDetails(key, matchDataList);
                matchDetailsForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Select a match to view the details");
            }
        }



        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Please select a match to delete");
                    return;
                }

                string query = "DELETE FROM Matches WHERE MatchID = @MatchID";

                int result = Con.SetData(query, new SqlParameter("@MatchID", key));

                if (result > 0)
                {
                    ShowMatches();
                    MessageBox.Show("Match deleted");

                    // Clear the selection in datagrid
                    MatchList.ClearSelection();
                    key = 0;
                }
                else
                {
                    MessageBox.Show("No match found or there was an error while deleting the match.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }




        public void RefreshData()
        {
            ShowMatches();
        }

    }
}
