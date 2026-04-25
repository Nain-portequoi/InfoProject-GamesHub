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
using Memory_Pierre;
using DataBase;
using PlayerInformation;

namespace NewGameForm
{
    public partial class MenuNewGame_Form : UserControl
    {
        #region DataMembers
        private MainMenu_Form _mainMenu;
        private DataBaseConfig _dataBase;

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
        private static string _selectedPlayer1Previous = null;
        private static string _selectedPlayer2 = null;
        private static string _selectedPlayer2Previous = null;
        #endregion

        public MenuNewGame_Form(MainMenu_Form mainMenu)
        {
            InitializeComponent();
            _mainMenu = mainMenu;
            CcbPlayer1.DropDownStyle = ComboBoxStyle.DropDownList;
            CcbPlayer2.DropDownStyle = ComboBoxStyle.DropDownList;

            MenuNewGame_Form_Load();
        }

        private void MenuNewGame_Form_Load()
        {
            _dataBase = new DataBaseConfig();
            int numberOfPlayers = _dataBase.GetNumberOfPlayers(_mainMenu.fileName);

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player player = _dataBase.GetPlayersPseudo(i + 1, _mainMenu.fileName);
                CcbPlayer1.Items.Add(player.Pseudo);
                CcbPlayer2.Items.Add(player.Pseudo);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _selectedPlayer1 = null;
            _selectedPlayer1Previous = null;
            _selectedPlayer2 = null;
            _selectedPlayer2Previous = null;
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

            Memory_Form memoryForm = new Memory_Form(this, _mainMenu);
            memoryForm.Dock = DockStyle.Fill;

            PnlMenuNewGame.Controls.Add(memoryForm);
        }


        #endregion

        private void CcbPlayer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPlayer1 = CcbPlayer1.SelectedItem.ToString();
            
            EnableStartGameButtons();
            DeletaPlayerFromComboBoxIfChosen(_selectedPlayer1, CcbPlayer2);
            AddPlayerBackToComboBox(_selectedPlayer1Previous, CcbPlayer2);
            _selectedPlayer1Previous = _selectedPlayer1;
        }

        private void CcbPlayer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedPlayer2 = CcbPlayer2.SelectedItem.ToString();

            EnableStartGameButtons();
            DeletaPlayerFromComboBoxIfChosen(_selectedPlayer2, CcbPlayer1);
            AddPlayerBackToComboBox(_selectedPlayer2Previous, CcbPlayer1);
            _selectedPlayer2Previous = _selectedPlayer2;
        }

        private void DeletaPlayerFromComboBoxIfChosen(string selectedPlayer, ComboBox comboBox)
        {
            if (selectedPlayer != null)
            {
                comboBox.Items.Remove(selectedPlayer);
            }
        }

        private void AddPlayerBackToComboBox(string player, ComboBox comboBox)
        {
            if (player != null && !comboBox.Items.Contains(player))
            {
                comboBox.Items.Add(player);
            }
        }

    }
}
