using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryCard
{
    public class Card
    {
        private string _nameImage;
        private int _imageIndex;
        private bool _isReturn;
        private bool _isMacthed;
        public Card(int imageIndex, string nameImage)
        {
            _imageIndex = imageIndex;
            _nameImage = nameImage;
            _isReturn = false;
          
        }
        public bool GetIsReturn()
        {
            return _isReturn;
        }
        public bool GetIsMatched()
        {
            return _isMacthed;
        }
        public void SetIsMatched(bool IsMatched)
        {
            _isMacthed = IsMatched;
        }
        public int GetImageIndex()
        {
            return _imageIndex;
        }
        public string GetNameImage()
        {
            return _nameImage;
        }
   
        public void ReturnCard()
        {
            if (_isReturn == false)
            {
                _isReturn = true;
            }
            else
            {
                _isReturn = false;
            }
        }
        
    }
    public class ImageCollection
    {
        private List<Card> _pileOfCard;


        public ImageCollection()
        {
            _pileOfCard = new List<Card>();
        }
        public List<Card> GetImageCollection()
        {
            return _pileOfCard;
        }
        public void CreatePileOfCard()
        {
            Card Card1 = new Card(1, "Bombardiro Crocodilo");
            _pileOfCard.Add(Card1);
            Card Card2 = new Card(1, "Bombardiro Crocodilo");
            _pileOfCard.Add(Card2);
            Card Card3 = new Card(2, "Ballerina Cappuccina");
            _pileOfCard.Add(Card3);
            Card Card4 = new Card(2, "Ballerina Cappuccina");
            _pileOfCard.Add(Card4);
            Card Card5 = new Card(3, "Brr brr Patapim");
            _pileOfCard.Add(Card5);
            Card Card6 = new Card(3, "Brr brr Patapim");
            _pileOfCard.Add(Card6);
            Card Card7 = new Card(4, "Cappucino assasino");
            _pileOfCard.Add(Card7);
            Card Card8 = new Card(4, "Cappucino assasino");
            _pileOfCard.Add(Card8);
            Card Card9 = new Card(5, "Chimpanzini Bananini");
            _pileOfCard.Add(Card9);
            Card Card10 = new Card(5, "Chimpanzini Bananini");
            _pileOfCard.Add(Card10);
            Card Card11 = new Card(6, "Il Cacto Hipopotamo");
            _pileOfCard.Add(Card11);
            Card Card12 = new Card(6, "Il Cacto Hipopotamo");
            _pileOfCard.Add(Card12);
            Card Card13 = new Card(7, "Lirilì Larilà");
            _pileOfCard.Add(Card13);
            Card Card14 = new Card(7, "Lirilì Larilà");
            _pileOfCard.Add(Card14);
            Card Card15 = new Card(8, "Tralalero Tralala");
            _pileOfCard.Add(Card15);
            Card Card16 = new Card(8, "Tralalero Tralala");
            _pileOfCard.Add(Card16);
            Card Card17 = new Card(9, "Tung tung tung sahur");
            _pileOfCard.Add(Card17);
            Card Card18 = new Card(9, "Tung tung tung sahur");
            _pileOfCard.Add(Card18);
        }
        public void MixCard()
        {
            Random Rn = new Random();
            int numberOfCard = _pileOfCard.Count;
            while (numberOfCard > 1)
            {
                int i = Rn.Next(numberOfCard); // Pour avoir un nbr aléatoire plus petit que le nombre de carte
                numberOfCard = numberOfCard - 1;
                Card Tampon = _pileOfCard[i];
                _pileOfCard[i] = _pileOfCard[numberOfCard];
                _pileOfCard[numberOfCard] = Tampon;
            }
        }

    }
    public abstract class game
    {
        public int CurrentPlayer = 1;
        public int NextPlayer(int NbPlayer)
        {
            CurrentPlayer = CurrentPlayer + 1;
            if(CurrentPlayer > NbPlayer)
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
        

        public MemoryGame(ImageCollection imageCollection)
        {
            _imageCollection = imageCollection;
            _currentSelectedCard = new List<Card>();
        }
        public void SetUpGame()
        {
            _imageCollection.CreatePileOfCard();
            _imageCollection.MixCard();
        }
        public enum FlipResult
        {
            Match,
            NoMatch,
            FirstCard
        }
        public FlipResult SelectCard(Card cardSelected)
        {
            if (cardSelected.GetIsReturn() && _currentSelectedCard.Count !=2 ) // Si jamais on clique sur une carte déjà retourné ! 
            {
                return FlipResult.FirstCard;
            }
            if (_currentSelectedCard.Count == 2) // Comme ça on laisse les cartes visibles jusqu'au troisième cliques ! 
            {
                _currentSelectedCard[0].ReturnCard();
                _currentSelectedCard[1].ReturnCard();
                _currentSelectedCard.Clear();
            }
            cardSelected.ReturnCard();
            if(_currentSelectedCard.Count == 1)
            {
                _currentSelectedCard.Add(cardSelected);
                if (_currentSelectedCard[1].GetImageIndex() == _currentSelectedCard[0].GetImageIndex())
                {

                    _currentSelectedCard[0].SetIsMatched(true);
                    _currentSelectedCard[1].SetIsMatched(true);
                    _currentSelectedCard.Clear();
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
