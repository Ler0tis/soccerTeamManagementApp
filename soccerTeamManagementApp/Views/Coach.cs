using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace soccerTeamManagementApp
{
    public partial class Coach : Form
    {
        Functions Con;

        public Coach()
        {
            InitializeComponent();
            Con = new Functions();
            GetTeam();
            ShowCoaches();
        }


        private void ShowCoaches()
        {
            string query = "SELECT C.CoachID, C.FirstName, C.LastName, T.TeamName AS Team, C.BirthDate, C.Salary " +
                    "FROM Coaches C " +
                    "LEFT JOIN Teams T ON C.TeamID = T.TeamID"; // Use of left JOIN get all coaches, even without team
            DataTable coachesData = Con.GetData(query);

            // Create a new column in the DataTable to store the formatted Salary
            coachesData.Columns.Add("FormattedSalary");

            // Format the Salary column to include the Euro symbol
            foreach (DataRow row in coachesData.Rows)
            {
                if (row["Salary"] != DBNull.Value)
                {
                    decimal salaryFromDatabase = Convert.ToDecimal(row["Salary"]);
                    string formattedSalary = $"€ {salaryFromDatabase:F2}";
                    row["FormattedSalary"] = formattedSalary;
                }
            }

            // Set the DataGridView's data source to the DataTable with the formatted Salary
            CoachesList.DataSource = coachesData;
        }

        private void label2_Click(object sender, EventArgs e)
        {

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
                else
                {
                    string coachFirstName = FirstNameTb.Text.Trim();
                    string coachLastName = LastNameTb.Text.Trim();
                    DateTime dateOfBirth = DOBTb.Value;

                    // add code to set Team and salary for Coach
                    int? team = selectTeamTb.SelectedValue != null ? (int?)selectTeamTb.SelectedValue : null;

                    // Remove symbol before insert into database
                    string salaryText = SalaryTb.Text.Replace("€", "").Trim();

                    if (!string.IsNullOrEmpty(salaryText) && decimal.TryParse(salaryText, out decimal salaryValue) && salaryValue >= 0)
                    {
                        using (SqlConnection connection = new SqlConnection(Con.ConStr))
                        {
                            connection.Open();

                            string coachInsertQuery = "INSERT INTO Coaches (TeamID, FirstName, LastName, BirthDate, Salary) " +
                                                       "VALUES (@Team, @FirstName, @LastName, @BirthDate, @Salary)";

                            using (SqlCommand cmd = new SqlCommand(coachInsertQuery, connection))
                            {

                                List<SqlParameter> parameters = new List<SqlParameter>

                                {
                                    new SqlParameter("@Team", team),
                                    new SqlParameter("@FirstName", coachFirstName),
                                    new SqlParameter("@LastName", coachLastName),
                                    new SqlParameter("@BirthDate", dateOfBirth),
                                    new SqlParameter("@Salary", salaryValue)
                                };

                                // Convert the List<SqlParameter> to an Array. Then add parameters to SQL-cmd. 
                                cmd.Parameters.AddRange(parameters.ToArray());

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Coach added");

                            ResetInputFieldsCoach();
                            ShowCoaches();

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
                MessageBox.Show("An error occurred while adding the coach: " + Ex.Message);
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a coach to update.");
                }

                else if (string.IsNullOrEmpty(FirstNameTb.Text) || string.IsNullOrEmpty(LastNameTb.Text))
                {
                    MessageBox.Show("Please fill in a first and last name");
                }
                else if (DOBTb.Value.Date == DateTime.Today)
                {
                    MessageBox.Show("Date of birth must be different from today.");
                }
                else
                {
                    string coachFirstName = FirstNameTb.Text.Trim();
                    string coachLastName = LastNameTb.Text.Trim();
                    DateTime dateOfBirth = DOBTb.Value;

                    // add code to set Team and salary for Coach
                    int? team = selectTeamTb.SelectedValue != null ? (int?)selectTeamTb.SelectedValue : null;

                    // Remove symbol before update into database
                    string salaryText = SalaryTb.Text.Replace("€", "").Trim();

                    if (!string.IsNullOrEmpty(salaryText) && decimal.TryParse(salaryText, out decimal salaryValue) && salaryValue >= 0)
                    {
                        using (SqlConnection connection = new SqlConnection(Con.ConStr))
                        {
                            connection.Open();

                            string coachUpdateQuery = "UPDATE Coaches SET TeamID = @Team, FirstName = @FirstName, LastName = @LastName, " +
                                                      "BirthDate = @BirthDate, Salary = @Salary WHERE CoachID = @CoachID";

                            using (SqlCommand cmd = new SqlCommand(coachUpdateQuery, connection))
                            {

                                List<SqlParameter> parameters = new List<SqlParameter>

                                {
                                    new SqlParameter("@CoachID", key),
                                    new SqlParameter("@Team", team),
                                    new SqlParameter("@FirstName", coachFirstName),
                                    new SqlParameter("@LastName", coachLastName),
                                    new SqlParameter("@BirthDate", dateOfBirth),
                                    new SqlParameter("@Salary", salaryValue)
                                };

                                // Convert the List<SqlParameter> to an Array. Then add parameters to SQL-cmd. 
                                cmd.Parameters.AddRange(parameters.ToArray());

                                cmd.ExecuteNonQuery();
                            }

                            MessageBox.Show("Coach updated");

                            ResetInputFieldsCoach();
                            ShowCoaches();

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
                MessageBox.Show("An error occurred while updating the coach: " + Ex.Message);
            }
        }

        private void ResetInputFieldsCoach()
        {
            // Reset input fields
            FirstNameTb.Text = "";
            LastNameTb.Text = "";
            DOBTb.Value = DateTime.Today;
            selectTeamTb.SelectedIndex = -1;
            SalaryTb.Text = "";
        }


        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show("Select a coach to delete");
                }

                else if (key != 0)
                {
                    string query = "DELETE FROM Coaches WHERE CoachID = @CoachID";

                    using (SqlConnection connection = new SqlConnection(Con.ConStr))
                    {
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.Add(new SqlParameter("@CoachID", key));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Coach deleted");

                    ResetInputFieldsCoach();
                    ShowCoaches();
                }
                else
                {
                    MessageBox.Show("Select a coach to delete.");
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

        private void FirstNameCoachTb_TextChanged(object sender, EventArgs e)
        {

        }

        int key = 0;
        private void CoachesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = CoachesList.Rows[e.RowIndex];

                // Get data for selected player
                FirstNameTb.Text = row.Cells["FirstName"].Value.ToString();
                LastNameTb.Text = row.Cells["LastName"].Value.ToString();
                DOBTb.Value = Convert.ToDateTime(row.Cells["BirthDate"].Value);

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


                // Fill Key with ID of coach
                key = Convert.ToInt32(row.Cells["CoachID"].Value);

                // Fetch the team of the coach and set it in the combobox
                int teamId = GetTeamIdForKey(key);
                selectTeamTb.SelectedValue = teamId;
            }
        }

        // for showing teamName in coachea Datagrid instead of TeamID
        private int GetTeamIdForKey(int coachKey)
        {
            string query = "SELECT TeamID FROM Coaches WHERE CoachID = @CoachID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@CoachID", coachKey));

                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return 0;
        }

        private void GetTeam()
        {
            string query = "SELECT * FROM Teams";
            selectTeamTb.DisplayMember = "TeamName";
            selectTeamTb.ValueMember = "TeamID";
            selectTeamTb.DataSource = Con.GetData(query);
        }


        private void LabelSalary_Click(object sender, EventArgs e)
        {
            Label euroLabel = new Label();
            euroLabel.Text = "€";
            euroLabel.Location = new System.Drawing.Point(SalaryTb.Left - 20, SalaryTb.Top);
            this.Controls.Add(euroLabel);
        }

        private void SalaryTb_LostFocus(object sender, EventArgs e)
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
        
    }
}
