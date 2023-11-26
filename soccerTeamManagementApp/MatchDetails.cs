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

namespace soccerTeamManagementApp
{
    public partial class MatchDetails : Form
    {

        private Functions Con;
        private int matchID;
        private int homeTeamScore = 0;
        private int awayTeamScore = 0;

        public MatchDetails(int matchID)
        {
            InitializeComponent();
            Con = new Functions();

            this.matchID = matchID;
            Show_MatchDetails();
            MatchDetails_Load(this, EventArgs.Empty);

            homeTeamScore = 0;
            awayTeamScore = 0;

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

            //UpdateScoreTextBox(GetHomeTeamID(matchID));
            //UpdateScoreTextBox(GetAwayTeamID(matchID));

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


        private void SelectTeamA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }


        private void AddHomeTeamBtn_Click(object sender, EventArgs e)
        {
            int homeTeamID = GetHomeTeamID(matchID);
            AddGoal(homeTeamID, selectHomePlayerTb, goalMinuteTeamA, GoalsTeamA);

            UpdateScoresAfterGoal(homeTeamID, GoalsTeamA);
        }

        private void AddAwayTeamBtn_Click(object sender, EventArgs e)
        {
            int awayTeamID = GetAwayTeamID(matchID);
            AddGoal(awayTeamID, selectAwayPlayerTb, goalMinuteTeamB, GoalsTeamB);

            UpdateScoresAfterGoal(awayTeamID, GoalsTeamB);
        }

        private void AddGoal(int teamID, ComboBox playerComboBox, TextBox minuteTextBox, DataGridView dataGridView)
        {
            try
            {
                string insertQuery = "INSERT INTO Goals (MatchID, PlayerID, GoalMinute) VALUES (@MatchID, @PlayerID, @GoalMinute)";

                int playerID = (int)playerComboBox.SelectedValue;
                int goalMinute;

                if (int.TryParse(minuteTextBox.Text, out goalMinute))
                {
                    int result = Con.SetData(insertQuery,
                        new SqlParameter("@MatchID", matchID),
                        new SqlParameter("@PlayerID", playerID),
                        new SqlParameter("@GoalMinute", goalMinute));

                    if (result > 0)
                    {
                        MessageBox.Show("Goal added");
                        ShowGoals(teamID, dataGridView); // Refresh datagridview


                        // Reset tekst en combobox
                        playerComboBox.SelectedIndex = 0;
                        minuteTextBox.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Failed to add the goal");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a player and enter the minute to add the goal");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
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

            if (GoalsTeamA.SelectedRows.Count > 0)
            {
                int goalID = Convert.ToInt32(GoalsTeamA.SelectedRows[0].Cells["GoalID"].Value);

                GoalsTeamA.Rows.RemoveAt(GoalsTeamA.SelectedRows[0].Index);

                RemoveGoal(goalID);
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

                RemoveGoal(goalID);
            }
            else
            {
                MessageBox.Show("Select a goal to remove.");
            }
        }


        private void RemoveGoal(int goalID)
        {
            try
            {
                string deleteQuery = "DELETE FROM Goals WHERE GoalID = @GoalID";

                int result = Con.SetData(deleteQuery, new SqlParameter("@GoalID", goalID));

                if (result > 0)
                {
                    MessageBox.Show("Goal removed");
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
            //UpdateScoresAfterGoal(teamID, GoalsTeamB);
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
                            MessageBox.Show("Goal updated");
                            ShowGoals(teamID, dataGridView); // Refresh datagridview



                            // Reset tekst en combobox
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


        ////////////////////////// SCORES /////////////////////////////
        private void UpdateScores()
        {
            try
            {
                // Bereken de scores voor het thuisteam en uitteam
                int homeTeamScore = CalculateTeamScore(GetHomeTeamID(matchID));
                int awayTeamScore = CalculateTeamScore(GetAwayTeamID(matchID));

                // Update de scores in de database
                string updateScoresQuery = "UPDATE Matches SET HomeTeamScore = @UpdatedHomeTeamScore, AwayTeamScore = @UpdatedAwayTeamScore WHERE MatchID = @MatchID";
                int result = Con.SetData(updateScoresQuery,
                    new SqlParameter("@UpdatedHomeTeamScore", homeTeamScore),
                    new SqlParameter("@UpdatedAwayTeamScore", awayTeamScore),
                    new SqlParameter("@MatchID_UpdateScores", matchID));

                if (result > 0)
                {
                    this.homeTeamScore = homeTeamScore;
                    this.awayTeamScore = awayTeamScore;
                }
                else
                {
                    MessageBox.Show("Failed to update scores");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating scores: " + ex.Message);
            }
        }

        private int CalculateTeamScore(int teamID)
        {
            // Bereken de totale score voor een team op basis van doelpunten in de database
            string query = "SELECT COUNT(GoalID) FROM Goals WHERE MatchID = @MatchID AND TeamID = @TeamID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);
                    cmd.Parameters.AddWithValue("@TeamID", teamID);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // Update scores after goal and refresh the page
        private void UpdateScoresAfterGoal(int teamID, DataGridView dataGridView)
        {
            UpdateScores(); 
            ShowGoals(teamID, dataGridView);
            UpdateScoreTextBox(teamID);
        }

        private void UpdateScoreTextBox(int teamID)
        {
            if (teamID == GetHomeTeamID(matchID))
            {
                homeTeamScore++;
                homeTeamScoreField.Text = homeTeamScore.ToString();
            }
            else if (teamID == GetAwayTeamID(matchID))
            {
                awayTeamScore++;
                awayTeamScoreField.Text = awayTeamScore.ToString();
            }
        }

        // waarom deze niet gebruiken om de score te zetten en aan te passen in de DB? En deze laten weergeven op de pagina ?????? ///
        private int GetHomeTeamScore(int matchID)
        {
            // Haal de score op voor het thuisteam op basis van de matchID
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
            // Haal de score op voor het uitteam op basis van de matchID
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



