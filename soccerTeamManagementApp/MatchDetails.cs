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
    public partial class MatchDetails : Form
    {

        private int matchID;
        Functions Con;
        public MatchDetails(int matchID)
        {
            InitializeComponent();
            Con = new Functions();

            this.matchID = matchID;
            Show_MatchDetails();
            MatchDetails_Load(this, EventArgs.Empty);
        }

        private void Show_MatchDetails()
        {
            string query = "SELECT T1.TeamName AS HomeTeam, T2.TeamName AS AwayTeam " +
                           "FROM Matches M " +
                           "INNER JOIN Teams T1 ON M.HomeTeamID = T1.TeamID " +
                           "INNER JOIN Teams T2 ON M.AwayTeamID = T2.TeamID " +
                           "WHERE M.MatchID = @MatchID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.Add(new SqlParameter("@MatchID", matchID));

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable matchData = new DataTable();
                        adapter.Fill(matchData);

                        if (matchData.Rows.Count > 0)
                        {
                            HomeTeamTb.Text = matchData.Rows[0]["HomeTeam"].ToString();
                            AwayTeamTb.Text = matchData.Rows[0]["AwayTeam"].ToString();
                        }
                        else
                        {
                            // No match found for provided MatchID
                            MessageBox.Show("No match data found for the selected match.");
                            this.Close();
                        }
                    }
                }
            }
        }

        private int GetHomeTeamID(int matchID)
        {
            string query = "SELECT HomeTeamID FROM Matches WHERE MatchID = @MatchID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private int GetAwayTeamID(int matchID)
        {
            string query = "SELECT AwayTeamID FROM Matches WHERE MatchID = @MatchID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MatchID", matchID);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        private void FillPlayerComboBoxes()
        {
            // Vul ComboBox voor Home Team
            List<string> homeTeamPlayers = GetPlayersForTeam("HomeTeam");
            selectHomePlayerTb.DataSource = homeTeamPlayers;

            // Vul ComboBox voor Away Team
            List<string> awayTeamPlayers = GetPlayersForTeam("AwayTeam");
            selectAwayPlayerTb.DataSource = awayTeamPlayers;
        }

        private List<string> GetPlayersForTeam(string teamType)
        {
            List<string> players = new List<string>();

            string query = $"SELECT CONCAT(FirstName, ' ', LastName) AS PlayerName " +
                           $"FROM Players P " +
                           $"WHERE P.TeamID = @TeamID";

            using (SqlConnection connection = new SqlConnection(Con.ConStr))
            {
                connection.Open();

                // Determine the teamID based on Home or Away
                int teamID = (teamType == "HomeTeam") ? GetHomeTeamID(matchID) : GetAwayTeamID(matchID);

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@TeamID", teamID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string playerName = reader["PlayerName"].ToString();
                            players.Add(playerName);
                        }
                    }
                }
            }

            return players;
        }


        private void MatchDetails_Load(object sender, EventArgs e)
        {
            FillPlayerComboBoxes();
        }



        private void SelectTeamA_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Home homeForm = new Home();
            homeForm.Show();
            this.Close();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
