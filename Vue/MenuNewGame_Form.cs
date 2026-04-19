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
using MemoryForm;

namespace NewGameForm
{
    public partial class MenuNewGame_Form : UserControl
    {
        #region DataMembers
        private MainMenu_Form _mainMenu;

        public MainMenu_Form GetMainMenu() 
        {
            return _mainMenu;
        }
        enum GameChoice
        {
            Pictionary,
            BlackJack
        }

        private static string _selectedPlayer1 = null;
        private static string _selectedPlayer2 = null;
        #endregion

        public MenuNewGame_Form(MainMenu_Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            CcbPlayer1.DropDownStyle = ComboBoxStyle.DropDownList;
            CcbPlayer2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.ShowMenuHost(_mainMenu.PnlHost);
            
        }

        private void EnableStartGameButtons()
        {
            if (_selectedPlayer1 != null && _selectedPlayer2 != null)
            {
                BtnPictionary.Enabled = true;
                BtnBlackJack.Enabled = true;
            }
            else
            {
                BtnPictionary.Enabled = false;
                BtnBlackJack.Enabled = false;
            }
        }


        #region GameSelection
        private void BtnPictionary_Click(object sender, EventArgs e)
        {
            ShowMemory();
        }

        private void BtnBlackJack_Click(object sender, EventArgs e)
        {
            // ShowBlackJack();         lorsque la classe BlackJack_Form sera créée
        }

        #endregion

        #region ShowMenu
        private void ShowMemory()
        {
            _mainMenu.SetPanel(PnlMenuNewGame);

            Memory_Form memoryForm = new Memory_Form(this);
            memoryForm.Dock = DockStyle.Fill;

            PnlMenuNewGame.Controls.Add(memoryForm);
        }


        #endregion

        private void CcbPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPlayer1 = CcbPlayer1.SelectedItem.ToString();
            
            EnableStartGameButtons();
        }

        private void CcbPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPlayer2 = CcbPlayer2.SelectedItem.ToString();

            EnableStartGameButtons();
        }

    }
}
