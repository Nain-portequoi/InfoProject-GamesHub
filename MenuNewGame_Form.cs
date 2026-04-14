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

namespace NewGameForm
{
    public partial class MenuNewGame_Form : UserControl
    {
        #region DataMembers
        private MainMenu_Form _mainMenu;
        #endregion

        public MenuNewGame_Form(MainMenu_Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.ShowMainMenu();
        }
    }
}
