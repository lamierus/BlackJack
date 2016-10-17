using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Resources;
using Engine;

namespace BlackjackWFA {
    public partial class Blackjack : Form {
        static Shoe drawPile;
        static BJPlayer Player1 = new BJPlayer();
        static List<PictureBox> Player1Cards = new List<PictureBox>();
        static BJDealer Dealer = new BJDealer();
        static List<PictureBox> DealerCards = new List<PictureBox>();
        static bool PlayingGame = false;
        private int Decks = 5;
        //private bool AllowClose = false;
        //allow all resources for the project to be available for use here, like icon and images
        private ResourceManager Resources = Engine.Properties.Resources.ResourceManager;

        public Blackjack() {
            //drawPile = new Shoe(Decks);
            Thread shoe = new Thread(BuildShoe);
            shoe.Start();
            InitializeComponent();
            InitializeCardBoxes(ref gbDealer, DealerCards);
            InitializeCardBoxes(ref gbPlayer, Player1Cards);
        }

        private void BuildShoe() {
            drawPile = new Shoe(Decks);
        }

        private void InitializeCardBoxes(ref GroupBox groupBox, List<PictureBox> picBoxes) {
            Point point = new Point(groupBox.Padding.Left, groupBox.Padding.Top);

            for (int i = 0; i < 21; i++) {
                var cardBox = new PictureBox();
                cardBox.SizeMode = PictureBoxSizeMode.StretchImage;
                cardBox.Size = new Size(135, 196);
                cardBox.Location = point;
                cardBox.Parent = groupBox;
                cardBox.Name = groupBox.Name + i.ToString();
                cardBox.Image = (Image)Resources.GetObject("Back_Side");
                groupBox.Controls.Add(cardBox);
                cardBox.BringToFront();
                picBoxes.Add(cardBox);
                if(i < 7) {
                    point.X += 30;
                }
            }
        }

        /// <summary>
        ///     when the window is activated, it goes to create the prompt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Blackjack_Activated(object sender, EventArgs e) {
            if (!PlayingGame) {
                RequestDeal();
            }
        }

