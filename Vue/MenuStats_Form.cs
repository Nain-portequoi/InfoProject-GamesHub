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

namespace MenuStatsForm
{
    public partial class MenuStats_Form : UserControl
    {
        private MainMenu_Form _mainMenu;

        public MenuStats_Form(MainMenu_Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.ShowMenuHost(_mainMenu.PnlHost);
        }
    }
}
