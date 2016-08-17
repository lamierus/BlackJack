using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    public class Hand {
        public string Name { get; set; }
        public int Score { get; set; }
        public int CardsInHand { get; set; }
        public static int Count = 0;
        protected List<Card> InHand = new List<Card>();
        //initialize a basic player
        public Hand(String name = "Player") {
            if (name == "Player") {
                Name = name + ' ' + Count.ToString();
            } else if (name == "\n" || name == " " || name == "") {
                Name = "Player" + ' ' + Count.ToString();
            } else {
                Name = name;
            }
            CardsInHand = 0;
            Count++;
        }
        ~Hand() {
            Count--;
            InHand.Clear();
        }
        //sort the player's hand, if required. first by suit, then by number
        public void Sort() {
            List<Card> NewHand = new List<Card>();
            InHand.Sort(delegate (Card c1, Card c2) { return c1.Suit.CompareTo(c2.Suit); });
            int suits = InHand.Last().Suit;
            for (int x = 0; x <= suits; x++) {
                List<Card> Suit = InHand.FindAll(c => c.Suit == x);
                Suit.Sort(delegate (Card c1, Card c2) { return c1.Number.CompareTo(c2.Number); });
                if (Suit.First().Number == 1) {
                    Card Ace = Suit.First();
                    Suit.Remove(Ace);
                    Suit.Add(Ace);
                }
                foreach (Card card in Suit) {
                    NewHand.Add(card);
                }
            }
            InHand.Clear();
            InHand = NewHand;
        }
        //add a card to the user's hand list
        public void Draw(Card card) {
            InHand.Add(card);
            CardsInHand++;
            ScoreHand();
        }
        //remove a card from the user's hand.
        public bool Discard(Card disc) {
            if (InHand.Remove(disc)) {
                Score -= disc.Number;
                CardsInHand--;
                return true;
            }
            return false;
        }
        //add up the current score of the user's hand
        protected void ScoreHand() {
            foreach (Card card in InHand) {
                if (card.Number == 0) {
                    Score += 14;
                } else {
                    Score += card.Number;
                }
            }
        }
        //remove all cards and reset the score of the Player's hand
        public void ClearHand() {
            InHand.Clear();
            Score = 0;
            CardsInHand = 0;
        }
        //return the current number of Players in the game.
        public int NumOfPlayers() {
            return Count;
        }
        //display all of the cards and the score of said hand
        public void ConsoleFlop() {
            foreach (Card card in InHand) {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine("\nScore: " + Score.ToString());
        }
    }
}
