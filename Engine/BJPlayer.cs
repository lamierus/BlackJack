using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Resources;
using System.Drawing;

namespace Engine {
    public class BJPlayer : Hand {
        public bool Stand { get; set; }
        public bool Bust { get; set; }
        public bool BlackJack { get; set; }
        public List<PictureBox> CardPictures = new List<PictureBox>();
        private ResourceManager Resources = Properties.Resources.ResourceManager;
        //initialize the Blackjack Player object
        public BJPlayer(String name = "Player") {
            Name = name;
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
            PictureBox cardPicture = new PictureBox();
            cardPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            cardPicture.Image = (Image)Resources.GetObject(card.GetImageName());
            cardPicture.Size = new Size(135, 196);
            cardPicture.Name = card.GetImageName();
            cardPicture.Tag = card.GetImageName();
            CardPictures.Add(cardPicture);
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

        //display the Players's hand.
        public virtual string Flop() {
            string output = "";
            foreach (Card card in InHand) {
                output += card.ToString() + Environment.NewLine;
            }
            output += Environment.NewLine + "Score: " + Score.ToString();
            return output;
        }

        public Image GetCardPicture(Card card) {
            PictureBox finder = CardPictures.Find(pb => pb.Image == card.Picture);
            return finder.Image;
        }

        //empty out the hand and reset the boolean properties.
        new public void ClearHand() {
            InHand.Clear();
            CardPictures.Clear();
            BlackJack = false;
            Bust = false;
            Stand = false;
            Score = 0;
        }
    }
}
