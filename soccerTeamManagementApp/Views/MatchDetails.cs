using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.IO;

namespace soccerTeamManagementApp
{

    public partial class MatchDetails : Form
    {

        private Functions Con;

        private int matchID;
        private int homeTeamScore;
        private int awayTeamScore;
        private int goalIDToRemove = -1;

        private List<MatchData> matchDataList;
       
        // constructor
        public MatchDetails(int matchID, List<MatchData> matchDataList)
        {
            InitializeComponent();
            Con = new Functions();

            this.matchID = matchID;
            this.matchDataList = matchDataList;

            Show_MatchDetails();
            MatchDetails_Load(this, EventArgs.Empty);

            if (homeTeamScore == 0 && awayTeamScore == 0)
            {
                InitializeScores();
            }

            
        }

        private void InitializeScores()
        {
            homeTeamScore = GetTeamScore(matchID, GetHomeTeamScore(matchID));
            awayTeamScore = GetTeamScore(matchID, GetAwayTeamScore(matchID));

            homeTeamScoreField.Text = homeTeamScore.ToString();
            awayTeamScoreField.Text = awayTeamScore.ToString();
        }

        private int GetTeamScore(int matchID, int teamID)
        {
            try
            {
                string query = (teamID == GetHomeTeamID(matchID))
                    ? "SELECT HomeTeamScore FROM Matches WHERE MatchID = @MatchID"
                    : "SELECT AwayTeamScore FROM Matches WHERE MatchID = @MatchID";

                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MatchID", matchID);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Er is een fout opgetreden bij het ophalen van het teamscore: " + ex.Message);
                return 0;
            }
        }


