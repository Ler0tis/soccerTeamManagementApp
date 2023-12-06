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


    public partial class Transfer : Form
    {
        Functions Con;
        private List<Player> transferHistory;

        public Transfer()
        {
            InitializeComponent();
            Con = new Functions();
            transferHistory = new List<Player>();

            selectTransferTeamTb.SelectedIndexChanged += selectTransferTeamTb_SelectedIndexChanged;

            GetTeams(selectTransferTeamTb);
            GetTeams(selectNewTransferTeamTb);

        }

        public class Player
        {
            public int PlayerID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int TeamID { get; set; } // Team waar de speler momenteel bij hoort
            public List<Goal> Goals { get; set; } = new List<Goal>(); // Lijst van doelpunten van de speler
        }


        
        private void GetTeams(ComboBox comboBox)
        {
            string query = "SELECT * FROM Teams";
            comboBox.DisplayMember = "TeamName";
            comboBox.ValueMember = "TeamId";
            comboBox.DataSource = Con.GetData(query);
        }


        private void GetPlayersForTeam(int teamID, ComboBox playerComboBox)
        {
            List<KeyValuePair<int, string>> players = GetPlayersForSelectedTeam(teamID);

            Console.WriteLine($"Number of players for team {teamID}: {players.Count}");

            playerComboBox.DisplayMember = "Value";
            playerComboBox.ValueMember = "Key";
            playerComboBox.DataSource = players; // set the list directly as DS
        }


        private List<KeyValuePair<int, string>> GetPlayersForSelectedTeam(int selectedTeamId)
        {
            List<KeyValuePair<int, string>> players = new List<KeyValuePair<int, string>>();

            string query = $"SELECT PlayerID, CONCAT(FirstName, ' ', LastName) AS PlayerName " +
                           $"FROM Players " +
                           $"WHERE TeamID = @TeamID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TeamID", selectedTeamId);

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

        private int selectedTeamID; // class variable 

        // Event handler for change selected team
        private void selectTransferTeamTb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Is a team selected?
            if (selectTransferTeamTb.SelectedValue != null && int.TryParse(selectTransferTeamTb.SelectedValue.ToString(), out int teamID))
            {
                // Save team ID in class variable
                selectedTeamID = teamID;

                GetPlayersForTeam(selectedTeamID, selectTransferPlayerTb);
            }
        }

        private void TransferPlayer(int currentTeamID, int selectedPlayerID, int newTeamID)
        {
            try
            {
                string updatePlayerQuery = "UPDATE Players SET TeamID = @NewTeamID WHERE PlayerID = @PlayerID AND TeamID = @CurrentTeamID";

                List<SqlParameter> playerParameters = new List<SqlParameter>
                {
                    new SqlParameter("@NewTeamID", newTeamID),
                    new SqlParameter("@PlayerID", selectedPlayerID),
                    new SqlParameter("@CurrentTeamID", currentTeamID)
                };

                // Update speler en doelpunten binnen een transactie
                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Update speler
                            using (SqlCommand cmdPlayer = new SqlCommand(updatePlayerQuery, connection, transaction))
                            {
                                cmdPlayer.Parameters.AddRange(playerParameters.ToArray());
                                cmdPlayer.ExecuteNonQuery();
                            }

                            // Zoek de speler op basis van PlayerID
                            Player player = GetPlayer(selectedPlayerID);

                            // Update doelpunten van de speler
                            foreach (Goal goal in player.Goals)
                            {
                                string updateGoalsQuery = "UPDATE Goals SET TeamID = @NewTeamID WHERE GoalID = @GoalID";
                                List<SqlParameter> goalsParameters = new List<SqlParameter>
                            {
                                new SqlParameter("@NewTeamID", newTeamID),
                                new SqlParameter("@GoalID", goal.GoalID)
                            };

                                using (SqlCommand cmdGoals = new SqlCommand(updateGoalsQuery, connection, transaction))
                                {
                                    cmdGoals.Parameters.AddRange(goalsParameters.ToArray());
                                    cmdGoals.ExecuteNonQuery();
                                }
                            }

                            // Commit de transactie als alles goed gaat
                            transaction.Commit();

                            MessageBox.Show("Player transferred successfully");

                            //TODO: first get the list filled for JSON and then save to Json
                            var transfer = new Player
                            {
                                PlayerID = selectedPlayerID,
                                TeamID = currentTeamID
                                
                            };

                            transferHistory.Add(transfer);

                            SaveTransfersToJson();

                            // Reset playerCombobox
                            selectTransferPlayerTb.DataSource = null;
                        }
                        catch (Exception ex)
                        {
                            // Bij een fout, rol de transactie terug
                            transaction.Rollback();
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private Player GetPlayer(int playerID)
        {
            Player player = null;

            string query = "SELECT PlayerID, FirstName, LastName, TeamID FROM Players WHERE PlayerID = @PlayerID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PlayerID", playerID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            player = new Player
                            {
                                PlayerID = Convert.ToInt32(reader["PlayerID"]),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                TeamID = Convert.ToInt32(reader["TeamID"]),
                                Goals = GetGoalsForPlayer(playerID)
                            };
                        }
                    }
                }
            }

            return player;
        }

        private List<Goal> GetGoalsForPlayer(int playerID)
        {
            List<Goal> goals = new List<Goal>();

            string query = "SELECT GoalID, MatchID, GoalMinute FROM Goals WHERE PlayerID = @PlayerID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PlayerID", playerID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Goal goal = new Goal
                            {
                                GoalID = Convert.ToInt32(reader["GoalID"]),
                                MatchID = Convert.ToInt32(reader["MatchID"]),
                                GoalMinute = Convert.ToInt32(reader["GoalMinute"])
                            };

                            goals.Add(goal);
                        }
                    }
                }
            }

            return goals;
        }






        private void TransferBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectTransferTeamTb.SelectedItem == null)
                {
                    MessageBox.Show("Select a team");
                    return;
                }

                // Is player selected?
                if (selectTransferPlayerTb.SelectedValue != null && int.TryParse(selectTransferPlayerTb.SelectedValue.ToString(), out int selectedPlayerID))
                {
                    // playerID and previous selectedTeamID then trigger TRansfer player
                    int newTeamID = Convert.ToInt32(selectNewTransferTeamTb.SelectedValue);
                    TransferPlayer(selectedTeamID, selectedPlayerID, newTeamID);
                }
                else
                {
                    MessageBox.Show("Select a player");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void SaveTransfersToJson()
        {
            string json = JsonConvert.SerializeObject(transferHistory, Formatting.Indented);
            File.WriteAllText("transfers.json", json);
        }

    

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();

            this.Close();
        }
    }
}
