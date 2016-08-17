using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Engine;

namespace BlackjackWFA {
    public partial class Blackjack : Form {
        static Shoe drawPile;
        static BJPlayer Player1 = new BJPlayer();
        static BJDealer Dealer = new BJDealer();
        //static bool PlayGame;
        List<int> DeckSize = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public Blackjack() {
            InitializeComponent();
            cbDecks.DataSource = DeckSize;
            cbDecks.SelectedIndex = 4;
            StartGame();
        }

        /*static void Main(string[] args) {
            Console.Title = "Blackjack in a Console!";
            Console.CursorVisible = false;
            Console.SetWindowSize(55, 30);
            Console.SetBufferSize(55, 30);
            Console.WriteLine("Enter a player name:");
            string input = Console.ReadLine();
            Player1 = new BJPlayer(input);
            Dealer = new BJDealer();
            Console.Clear();
            Console.WriteLine("Welcome " + Player1.Name.ToString() + "!");
            Console.WriteLine();
            Console.WriteLine("Are you ready to play some Blackjack? (Y/N)");
            PlayGame = false;
            while (!PlayGame) {
                input = Console.ReadKey().KeyChar.ToString();
                if (input.ToLower() == "n") {
                    Quit();
                } else if (input.ToLower() == "y") {
                    PlayGame = true;
                } else {
                    Console.WriteLine();
                    Console.WriteLine("Please press either (Y)es or (N)o to continue.");
                }
            }
            Console.WriteLine('\n');
            Console.WriteLine("How many Decks would you like to play with?");
            Console.WriteLine("(The standard size for blackjack is 5 decks.)");
            Console.WriteLine("Minimum: 1    Maximum: 10");
            int parsedNum;
            int numDecks;
            input = Console.ReadLine();
            //parse the input to make sure it's a number
            if (int.TryParse(input, out parsedNum)) {
                if (parsedNum < 1) {
                    parsedNum = 1;
                } else if (parsedNum > 10) {
                    parsedNum = 10;
                }
                numDecks = parsedNum;
            } else {
                numDecks = 5;
            }
            drawPile = new Shoe(numDecks);
            do {
                if (drawPile.IsEmpty()) {
                    drawPile.Reshuffle();
                }
                StartGame();
                while (!Player1.Stand && !Player1.Bust && !Dealer.Bust) {
                    PlayerTurn();
                    DisplayHands();
                }
                if (Player1.Stand || Player1.Bust) {
                    Console.WriteLine();
                    Console.WriteLine("Dealers turn!  Press any key to continue");
                }
                Console.ReadKey(true);
                Dealer.Turn = true;
                do {
                    if (!Player1.Bust) {
                        DealerTurn();
                    } else {
                        Dealer.Stand = true;
                    }
                    DisplayHands();
                    if (!Dealer.Stand && !Dealer.Bust) {
                        Console.WriteLine();
                        Console.WriteLine("Dealer hits.  Press any key to continue.");
                        Console.ReadKey(true);
                    } else if (Dealer.Stand) {
                        Console.WriteLine();
                        Console.WriteLine("Dealer Stands.");
                    }
                } while (!Dealer.Stand && !Dealer.Bust && !Player1.Bust);
                if (Dealer.Stand || Dealer.Bust) {
                    Console.WriteLine();
                    if (Dealer.Bust) {
                        Console.WriteLine("Dealers busted.  Press any key to check who won!");
                    } else {
                        Console.WriteLine("Dealers turn is over.  Press any key to check who won!");
                    }
                }
                Console.ReadKey(true);
                if (CheckWinner()) {
                    Console.Clear();
                    Console.WriteLine("Congratulations, " + Player1.Name + "!\nYou won this hand of blackjack!");
                } else {
                    Console.Clear();
                    Console.WriteLine("Unfortunately, The Dealer won this hand of blackjack.\nSorry!");
                }
                Console.WriteLine();
                Console.WriteLine("Do you wish to (C)ontinue? or (Q)uit?");
                bool quit = false;
                do {
                    input = Console.ReadKey().KeyChar.ToString();
                    if (input.ToLower() == "q") {
                        quit = true;
                        PlayGame = false;
                    } else if (input.ToLower() == "c") {
                        Player1.ClearHand();
                        Dealer.ClearHand();
                        break;
                    } else {
                        Console.WriteLine();
                        Console.WriteLine("Please press either (C)ontinue or (Q)uit to continue from here.");
                    }
                } while (!quit);
            } while (PlayGame);
            Quit();
        }*/
        //function to start up the game with the initial draws for each player.
        private void StartGame() {
            for (int x = 0; x < 2; x++) {
                Player1.Draw(drawPile.Deal());
                Dealer.Draw(drawPile.Deal());
            }
            DisplayHands();
        }

        //draw the hands on the console
        private void DisplayHands() {
            //rtbDealer.Clear();
            rtbDealer.Text = Dealer.Flop() + Environment.NewLine + rtbDealer.Text;
            //rtbPlayer.Clear();
            rtbPlayer.Text = Player1.Flop() + Environment.NewLine + rtbPlayer.Text;
            /*Console.WriteLine(Player1.Name + "'s Hand");
            Player1.ConsoleFlop();
            if (Player1.Bust) {
                Console.WriteLine();
                Console.WriteLine(Player1.Name + " busted!");
            }*/
        }

        //logic to perform the player's turn
        private void PlayerTurn() {
            if (Player1.Score > 21) {
                Player1.Bust = true;
                return;
            }
            if (Player1.Score == 21) {
                Player1.Stand = true;
                return;
            }
            /*bool done = false;
            do {
                Console.WriteLine();
                Console.WriteLine("(H)it or (S)tand?");
                string input = Console.ReadKey().KeyChar.ToString();
                if (input.ToLower() == "s") {
                    Player1.Stand = true;
                    done = true;
                } else if (input.ToLower() == "h") {
                    Player1.Draw(drawPile.Deal());
                    done = true;
                }
            } while (!done);*/
        }

        //logic to perform the dealer's turn
        private void DealerTurn() {
            if (Dealer.Score > 21) {
                Dealer.Bust = true;
                return;
            }
            if (Dealer.Score >= 18) {
                Dealer.Stand = true;
                return;
            }
            Dealer.Draw(drawPile.Deal());
        }

        //find out who won the hand
        private bool CheckWinner() {
            if (!Player1.Bust) {
                if (Dealer.Bust) {
                    return true;
                } else if (Dealer.Score < Player1.Score) {
                    return true;
                } else if (Player1.Score == 21 && Dealer.Score == 21) {
                    return false;
                } else if (Player1.Score == 21) {
                    return true;
                }
            }
            return false;
        }

        private void cbDecks_SelectedIndexChanged(object sender, EventArgs e) {
            drawPile = new Shoe((int)cbDecks.SelectedItem);
            //StartGame();
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        private void btnHit_Click(object sender, EventArgs e) {

        }

        private void btnStand_Click(object sender, EventArgs e) {
            Player1.Stand = true;
        }
    }
}
