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
            TxtPseudo.Focus(); // On place le focus sur le champ de saisie du pseudo pour que l'utilisateur puisse commencer à taper immédiatement
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
                try 
                {
                    _dataBase.InsertPlayer(TxtPseudo.Text, TxtFirstName.Text, TxtLastName.Text, 0); // On insère le joueur dans la base de données avec un score initial de 0
                    _mainMenu.ShowMenuHost(_mainMenu.PnlHost); // Après avoir enregistré les informations du joueur, on retourne au menu principal
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving player information. \nThe pseudo might already exist !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // En cas d'erreur lors de l'enregistrement des informations du joueur, on affiche un message d'erreur à l'utilisateur
                }
            }
        }
        private bool WantToSave(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to save the information?", "Save Information", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes) // Si l'utilisateur clique sur "Yes", on retourne true pour indiquer qu'il souhaite enregistrer les informations
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
            if (TxtPseudo.Text != "") // Si le champ de saisie du pseudo n'est pas vide, on active le bouton "Save Information". Sinon, on le désactive pour empêcher l'utilisateur d'enregistrer des informations incomplètes
            {
                BtnSaveInformation.Enabled = true;
            }
            else
            {
                BtnSaveInformation.Enabled = false;
            }
        }
        private void PerformClickSave(KeyPressEventArgs e) // Cette méthode est appelée lors de la pression d'une touche dans les champs de saisie du pseudo, du prénom ou du nom. Si la touche pressée est "Enter", on déclenche le clic sur le bouton "Save Information" pour enregistrer les informations du joueur.
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
