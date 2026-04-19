using NewGameForm;
using MenuCreatePlayer;
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
        public MainMenu_Form()
        {
            InitializeComponent();
            
        }


        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            ShowMenuNewGame();
        }

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


        private void BtnLeave_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCreatePlayer_Click(object sender, EventArgs e)
        {
            ShowMenuCreatePlayer();
        }
    }
}
