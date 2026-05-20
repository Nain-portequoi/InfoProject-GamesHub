using MemoryCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGameClass
{
    public abstract class game
    {
        public int CurrentPlayer = 1;
        public int NextPlayer(int NbPlayer) // Permet de passer au joueur suivant, en fonction du nombre de joueurs 
        {
            CurrentPlayer = CurrentPlayer + 1;
            if (CurrentPlayer > NbPlayer)
            {
                CurrentPlayer = 1;
            }
            return CurrentPlayer;
        }
    }
    public class MemoryGame : game
    {
        private ImageCollection _imageCollection = new ImageCollection();
        private List<Card> _currentSelectedCard;
        private int _pairsFound = 0;


        public MemoryGame(ImageCollection imageCollection)
        {
            _imageCollection = imageCollection;
            _currentSelectedCard = new List<Card>();
        }
        public void SetUpGame() // Prépare le jeu en créant et en mélangeant les cartes
        {
            _imageCollection.CreatePileOfCard(); // Crée les cartes à partir des images
            _imageCollection.MixCard();
        }

        public enum FlipResult // Permet de savoir si les cartes sélectionnées sont identiques ou pas, ou si c'est la première carte sélectionnée, ou si le jeu est terminé
        {
            Match,
            NoMatch,
            FirstCard,
            GameFinish

        }
        public FlipResult SelectCard(Card cardSelected)
        {
            if (cardSelected.GetIsReturn() && _currentSelectedCard.Count != 2) // Si jamais on clique sur une carte déjà retourné ! 
            {
                return FlipResult.FirstCard;
            }
            if (_currentSelectedCard.Count == 2) // Comme ça on laisse les cartes visibles jusqu'au troisième cliques ! 
            {
                _currentSelectedCard[0].ReturnCard();
                _currentSelectedCard[1].ReturnCard();
                _currentSelectedCard.Clear();
            }
            cardSelected.ReturnCard(); // On retourne la carte sélectionnée
            if (_currentSelectedCard.Count == 1)
            {
                _currentSelectedCard.Add(cardSelected);
                if (_currentSelectedCard[1].GetImageIndex() == _currentSelectedCard[0].GetImageIndex())
                {

                    _currentSelectedCard[0].SetIsMatched(true);
                    _currentSelectedCard[1].SetIsMatched(true);
                    _currentSelectedCard.Clear();
                    _pairsFound = _pairsFound + 1;
                    if (_pairsFound == 9)
                    {
                        return FlipResult.GameFinish;
                    }
                    return FlipResult.Match;
                }
                else
                {
                    NextPlayer(2);
                    return FlipResult.NoMatch;
                }
            }
            _currentSelectedCard.Add(cardSelected);
            return FlipResult.FirstCard;
        }

    }
}
