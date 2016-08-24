using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

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

        //blank out the dealer's hand and all boolean properties
        new public void ClearHand() {
            InHand.Clear();
            BlackJack = false;
            Bust = false;
            Stand = false;
            Turn = false;
            Score = 0;
        }

        //score the hand, based upon Blackjack rules
        protected override void ScoreHand() {
            Score = 0;
            if (!Bust && !Stand && !Turn) {
                return;
            }
            int aces = 0;
            foreach (Card card in InHand) {
                //have to check for aces, for scoring properly
                if (card.Number == 1) {
                    Score += 11;
                    aces++;
                } else if (card.Number > 10) {
                    Score += 10;
                } else {
                    Score += card.Number;
                }
            }

            if (aces > 0 && Score > 21) {
                for (int x = 0; x < aces; x++) {
                    Score -= 10;
                }
            }

            if (Score > 21) {
                Bust = true;
            } else if (Score == 21) {
                BlackJack = true;
                Stand = true;
            }
        }

        //display the Dealer's hand.
        public override string Flop() {
            string output = "";
            if (!Bust && !Stand && !Turn) {
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

        public override List<Image> GetCardPictures() {
            List<Image> pictures = new List<Image>();
            foreach (Card card in InHand) {
                if ((InHand.IndexOf(card) == 0) && (!Bust && !Stand && !Turn)) {
                    pictures.Add(Properties.Resources.Back_Side);
                } else {
                    pictures.Add(card.Picture);
                }
            }
            return pictures;
        }
    }
}
