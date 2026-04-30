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
            List<string> info = _database.GetAllInfos(_mainMenu.fileName, query);
            foreach (var item in info)
            {
                RichTxtStats.AppendText(item + Environment.NewLine);
            }
        }
        private void RdbShowPlayers_CheckedChanged(object sender, EventArgs e)
        {
            SetStatsLocation(_nextLocation);       // Change the location of the stats group box when a radio button is checked
            SetRichTxtStatsAndSearchVisible(true);
            RichTxtStats.Clear();
            RichTxtStats.Text = "Player ID \tPseudo \tFirst Name\t Last Name \tTotal Score \tResults \n";
            WriteRichTxtStats("SELECT * FROM Players");
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
            RichTxtStats.Text = "Round ID\t Winner Player ID\t Game ID\t\n";
            WriteRichTxtStats("SELECT * FROM Rounds");
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
                string command = txtSearchBox.Text;
                MessageBox.Show("Search command: " + command);
                RichTxtStats.Clear();
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
