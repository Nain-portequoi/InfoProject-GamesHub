using MainMenuForm;
using MemoryCard;
using NewGameForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DataBase;
using PlayerInformation;
using MemoryGameClass;


namespace Memory_Pierre
{
    public partial class Memory_Form : UserControl
    {
        private ImageCollection _imageCollection;
        private List<Button> InterfaceButton;
        private MemoryGame _game;
        private readonly MenuNewGame_Form _menuNewGame;
        private readonly MainMenu_Form _mainMenu;
        private DataBaseConfig _database;
        private Player _player1;
        private Player _player2;

        public Memory_Form(MenuNewGame_Form menuNewGame, MainMenu_Form mainMenu)
        {
            InitializeComponent();
            _menuNewGame = menuNewGame;
            _mainMenu = mainMenu;
            pbPlayer1.Value = 0;
            pbPlayer2.Value = 0;
            SetPlayer();

            InterfaceButton = new List<Button> { BtnCard1, BtnCard2, BtnCard3, BtnCard4, BtnCard5, BtnCard6, BtnCard7, BtnCard8, BtnCard9, BtnCard10, BtnCard11, BtnCard12, BtnCard13, BtnCard14, BtnCard15, BtnCard16, BtnCard17, BtnCard18 };
            CreateNewGame();
        }
        private void ConnectCardToButton(List<Button> Button, List<Card> Card)
        {
            int i;
            for(i=0;i<Button.Count;i++)
            {
                Button[i].Tag = Card[i]; // On associe chaque carte à un bouton en utilisant la propriété Tag
            }
        }
        private void PutImageRecto(List<Button> listOfButton)
        {
            try
            {
                foreach (Button BtnCard in listOfButton)
                {
                    HideImage(BtnCard); // On met l'image de dos sur chaque bouton et on gère les exceptions au cas où l'image ne serait pas trouvée
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _mainMenu.ShowMenuHost(_menuNewGame.PnlMenuNewGame);
            }
        }
        private void ShowImage(Button btn)
        {
            
            Card carte = (Card)btn.Tag;
            // On va chercher l'image dans les ressources grâce au nom
            // On utilise Properties.Resources.ResourceManager.GetObject(nom)
            object ressourceImage = InfoProject_GamesHub.Properties.Resources.ResourceManager.GetObject(carte.GetNameImage());


            if (ressourceImage != null)
            {
                btn.BackgroundImage = (Image)ressourceImage; // On met l'image de la carte sur le bouton
                btn.BackgroundImageLayout = ImageLayout.Stretch; // Pour que l'image remplisse le bouton
            }
            else
                throw new Exception("Image not found: " + carte.GetNameImage());
        }


        private void HideImage(Button btn)
        {
            object ImageRecto = InfoProject_GamesHub.Properties.Resources.ResourceManager.GetObject("Recto"); // On va chercher l'image de dos dans les ressources grâce au nom
            if (ImageRecto != null) // On vérifie que l'image a été trouvée sinon on envoie une exception
            {
                btn.BackgroundImage = (Image)ImageRecto;
                btn.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
                throw new Exception("Image not found: Recto");
        }

        private void AnyButtonClick(object sender, EventArgs e)
        { 
            Button buttonClicked = (Button)sender; // On récupère le bouton qui a été cliqué
            Card CardClicked = (Card)buttonClicked.Tag; // On récupère la carte associée à ce bouton grâce à la propriété Tag

            switch (_game.SelectCard(CardClicked)) 
            {
                case MemoryGame.FlipResult.Match: // Si les deux cartes correspondent, on ajoute un point au joueur et on affiche le score du round
                    AddScore();
                    ShowScoreRound();
                    break;
                case MemoryGame.FlipResult.NoMatch: // Si les deux cartes ne correspondent pas, on change de joueur et on affiche le joueur actuel
                    ShowPlayerTurn();
                    break;
                case MemoryGame.FlipResult.GameFinish: // Si le jeu est terminé, on ajoute un point au joueur qui a gagné le round, on affiche le score du round, on montre les deux dernières cartes et on affiche le message de fin de jeu
                    AddScore();
                    ShowScoreRound();
                    ShowAndHideCard(InterfaceButton); // Pour quand même montrer les deux dernières cartes 
                    GameFinish();
                    break;
            }
            ShowAndHideCard(InterfaceButton);
        }
        private void AddScore() 
        {
            if (_game.CurrentPlayer == 1)
            {
                _player1.ScoreRound += 1;
            }
            else
            {
                _player2.ScoreRound += 1;
            }
        }
        private void ShowScoreRound() 
        {
            pbPlayer1.Value = _player1.ScoreRound; // On affiche le score du round de chaque joueur dans les progress bars
            pbPlayer2.Value = _player2.ScoreRound;
        }
        private void GameFinish()
        {
            int gameID = _database.GetGameID("Memory");
            if (pbPlayer1.Value > pbPlayer2.Value)
            {
                _database.InsertRound(_player1.PlayerID, _player2.PlayerID, gameID); // On insère le résultat du round dans la base de données en précisant les ID des joueurs et l'ID du jeu
                _player1.ScoreTot += 1; // On ajoute un point au score total du joueur qui a gagné le round
                _database.UpdateScoreTot(_player1.PlayerID, _player1.ScoreTot); // On met à jour le score total du joueur dans la base de données
                ShowGameFinishMessage(_player1); // On affiche un message de fin de jeu en précisant le score final et le nom du joueur qui a gagné
            }
            else
            {
                _database.InsertRound(_player2.PlayerID, _player1.PlayerID, gameID); // même chose que pour le joueur 1 mais pour le joueur 2
                _player2.ScoreTot += 1;
                _database.UpdateScoreTot(_player2.PlayerID, _player2.ScoreTot);
                ShowGameFinishMessage(_player2);
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to play a new game ?", "NewGame" , MessageBoxButtons.YesNo); // On demande au joueur s'il veut faire une nouvelle partie
            if (dialogResult == DialogResult.No)
            {
                _mainMenu.ShowMenuHost(_menuNewGame.PnlMenuNewGame); // S'il ne veut pas faire une nouvelle partie, on retourne au menu de sélection des joueurs
            }
            else
            {
                CreateNewGame(); // S'il veut faire une nouvelle partie, on recommence une partie en réinitialisant le jeu et les scores du round
            }

        }
        private void ShowGameFinishMessage(Player player) // On affiche un message de fin de jeu en précisant le score final et le nom du joueur qui a gagné
        {
            MessageBox.Show($"The game is finish \nScore final :{_player1.Pseudo} {_player1.ScoreRound} - {_player2.ScoreRound} {_player2.Pseudo}  \n{player.Pseudo} won the game !");
        }
        private void ShowAndHideCard(List<Button> AllButton) 
        {
            foreach (Button button in AllButton)
            {
                Card card = (Card)button.Tag;
                try
                {
                    if (card.GetIsReturn() == true)
                    {
                        ShowImage(button); // Si la carte est retournée, on affiche son image
                    }
                    else
                    {
                        HideImage(button); // Si la carte n'est pas retournée, on affiche l'image de dos
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); // On gère les exceptions au cas où une image ne serait pas trouvée et on retourne au menu de sélection des joueurs et de jeux
                    _mainMenu.ShowMenuHost(_menuNewGame.PnlMenuNewGame);
                }
            }
        }

        private void ShowPlayerTurn() // On affiche le joueur actuel en mettant son nom en vert et en entourant son nom de ">" et "<" et en mettant le nom de l'autre joueur en rouge
        {
            if (_game.CurrentPlayer == 1)
            {
                SwitchPlayerVisuals(lblPlayer1, lblPlayer2, _player1.Pseudo, _player2.Pseudo);
            }
            else
            {
                SwitchPlayerVisuals(lblPlayer2, lblPlayer1, _player2.Pseudo, _player1.Pseudo);
            }
        }

        private void SwitchPlayerVisuals(System.Windows.Forms.Label label1, System.Windows.Forms.Label label2, string activePlayer, string inactivePlayer)
        {
            label1.Text = "> " + activePlayer + " <";
            label2.Text = inactivePlayer;
            label1.ForeColor = Color.Green;
            label2.ForeColor = Color.Red;
        }
        private void CreateNewGame() // On crée une nouvelle partie en réinitialisant le jeu, les cartes, les scores du round et en affichant le joueur qui commence
        {
            _imageCollection = new ImageCollection();
            _game = new MemoryGame(_imageCollection);
            _game.SetUpGame();
            ConnectCardToButton(InterfaceButton, _imageCollection.GetImageCollection());
            PutImageRecto(InterfaceButton);
            pbPlayer1.Value = 0;
            pbPlayer2.Value = 0;
            ShowPlayerTurn();
            ShowAndHideCard(InterfaceButton);
        }

        private void SetPlayer() // On récupère les informations des joueurs sélectionnés dans le menu de sélection des joueurs et de jeux grâce à leurs ID et on les stocke dans des objets Player
        {
            _database = new DataBaseConfig();
            _player1 = _database.GetPlayersAllInformations(_menuNewGame.GetPlayer1ID());
            _player2 = _database.GetPlayersAllInformations(_menuNewGame.GetPlayer2ID());
            
        }

      
        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.ShowMenuHost(_menuNewGame.PnlMenuNewGame);
        }
    }
}
