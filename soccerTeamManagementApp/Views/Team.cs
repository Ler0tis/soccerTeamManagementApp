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
                    MessageBox.Show("Team name and address are required fields");
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
                TeamName.Text = row.Cells[1].Value.ToString();
                TeamAddress.Text = row.Cells[2].Value.ToString();

                key = Convert.ToInt32(row.Cells[0].Value);
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
                string team = TeamName.Text;
                string teamAddress = TeamAddress.Text;
                string query = "DELETE FROM Team WHERE TeamId = {0}";

                query = string.Format(query, key);
                Con.SetData(query);

                ShowTeams();
                MessageBox.Show("Team deleted");

                // Reset input fields
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
