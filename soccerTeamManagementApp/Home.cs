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

        private void ManageTeamImg_Click(object sender, EventArgs e)
        {
            Team Obj = new Team();
            Obj.Show();
            this.Hide();
        }

        private void ManageTeamsLink_Click(object sender, EventArgs e)
        {
            Team Obj = new Team();
            Obj.Show();
            this.Hide();
        }

        private void ManagePlayersImg_Click(object sender, EventArgs e)
        {
            Player Obj = new Player();
            Obj.Show();
            this.Hide();
        }

        private void ManagePlayersLink_Click(object sender, EventArgs e)
        {
            Player Obj = new Player();
            Obj.Show();
            this.Hide();
        }

        private void ManageCoachesImg_Click(object sender, EventArgs e)
        {
            Coach Obj = new Coach();
            Obj.Show();
            this.Hide();
        }

        private void ManageCoachesLink_Click(object sender, EventArgs e)
        {
            Coach Obj = new Coach();
            Obj.Show();
            this.Hide();
        }

        private void ManageMatchesImg_Click(object sender, EventArgs e)
        {
            Match Obj = new Match();
            Obj.Show();
            this.Hide();
        }

        private void ManageMatchesLink_Click(object sender, EventArgs e)
        {
            Match Obj = new Match();

            // Gets all teams
            DataTable teamsTable = Con.GetTeams();
            if (teamsTable != null && teamsTable.Rows.Count >= 2)
            {
                List<string> teamNames = new List<string>();
                List<int> teamIds = new List<int>();

                foreach (DataRow row in teamsTable.Rows)
                {
                    // Add teamname to list
                    teamNames.Add(row["TeamName"].ToString());

                    // Add teamID to list
                    teamIds.Add(Convert.ToInt32(row["TeamId"]));
                }

                // Set lists with teamnames and id active for selectedTeamA and B.DataSource 
                Obj.SetTeamNames(teamNames, teamIds);

                Obj.Show();
                this.Hide();
            }
        }


        private void ManageTransfersImg_Click(object sender, EventArgs e)
        {

        }

        private void ManageTransfersLink_Click(object sender, EventArgs e)
        {

        }
        private void LogoutImg_Click(object sender, EventArgs e)
        {

        }
        private void LogoutLink_Click(object sender, EventArgs e)
        {

        }


    }
}
