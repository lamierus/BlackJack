﻿using System;
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
        
        //blank out the dealer's hand and all boolean properties
        new public void ClearHand() {
            InHand.Clear();
            BlackJack = false;
            Bust = false;
            Stand = false;
            Turn = false;
            Score = 0;
        }

        //display the Dealer's hand.
        public string Flop() {
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
    }
}
