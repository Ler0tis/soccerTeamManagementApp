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
    public partial class Home : Form
    {
        Functions Con;
        public Home()
        {
            InitializeComponent();
            Con = new Functions();
        }


        private void manageTeamsLink_Click(object sender, EventArgs e)
        {
            Team Obj = new Team();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Team Obj = new Team();
            Obj.Show();
            this.Hide();
        }

        private void manageTeam_Click(object sender, EventArgs e)
        {
            Player Obj = new Player();
            Obj.Show();
            this.Hide();
        }

        private void managePlayersLink_Click(object sender, EventArgs e)
        {
            Player Obj = new Player();
            Obj.Show();
            this.Hide();
        }

        private void manageCoachImg_Click(object sender, EventArgs e)
        {

        }

        private void manageCoachesLink_Click(object sender, EventArgs e)
        {

        }

        private void manageMatchImg_Click(object sender, EventArgs e)
        {
            Match Obj = new Match();
            Obj.Show();
            this.Hide();
        }

        private void manageMatchLink_Click(object sender, EventArgs e)
        {

            Match Obj = new Match();

            // Get all teams
            DataTable teamsTable = Con.GetTeams();

            if (teamsTable != null && teamsTable.Rows.Count >= 2)
            {
                // Make new list to save Teams that can be selected for Match.cs
                List<string> teamNames = new List<string>();

                foreach (DataRow row in teamsTable.Rows)
                {
                    // Add teamnaam to list
                    teamNames.Add(row["TeamName"].ToString());
                }

                // Set list with teamnames active for dataSource Combobox
                Obj.SetTeamNames(teamNames);

                // Show match page
                Obj.Show();
                this.Hide();
            }
        }

        private void manageTransferImg_Click(object sender, EventArgs e)
        {

        }

        private void manageTransferLink_Click(object sender, EventArgs e)
        {

        }

        private void logoutImg_Click(object sender, EventArgs e)
        {

        }

        private void logoutLink_Click(object sender, EventArgs e)
        {

        }
    }
}
