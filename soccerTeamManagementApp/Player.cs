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
    public partial class Player : Form
    {
        Functions Con;
        public Player()
        {
            
            InitializeComponent();
            Con = new Functions();
            ShowPlayer();
            GetTeam();
        }

        private void ShowPlayer()
        {
            string Query = "select * from Player";
            PlayerList.DataSource = Con.GetData(Query);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetTeam()
        {
            string Query = "select * from Team";
            selectTeamTb.DisplayMember = Con.GetData(Query).Columns["TeamName"].ToString();
            selectTeamTb.ValueMember = Con.GetData(Query).Columns["TeamId"].ToString();
            selectTeamTb.DataSource = Con.GetData(Query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (FirstNameTb.Text == "" || LastNameTb.Text == "" || selectTeamTb.SelectedIndex == -1 || SalaryTb.Text == "")
                {
                    MessageBox.Show("Missing Data");
                }
                else
                {
                    string FirstName = FirstNameTb.Text;
                    string LastName = LastNameTb.Text;
                    int Team = Convert.ToInt32(selectTeamTb.SelectedValue.ToString());
                    string DOB = DOBTb.Value.ToString();
                    string Position = PositionCh.SelectedItem.ToString();
                    int Salary = Convert.ToInt32(SalaryTb.Text);
                    int JerseyNumber = Convert.ToInt32(JerseyNumberTb.Text);

                    string Query = "INSERT INTO Player (FirstName, LastName, Team, BirthDate, Position, Salary, JerseyNumber) VALUES ('{0}', '{1}', {2}, '{3}', '{4}', {5}, {6})";
                    Query = string.Format(Query, FirstName, LastName, Team, DOB, Position, Salary, JerseyNumber);
                    Con.SetData(Query);
                    ShowPlayer();
                    MessageBox.Show("Player added");
                    FirstNameTb.Text = "";
                    LastNameTb.Text = "";
                    selectTeamTb.SelectedIndex = -1;
                    PositionCh.SelectedIndex = -1;
                    SalaryTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