        /// <summary>
        ///     when the window is Loaded, it goes to create the prompt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Blackjack_Load(object sender, EventArgs e) {
            using (var form = new NewGame(Player1, Decks)) {
                var result = form.ShowDialog();
                if (result == DialogResult.Cancel) {
                    Close();
                } else {
                    Player1 = form.ReturnPlayer;
                    if (drawPile == null || form.ReturnNumDecks != Decks) {
                        Decks = form.ReturnNumDecks;
                        BuildShoe();
                    }
                }
            }
            lblPlayerHand.Text = Player1.Name + "\'s Hand";
            PlayingGame = true;
            StartGame();
        }

        /// <summary>
        ///     creates and displays a dialog to ask the player if they want to play the game.
        /// </summary>
        private void RequestDeal() {
            using (var form = new NewGame(Player1, Decks)) {
                var result = form.ShowDialog();
                if (result == DialogResult.Cancel) {
                    Close();
                } else {
                    Player1 = form.ReturnPlayer;
                    if (drawPile == null || form.ReturnNumDecks != Decks) {
                        Decks = form.ReturnNumDecks;
                        BuildShoe();
                    }
                }
            }
            lblPlayerHand.Text = Player1.Name + "\'s Hand";
            PlayingGame = true;
            StartGame();
        }
        
        /// <summary>
        ///     function to start up the game with the initial draws for each player.
        /// </summary>
        private void StartGame() {
            BlankHand(Player1, Player1Cards);
            BlankHand(Dealer, DealerCards);

            for (int x = 0; x < 2; x++) {
                TakeTurn(Player1, rtbPlayer, Player1Cards);
                TakeTurn(Dealer, rtbDealer, DealerCards);
            }

            DisplayHand(Player1, rtbPlayer, Player1Cards);
            DisplayHand(Dealer, rtbDealer,DealerCards);
        }

        /// <summary>
        ///     clear the hand and blank out the picture boxes in the groupbox for the chosen hand
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="gBox"></param>
        private void BlankHand(BJPlayer hand, List<PictureBox> picBox) {
            hand.ClearHand();
            foreach (PictureBox pb in picBox) {
                pb.Image = null;
            }
        }

        /// <summary>
        ///     draw the hand provided in the provided box
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="textBox"></param>
        private void DisplayHand(BJPlayer hand, RichTextBox textBox, List<PictureBox> picBox) {
            textBox.Clear();
            textBox.Text = hand.Score.ToString();
            var cardPics = hand.GetCardPictures();
            
            for (int i = 0; i < hand.CardsInHand; i++) {
                picBox.ElementAt(i).Image = cardPics.ElementAt(i);
                picBox.ElementAt(i).BringToFront();
            }
        }

        /// <summary>
        ///     receives the specified player and associated text box and 
        ///     provides logic to perform the turn for the player, depending on
        ///     the specific player's bust and stand properties.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="textBox"></param>
        private void TakeTurn(BJPlayer hand, RichTextBox textBox, List<PictureBox> picBox) {
            if (hand.Bust) {
                DisplayHand(hand, textBox, picBox);
                return;
            }
            if (hand.Stand) {
                DisplayHand(hand, textBox, picBox);
                return;
            }
            Card drawn = new Card();

            if (!drawPile.Deal(out drawn)) {
                //ShowReshuffleDialog();
                drawPile.Reshuffle(Decks);
                drawPile.Deal(out drawn);
            }
            hand.Draw(drawn);
        }
        
        /*private void ShowReshuffleDialog() {
            Form frmReshuffle = new Form();
            RichTextBox rtbReshuffle = new RichTextBox();

            //setting up the rich text box
            rtbReshuffle.Name = "rtbReshuffle";
            rtbReshuffle.Tag = "rtbReshuffle";
            rtbReshuffle.SelectionAlignment = HorizontalAlignment.Center;
            rtbReshuffle.ReadOnly = true;
            rtbReshuffle.ScrollBars = RichTextBoxScrollBars.None;
            rtbReshuffle.TabStop = false;
            rtbReshuffle.Text = Environment.NewLine + "RESHUFFLING SHOE!" + Environment.NewLine;
            rtbReshuffle.Dock = DockStyle.Fill;
            rtbReshuffle.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            frmReshuffle.Controls.Add(rtbReshuffle);

            //setting up the rest of the winner display form
            frmReshuffle.Parent = ParentForm;
            frmReshuffle.ShowInTaskbar = false;
            frmReshuffle.Height = 100;
            frmReshuffle.Width = 400;
            frmReshuffle.MinimizeBox = false;
            frmReshuffle.MaximizeBox = false;
            frmReshuffle.StartPosition = FormStartPosition.CenterParent;
            frmReshuffle.Focus();
            //frmReshuffle.ControlBox = false;
            frmReshuffle.ShowDialog();

            drawPile.Reshuffle(Decks);

            Thread.Sleep(1000);
            
            frmReshuffle.Close();
        }*/

        /// <summary>
        ///     logic to decide how the dealer takes it's turn
        /// </summary>
        private void DealerTurn() {
            if (!Player1.Bust && !Player1.BlackJack && ((Player1.Score > Dealer.Score) || Dealer.Score < 18)) {
                do {
                    TakeTurn(Dealer, rtbDealer, DealerCards);
                } while (!Dealer.Bust && !Dealer.Stand);
            } else {
                Dealer.Stand = true;
            }
            DisplayHand(Dealer, rtbDealer, DealerCards);
            CheckWinner();
        }

        /// <summary>
        ///     find out who won the hand
        /// </summary>
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

        /// <summary>
        ///     Build and display the dialog box to show who is the winner
        /// </summary>
        /// <param name="player"></param>
        /// <param name="textBox"></param>
        private void ShowWinnerDialog(BJPlayer player, RichTextBox textBox) {
            textBox.Text += Environment.NewLine + Environment.NewLine + player.Name + " wins!";

            Form Winner = new Form();
            RichTextBox rtbWinner = new RichTextBox();

            //setting up the rich text box
            rtbWinner.Name = "rtbWinner";
            rtbWinner.Tag = "rtbWinner";
            rtbWinner.SelectionAlignment = HorizontalAlignment.Center;
            rtbWinner.ReadOnly = true;
            rtbWinner.ScrollBars = RichTextBoxScrollBars.None;
            rtbWinner.TabStop = false;
            rtbWinner.Text = Environment.NewLine + player.Name + " wins!" + Environment.NewLine;
            rtbWinner.Dock = DockStyle.Fill;
            rtbWinner.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            rtbWinner.ReadOnly = true;
            rtbWinner.MouseClick += new MouseEventHandler(rtbWinner_Close);
            rtbWinner.KeyPress += new KeyPressEventHandler(rtbWinner_Close);
            Winner.Controls.Add(rtbWinner);

            //setting up the rest of the winner display form
            Winner.ShowInTaskbar = false;
            Winner.Height = 125;
            Winner.Width = 250;
            Winner.MinimizeBox = false;
            Winner.MaximizeBox = false;
            Winner.StartPosition = FormStartPosition.CenterParent;
            Winner.MouseClick += new MouseEventHandler(Winner_Close);
            Winner.KeyPress += new KeyPressEventHandler(Winner_Close);
            Winner.ControlBox = false;
            Winner.Focus();
            Winner.ShowDialog();

            StartGame();
        }
        /// <summary>
        ///     something something something close the winning dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Winner_Close(object sender, EventArgs e) {
            Form sent = sender as Form;
            sent.Close();
        }
        private void rtbWinner_Close(object sender, EventArgs e) {
            RichTextBox sent = sender as RichTextBox;
            sent.Parent.Visible = false;
        }

        /// <summary>
        ///     logic for determining if the user can perform their turn
        ///     when the "Hit" button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHit_Click(object sender, EventArgs e) {
            if (PlayingGame) {
                TakeTurn(Player1, rtbPlayer, Player1Cards);
                DisplayHand(Player1, rtbPlayer, Player1Cards);
                if (Player1.Bust || Player1.BlackJack || Player1.Stand) {
                    Dealer.Turn = true;
                    DealerTurn();
                }
            }
        }

        /// <summary>
        ///     end the user's turn and redraw their hand.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStand_Click(object sender, EventArgs e) {
            if (PlayingGame) {
                Player1.Stand = true;
                DisplayHand(Player1, rtbPlayer, Player1Cards);
                Dealer.Turn = true;
                DealerTurn();
            }
        }

        /// <summary>
        ///     logic to quit the game when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e) {
            AllowClose = true;
            this.Close();
        }
        
        /// <summary>
        ///     check if it's okay to close the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (!AllowClose) {
                e.Cancel = true;
            }
        }
    }
}
