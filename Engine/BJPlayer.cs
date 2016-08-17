using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine {
    public class BJPlayer : Hand {
        public bool Stand { get; set; }
        public bool Bust { get; set; }
        public bool BlackJack { get; set; }
        //initialize the Blackjack Player object
        public BJPlayer(String name = "Player") {
            if (name == "Player") {
                Name = name + ' ' + Count.ToString();
            } else if (name == "\n" || name == " " || name == "") {
                Name = "Player" + ' ' + Count.ToString();
            } else {
                Name = name;
            }
            Stand = false;
            Bust = false;
            BlackJack = false;
            Count++;
        }
        ~BJPlayer() {
            Count--;
            InHand.Clear();
        }
        //draw a card from the pile and place it in the player's hand
        new public void Draw(Card card) {
            InHand.Add(card);
            ScoreHand();
        }
        //score the hand, based upon Blackjack rules
        new protected void ScoreHand() {
            Score = 0;
            int aces = 0;
            foreach (Card card in InHand) {
                //have to check for aces, for scoring properly
                if (card.Number == 1) {
                    Score += 11;
                    aces++;
                } else {
                    Score += card.Number;
                }
            }
            if (aces > 0 && Score > 21) {
                for (int x = 0; x < aces; x++) {
                    Score -= 10;
                }
            }
        }

        //display the Players's hand.
        public string Flop() {
            string output = "";
            foreach (Card card in InHand) {
                output += card.ToString() + Environment.NewLine;
            }
            output += Environment.NewLine + "Score: " + Score.ToString();
            return output;
        }

        //empty out the hand and reset the boolean properties.
        new public void ClearHand() {
            InHand.Clear();
            BlackJack = false;
            Bust = false;
            Stand = false;
            Score = 0;
        }
    }
}
