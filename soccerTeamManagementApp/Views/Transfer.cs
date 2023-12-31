﻿using System;
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
        private int selectedTeamID;

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
            public List<TeamHistory> TeamHistory { get; set; } = new List<TeamHistory>();
            public List<Goal> Goals { get; set; } = new List<Goal>();
        }

        public class TeamHistory
        {
            public int TeamID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
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
            playerComboBox.DataSource = players; // set the list of players directly as DS
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


        // Event handler for change selected team
        private void selectTransferTeamTb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Is a team selected?
            if (selectTransferTeamTb.SelectedValue != null && int.TryParse(selectTransferTeamTb.SelectedValue.ToString(), out int teamID))
            {
                // Save team ID in the class variable
                selectedTeamID = teamID;

                GetPlayersForTeam(selectedTeamID, selectTransferPlayerTb);
            }
        }

        // Transfer player to new team. Keep reminding oldTeamID for later use if needed.
        private void TransferPlayer(int currentTeamID, int selectedPlayerID, int newTeamID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();
                    SqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        string updatePlayerQuery = "UPDATE Players SET OldTeamID = TeamID, TeamID = @NewTeamID WHERE PlayerID = @PlayerID AND TeamID = @CurrentTeamID";
                        using (SqlCommand cmdPlayer = new SqlCommand(updatePlayerQuery, connection, transaction))
                        {
                            cmdPlayer.Parameters.AddWithValue("@NewTeamID", newTeamID);
                            cmdPlayer.Parameters.AddWithValue("@PlayerID", selectedPlayerID);
                            cmdPlayer.Parameters.AddWithValue("@CurrentTeamID", currentTeamID);
                            int rowsAffected = cmdPlayer.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                transaction.Commit();
                                MessageBox.Show("Player transferred successfully");

                                UpdatePlayerHistory(selectedPlayerID, newTeamID);
                            }
                            else
                            {
                                MessageBox.Show("Player transfer failed. The selected player doesn't exist in the current team, or the team IDs don't match.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("An error occurred during the transfer: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }



        private void UpdatePlayerHistory(int playerID, int newTeamID)
        {
            Player player = LoadPlayerHistory(playerID);

            TeamHistory teamHistory = new TeamHistory
            {
                TeamID = newTeamID,
                StartDate = DateTime.Now // Transfer date is set on moment the transfer is done
            };

            player.TeamHistory.Add(teamHistory);

            SavePlayerHistory(player);
        }

        private Player LoadPlayerHistory(int playerID)
        {
            string filePath = $"player_{playerID}_history.json";
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Player>(json) ?? new Player();
            }
            else
            {
                return new Player { PlayerID = playerID };
            }
        }

        private void SavePlayerHistory(Player player)
        {
            string json = JsonConvert.SerializeObject(player, Formatting.Indented);
            File.WriteAllText($"player_{player.PlayerID}_history.json", json);
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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();

            this.Close();
        }

    }
}
