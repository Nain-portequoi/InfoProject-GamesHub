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


namespace Memory_Pierre
{
    public partial class Memory_Form : UserControl
    {
        private ImageCollection _imageCollection;
        private List<Button> InterfaceButton;
        private MemoryGame _game;
        private readonly MenuNewGame_Form _menuNewGame;
        private readonly MainMenu_Form _mainMenu;
        private readonly DataBaseConfig _database;

        public Memory_Form(MenuNewGame_Form menuNewGame, MainMenu_Form mainMenu)
        {
            InitializeComponent();
            _menuNewGame = menuNewGame;
            _mainMenu = mainMenu;
            InterfaceButton = new List<Button> { BtnCard1, BtnCard2, BtnCard3, BtnCard4, BtnCard5, BtnCard6, BtnCard7, BtnCard8, BtnCard9, BtnCard10, BtnCard11, BtnCard12, BtnCard13, BtnCard14, BtnCard15, BtnCard16, BtnCard17, BtnCard18 };
            CreateNewGame();
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
                    if (_game.CurrentPlayer == 1)
                        pbPlayer1.Value += 1;
                    else
                        pbPlayer2.Value += 1;
                    break;
                case MemoryGame.FlipResult.NoMatch:
                    ColorNextPlayer();
                    break;
                case MemoryGame.FlipResult.GameFinish:
                    ShowAndHideCard(InterfaceButton); // Pour quand même montrer les deux dernières cartes 
                    GameFinish();
                    break;
            }
            ShowAndHideCard(InterfaceButton);
        }
        private void GameFinish()
        {
            if (pbPlayer1.Value > pbPlayer2.Value)
            {
                MessageBox.Show($"The game is finish, {_menuNewGame.GetPseudo1()} won the game !");
            }
            else
            {
                MessageBox.Show($"The game is finish, {_menuNewGame.GetPseudo2()} won the game ");
            }
            DialogResult dialogResult = MessageBox.Show("Do you want playing a new game ?", "NewGame" , MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.No)
            {
                _mainMenu.ShowMenuHost(_menuNewGame.PnlMenuNewGame);
            }
            else
            {
                CreateNewGame();
            }
        }
        private void SetUpNameAndColorPlayer()
        {
            lblPlayer1.Text = _menuNewGame.GetPseudo1();
            lblPlayer2.Text = _menuNewGame.GetPseudo2();
            lblPlayer1.ForeColor = Color.Green;
            lblPlayer2.ForeColor = Color.Red;
        }
        private void ColorNextPlayer()
        {
           
            if(_game.CurrentPlayer == 1)
            {
                lblPlayer1.ForeColor = Color.Green;
                lblPlayer2.ForeColor = Color.Red;
            }
            else if (_game.CurrentPlayer == 2)
            {
                lblPlayer1.ForeColor = Color.Red;
                lblPlayer2.ForeColor= Color.Green;
            }
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
        private void CreateNewGame()
        {
            _imageCollection = new ImageCollection();
            _game = new MemoryGame(_imageCollection);
            _game.SetUpGame();
            ConnectCardToButton(InterfaceButton, _imageCollection.GetImageCollection());
            PutImageRecto(InterfaceButton);
            pbPlayer1.Value = 0;
            pbPlayer2.Value = 0;
            SetUpNameAndColorPlayer();
            ShowAndHideCard(InterfaceButton);
        }
        private void BtnBack_Click(object sender, EventArgs e)
        {
            _mainMenu.ShowMenuHost(_menuNewGame.PnlMenuNewGame);
        }
    }
}
