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
            String Query = "Select * from Team";
            TeamList.DataSource = Con.GetData(Query);
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
                if(TeamName.Text == "")
                {
                    MessageBox.Show("Missing Data");
                } else
                {
                    string Team = TeamName.Text;
                    String Query = "insert into Team (TeamName) values ('{0}')";
                    Query = string.Format(Query,TeamName.Text);
                    Con.SetData(Query);
                    ShowTeams();
                    MessageBox.Show("Team added");
                    TeamName.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
