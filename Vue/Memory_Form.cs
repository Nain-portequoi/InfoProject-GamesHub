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
            SetPlayer();
            InterfaceButton = new List<Button> { BtnCard1, BtnCard2, BtnCard3, BtnCard4, BtnCard5, BtnCard6, BtnCard7, BtnCard8, BtnCard9, BtnCard10, BtnCard11, BtnCard12, BtnCard13, BtnCard14, BtnCard15, BtnCard16, BtnCard17, BtnCard18 };
            CreateNewGame();
            MessageBox.Show($"ID joueur 1 : {_player1.PlayerID} et ID joueur 2 : {_player2.PlayerID} et leur pseudo sont : {_player1.Pseudo} et {_player2.Pseudo}");
        }
        private void ConnectCardToButton(List<Button> Button, List<Card> Card)
        {
            int i;
            for(i=0;i<Button.Count;i++)
            {
                Button[i].Tag = Card[i];
            }
        }
        private void PutImageRecto(List<Button> listOfButton)
        {
            foreach(Button BtnCard in listOfButton)
            {
                HideImage(BtnCard);
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
                btn.BackgroundImage = (Image)ressourceImage;
                btn.BackgroundImageLayout = ImageLayout.Stretch; // Pour que l'image remplisse le bouton
            }
        }


        private void HideImage(Button btn)
        {
            object ImageRecto = InfoProject_GamesHub.Properties.Resources.ResourceManager.GetObject("Recto");
            btn.BackgroundImage = (Image)ImageRecto;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void AnyButtonClick(object sender, EventArgs e)
        {
            Button buttonClicked = (Button)sender;
            Card CardClicked = (Card)buttonClicked.Tag;
           
            switch (_game.SelectCard(CardClicked))
            {
                case MemoryGame.FlipResult.Match:
                    AddScore();
                    ShowScoreRound();
                    break;
                case MemoryGame.FlipResult.NoMatch:
                    ShowPlayerTurn();
                    break;
                case MemoryGame.FlipResult.GameFinish:
                    AddScore();
                    ShowScoreRound();
                    ShowAndHideCard(InterfaceButton); // Pour quand même montrer les deux dernières cartes 
                    GameFinish();
                    break;
            }
            ShowAndHideCard(InterfaceButton);
        }
        private void AddScore() // J'ai ajouté ça /////////
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
        private void ShowScoreRound() // J'ai ajouté ça /////////
        {
            pbPlayer1.Value = _player1.ScoreRound;
            pbPlayer2.Value = _player2.ScoreRound;
        }
        private void GameFinish()
        {
            int gameID = _database.GetGameID("Memory", _mainMenu.fileName);
            if (pbPlayer1.Value > pbPlayer2.Value)
            {
                _database.InsertRound(_player1.PlayerID, gameID, "GamesHub.db");
                ShowGameFinishMessage(_player1);
            }
            else
            {
                _database.InsertRound(_player2.PlayerID, gameID, "GamesHub.db");
                ShowGameFinishMessage(_player2);
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to play a new game ?", "NewGame" , MessageBoxButtons.YesNo); // J'ai modifié ça pour voir le score ///////
            if(dialogResult == DialogResult.No)
            {
                _mainMenu.ShowMenuHost(_menuNewGame.PnlMenuNewGame);
            }
            else
            {
                CreateNewGame();
            }

        }
        private void ShowGameFinishMessage(Player player)
        {
            MessageBox.Show($"The game is finish \nScore final :{_player1.Pseudo} {_player1.ScoreRound} - {_player2.ScoreRound} {_player2.Pseudo}  \n{player.Pseudo} won the game !");
        }
        private void ShowAndHideCard(List<Button> AllButton)
        {
            foreach(Button button in AllButton)
            {
                Card card = (Card)button.Tag;
                if(card.GetIsReturn()==true)
                {
                    ShowImage(button);
                }
                else
                {
                    HideImage(button);
                }
            }
        }

        private void ShowPlayerTurn()
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
        private void CreateNewGame()
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

        private void SetPlayer()
        {
            _database = new DataBaseConfig();
            _player1 = _database.GetPlayersAllInformations(_menuNewGame.GetPlayer1ID(), _mainMenu.fileName);
            _player2 = _database.GetPlayersAllInformations(_menuNewGame.GetPlayer2ID(), _mainMenu.fileName);
            
        }

      
        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.ShowMenuHost(_menuNewGame.PnlMenuNewGame);
        }
    }
}
