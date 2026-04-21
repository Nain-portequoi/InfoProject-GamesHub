using NewGameForm;
using MenuCreatePlayer;
using MenuStatsForm;
using DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainMenuForm
{
    public partial class MainMenu_Form : Form
    {
        private readonly DataBaseConfig _dataBase = new DataBaseConfig();
        public readonly string fileName = "GamesHub.db";
        public MainMenu_Form()
        {
            InitializeComponent();
            
            //_dataBase.DeleteAllPlayers();
            _dataBase.CreateGameTable(fileName);
            _dataBase.CreatePlayersTable(fileName);
        }

        #region ShowMenuMethods
        private void ShowMenuNewGame()
        {
            SetPanel(PnlHost);

            MenuNewGame_Form menuNewGame = new MenuNewGame_Form(this);
            menuNewGame.Dock = DockStyle.Fill;

            PnlHost.Controls.Add(menuNewGame);
        }

        private void ShowMenuCreatePlayer()
        {
            SetPanel(PnlHost);

            CreatePlayer_Form createPlayer = new CreatePlayer_Form(this);
            createPlayer.Dock = DockStyle.Fill;

            PnlHost.Controls.Add(createPlayer);
        }

        private void ShowMenuStats()
        {
            SetPanel(PnlHost);
            // Create an instance of the MenuStats_Form
            MenuStats_Form menuStats = new MenuStats_Form(this);
            menuStats.Dock = DockStyle.Fill;
            PnlHost.Controls.Add(menuStats);
        }        
        public void SetPanel(Panel panel) 
        {
            panel.Controls.Clear();
            panel.Dock = DockStyle.Fill;
            panel.Visible = true;
        }

        public void ShowMenuHost(Panel panel)
        {
            panel.Controls.Clear();
            panel.Visible = false;
        }
        #endregion


        private void BtnLeave_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            ShowMenuNewGame();
        }
        private void BtnCreatePlayer_Click(object sender, EventArgs e)
        {
            ShowMenuCreatePlayer();
        }

        private void BtnStats_Click(object sender, EventArgs e)
        {
            ShowMenuStats();
        }
    }
}
