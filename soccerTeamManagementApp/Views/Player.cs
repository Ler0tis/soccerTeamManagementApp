using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace soccerTeamManagementApp

{
    public partial class Player : Form
    {
        Functions Con;
        public Player()
        {

            InitializeComponent();
            Con = new Functions();
            ShowPlayers();
            GetTeams();
        }

        private void ShowPlayers()
        {
            string query = "SELECT P.PlayerID, P.FirstName, P.LastName, T.TeamName AS Team, P.BirthDate, P.JerseyNumber, P.Position, P.Salary " +
                    "FROM Players P " +
                    "LEFT JOIN Teams T ON P.TeamID = T.TeamId"; // Use of left JOIN get all players, even without team
            DataTable playerData = Con.GetData(query);

            // Create a new column in the DataTable to store the formatted Salary
            playerData.Columns.Add("FormattedSalary");

            // Format the Salary column to include the Euro symbol
            foreach (DataRow row in playerData.Rows)
            {
                if (row["Salary"] != DBNull.Value)
                {
                    decimal salaryFromDatabase = Convert.ToDecimal(row["Salary"]);
                    string formattedSalary = $"€ {salaryFromDatabase:F2}";
                    row["FormattedSalary"] = formattedSalary;
                }
            }

            // Set the DataGridView's data source to the DataTable with the formatted Salary
            PlayerList.DataSource = playerData;

            //PlayerList.Columns["PlayerId"].Visible = false;
        }

        private void GetTeams()
        {
            string query = "SELECT * FROM Teams";
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
                    MessageBox.Show("Please fill in a first and last name");
                }
                else if (DOBTb.Value.Date == DateTime.Today)
                {
                    MessageBox.Show("Date of birth must be different from today.");
                }
                else if (PositionCh.SelectedItem == null)
                {
                    MessageBox.Show("Please select a position");
                }
                else
                {
                    string playerFirstName = FirstNameTb.Text.Trim();
                    string playerLastName = LastNameTb.Text.Trim(); ;
                    DateTime dateOfBirth = DOBTb.Value;

                    // add code to set Team and salary for Coach
                    int? team = selectTeamTb.SelectedValue != null ? (int?)selectTeamTb.SelectedValue : null;

                    string position = PositionCh.SelectedItem == null ? null : PositionCh.SelectedItem.ToString();

                    string jerseyNumber = JerseyNumberTb.Text.Trim();

                    // Remove symbol before insert into database
                    string salaryText = SalaryTb.Text.Replace("€", "").Trim();

                    if (!string.IsNullOrEmpty(salaryText) && decimal.TryParse(salaryText, out decimal salaryValue) && salaryValue >= 0)
                    {
                        using (SqlConnection connection = new SqlConnection(Con.ConStr))
                        {
                            connection.Open();

                            string playerInsertQuery = "INSERT INTO Players (TeamID, FirstName, LastName, BirthDate, Position, JerseyNumber, Salary) " +
                                                       "VALUES (@TeamID, @FirstName, @LastName, @BirthDate, @Position, @JerseyNumber, @Salary)";

                            using (SqlCommand cmd = new SqlCommand(playerInsertQuery, connection))
                            {

                                List<SqlParameter> parameters = new List<SqlParameter>

                                {
                                    new SqlParameter("@TeamID", team),
                                    new SqlParameter("@FirstName", playerFirstName),
                                    new SqlParameter("@LastName", playerLastName),
                                    new SqlParameter("@BirthDate", dateOfBirth),
                                    new SqlParameter("@Position", position),
                                    new SqlParameter("@JerseyNumber", jerseyNumber),
                                    new SqlParameter("@Salary", salaryValue)
                                };

                                // Convert the List<SqlParameter> to an Array. Then add parameters to SQL-cmd. 
                                cmd.Parameters.AddRange(parameters.ToArray());

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Player added");

                            ResetInputFieldsPlayer();
                            ShowPlayers();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid salary. Please enter a valid numeric value.");
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("An error occurred while adding the player: " + Ex.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a player to update");
                }
                else if (string.IsNullOrEmpty(FirstNameTb.Text) || string.IsNullOrEmpty(LastNameTb.Text))
                {
                    MessageBox.Show("First name and last name are required fields");
                }
                else if (DOBTb.Value.Date == DateTime.Today)
                {
                    MessageBox.Show("Date of birth must be different from today");
                }
                else if (PositionCh.SelectedItem == null)
                {
                    MessageBox.Show("Position is required");
                }
                else
                {
                    string playerFirstName = FirstNameTb.Text.Trim();
                    string playerLastName = LastNameTb.Text.Trim(); ;
                    DateTime dateOfBirth = DOBTb.Value;

                    // add code to set Team and salary for Coach
                    int? team = selectTeamTb.SelectedValue != null ? (int?)selectTeamTb.SelectedValue : null;

                    string position = PositionCh.SelectedItem == null ? null : PositionCh.SelectedItem.ToString();

                    string jerseyNumber = JerseyNumberTb.Text.Trim();

                    // Remove symbol before insert into database
                    string salaryText = SalaryTb.Text.Replace("€", "").Trim();

                    if (!string.IsNullOrEmpty(salaryText) && decimal.TryParse(salaryText, out decimal salaryValue) && salaryValue >= 0)
                    {
                        using (SqlConnection connection = new SqlConnection(Con.ConStr))
                        {
                            connection.Open();

                            string playerInsertQuery = "UPDATE Players SET TeamID = @TeamID, FirstName = @FirstName, LastName = @LastName, " +
                                "BirthDate = @BirthDate, Position = @Position, JerseyNumber = @JerseyNumber, Salary = @Salary " +
                                "WHERE PlayerID = @PlayerID"; 

                            using (SqlCommand cmd = new SqlCommand(playerInsertQuery, connection))
                            {

                                List<SqlParameter> parameters = new List<SqlParameter>

                                {
                                    new SqlParameter("@PlayerID", key),
                                    new SqlParameter("@TeamID", team),
                                    new SqlParameter("@FirstName", playerFirstName),
                                    new SqlParameter("@LastName", playerLastName),
                                    new SqlParameter("@BirthDate", dateOfBirth),
                                    new SqlParameter("@Position", position),
                                    new SqlParameter("@JerseyNumber", jerseyNumber),
                                    new SqlParameter("@Salary", salaryValue)
                                };

                                // Convert the List<SqlParameter> to an Array. Then add parameters to SQL-cmd. 
                                cmd.Parameters.AddRange(parameters.ToArray());

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Player updated");

                            ResetInputFieldsPlayer();
                            ShowPlayers();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid salary. Please enter a valid numeric value.");
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("An error occurred while updating the player: " + Ex.Message);
            }
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a player to delete");
                }
                else if (key != 0)
                {
                    string query = "DELETE FROM Players WHERE PlayerID = @PlayerID";

                    using (SqlConnection connection = new SqlConnection(Con.ConStr))
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.Add(new SqlParameter("@PlayerID", key));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Player deleted");

                    ResetInputFieldsPlayer();
                    ShowPlayers();
                }
                else
                {
                    MessageBox.Show("Select a player to delete");
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

        private void ResetInputFieldsPlayer()
        {
            FirstNameTb.Text = "";
            LastNameTb.Text = "";
            selectTeamTb.SelectedIndex = -1;
            DOBTb.Value = DateTime.Today;
            PositionCh.SelectedIndex = -1;
            SalaryTb.Text = "";
            JerseyNumberTb.Text = "";
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

                // Format and display the salary with the euro symbol
                if (row.Cells["Salary"].Value != DBNull.Value)
                {
                    decimal salaryFromDatabase = Convert.ToDecimal(row.Cells["Salary"].Value);
                    SalaryTb.Text = $"€ {salaryFromDatabase:F2}";
                }
                else
                {
                    SalaryTb.Text = string.Empty; // Clear the SalaryTb if the value in DB Null
                }

                JerseyNumberTb.Text = row.Cells["JerseyNumber"].Value.ToString();

                // Fill Key with ID of Player
                key = Convert.ToInt32(row.Cells["PlayerID"].Value);

                // Fetch the team of the player and set it in the combobox
                int teamId = GetTeamIdForKey(key);
                selectTeamTb.SelectedValue = teamId;
            }
        }


        private int GetTeamIdForKey(int playerKey)
        {
            // get the team ID for the player based on the player's key
            string query = "SELECT TeamID FROM Players WHERE PlayerID = @PlayerID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@PlayerID", playerKey));

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            // Return a default value if no team ID is found
            return 0;
        }



        private void LabelSalary_Click(object sender, EventArgs e)
        {
            Label euroLabel = new Label();
            euroLabel.Text = "€";
            euroLabel.Location = new System.Drawing.Point(SalaryTb.Left - 20, SalaryTb.Top);
            this.Controls.Add(euroLabel);
        }

        private void SalaryTb_LostFocus(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!decimal.TryParse(SalaryTb.Text, out decimal salary) || salary < 0)
            {
                MessageBox.Show("Invalid salary. Please enter a valid numeric value.");
                SalaryTb.Text = ""; // remove unnecessary text
            }
            else
            {
                SalaryTb.Text = $"€ {salary:F2}"; // show two decimals
            }
        }


        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void selectTeamTb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
