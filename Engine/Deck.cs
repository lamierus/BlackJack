using System;
using System.Resources;
using System.Drawing;

namespace Engine {
    public class Deck {
		private Card[] cardDeck { get; set; }
		private int Suits { get; set; }
		private int CardsPerSuit { get; set; }
        public int DeckSize { get; set; }
        private ResourceManager Resources = Properties.Resources.ResourceManager;
        //default deck call with 4 suits and 13 cards per suit
        public Deck(int numSuits = 4, int numCardsPerSuit = 13) {
            Suits = numSuits;
            CardsPerSuit = numCardsPerSuit;
            this.DeckSize = Suits * CardsPerSuit;
            BuildDeck();
            Shuffle();
        }

        ~Deck() {
            cardDeck = null;
        }

        //build the deck in order
        private void BuildDeck() {
            cardDeck = new Card[CardsPerSuit * Suits];
            for (int x = 1; x <= Suits; x++) {
                for (int y = 1; y <= CardsPerSuit; y++) {
                    cardDeck[(y - 1) + (CardsPerSuit * (x - 1))] = new Card();
                    cardDeck[(y - 1) + (CardsPerSuit * (x - 1))].Suit = x;
                    cardDeck[(y - 1) + (CardsPerSuit * (x - 1))].Number = y;
                    cardDeck[(y - 1) + (CardsPerSuit * (x - 1))].Picture = 
                        (Image)Resources.GetObject(cardDeck[(y - 1) + (CardsPerSuit * (x - 1))].GetImageName());
                }
            }
        }
        //return the # of suits of the deck
        public int GetSuits() {
            return Suits;
        }
        //return the # of cards per suit of the deck
        public int GetCardsPerSuit() {
            return CardsPerSuit;
        }
        //checks the draw to make sure the card exists in the deck, still
        public bool CheckDraw(int drawn) {
            if (cardDeck[drawn] == null) {
                return false;
            }
            return true;
        }
        //draw a card from the deck
        public Card Draw(int drawn) {
            Card draw = cardDeck[drawn];
            RemoveCard(drawn);
            return draw;
        }
        //private function to remove a card from the deck, when drawn
        private void RemoveCard(int rm) {
            cardDeck[rm] = null;
        }
        //shuffle the deck
        public void Shuffle() {
            //Make a random object with a date/time seed to create the random numbers
            //when shuffling the cards from the current Deck object
            Random r = new Random((int)DateTime.Now.Ticks);
            int shuffle = r.Next(Math.Abs((int)DateTime.Now.Ticks / (CardsPerSuit * Suits)) / CardsPerSuit);
            for (int x = 0; x < shuffle; x++) {
                int shuffleCard1 = r.Next(CardsPerSuit * Suits);
                int shuffleCard2 = r.Next(CardsPerSuit * Suits);
                Card temp = cardDeck[shuffleCard1];
                cardDeck[shuffleCard1] = cardDeck[shuffleCard2];
                cardDeck[shuffleCard2] = temp;
            }
        }
        //reshuffle the deck
        public void Reshuffle() {
            BuildDeck();
            Shuffle();
        }
        //check if the deck is empty
        public bool IsEmpty() {
            bool isEmpty = true;
            foreach (Card card in cardDeck) {
                if (card != null) {
                    isEmpty = false;
                    break;
                }
            }
            return isEmpty;
        }
        //output all of the cards from the deck on a seperate line
        public void ConsoleFlop() {
            foreach (Card card in cardDeck) {
                if (card != null) {
                    Console.WriteLine(card.ToString());
                } else {
                    Console.WriteLine();
                }
            }
        }
    }
}
