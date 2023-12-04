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
    public partial class Team : Form
    {
        Functions Con;

        public Team()
        {
            InitializeComponent();
            Con = new Functions();
            ShowTeams();
        }

        private void ShowTeams()
        {
            string query = "SELECT * FROM Teams";
            TeamList.DataSource = Con.GetData(query);
            
        }


    private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TeamName.Text) || string.IsNullOrEmpty(TeamAddress.Text))
                {
                    MessageBox.Show("Please fill in a team name and an address");
                } 
                else
                {
                    string team = TeamName.Text.Trim();
                    string teamAddress = TeamAddress.Text.Trim();
                    string query = "INSERT INTO Teams (TeamName, TeamAddress) values ('{0}', '{1}')";
                    query = string.Format(query, TeamName.Text, TeamAddress.Text);
                    Con.SetData(query);

                    MessageBox.Show("Team added");

                    ResetInputFieldsTeam();
                    ShowTeams();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int key = 0;
        private void TeamList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = TeamList.Rows[e.RowIndex];

                // Gets data of selected team
                TeamName.Text = row.Cells["TeamName"].Value.ToString();
                TeamAddress.Text = row.Cells["TeamAddress"].Value.ToString();

                key = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a team to update");
                }
                else if (string.IsNullOrEmpty(TeamName.Text) || string.IsNullOrEmpty(TeamAddress.Text))
                {
                    MessageBox.Show("Please fill in a team name and an address");
                }
                else
                {
                    string teamName = TeamName.Text.Trim();
                    string teamAddress = TeamAddress.Text.Trim();

                    if (key > 0)
                    {
                        string query = "UPDATE Teams SET TeamName = '{0}', TeamAddress = '{1}' WHERE TeamID = {2}";
                        query = string.Format(query, teamName, teamAddress, key);
                        Con.SetData(query);

                        MessageBox.Show("Team updated");

                        ResetInputFieldsTeam();
                        ShowTeams();
                    }
                    else
                    {
                        MessageBox.Show("Select a team to update");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a team to delete");
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(Con.ConStr))
                    {
                        connection.Open();

                        // Delete matches
                        string deleteMatchesQuery = "DELETE FROM Matches WHERE HomeTeamID = @TeamID OR AwayTeamID = @TeamID";
                        using (SqlCommand cmd = new SqlCommand(deleteMatchesQuery, connection))
                        {
                            cmd.Parameters.Add(new SqlParameter("@TeamID", key));
                            cmd.ExecuteNonQuery();
                        }

                        // Update players with No Team ( TeamId 18 )
                        string updatePlayersQuery = "UPDATE Players SET TeamID = 18 WHERE TeamID = @TeamID";
                        using (SqlCommand cmd = new SqlCommand(updatePlayersQuery, connection))
                        {
                            cmd.Parameters.Add(new SqlParameter("@TeamID", key));
                            cmd.ExecuteNonQuery();
                        }

                        // Delete Team
                        string deleteTeamQuery = "DELETE FROM Teams WHERE TeamID = @TeamID";
                        using (SqlCommand cmd = new SqlCommand(deleteTeamQuery, connection))
                        {
                            cmd.Parameters.Add(new SqlParameter("@TeamID", key));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Team deleted");

                    ResetInputFieldsTeam();
                    ShowTeams();


                }
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ResetInputFieldsTeam()
        {
            // Reset input fields
            TeamName.Text = "";
            TeamAddress.Text = "";
        }


        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }
    }
}
