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
            GetTeam();
        }

        private void ShowPlayers()
        {
            string query = "SELECT P.PlayerId, P.FirstName, P.LastName, T.TeamName AS Team, P.BirthDate, P.JerseyNumber, P.Position, P.Salary " +
                    "FROM Player P " +
                    "LEFT JOIN Team T ON P.Team = T.TeamId"; // Use of left JOIN get all players, even without team
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
                if (key == 0)
                {
                    MessageBox.Show("Please fill in data to add a player");
                }
                else if (string.IsNullOrEmpty(FirstNameTb.Text) || string.IsNullOrEmpty(LastNameTb.Text))
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
                    string firstName = FirstNameTb.Text.Trim();
                    string lastName = LastNameTb.Text.Trim();

                    int? team = selectTeamTb.SelectedValue != null ? (int?)Convert.ToInt32(selectTeamTb.SelectedValue) : null;
                    DateTime dateOfBirth = DOBTb.Value;
                    string position = PositionCh.SelectedItem == null ? null : PositionCh.SelectedItem.ToString();

                    // Remove symbol from salary inputfield
                    string salaryText = SalaryTb.Text.Replace("€", "").Trim();

                    if (!string.IsNullOrEmpty(salaryText) && decimal.TryParse(salaryText, out decimal salaryValue) && salaryValue >= 0)
                    {
                        List<SqlParameter> parameters = new List<SqlParameter>
                        {
                            new SqlParameter("@FirstName", firstName),
                            new SqlParameter("@LastName", lastName),
                            new SqlParameter("@Team", team),
                            new SqlParameter("@BirthDate", dateOfBirth),
                            new SqlParameter("@Position", position),
                            new SqlParameter("@Salary", salaryValue)
                        };

                        if (!string.IsNullOrEmpty(JerseyNumberTb.Text) && int.TryParse(JerseyNumberTb.Text, out int jerseyNumberValue))
                        {
                            parameters.Add(new SqlParameter("@JerseyNumber", jerseyNumberValue));
                        }

                        string columns = "FirstName, LastName, Team, BirthDate, Position, Salary";
                        string values = "@FirstName, @LastName, @Team, @BirthDate, @Position, @Salary";

                        if (parameters.Any(p => p.ParameterName == "@JerseyNumber"))
                        {
                            columns += ", JerseyNumber";
                            values += ", @JerseyNumber";
                        }

                        string query = $"INSERT INTO Player ({columns}) VALUES ({values})";

                        Con.SetData(query, parameters.ToArray());

                        MessageBox.Show("Player added");

                        ResetInputFieldsPlayer();
                        ShowPlayers();

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

        private void ResetInputFieldsPlayer()
        {
            // Reset input fields
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
                key = Convert.ToInt32(row.Cells["PlayerId"].Value);

                // Fetch the team of the player and set it in the combobox
                int teamId = GetTeamIdForKey(key);
                selectTeamTb.SelectedValue = teamId;
            }
        }


        private int GetTeamIdForKey(int playerKey)
        {
            // get the team ID for the player based on the player's key
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
                    string firstName = FirstNameTb.Text.Trim();
                    string lastName = LastNameTb.Text.Trim();
                    int? team = selectTeamTb.SelectedValue != null ? (int?)Convert.ToInt32(selectTeamTb.SelectedValue) : null;
                    DateTime dateOfBirth = DOBTb.Value;
                    string position = PositionCh.SelectedItem == null ? null : PositionCh.SelectedItem.ToString();

                    // Delete symbol from salary input field before update
                    string salaryText = SalaryTb.Text.Replace("€", "").Trim();

                    int salaryValue, jerseyNumberValue;

                    SqlParameter[] parameters = new SqlParameter[]
                    {
                        new SqlParameter("@PlayerId", key),
                        new SqlParameter("@FirstName", firstName),
                        new SqlParameter("@LastName", lastName),
                        new SqlParameter("@Team", team),
                        new SqlParameter("@BirthDate", dateOfBirth),
                        new SqlParameter("@Position", position)
                    };

                    if (!string.IsNullOrEmpty(salaryText) && int.TryParse(salaryText, out salaryValue))
                    {
                        // Add symbol to salary input field
                        SalaryTb.Text = $"€ {salaryText}"; // Show symbol in input field
                        parameters = parameters.Concat(new SqlParameter[] { new SqlParameter("@Salary", salaryValue) }).ToArray();
                    }

                    if (!string.IsNullOrEmpty(JerseyNumberTb.Text) && int.TryParse(JerseyNumberTb.Text, out jerseyNumberValue))
                    {
                        parameters = parameters.Concat(new SqlParameter[] { new SqlParameter("@JerseyNumber", jerseyNumberValue) }).ToArray();
                    }

                    string updateColumns = "FirstName = @FirstName, LastName = @LastName, Team = @Team, BirthDate = @BirthDate, Position = @Position";

                    if (parameters.Any(p => p.ParameterName == "@Salary"))
                    {
                        updateColumns += ", Salary = @Salary";
                    }

                    if (parameters.Any(p => p.ParameterName == "@JerseyNumber"))
                    {
                        updateColumns += ", JerseyNumber = @JerseyNumber";
                    }

                    // Use different parameter name for second time @playerId is needed
                    string query = $"UPDATE Player SET {updateColumns} WHERE PlayerId = @PlayerId";

                    Con.SetData(query, parameters);

                    MessageBox.Show("Player updated");

                    ResetInputFieldsPlayer();
                    ShowPlayers();

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
                if (key == 0)
                {
                    MessageBox.Show("Select a player to delete");
                }
                else
                {
                    string query = "DELETE FROM Player WHERE PlayerId = {0}";

                    query = string.Format(query, key);
                    Con.SetData(query);

                    MessageBox.Show("Player deleted");

                    ResetInputFieldsPlayer();
                    ShowPlayers();
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
