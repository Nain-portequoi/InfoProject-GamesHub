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

        public MainMenu_Form()
        {
            InitializeComponent();
            
            //_dataBase.DeleteAllData();
            _dataBase.CreateGameTable();
            _dataBase.CreatePlayersTable();
            _dataBase.CreateRoundTable();
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
            // On crée une instance de MenuStats_Form en lui passant une référence à MainMenu_Form (this)
            MenuStats_Form menuStats = new MenuStats_Form(this);
            menuStats.Dock = DockStyle.Fill;
            PnlHost.Controls.Add(menuStats);
        }        
        public void SetPanel(Panel panel) 
        {
            panel.Controls.Clear(); // On efface les contrôles existants dans le panel
            panel.Dock = DockStyle.Fill; // On définit le Dock du panel pour qu'il remplisse tout l'espace disponible
            panel.Visible = true; // On rend le panel visible pour afficher le nouveau menu
        }

        public void ShowMenuHost(Panel panel)
        {
            panel.Controls.Clear(); // On efface les contrôles existants dans le panel
            panel.Visible = false; // On rend le panel invisible pour éviter les problèmes d'affichage
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
