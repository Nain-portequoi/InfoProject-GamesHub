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
using NewGameForm;

namespace MemoryForm
{
    public partial class Memory_Form : UserControl
    {
        private MenuNewGame_Form _newGameForm;
        private MainMenu_Form _mainMenu;
        public Memory_Form(MenuNewGame_Form newGameForm)
        {
            InitializeComponent();
            _newGameForm = newGameForm;
            _mainMenu = newGameForm.GetMainMenu();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.ShowMenuHost(_newGameForm.PnlMenuNewGame);
        }
    }
}
