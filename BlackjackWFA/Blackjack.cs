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
            //RequestDeal();
        }

        private void RequestDeal() {
            Button btnDeal = new Button();
            btnDeal.Text = "Deal me in!";
            btnDeal.Location = new System.Drawing.Point(55, 30);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new System.Drawing.Size(200, 30);
            btnDeal.TabIndex = 1;
            btnDeal.UseVisualStyleBackColor = true;
            btnDeal.Click += new EventHandler(this.btnQuit_Click);
            Button btnDealQuit = new Button();
            btnDealQuit.Text = "I don't want to play.";
            btnDealQuit.Location = new System.Drawing.Point(90, 30);
            btnDealQuit.Name = "btnDealQuit";
            btnDealQuit.Size = new System.Drawing.Size(200, 30);
            btnDealQuit.TabIndex = 1;
            btnDealQuit.UseVisualStyleBackColor = true;
            btnDealQuit.Click += new EventHandler(this.btnQuit_Click);
            Form frmDeal = new Form();
            frmDeal.Parent = this.ParentForm;
            frmDeal.Height = 150;
            frmDeal.Width = 250;
            frmDeal.Controls.Add(btnDeal);
            frmDeal.Controls.Add(btnDealQuit);
            frmDeal.StartPosition = FormStartPosition.CenterParent;
            frmDeal.ShowDialog();
        }

        private void btnDeal_Click(object sender, EventArgs e) {
            StartGame();
        }

        private void btnDealQuit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        //function to start up the game with the initial draws for each player.
        private void StartGame() {
            Player1.ClearHand();
            Dealer.ClearHand();
            for (int x = 0; x < 2; x++) {
                Player1.Draw(drawPile.Deal());
                Dealer.Draw(drawPile.Deal());
            }
            DisplayHand(Player1, rtbPlayer);
            DisplayHand(Dealer, rtbDealer);
        }

        //draw the hands on the console
        private void DisplayHand(BJPlayer hand, RichTextBox textBox) {
            textBox.Clear();
            textBox.Text = hand.Flop();
            if (hand.Bust) {
                textBox.Text += Environment.NewLine + hand.Name + " busted!";
            } else if (hand.Stand) {
                textBox.Text += Environment.NewLine + hand.Name + " stands.";
            }
            
        }

        private void TakeTurn(BJPlayer hand, RichTextBox textBox) {
            if (hand.Bust) {
                DisplayHand(hand, textBox);
                return;
            }
            if (hand.Stand) {
                DisplayHand(hand, textBox);
                return;
            }
            hand.Draw(drawPile.Deal());
            DisplayHand(hand, textBox);
        }

        private void DealerTurn() {
            if (!Player1.Bust) {
                do {
                    TakeTurn(Dealer, rtbDealer);
                } while (!Dealer.Bust && !Dealer.Stand);
            } else {
                Dealer.Stand = true;
            }
            DisplayHand(Dealer, rtbDealer);
            CheckWinner();
        }

        //find out who won the hand
        private void CheckWinner() {
            if (!Player1.Bust) {
                if (Dealer.Bust) {
                    //return true;  // player wins
                    ShowWinnerDialog(Player1, rtbPlayer);
                    return;
                } else if (Dealer.Score < Player1.Score) {
                    //return true;  // player wins
                    ShowWinnerDialog(Player1, rtbPlayer);
                    return;
                } else if (Player1.Score == 21 && Dealer.Score == 21) {
                    //return false; // dealer wins
                    ShowWinnerDialog(Dealer, rtbDealer);
                    return;
                } else if (Player1.Score == 21) {
                    //return true;  // player wins
                    ShowWinnerDialog(Player1, rtbPlayer);
                    return;
                }
            }
            //Dealer wins
            ShowWinnerDialog(Dealer, rtbDealer);
        }

        private void ShowWinnerDialog(BJPlayer player, RichTextBox textBox) {
            textBox.Text += Environment.NewLine + Environment.NewLine + player.Name + " wins!";
            RichTextBox rtbWinner = new RichTextBox();
            rtbWinner.Name = "rtbWinner";
            rtbWinner.ReadOnly = true;
            rtbWinner.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            rtbWinner.TabStop = false;
            rtbWinner.Text = Environment.NewLine + player.Name + " wins!" + Environment.NewLine;
            rtbWinner.Dock = DockStyle.Fill;
            rtbWinner.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            rtbWinner.ReadOnly = true;
            Form Winner = new Form();
            Winner.Parent = this.ParentForm;
            Winner.Height = 150;
            Winner.Width = 250;
            Winner.Controls.Add(rtbWinner);
            Winner.StartPosition = FormStartPosition.CenterParent;
            Winner.ShowDialog();
            StartGame();
        }

        private void cbDecks_SelectedIndexChanged(object sender, EventArgs e) {
            drawPile = new Shoe((int)cbDecks.SelectedItem);
            StartGame();
        }

        private void btnQuit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        private void btnHit_Click(object sender, EventArgs e) {
            TakeTurn(Player1, rtbPlayer);
            if (Player1.Bust || Player1.BlackJack || Player1.Stand) {
                Dealer.Turn = true;
                DealerTurn();
            }
        }

        private void btnStand_Click(object sender, EventArgs e) {
            Player1.Stand = true;
            DisplayHand(Player1, rtbPlayer);
            Dealer.Turn = true;
            DealerTurn();
        }
    }
}
