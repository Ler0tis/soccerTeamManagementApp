using System;
using System.Data;
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
            string query = "SELECT P.PlayerId, P.FirstName, P.LastName, T.TeamName AS Team, P.BirthDate, P.JerseyNumber, P.Position, P.Salary " +
                    "FROM Player P " +
                    "LEFT JOIN Team T ON P.Team = T.TeamId"; // Use of left JOIN get all players, even without team
            PlayerList.DataSource = Con.GetData(query);

            //PlayerList.Columns["PlayerId"].Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GetTeam()
        {
            string query = "SELECT * FROM Team";
            selectTeamTb.DisplayMember = "TeamName";
            selectTeamTb.ValueMember = "TeamId";
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

                    int? team = null; // Declare as nullable integer
                    if (selectTeamTb.SelectedValue != null)
                    {
                        team = Convert.ToInt32(selectTeamTb.SelectedValue.ToString());
                    }

                    DateTime dateOfBirth = DOBTb.Value;
                    string formattedDateOfBirth = dateOfBirth.ToString("yyy-MM-dd");
                    string position = PositionCh.SelectedItem == null ? null : PositionCh.SelectedItem.ToString();
                    int salary = Convert.ToInt32(SalaryTb.Text);
                    int jerseyNumber = Convert.ToInt32(JerseyNumberTb.Text);

                    if (position == null)
                    {
                        MessageBox.Show("Position is required.");
                    }

                    string query = "INSERT INTO Player (FirstName, LastName, Team, BirthDate, Position, Salary, JerseyNumber) VALUES ('{0}', '{1}', {2}, '{3}', '{4}', {5}, {6})";
                    query = string.Format(query, firstName, lastName, team, formattedDateOfBirth, position, salary, jerseyNumber);
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
                FirstNameTb.Text = row.Cells["FirstName"].Value.ToString();
                LastNameTb.Text = row.Cells["LastName"].Value.ToString();
                DOBTb.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);
                PositionCh.SelectedItem = row.Cells["Position"].Value.ToString();
                SalaryTb.Text = row.Cells["Salary"].Value.ToString();
                JerseyNumberTb.Text = row.Cells["JerseyNumber"].Value.ToString();

                // Fill Key with ID of Player
                key = Convert.ToInt32(row.Cells["PlayerId"].Value);

                // Fetch the team of the player and set it in the combobox
                int teamId = GetTeamIdForKey(key);
                selectTeamTb.SelectedValue = teamId;
            }
        }

        private int GetTeamIdForKey(int playerKey)
        {
            // Your SQL query to get the team ID for the player based on the player's key
            string query = "SELECT Team FROM Player WHERE PlayerId = {0}";
            query = string.Format(query, playerKey);

            DataTable result = Con.GetData(query);

            if (result != null && result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["Team"]);
            }

            // Return a default value if no team ID is found
            return 0;
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
                    int? team = null;
                    if (selectTeamTb.SelectedValue != null)
                    {
                        team = Convert.ToInt32(selectTeamTb.SelectedValue.ToString());
                    }
                    DateTime dateOfBirth = DOBTb.Value;
                    string formattedDateOfBirth = dateOfBirth.ToString("yyy-MM-dd");
                    string position = PositionCh.SelectedItem == null ? null : PositionCh.SelectedItem.ToString();
                    int salary = Convert.ToInt32(SalaryTb.Text);
                    int jerseyNumber = Convert.ToInt32(JerseyNumberTb.Text);

                    string query = "UPDATE Player SET FirstName = '{0}', LastName = '{1}'," +
                        " Team = {2}, BirthDate = '{3}', Position = '{4}', Salary = {5}, JerseyNumber = {6} " +
                        "WHERE PlayerId = {7}";
                    query = string.Format(query, firstName, lastName, team, formattedDateOfBirth, position, salary, jerseyNumber, key);
                    Con.SetData(query);

                    ShowPlayer();
                    MessageBox.Show("Player updated");

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

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Player WHERE PlayerId = {0}";

                query = string.Format(query, key);
                Con.SetData(query);

                ShowPlayer();
                MessageBox.Show("Player deleted");

                // Reset input fields
                FirstNameTb.Text = "";
                LastNameTb.Text = "";
                selectTeamTb.SelectedIndex = -1;
                PositionCh.SelectedIndex = -1;
                JerseyNumberTb.Text = "";
                SalaryTb.Text = "";
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


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }



        private void Player_Load(object sender, EventArgs e)
        {

        }

        private void FirstNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void DOBTb_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
