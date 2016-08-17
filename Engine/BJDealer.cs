using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    public class BJDealer : BJPlayer {
        public bool Turn { get; set; }
        //initialize the dealer object
        public BJDealer() {
            Name = "Dealer";
            Stand = false;
            Bust = false;
            BlackJack = false;
            Turn = false;
        }
        //display the Dealer's hand.
        new public void ConsoleFlop() {
            if (!Bust && !Stand && !Turn) {
                Console.WriteLine("__ of _____");
                for (int x = 1; x < InHand.Count; x++) {
                    Console.WriteLine(InHand.ElementAt(x).ToString());
                }
            } else {
                foreach (Card card in InHand) {
                    Console.WriteLine(card.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Score: " + Score.ToString());
            }
        }
        //blank out the dealer's hand and all boolean properties
        new public void ClearHand() {
            InHand.Clear();
            BlackJack = false;
            Bust = false;
            Stand = false;
            Turn = false;
            Score = 0;
        }
    }
}
