using NewGameForm;
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
            PnlHost.Controls.Clear();
            PnlHost.Dock = DockStyle.Fill;
            PnlHost.Visible = true;

            MenuNewGame_Form menuNewGame = new MenuNewGame_Form(this);
            menuNewGame.Dock = DockStyle.Fill;

            PnlHost.Controls.Add(menuNewGame);
        }

        public void ShowMainMenu()
        {
            PnlHost.Controls.Clear();
            PnlHost.Visible = false;
        }


    }
}
