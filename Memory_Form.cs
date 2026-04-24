using Memory_Pierre.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Memory_Pierre
{
    public partial class Memory_Form : Form
    {
        private ImageCollection _imageCollection;
        private List<Button> InterfaceButton;
        private Game _game;
        int x = 0;
        public Memory_Form()
        {
            InitializeComponent();
            _imageCollection = new ImageCollection();
            _game = new Game(_imageCollection);
            _game.SetUpGame();
            InterfaceButton = new List<Button> { BtnCard1, BtnCard2, BtnCard3, BtnCard4, BtnCard5, BtnCard6, BtnCard7, BtnCard8, BtnCard9, BtnCard10, BtnCard11, BtnCard12, BtnCard13, BtnCard14, BtnCard15, BtnCard16, BtnCard17, BtnCard18 };
            ConnectCardToButton(InterfaceButton, _imageCollection.GetImageCollection());
            PutImageRecto(InterfaceButton);
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
            object ressourceImage = Properties.Resources.ResourceManager.GetObject(carte.GetNameImage());

            
            if (ressourceImage != null)
            {
                btn.BackgroundImage = (Image)ressourceImage;
                btn.BackgroundImageLayout = ImageLayout.Stretch; // Pour que l'image remplisse le bouton
            }
        }


        private void HideImage(Button btn)
        {
            object ImageRecto = Properties.Resources.ResourceManager.GetObject("Recto");
            btn.BackgroundImage = (Image)ImageRecto;
            btn.BackgroundImageLayout = ImageLayout.Stretch;
        }


        private void AnyButtonClick(object sender, EventArgs e)
        {
            Button buttonClicked = (Button)sender;
            Card CardClicked = (Card)buttonClicked.Tag;
            _game.SelectCard(CardClicked);
            /*
            if(_game.SelectCard(CardClicked) == Game.FlipResult.Match)
            {
                // Ajouter des points 
                // Faire en sorte que si un joueur a gagné, la partie s'arrête ! 
            }
            if (_game.SelectCard(CardClicked) == Game.FlipResult.NoMatch)
            {
                // Joueur suivant
            }
            */
            ShowAndHideCard(InterfaceButton);
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
    }
}
