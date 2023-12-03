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

    public class TransferData
    {
        public int PlayerID { get; set; }
        public int OldTeamID { get; set; }
        public int NewTeamID { get; set; }
    }


    public partial class Transfer : Form
    {
        Functions Con;
        public Transfer()
        {
            InitializeComponent();
            Con = new Functions();

            selectTransferTeamTb.SelectedIndexChanged += selectTransferTeamTb_SelectedIndexChanged;
            // Need selectNewTransferTeam as well?

            GetTeams(selectTransferTeamTb);
            GetTeams(selectNewTransferTeamTb);

        }

        private void label2_Click(object sender, EventArgs e)
        {

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

        // Event handler change selected team
        private void selectTransferTeamTb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Is a team selected?
            if (selectTransferTeamTb.SelectedValue != null && int.TryParse(selectTransferTeamTb.SelectedValue.ToString(), out int teamID))
            {
                // Save team ID in class cariable
                selectedTeamID = teamID;

                GetPlayersForTeam(selectedTeamID, selectTransferPlayerTb);
            }
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

        private void TransferPlayer(int currentTeamID, int selectedPlayerID, int newTeamID)
        {
            try
            {
                string updateQuery = "UPDATE Players SET TeamID = @NewTeamID WHERE PlayerID = @PlayerID AND TeamID = @CurrentTeamID";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@NewTeamID", newTeamID),
                    new SqlParameter("@PlayerID", selectedPlayerID),
                    new SqlParameter("@CurrentTeamID", currentTeamID)
                };

                int result = Con.SetData(updateQuery, parameters.ToArray());

                if (result > 0)
                {
                    MessageBox.Show("Player transferred successfully");
                    selectTransferPlayerTb.DataSource = null;
                    

                    // TODO: Voeg JSON opslaan toe voor history van transfers
                }
                else
                {
                    MessageBox.Show("Failed to transfer player");
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
