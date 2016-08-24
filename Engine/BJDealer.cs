using System;
using System.Linq;

namespace Engine {
    public class BJDealer : BJPlayer {
        ///public bool Turn { get; set; }
        //initialize the dealer object
        public BJDealer() {
            Name = "Dealer";
            Stand = false;
            Bust = false;
            BlackJack = false;
            //Turn = false;
        }
        
        /*//blank out the dealer's hand and all boolean properties
        new public void ClearHand() {
            InHand.Clear();
            CardPictures.Clear();
            BlackJack = false;
            Bust = false;
            Stand = false;
            Turn = false;
            Score = 0;
        }*/

        //display the Dealer's hand.
        public override string Flop() {
            string output = "";
            //if (!Bust && !Stand && !Turn) {
            if (!Bust && !Stand) {
                output += "__ of _____" + Environment.NewLine;
                for (int x = 1; x < InHand.Count; x++) {
                    output += InHand.ElementAt(x).ToString() + Environment.NewLine;
                }
            } else {
                foreach (Card card in InHand) {
                    output += card.ToString() + Environment.NewLine;
                }
                output += Environment.NewLine + "Score: " + Score.ToString();
            }
            return output;
        }

        //display the Dealer's hand in a console
        new public void ConsoleFlop() {
            //if (!Bust && !Stand && !Turn) {
            if (!Bust && !Stand) {
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
    }
}
