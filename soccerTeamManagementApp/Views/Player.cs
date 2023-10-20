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
            string query = "SELECT * FROM Player";
            PlayerList.DataSource = Con.GetData(query);
            //PlayerList.Columns["PlayerId"].Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GetTeam()
        {
            string query = "SELECT * FROM Team";
            selectTeamTb.DisplayMember = Con.GetData(query).Columns["TeamName"].ToString();
            selectTeamTb.ValueMember = Con.GetData(query).Columns["TeamId"].ToString();
            selectTeamTb.DataSource = Con.GetData(query);
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FirstNameTb.Text) || string.IsNullOrEmpty(LastNameTb.Text))
                {
                    MessageBox.Show("First name and last name are required fields.");
                }
                else
                {
                    string firstName = FirstNameTb.Text.Trim();
                    string lastName = LastNameTb.Text.Trim();
                    int team = Convert.ToInt32(selectTeamTb.SelectedValue.ToString());
                    string dateOfBirth = DOBTb.Value.ToString();
                    string position = PositionCh.SelectedItem == null ? null : PositionCh.SelectedItem.ToString();
                    int salary = Convert.ToInt32(SalaryTb.Text);
                    int jerseyNumber = Convert.ToInt32(JerseyNumberTb.Text);

                    if (position == null)
                    {
                        MessageBox.Show("Position is required.");
                    }

                    string query = "INSERT INTO Player (FirstName, LastName, Team, BirthDate, Position, Salary, JerseyNumber) VALUES ('{0}', '{1}', {2}, '{3}', '{4}', {5}, {6})";
                    query = string.Format(query, firstName, lastName, team, dateOfBirth, position, salary, jerseyNumber);
                    Con.SetData(query);

                    ShowPlayer();
                    MessageBox.Show("Player added");

                    // Reset input fields
                    FirstNameTb.Text = "";
                    LastNameTb.Text = "";
                    selectTeamTb.SelectedIndex = -1;
                    DOBTb.Value = DateTime.Today;
                    PositionCh.SelectedIndex = -1;
                    SalaryTb.Text = "";
                    JerseyNumberTb.Text = "";
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int key = 0;

        private void PlayerList_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = PlayerList.Rows[e.RowIndex];

                // Get data for selected player
                FirstNameTb.Text = row.Cells[1].Value.ToString();
                LastNameTb.Text = row.Cells[2].Value.ToString();
                DOBTb.Value = Convert.ToDateTime(row.Cells[3].Value);
                PositionCh.SelectedItem = row.Cells["Position"].Value.ToString();
                SalaryTb.Text = row.Cells[4].Value.ToString();
                JerseyNumberTb.Text = row.Cells[5].Value.ToString();

                // Fill Key with ID of Player
                key = Convert.ToInt32(row.Cells[0].Value);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(FirstNameTb.Text) || string.IsNullOrEmpty(LastNameTb.Text))
                {
                    MessageBox.Show("First name and last name are required fields.");
                }
                else
                {
                    string firstName = FirstNameTb.Text.Trim();
                    string lastName = LastNameTb.Text.Trim();
                    int team = Convert.ToInt32(selectTeamTb.SelectedValue.ToString());
                    string dateOfBirth = DOBTb.Value.ToString();
                    string position = PositionCh.SelectedItem == null ? null : PositionCh.SelectedItem.ToString();
                    int salary = Convert.ToInt32(SalaryTb.Text);
                    int jerseyNumber = Convert.ToInt32(JerseyNumberTb.Text);

                    string query = "UPDATE Player SET FirstName = '{0}', LastName = '{1}'," +
                        " Team = {2}, BirthDate = '{3}', Position = '{4}', Salary = {5}, JerseyNumber = {6} " +
                        "WHERE PlayerId = {7}";
                    query = string.Format(query, firstName, lastName, team, dateOfBirth, position, salary, jerseyNumber, key);
                    Con.SetData(query);

                    ShowPlayer();
                    MessageBox.Show("Player updated");

                    // Reset input fields
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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string firstName = FirstNameTb.Text;
                string lastName = LastNameTb.Text;
                int team = Convert.ToInt32(selectTeamTb.SelectedValue.ToString());
                string dateOfBirth = DOBTb.Value.ToString("yyyy-MM-dd");
                string position = PositionCh.SelectedItem.ToString();
                int salary = Convert.ToInt32(SalaryTb.Text);
                int jerseyNumber = Convert.ToInt32(JerseyNumberTb.Text);

                string query = "DELETE FROM PLayer WHERE PlayerId = {0}";

                query = string.Format(query, key);
                Con.SetData(query);

                ShowPlayer();
                MessageBox.Show("Team deleted");

            } catch (Exception Ex)
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

        private void Player_Load(object sender, EventArgs e)
        {

        }

        private void FirstNameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
