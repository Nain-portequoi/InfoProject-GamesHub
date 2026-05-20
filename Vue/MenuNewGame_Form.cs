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
        private DataBaseConfig _dataBase = new DataBaseConfig();
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
            
            int numberOfPlayers = _dataBase.GetNumberOfPlayers(); // Récupère le nombre total de joueurs dans la base de données

            for (int i = 0; i < numberOfPlayers; i++)
            {
                Player player = _dataBase.GetPlayersPseudo(i + 1); // Récupère les informations du joueur à l'index i (en commençant par 1)
                CcbPlayer1.Items.Add(player.Pseudo); // Ajoute le pseudo du joueur à la ComboBox des joueurs 1
                CcbPlayer2.Items.Add(player.Pseudo); // Ajoute le pseudo du joueur à la ComboBox des joueurs 2
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            _selectedPlayer1 = null; // Réinitialise les joueurs sélectionnés
            _selectedPlayer1Previous = null; 
            _selectedPlayer2 = null;
            _selectedPlayer2Previous = null;
            _mainMenu.ShowMenuHost(_mainMenu.PnlHost); // Affiche le menu principal
        }

        private void EnableStartGameButtons() // Active ou désactive les boutons de démarrage des jeux en fonction de la sélection des joueurs
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
        public string GetPseudo1()
        {
            return _selectedPlayer1;
        }
        public string GetPseudo2()
        {
            return _selectedPlayer2;
        }

        public int GetPlayer1ID()
        {
            return _dataBase.GetPlayerID(_selectedPlayer1); // Récupère l'ID du joueur 1 en fonction de son pseudo
        }

        public int GetPlayer2ID()
        {
            return _dataBase.GetPlayerID(_selectedPlayer2);
        }

        #region GameSelection
        private void BtnPictionary_Click(object sender, EventArgs e)
        {
            _dataBase.InsertGame("Memory"); // Insère une nouvelle partie de Memory dans la base de données
            ShowMemory(); // Affiche le form du jeu Memory
        }

        private void BtnBlackJack_Click(object sender, EventArgs e) // Affiche un message indiquant que le jeu n'est pas encore disponible
        {
            MessageBox.Show("This game is not available yet. Please choose another one.");
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
            _selectedPlayer1 = CcbPlayer1.SelectedItem.ToString(); // Récupère le pseudo du joueur 1 sélectionné

            EnableStartGameButtons();
            DeletaPlayerFromComboBoxIfChosen(_selectedPlayer1, CcbPlayer2); // Supprime le joueur 1 de la ComboBox des joueurs 2 pour éviter qu'il soit sélectionné en même temps
            AddPlayerBackToComboBox(_selectedPlayer1Previous, CcbPlayer2); // Ajoute le joueur 1 précédent à la ComboBox des joueurs 2 pour qu'il puisse être sélectionné à nouveau si le joueur change sa sélection
            _selectedPlayer1Previous = _selectedPlayer1; // Met à jour le joueur 1 précédent pour la prochaine sélection
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
