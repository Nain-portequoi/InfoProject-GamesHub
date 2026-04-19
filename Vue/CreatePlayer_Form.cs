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

namespace MenuCreatePlayer
{
    public partial class CreatePlayer_Form : UserControl
    {
        private MainMenu_Form _mainMenu;
        public CreatePlayer_Form(MainMenu_Form mainMenu)
        {
            _mainMenu = mainMenu;
            InitializeComponent();
            TxtPseudo.Focus();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
           _mainMenu.ShowMenuHost(_mainMenu.PnlHost);
        }

        private void BtnSaveInformation_Click(object sender, EventArgs e)
        {
            if (WantToSave(sender, e))
            {
                // Save the information
            }
        }

        private bool WantToSave(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void TxtPseudo_TextChanged(object sender, EventArgs e)
        {
            if (TxtPseudo.Text != "")
            {
                BtnSaveInformation.Enabled = true;
            }
            else
            {
                BtnSaveInformation.Enabled = false;
            }
        }
    }
}
