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
            SetRichTxtStatsVisible(true);
            RichTxtStats.Clear();
            RichTxtStats.Text = "Player ID \tPseudo \tFirst Name \tLast Name \tTotal Score \tResults \n";
            WriteRichTxtStats("SELECT * FROM Players");
        }



        private void RdbShowGames_CheckedChanged(object sender, EventArgs e)
        {
            SetStatsLocation(_nextLocation);
            SetRichTxtStatsVisible(true);
            RichTxtStats.Clear();
            WriteRichTxtStats("SELECT * FROM Games");
        }

        private void RdbShowRounds_CheckedChanged(object sender, EventArgs e)
        {
            SetStatsLocation(_nextLocation);
            SetRichTxtStatsVisible(true);
            RichTxtStats.Clear();
            WriteRichTxtStats("SELECT * FROM Rounds");
        }

        private void SetStatsLocation(Point location)
        {
            GpbStats.Location = location;
        }

        private void SetRichTxtStatsVisible(bool visible)
        {
            RichTxtStats.Visible = visible;
        }
    }
}
