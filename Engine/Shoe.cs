using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    public class Shoe {
        private Queue<Card> DrawPile = new Queue<Card>();
        private List<Card> InPlay = new List<Card>();
        private Stack<Card> DiscardPile = new Stack<Card>();
        public int CardsInShoe { get; set; }
        public int CardsInPlay { get; set; }
        public int CardsInDiscard { get; set; }
        private int NumDecks;
        private int NumSuits;
        private int CardsPerSuit;
        //Defaults of a new deck are the standard shoe size for Black Jack
        public Shoe(int numDecks = 5, int numSuits = 4, int numCardsPerSuit = 13) {
            NumDecks = numDecks;
            NumSuits = numSuits;
            CardsPerSuit = numCardsPerSuit;
            CardsInShoe = 0;
            CardsInPlay = 0;
            CardsInDiscard = 0;
            BuildDecks();
        }
        //Function to build and shuffle the decks into the Shoe Queue
        private void BuildDecks() {
            Deck[] cardDecks = new Deck[NumDecks];
            for (int x = 0; x < cardDecks.Length; x++) {
                cardDecks[x] = new Deck(NumSuits, CardsPerSuit);
            }
            Shuffle(cardDecks);
        }

        private void Shuffle (Deck[] cardDecks) {
            //Make a random object with a date/time seed to create the random numbers
            //when shuffling the cards from 5 decks into a single Shoe object
            Random r = new Random((int)DateTime.Now.Ticks);
            int shuffleCard = r.Next(CardsPerSuit * NumSuits);
            int shuffleDeck = r.Next(NumDecks);
            while (DrawPile.Count < (CardsPerSuit * NumSuits) * NumDecks) {
                //check to see if the card has been drawn from the deck and add it to the shoe
                if (cardDecks[shuffleDeck].CheckDraw(shuffleCard)) {
                    DrawPile.Enqueue(cardDecks[shuffleDeck].Draw(shuffleCard));
                    this.CardsInShoe++;
                }
                shuffleCard = r.Next(CardsPerSuit * NumSuits);
                shuffleDeck = r.Next(NumDecks);
            }
        }
        //clear out all sequences and reshuffle the Shoe.
        public void Reshuffle() {
            CardsInShoe = 0;
            DrawPile.Clear();
            CardsInPlay = 0;
            InPlay.Clear();
            CardsInDiscard = 0;
            DiscardPile.Clear();
            BuildDecks();
        }
        public void Reshuffle(int numDecks) {
            NumDecks = numDecks;
            CardsInShoe = 0;
            DrawPile.Clear();
            CardsInPlay = 0;
            InPlay.Clear();
            CardsInDiscard = 0;
            DiscardPile.Clear();
            BuildDecks();
        }
        //return the # of Cards each deck in the current Shoe contains
        public int GetCardsPerDeck() {
            return (CardsPerSuit * NumSuits);
        }
        //return the # of Decks used in the current Shoe
        public int GetDecks() {
            return NumDecks;
        }
        //return the # of Suits used in the current Shoe
        public int GetSuits() {
            return NumSuits;
        }
        //draw the top card off out of the Shoe Queue and place it in the InPlay sequence
        public Card Deal() {
            Card drawn = new Card();
            if (this.IsEmpty()) {
                Reshuffle();
                drawn = DrawPile.Dequeue();
                this.CardsInShoe--;
                InPlay.Add(drawn);
                this.CardsInPlay++;
            } else {
                drawn = DrawPile.Dequeue();
                this.CardsInShoe--;
                InPlay.Add(drawn);
                this.CardsInPlay++;
            }
            return drawn;
        }
        //discard the chosen card from the cards that are currently in play
        public void Discard(Card disc) {
            if (InPlay.Remove(disc)) {
                DiscardPile.Push(disc);
                this.CardsInPlay--;
                this.CardsInDiscard++;
            }
        }
        //Test if the Shoe is empty
        public bool IsEmpty() {
            return DrawPile.Count == 0;
        }
        //This will output a card's suit # and number on a line for every card stored in every sequence of the current shoe object
        public void ConsoleFlop() {
            Console.WriteLine("Draw Pile");
            foreach (Card card in DrawPile) {
                if (card != null) {
                    Console.WriteLine(card.ToString());
                } else {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Cards in Play");
            foreach (Card card in InPlay) {
                if (card != null) {
                    Console.WriteLine(card.ToString());
                } else {
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Discard Pile");
            foreach (Card card in DiscardPile) {
                if (card != null) {
                    Console.WriteLine(card.ToString());
                } else {
                    Console.WriteLine();
                }
            }
        }
    }
}
