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

        private List<MatchData> matchDataList;
       

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


        private MatchData currentMatchData = new MatchData();
        private void AddGoal(int matchID, int teamID, ComboBox playerComboBox, TextBox minuteTextBox, DataGridView dataGridView)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Goals (MatchID, PlayerID, GoalMinute) VALUES (@MatchID, @PlayerID, @GoalMinute)";

                    List<SqlParameter> parameters = new List<SqlParameter>
                    {
                        new SqlParameter("@MatchID", matchID),
                        new SqlParameter("@PlayerID", (int)playerComboBox.SelectedValue),
                        new SqlParameter("@GoalMinute", Convert.ToInt32(minuteTextBox.Text))
                    };

                    int result = Con.SetData(insertQuery, parameters.ToArray());

                    // Error handeling: check lenght of matchDataList
                    //MessageBox.Show($"Number of items in matchDataList: {matchDataList.Count}");

                    // Error handeling: check if there are matching MatchIDs
                    //MessageBox.Show($"Matching MatchIDs: {string.Join(", ", matchDataList.Select(match => match.MatchID))}");

                    // Error handeling: loop to see data of matchDataList if any
                    /*foreach (var matchData in matchDataList)
                    {
                        MessageBox.Show($"MatchID in matchDataList: {matchData.MatchID}, HomeTeam: {matchData.HomeTeam}, AwayTeam: {matchData.AwayTeam}");
                    }
                    */

                    // JSON //
                    MatchData currentMatchData = matchDataList.FirstOrDefault(match => match.MatchID == matchID);

                    if (currentMatchData != null)
                    {
                        Goal newGoal = new Goal
                        {
                            PlayerID = (int)playerComboBox.SelectedValue,
                            GoalMinute = Convert.ToInt32(minuteTextBox.Text),
                            MatchID = matchID
                    };

                        currentMatchData.Goals.Add(newGoal);


                        // Show list with current goals from Team
                        ShowGoals(teamID, dataGridView);

                        // Save updated Matchdata in JSON
                        SaveMatchDataToJson(matchDataList);
                    }

                    if (result > 0)
                    {
                        MessageBox.Show("Goal added");

                        UpdateScores(matchID, teamID, 1);

                        ShowGoals(teamID, dataGridView);

                        UpdateScoreTextBox(teamID);

                        // reset input fields
                        playerComboBox.SelectedIndex = 0;
                        minuteTextBox.Text = string.Empty;
                        
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the goal");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while establishing database connection: " + ex.Message);
            }
        }

        // TODO: add parameter List to SaveMatchDataToJson to update list accordingly
        private void SaveMatchDataToJson(List<MatchData> matchDataList)
        {
            try
            {
                // Find the right MatchData in list to update
                MatchData existingMatchData = matchDataList.FirstOrDefault(match => match.MatchID == currentMatchData.MatchID);

                if (existingMatchData != null)
                {
                    // If MatchData exist in list, replace with current MatchData
                    int index = matchDataList.IndexOf(existingMatchData);
                    matchDataList[index] = currentMatchData;
                }
                else
                {
                    
                    matchDataList.Add(currentMatchData);
                }

                // write list to JSON-file
                string json = JsonConvert.SerializeObject(matchDataList, Formatting.Indented);
                System.IO.File.WriteAllText("matches.json", json);

                string currentDirectory = Environment.CurrentDirectory;

                /*
                Error handeling: check where the file is saved
                MessageBox.Show("JSON content:\n" + json);
                MessageBox.Show("JSON file saved to: " + Path.Combine(currentDirectory, "matches.json"));
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while saving match data to JSON: " + ex.Message);
            }
        }

        /*private List<MatchData> LoadMatchDataFromJson()
        {
            try
            {
                string json = System.IO.File.ReadAllText("matches.json");
                List<MatchData> matchDataList = JsonConvert.DeserializeObject<List<MatchData>>(json);

                return matchDataList ?? new List<MatchData>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading match data from JSON: " + ex.Message);
                return new List<MatchData>();
            }
        }
        */



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

            if (GoalsTeamA.SelectedRows.Count > 0)
            {
                int goalID = Convert.ToInt32(GoalsTeamA.SelectedRows[0].Cells["GoalID"].Value);

                GoalsTeamA.Rows.RemoveAt(GoalsTeamA.SelectedRows[0].Index);

                RemoveGoal(GetHomeTeamID(matchID), goalID, GoalsTeamA);
            }
            else
            {
                MessageBox.Show("Select a goal to remove.");
            }
        }

        private void DeleteGoalB_Btn_Click(object sender, EventArgs e)
        {
            if (GoalsTeamB.SelectedRows.Count > 0)
            {
                int goalID = Convert.ToInt32(GoalsTeamB.SelectedRows[0].Cells["GoalID"].Value);

                GoalsTeamB.Rows.RemoveAt(GoalsTeamB.SelectedRows[0].Index);

                RemoveGoal(GetAwayTeamID(matchID), goalID, GoalsTeamB);
            }
            else
            {
                MessageBox.Show("Select a goal to remove.");
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

                    ShowGoals(teamID, dataGridView);

                    UpdateScoreTextBox(teamID);

                    SaveMatchDataToJson(matchDataList);

                   
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

                            SaveMatchDataToJson(matchDataList);

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



