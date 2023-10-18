using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            String Query = "SELECT * FROM Team";
            TeamList.DataSource = Con.GetData(Query);
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
                    MessageBox.Show("Team name and address are required fields");
                } else
                {
                    string Team = TeamName.Text.Trim();
                    string teamAddress = TeamAddress.Text.Trim();
                    String Query = "INSERT INTO Team (TeamName, TeamAddress) values ('{0}', '{1}')";
                    Query = string.Format(Query,TeamName.Text, TeamAddress.Text);
                    Con.SetData(Query);
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

        int Key = 0;
        private void TeamList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = TeamList.Rows[e.RowIndex];
                // Haal de waarden van de geselecteerde speler op
                TeamName.Text = row.Cells[1].Value.ToString();
                TeamAddress.Text = row.Cells[2].Value.ToString();

                // Vul het Key-veld met de ID van de speler (kolom 0)
                Key = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TeamName.Text) || string.IsNullOrEmpty(TeamAddress.Text))
                {
                    MessageBox.Show("Team name and address are required fields");
                }
                else
                {
                    string teamName = TeamName.Text.Trim();
                    string teamAddress = TeamAddress.Text.Trim();

                    if (Key > 0)
                    {
                        string query = "UPDATE Team SET TeamName = '{0}', TeamAddress = '{1}' WHERE TeamId = {2}";
                        query = string.Format(query, teamName, teamAddress, Key);
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
                if (TeamName.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string Team = TeamName.Text;
                    string teamAddress = TeamAddress.Text;
                    String Query = "DELETE FROM Team WHERE TeamId = {0}";

                    Query = string.Format(Query,Key);
                    Con.SetData(Query);
                    ShowTeams();
                    MessageBox.Show("Team deleted");

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

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();

            this.Close();
        }
    }
}