        private void Show_MatchDetails()
        {
            string query = "SELECT T1.TeamName AS HomeTeam, T2.TeamName AS AwayTeam " +
                           "FROM Matches M " +
                           "INNER JOIN Teams T1 ON M.HomeTeamID = T1.TeamID " +
                           "INNER JOIN Teams T2 ON M.AwayTeamID = T2.TeamID " +
                           "WHERE M.MatchID = @MatchID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@MatchID", matchID));

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable matchData = new DataTable();
                        adapter.Fill(matchData);

                        if (matchData.Rows.Count > 0)
                        {
                            HomeTeamTb.Text = matchData.Rows[0]["HomeTeam"].ToString();
                            AwayTeamTb.Text = matchData.Rows[0]["AwayTeam"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No match data found for the selected match.");
                            this.Close();
                        }
                    }
                }
            }
        }

        private int GetHomeTeamID(int matchID)
        {
            string query = "SELECT HomeTeamID FROM Matches WHERE MatchID = @MatchID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private int GetAwayTeamID(int matchID)
        {
            string query = "SELECT AwayTeamID FROM Matches WHERE MatchID = @MatchID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void FillPlayerComboBoxes(ComboBox comboBox, string teamType)
        {
            List<KeyValuePair<int, string>> teamPlayers = GetPlayersForTeam(teamType);

            comboBox.DataSource = new BindingSource(teamPlayers, null);
            comboBox.DisplayMember = "Value";
            comboBox.ValueMember = "Key";
        }


        private List<KeyValuePair<int, string>> GetPlayersForTeam(string teamType)
        {
            List<KeyValuePair<int, string>> players = new List<KeyValuePair<int, string>>();

            string query = $"SELECT P.PlayerID, CONCAT(P.FirstName, ' ', P.LastName) AS PlayerName " +
                           $"FROM Players P " +
                           $"JOIN Matches M ON (M.HomeTeamID = P.TeamID OR M.AwayTeamID = P.TeamID) " +
                           $"WHERE M.MatchID = @MatchID AND P.TeamID = @TeamID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();

                // Determine team based on type Home or Away
                int teamID = (teamType == "HomeTeam") ? GetHomeTeamID(matchID) : GetAwayTeamID(matchID);

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);
                    cmd.Parameters.AddWithValue("@TeamID", teamID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int playerID = Convert.ToInt32(reader["PlayerID"]);
                            string playerName = reader["PlayerName"].ToString();
                            players.Add(new KeyValuePair<int, string>(playerID, playerName));
                        }
                    }
                }
            }

            return players;
        }

        

        private void MatchDetails_Load(object sender, EventArgs e)
        {
            Show_MatchDetails();
            FillPlayerComboBoxes(selectHomePlayerTb, "HomeTeam");
            FillPlayerComboBoxes(selectAwayPlayerTb, "AwayTeam");

            ShowGoals(GetHomeTeamID(matchID), GoalsTeamA);
            ShowGoals(GetAwayTeamID(matchID), GoalsTeamB);

            GoalsTeamA.CellContentClick += GoalsTeamA_CellContentClick;
            GoalsTeamB.CellContentClick += GoalsTeamB_CellContentClick;

            // TODO:  necessary? already use it in InitialzeScores()
            homeTeamScoreField.Text = homeTeamScore.ToString();
            awayTeamScoreField.Text = awayTeamScore.ToString();
            
        }


        private void ShowGoals(int teamID, DataGridView dataGridView)
        {
            string query = "SELECT G.GoalID, P.FirstName + ' ' + P.LastName AS PlayerName, G.GoalMinute " +
                           "FROM Goals G " +
                           "INNER JOIN Players P ON G.PlayerID = P.PlayerID " +
                           "WHERE G.MatchID = @MatchID AND P.TeamID = @TeamID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);
                    cmd.Parameters.AddWithValue("TeamID", teamID);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        // Fill datagrid with Goals
                        DataTable goalData = new DataTable();
                        adapter.Fill(goalData);
                        dataGridView.DataSource = goalData;
                    }
                }
            }
        }


        private MatchData currentMatchData = new MatchData();

        private void AddHomeTeamBtn_Click(object sender, EventArgs e)
        {
            
            int homeTeamID = GetHomeTeamID(matchID);
            AddGoal(matchID, homeTeamID, selectHomePlayerTb, goalMinuteTeamA, GoalsTeamA);
        }

        private void AddAwayTeamBtn_Click(object sender, EventArgs e)
        {
            
            int awayTeamID = GetAwayTeamID(matchID);
            AddGoal(matchID, awayTeamID, selectAwayPlayerTb, goalMinuteTeamB, GoalsTeamB);
        }

        private void AddGoal(int matchID, int teamID, ComboBox playerComboBox, TextBox minuteTextBox, DataGridView dataGridView, int goalID = -1)
        {
            try
            {
                // Get the MatchData from the database. Needed when saving to JSON under the correct team + MatchID
                currentMatchData = GetMatchDataFromDatabase(matchID);

                int generatedGoalID = -1;

                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Goals (MatchID, PlayerID, GoalMinute) VALUES (@MatchID, @PlayerID, @GoalMinute); SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@MatchID", matchID);
                        cmd.Parameters.AddWithValue("@PlayerID", (int)playerComboBox.SelectedValue);
                        cmd.Parameters.AddWithValue("@GoalMinute", Convert.ToInt32(minuteTextBox.Text));

                        
                        //goalID is geenerated by SCOPE_IDENTITY()
                        generatedGoalID = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }


                if (generatedGoalID > 0)
                {
                    Goal newGoal = new Goal
                    {
                        PlayerID = (int)playerComboBox.SelectedValue,
                        GoalMinute = Convert.ToInt32(minuteTextBox.Text),
                        GoalID = generatedGoalID
                    };

                    // Add goal to the correct list
                    if (teamID == GetHomeTeamID(matchID))
                    {
                        currentMatchData.HomeTeamGoals.Add(newGoal);
                    }
                    else if (teamID == GetAwayTeamID(matchID))
                    {
                        currentMatchData.AwayTeamGoals.Add(newGoal);
                    }

                    // Save match data to JSON
                    SaveMatchDataToJson(matchDataList, matchID);

                    ShowGoals(teamID, dataGridView);
                    MessageBox.Show("Goal added");

                    // Update scores/textbox
                    UpdateScores(matchID, teamID, 1);
                    UpdateScoreTextBox(teamID);

                    // Reset input fields
                    playerComboBox.SelectedIndex = 0;
                    minuteTextBox.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Failed to add the goal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while establishing a database connection: " + ex.Message);
            }
        }



        private MatchData GetMatchDataFromDatabase(int matchID)
        {
            try
            {
                string query = "SELECT M.MatchID, T1.TeamName AS HomeTeam, T2.TeamName AS AwayTeam, M.MatchDate, M.HomeTeamScore, M.AwayTeamScore " +
                               "FROM Matches M " +
                               "INNER JOIN Teams T1 ON M.HomeTeamID = T1.TeamID " +
                               "INNER JOIN Teams T2 ON M.AwayTeamID = T2.TeamID " +
                               "WHERE M.MatchID = @MatchID";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@MatchID", matchID)
                };

                DataTable matchDataTable = Con.GetData(query, parameters.ToArray());

                if (matchDataTable.Rows.Count > 0)
                {
                    DataRow row = matchDataTable.Rows[0];

                    MatchData matchData = new MatchData
                    {
                        MatchID = Convert.ToInt32(row["MatchID"]),
                        HomeTeam = row["HomeTeam"].ToString(),
                        AwayTeam = row["AwayTeam"].ToString(),
                        MatchDate = Convert.ToDateTime(row["MatchDate"]),
                        HomeTeamScore = Convert.ToInt32(row["HomeTeamScore"]),
                        AwayTeamScore = Convert.ToInt32(row["AwayTeamScore"]),
                        
                    };

                    return matchData;
                }
                else
                {
                    MessageBox.Show("Match not found");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching match data from the database: " + ex.Message);
                return null;
            }
        }


        private void GoalsTeamA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GoalsTeamA.Rows[e.RowIndex];

                string playerName = row.Cells["PlayerName"].Value.ToString();
                string goalMinute = row.Cells["GoalMinute"].Value.ToString();

                // Set data in inputfields
                selectHomePlayerTb.Text = playerName;
                goalMinuteTeamA.Text = goalMinute;
            }
        }

        private void GoalsTeamB_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = GoalsTeamB.Rows[e.RowIndex];

                string playerName = row.Cells["PlayerName"].Value.ToString();
                string goalMinute = row.Cells["GoalMinute"].Value.ToString();

                // Set data in inputfields
                selectAwayPlayerTb.Text = playerName;
                goalMinuteTeamB.Text = goalMinute;
            }
        }

        private void DeleteGoalA_Btn_Click(object sender, EventArgs e)
        {
            if (GoalsTeamA.Rows.Count > 0 && GoalsTeamA.SelectedRows.Count > 0)
            {
                int selectedIndex = GoalsTeamA.SelectedRows[0].Index;
                int goalIDToRemove = Convert.ToInt32(GoalsTeamA.SelectedRows[0].Cells["GoalID"].Value);

                // Remove the selected row from the DataGridView
                GoalsTeamA.Rows.RemoveAt(selectedIndex);

                // Remove the goal from the data
                RemoveGoal(GetHomeTeamID(matchID), goalIDToRemove, GoalsTeamA);
            }
            else
            {
                MessageBox.Show("No goal selected to remove.");
            }
        }

        private void DeleteGoalB_Btn_Click(object sender, EventArgs e)
        {
            if (GoalsTeamB.Rows.Count > 0 && GoalsTeamB.SelectedRows.Count > 0)
            {
                int selectedIndex = GoalsTeamB.SelectedRows[0].Index;
                int goalIDToRemove = Convert.ToInt32(GoalsTeamB.SelectedRows[0].Cells["GoalID"].Value);

                // Remove the selected row from the DataGridView
                GoalsTeamB.Rows.RemoveAt(selectedIndex);

                // Remove the goal from the data
                RemoveGoal(GetAwayTeamID(matchID), goalIDToRemove, GoalsTeamB);
            }
            else
            {
                MessageBox.Show("No goal selected to remove.");
            }
        }


        private void RemoveGoal(int teamID, int goalID, DataGridView dataGridView)
        {
            try
            {
                string deleteQuery = "DELETE FROM Goals WHERE GoalID = @GoalID";

                int result = Con.SetData(deleteQuery, new SqlParameter("@GoalID", goalID));

                if (result > 0)
                {
                    MessageBox.Show("Goal removed");

                    // Refresh Matches, datagrid, textbox
                    UpdateScores(matchID, teamID, -1);

                    // Remove the goal from the JSON data
                    SaveMatchDataToJson(matchDataList, matchID);

                    ShowGoals(teamID, dataGridView);
                    UpdateScoreTextBox(teamID);
                }
                else
                {
                    MessageBox.Show("Failed to remove the goal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void SaveMatchDataToJson(List<MatchData> matchDataList, int matchID)
        {
            try
            {
                string jsonPath = "matches.json";

                // Read current data from JSON file
                List<MatchData> existingMatchDataList = JsonConvert.DeserializeObject<List<MatchData>>(File.ReadAllText(jsonPath)) ?? new List<MatchData>();

                // Find the match in the list
                MatchData existingMatchData = existingMatchDataList.FirstOrDefault(match => match.MatchID == matchID);

                if (existingMatchData != null)
                {
                    // Update the existing match data with the updated goal information
                    existingMatchData.HomeTeamGoals = GetGoalsFromDatabase(matchID, existingMatchData.HomeTeam, existingMatchData.HomeTeamGoals);
                    existingMatchData.AwayTeamGoals = GetGoalsFromDatabase(matchID, existingMatchData.AwayTeam, existingMatchData.AwayTeamGoals);

                    // Write the updated list back to JSON
                    File.WriteAllText(jsonPath, JsonConvert.SerializeObject(existingMatchDataList, Formatting.Indented));

                    MessageBox.Show("Match data saved successfully.");
                }
                else
                {
                    MessageBox.Show($"Match not found in JSON. MatchID: {matchID}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving match data to JSON: " + ex.Message);
            }
        }


        private List<Goal> GetGoalsFromDatabase(int matchID, string teamName, List<Goal> currentGoals)
        {
            List<Goal> updatedGoals = new List<Goal>();

            try
            {
                string query = "SELECT G.GoalID, P.PlayerID, G.GoalMinute " +
                               "FROM Goals G " +
                               "INNER JOIN Players P ON G.PlayerID = P.PlayerID " +
                               "WHERE G.MatchID = @MatchID AND P.TeamID = (SELECT TeamID FROM Teams WHERE TeamName = @TeamName)";

                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MatchID", matchID);
                        cmd.Parameters.AddWithValue("@TeamName", teamName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int goalID = Convert.ToInt32(reader["GoalID"]);
                                int playerID = Convert.ToInt32(reader["PlayerID"]);
                                int goalMinute = Convert.ToInt32(reader["GoalMinute"]);

                                // Check if the goalID is in the current goals list
                                Goal existingGoal = currentGoals.FirstOrDefault(goal => goal.GoalID == goalID);

                                if (existingGoal != null)
                                {
                                    // Use the existing goal if found
                                    updatedGoals.Add(existingGoal);
                                }
                                else
                                {
                                    // If not found, create a new goal
                                    Goal newGoal = new Goal
                                    {
                                        GoalID = goalID,
                                        PlayerID = playerID,
                                        GoalMinute = goalMinute
                                    };

                                    updatedGoals.Add(newGoal);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while fetching goals from the database: " + ex.Message);
            }

            return updatedGoals;
        }




        private void EditGoalA_Btn_Click(object sender, EventArgs e)
        {
            int teamID = GetHomeTeamID(matchID);
            ComboBox playerComboBox = selectHomePlayerTb;
            TextBox minuteTextBox = goalMinuteTeamA;
            DataGridView dataGridView = GoalsTeamA;

            HandleEditGoal(teamID, playerComboBox, minuteTextBox, dataGridView);
        }


        private void EditGoalB_Btn_Click(object sender, EventArgs e)
        {
            int teamID = GetAwayTeamID(matchID);
            ComboBox playerComboBox = selectAwayPlayerTb;
            TextBox minuteTextBox = goalMinuteTeamB;
            DataGridView dataGridView = GoalsTeamB;

            HandleEditGoal(teamID, playerComboBox, minuteTextBox, dataGridView);

        }


        private void HandleEditGoal(int teamID, ComboBox playerComboBox, TextBox minuteTextBox, DataGridView dataGridView)
        {

            try
            {

                if (dataGridView.SelectedRows.Count > 0)
                {
                    // Get ID Goal from selected row
                    int goalID = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["GoalID"].Value);

                    string updateQuery = "UPDATE Goals SET PlayerID = @PlayerID, GoalMinute = @GoalMinute WHERE GoalID = @GoalID";

                    int playerID = (int)playerComboBox.SelectedValue;
                    int goalMinute;

                    if (int.TryParse(minuteTextBox.Text, out goalMinute))
                    {
                        int result = Con.SetData(updateQuery,
                            new SqlParameter("@PlayerID", playerID),
                            new SqlParameter("@GoalMinute", goalMinute),
                            new SqlParameter("@GoalID", goalID));

                        if (result > 0)
                        {
                            
                            ShowGoals(teamID, dataGridView); // Refresh datagridview

                            SaveMatchDataToJson(matchDataList, matchID);

                            // Reset text en combobox
                            playerComboBox.SelectedIndex = 0;
                            minuteTextBox.Text = string.Empty;
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the goal");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select a player and enter the minute to add the goal");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a goal to edit");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Match matchForm = (Match)Application.OpenForms["Match"];
            matchForm?.RefreshData(); // To refresh data from Match
            this.Close();
        }



        ////////////////////////// SCORES /////////////////////////////
        private void UpdateScores(int matchID, int teamID, int increment)
        {
            try
            {
                string updateScoreQuery = "UPDATE Matches SET ";

                if (teamID == GetHomeTeamID(matchID))
                {
                    updateScoreQuery += "HomeTeamScore = HomeTeamScore + @Increment";
                }
                else if (teamID == GetAwayTeamID(matchID))
                {
                    updateScoreQuery += "AwayTeamScore = AwayTeamScore + @Increment";
                }

                updateScoreQuery += " WHERE MatchID = @MatchID";

                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(updateScoreQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@MatchID", matchID);
                        cmd.Parameters.AddWithValue("@Increment", increment);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            // No message needed ( already Goal added in other method)
                        }
                        else
                        {
                            MessageBox.Show("Failed to update the score");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void UpdateScoreTextBox(int teamID)
        {
            try
            {
                string selectScoreQuery = "SELECT HomeTeamScore, AwayTeamScore FROM Matches WHERE MatchID = @MatchID";

                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();

                    using (SqlCommand cmd = new SqlCommand(selectScoreQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@MatchID", matchID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                homeTeamScore = Convert.ToInt32(reader["HomeTeamScore"]);
                                awayTeamScore = Convert.ToInt32(reader["AwayTeamScore"]);

                                homeTeamScoreField.Text = homeTeamScore.ToString();
                                awayTeamScoreField.Text = awayTeamScore.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        

        private int GetHomeTeamScore(int matchID)
        {
            string query = "SELECT HomeTeamScore FROM Matches WHERE MatchID = @MatchID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);

                    // Check for DBNull, because of InvalidCastException. Can convert from DBNull to different type
                    object result = cmd.ExecuteScalar();
                    return (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
            }
        }

        private int GetAwayTeamScore(int matchID)
        {
            string query = "SELECT AwayTeamScore FROM Matches WHERE MatchID = @MatchID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);

                    // Check for DBNull, because of InvalidCastException. Can convert from DBNull to different type
                    object result = cmd.ExecuteScalar();
                    return (result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
            }
        }

        
    }
}



