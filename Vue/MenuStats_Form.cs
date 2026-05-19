using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainMenuForm;
using DataBase;

namespace MenuStatsForm
{
    public partial class MenuStats_Form : UserControl
    {
        private readonly MainMenu_Form _mainMenu;
        private readonly Point _nextLocation = new Point(350,325);
        private readonly DataBaseConfig _database = new DataBaseConfig();


        public MenuStats_Form(MainMenu_Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.ShowMenuHost(_mainMenu.PnlHost);
        }
        private void WriteRichTxtStats(string query)
        {
            List<string> info = _database.GetAllInfos(query);
            foreach (var item in info)
            {
                RichTxtStats.AppendText(item + Environment.NewLine);
            }
        }
        private void RdbShowPlayers_CheckedChanged(object sender, EventArgs e)
        {
            SetStatsLocation(_nextLocation);
            SetRichTxtStatsAndSearchVisible(true);
            RichTxtStats.Clear();
            RichTxtStats.Text = "Player ID \tPseudo \tScore \tTotal Games played\n";

            string SQLRequest = @"
            SELECT 
            p.PlayerId, 
            p.Pseudo,
            p.ScoreTot,
            COUNT(r.RoundID) AS TotalGames
            FROM Players p 
            LEFT JOIN Rounds r 
            ON p.PlayerId = r.WinnerPlayerId 
            OR p.PlayerId = r.LooserPlayerId
            GROUP BY p.PlayerId, p.Pseudo
            ORDER BY p.PlayerId ASC;";

            WriteRichTxtStats(SQLRequest);
        }



        private void RdbShowGames_CheckedChanged(object sender, EventArgs e)
        {
            SetStatsLocation(_nextLocation);
            SetRichTxtStatsAndSearchVisible(true);
            RichTxtStats.Clear();
            RichTxtStats.Text = "Game ID\t Game name\t\n";
            WriteRichTxtStats("SELECT * FROM Games");
        }

        private void RdbShowRounds_CheckedChanged(object sender, EventArgs e)
        {
            SetStatsLocation(_nextLocation);
            SetRichTxtStatsAndSearchVisible(true);
            RichTxtStats.Clear();
            RichTxtStats.Text = "Round ID\tWinner\tLooser\tGame ID\t\n";

            string query = @"
            SELECT 
            r.RoundID, 
            pw.Pseudo AS Winner, 
            pl.Pseudo AS Looser, 
            r.GameID
            FROM Rounds r
            INNER JOIN Players pw ON r.WinnerPlayerId = pw.PlayerId
            INNER JOIN Players pl ON r.LooserPlayerId = pl.PlayerId";

            WriteRichTxtStats(query);
        }

        private void SetStatsLocation(Point location)
        {
            GpbStats.Location = location;
        }

        private void SetRichTxtStatsAndSearchVisible(bool visible)
        {
            RichTxtStats.Visible = visible;
            pctSearch.Visible = visible;
            lblSearch.Visible = visible;
            txtSearchBox.Visible = visible;
        }

        private void txtSearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // évite le "ding" du Enter

                string searchInput = txtSearchBox.Text.Trim();

                // Validation : un seul mot, non vide, caractères alphanumériques uniquement
                if (string.IsNullOrWhiteSpace(searchInput))
                {
                    MessageBox.Show("Please enter a pseudo to search.");
                    return;
                }

                if (searchInput.Contains(' '))
                {
                    MessageBox.Show("Please enter only one word (a pseudo).");
                    return;
                }

                // On autorise uniquement lettres, chiffres et underscore -> évite les caractères dangereux
                if (!System.Text.RegularExpressions.Regex.IsMatch(searchInput, @"^[a-zA-Z0-9_]+$")) // Si l'on ne fait pas ça, on peut faire du SQL injection en tapant "toto' OR '1'='1" et ça nous afficherait tous les joueurs (exemple donné par Mr Evrard au laboratoire)
                {
                    MessageBox.Show("The pseudo can only contain letters, digits and underscores.");
                    return;
                }

                RichTxtStats.Clear();
                RichTxtStats.Text = "Player ID \tPseudo \tScore Tot\n";

                string command = $"SELECT playerID, Pseudo, ScoreTot FROM Players WHERE Pseudo = '{searchInput}'";

                try
                {
                    WriteRichTxtStats(command);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while executing the search command.\n\tError: " + ex.Message);
                }
            }
        }

    }
}
