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
using DataBase;

namespace MenuCreatePlayer
{
    public partial class CreatePlayer_Form : UserControl
    {
        private readonly MainMenu_Form _mainMenu;
        private readonly MenuNewGame_Form _newGame;
        private readonly DataBaseConfig _dataBase = new DataBaseConfig();
        public CreatePlayer_Form(MainMenu_Form mainMenu)
        {
            _mainMenu = mainMenu;
            InitializeComponent();
            TxtPseudo.Focus();
            _newGame = new MenuNewGame_Form(_mainMenu);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
           _mainMenu.ShowMenuHost(_mainMenu.PnlHost);
        }

        private void BtnSaveInformation_Click(object sender, EventArgs e)
        {
            if (WantToSave(sender, e))
            {
                bool ok = _dataBase.InsertPlayer(TxtPseudo.Text, TxtFirstName.Text, TxtLastName.Text, 0, "");
                if (ok)
                {
                    _mainMenu.ShowMenuHost(_mainMenu.PnlHost);
                }
                else
                {
                    MessageBox.Show("Error saving player information. \nThe pseudo might already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
        private void PerformClickSave(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnSaveInformation.PerformClick();
            }
        }
        private void TxtPseudo_KeyPress(object sender, KeyPressEventArgs e)
        {
            PerformClickSave(e);
        }

        private void TxtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            PerformClickSave(e);
        }

        private void TxtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            PerformClickSave(e);
        }

    }
}
