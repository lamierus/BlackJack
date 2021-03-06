﻿using System;
using System.Drawing;
using System.Resources;

namespace Engine {
    public class Card : IEquatable<Card> {//IComparable, IEquatable<Card> {
        public int Suit { get; set; }
        public int Number { get; set; }
        public Image Picture { get; set; }
        
        //set up a default card object, with optional overloads to set the suit and number
        public Card(int suit = 0, int number = 0, Image picture = null) {
            Suit = suit;
            Number = number;
            Picture = picture;
        }
        //allow the card to be output as a string value
        public override string ToString() {
            string cardSuit;
            string cardNum;
            if (Suit <= 4 && Suit >= 1) {
                if (Suit == 1) {
                    cardSuit = "Diamonds";
                } else if (Suit == 2) {
                    cardSuit = "Clubs";
                } else if (Suit == 3) {
                    cardSuit = "Hearts";
                } else
                    cardSuit = "Spades";
            } else {
                cardSuit = "Unknown Suit";
            }
            if (Number > 0 && Number <= 13) {
                if (Number == 1) {
                    cardNum = "Ace";
                } else if (Number == 11) {
                    cardNum = "Jack";
                } else if (Number == 12) {
                    cardNum = "Queen";
                } else if (Number == 13) {
                    cardNum = "King";
                } else {
                    cardNum = Number.ToString();
                }
            } else {
                cardNum = "Unknown Number";
            }
            return cardNum + " of " + cardSuit;
        }
        //allow the card to be output as a string value
        public string GetImageName() {
            string name = this.ToString();
            name = name.Replace(' ', '_');
            if (Number == 1 || Number > 10) {
                return name;
            }
			return name;//'_' + name;
        }
        // the logic required to be able to compare cards to each other
        public override bool Equals(Object obj) {
            if (obj == null) {
                return false;
            }
            Card objAsCard = obj as Card;
            if (objAsCard == null) {
                return false;
            } else {
                return Equals(objAsCard);
            }
        }
        public override int GetHashCode() {
            return Suit * Number;
        }
        public bool Equals(Card other) {
            if (other == null) {
                return false;
            }
            return ((this.Suit.Equals(other.Suit) && (this.Number.Equals(other.Number))));
        }
        public static bool operator ==(Card lhs, Card rhs) {
            if (object.ReferenceEquals(lhs, null)) {
                return object.ReferenceEquals(rhs, null);
            }
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Card lhs, Card rhs) {
            if (object.ReferenceEquals(lhs, null)) {
                return object.ReferenceEquals(rhs, null);
            }
            return !(lhs.Equals(rhs));
        }
        public static bool operator <(Card lhs, Card rhs) {
            if (object.ReferenceEquals(lhs, null)) {
                return object.ReferenceEquals(rhs, null);
            }
            bool status = false;
            if (lhs.Suit < rhs.Suit && lhs.Number < rhs.Number) {
                status = true;
            }
            return status;
        }
        public static bool operator >(Card lhs, Card rhs) {
            if (object.ReferenceEquals(lhs, null)) {
                return object.ReferenceEquals(rhs, null);
            }
            bool status = false;
            if (lhs.Suit > rhs.Suit && lhs.Number > rhs.Number) {
                status = true;
            }
            return status;
        }
        public static bool operator <=(Card lhs, Card rhs) {
            if (object.ReferenceEquals(lhs, null)) {
                return object.ReferenceEquals(rhs, null);
            }
            bool status = false;
            if (lhs.Suit <= rhs.Suit && lhs.Number <= rhs.Number) {
                status = true;
            }
            return status;
        }
        public static bool operator >=(Card lhs, Card rhs) {
            if (object.ReferenceEquals(lhs, null)) {
                return object.ReferenceEquals(rhs, null);
            }
            bool status = false;
            if (lhs.Suit >= rhs.Suit && lhs.Number >= rhs.Number) {
                status = true;
            }
            return status;
        }
    }
}
