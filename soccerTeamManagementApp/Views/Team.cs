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
            string query = "SELECT * FROM Team";
            TeamList.DataSource = Con.GetData(query);
            //TeamList.Columns["TeamId"].Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TeamName.Text) || string.IsNullOrEmpty(TeamAddress.Text))
                {
                    MessageBox.Show("Please fill in a team name and an address");
                } else
                {
                    string team = TeamName.Text.Trim();
                    string teamAddress = TeamAddress.Text.Trim();
                    string query = "INSERT INTO Team (TeamName, TeamAddress) values ('{0}', '{1}')";
                    query = string.Format(query, TeamName.Text, TeamAddress.Text);
                    Con.SetData(query);

                    ShowTeams();
                    MessageBox.Show("Team added");

                    // Reset input fields
                    TeamName.Text = "";
                    TeamAddress.Text = "";
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
                if (string.IsNullOrEmpty(TeamName.Text) || string.IsNullOrEmpty(TeamAddress.Text))
                {
                    MessageBox.Show("Please fill in a team name and an address");
                }
                else
                {
                    string teamName = TeamName.Text.Trim();
                    string teamAddress = TeamAddress.Text.Trim();

                    if (key > 0)
                    {
                        string query = "UPDATE Team SET TeamName = '{0}', TeamAddress = '{1}' WHERE TeamId = {2}";
                        query = string.Format(query, teamName, teamAddress, key);
                        Con.SetData(query);

                        ShowTeams();
                        MessageBox.Show("Team updated");

                        // Reset input fields
                        TeamName.Text = "";
                        TeamAddress.Text = "";
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
                using (SqlConnection connection = new SqlConnection(Con.ConStr))
                {
                    connection.Open();

                    // Eerst de wedstrijden verwijderen
                    string deleteMatchesQuery = "DELETE FROM Match WHERE HomeTeamId = @TeamId OR AwayTeamId = @TeamId";
                    using (SqlCommand cmd = new SqlCommand(deleteMatchesQuery, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@TeamId", key));
                        cmd.ExecuteNonQuery();
                    }

                    // Spelers bijwerken om ze aan "No team" te koppelen (waarbij 0 het TeamId is voor "No team")
                    string updatePlayersQuery = "UPDATE Player SET Team = 18 WHERE Team = @TeamId";
                    using (SqlCommand cmd = new SqlCommand(updatePlayersQuery, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@TeamId", key));
                        cmd.ExecuteNonQuery();
                    }

                    // Team zelf verwijderen
                    string deleteTeamQuery = "DELETE FROM Team WHERE TeamId = @TeamId";
                    using (SqlCommand cmd = new SqlCommand(deleteTeamQuery, connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@TeamId", key));
                        cmd.ExecuteNonQuery();
                    }
                }

                ShowTeams();
                MessageBox.Show("Team deleted");

                // Reset invoervelden
                TeamName.Text = "";
                TeamAddress.Text = "";
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
    }
}
