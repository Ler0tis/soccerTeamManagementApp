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
    public partial class Match : Form
    {
        Functions Con;
        public Match()
        {
            InitializeComponent();
            Con = new Functions();
        }

        public void SetTeamNames(List<string> teamNames)
        {
            
            // Selectionfields for team A and B from database
            selectTeamATb.DataSource = teamNames;
            selectTeamBTb.DataSource = teamNames;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            int teamAId = Convert.ToInt32(selectTeamATb.SelectedValue);
            int teamBId = Convert.ToInt32(selectTeamBTb.SelectedValue);

            // Validation
            if (teamAId == teamBId)
            {
                MessageBox.Show("Team A and B are the same. Please select two different teams");
                return;
            }
            DateTime matchDate = matchDayTb.Value;

            
            // SQL-query to add new match 
            string query = "INSERT INTO Match (TeamAId, TeamBId, MatchDate) VALUES ({0}, {1}, '{2}')";
            query = string.Format(query, teamAId, teamBId, matchDate.ToString("yyyy-MM-dd"));

            // Execute query with DB connection
            Con.SetData(query);
        }



        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();

            this.Close();
        }

        private void selectTeamATb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
