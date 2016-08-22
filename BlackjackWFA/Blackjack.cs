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
        static bool PlayingGame = false;
        int Decks = 5;
        //allow all resources for the project to be available for use here, liek icon and such
        ComponentResourceManager resources = new ComponentResourceManager(typeof(Blackjack));

        public Blackjack() {
            InitializeComponent();
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
        ///     creates and displays a dialog to ask the player if they want to play the game.
        /// </summary>
        private void RequestDeal() {
            Form frmContinue = BuildDialog();
            frmContinue.ShowDialog();
            //Application.Run(frmContinue);
        }

        /// <summary>
        ///     returns the built form, to accept input from the user.
        /// </summary>
        /// <returns></returns>
        private Form BuildDialog() {
            //declaring all of the parts at the beginning.
            Form frmDeal = new Form();
            Label lblName = new Label();
            TextBox txtName = new TextBox();
            Label lblDecks = new Label();
            ComboBox cbDecks = new ComboBox();
            Button btnDeal = new Button();
            Button btnDealQuit = new Button();

            // Label for the text box
            lblName.Text = "Enter your Name";
            lblName.Name = "lblName";
            lblName.Tag = "lblName";
            lblName.Size = new Size(100, 15);
            lblName.Location = new Point(15, 10);
            lblName.Parent = frmDeal.ParentForm;
            frmDeal.Controls.Add(lblName);

            //text box for the user's name to be entered.
            txtName.Text = Player1.Name;
            txtName.Name = "txtName";
            txtName.Tag = "txtName";
            txtName.Size = new Size(100, 20);
            txtName.Location = new Point(15, 25);
            txtName.TabIndex = 3;
            txtName.Parent = frmDeal.ParentForm;
            txtName.TextChanged += new EventHandler(txtName_TextChanged);
            frmDeal.Controls.Add(txtName);

            //label for the decksize combo box
            lblDecks.AutoSize = true;
            lblDecks.Text = "Number of Decks in Shoe";
            lblDecks.Name = "lblDecks";
            lblDecks.Tag = "lblDecks";
            lblDecks.Size = new Size(129, 13);
            lblDecks.Location = new Point(145, 10);
            lblDecks.Parent = frmDeal.ParentForm;
            frmDeal.Controls.Add(lblDecks);

            //deck size combo box
            cbDecks.DataSource = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };  // creating and assigning the list for the combo box
            cbDecks.FormattingEnabled = false;
            //cbDecks.SelectedIndex = 4;    //can't seem to get this to work, properly, anymore.
            cbDecks.Name = "cbDecks";
            cbDecks.Tag = "cbDecks";
            cbDecks.Size = new Size(128, 21);
            cbDecks.Location = new Point(145, 25);
            cbDecks.TabIndex = 4;
            cbDecks.Parent = frmDeal.ParentForm;
            cbDecks.DropDownClosed += new EventHandler(cbDecks_DropDownClosed);
            frmDeal.Controls.Add(cbDecks);

            //button to start the game.
            btnDeal.Text = "Deal me in!";
            btnDeal.Name = "btnDeal";
            btnDeal.Tag = "btnDeal";
            btnDeal.Size = new Size(200, 30);
            btnDeal.Location = new Point(45, 50);
            btnDeal.TabIndex = 1;
            btnDeal.UseVisualStyleBackColor = true;
            btnDeal.Parent = frmDeal.ParentForm;
            btnDeal.Click += new EventHandler(btnDeal_Click);
            frmDeal.Controls.Add(btnDeal);
            frmDeal.AcceptButton = btnDeal;

            //button to quit the game
            btnDealQuit.Text = "I don't want to play.";
            btnDealQuit.Name = "btnDealQuit";
            btnDealQuit.Tag = "btnDealQuit";
            btnDealQuit.Size = new Size(200, 30);
            btnDealQuit.Location = new Point(45, 85);
            btnDealQuit.TabIndex = 2;
            btnDealQuit.UseVisualStyleBackColor = true;
            btnDealQuit.Parent = frmDeal.ParentForm;
            btnDealQuit.Click += new EventHandler(btnQuit_Click);  // uses the same event handler as the quit button in the main UI.
            frmDeal.Controls.Add(btnDealQuit);
            
            //initialize the rest of the form
            frmDeal.ShowInTaskbar = false;
            frmDeal.Icon = ((Icon)(resources.GetObject("$this.Icon")));
            frmDeal.Width = 305;
            frmDeal.Height = 140;
            frmDeal.StartPosition = FormStartPosition.CenterParent;
            frmDeal.MaximizeBox = false;
            frmDeal.MinimizeBox = false;
            frmDeal.AutoScaleMode = AutoScaleMode.Font;
            frmDeal.ControlBox = false;

            return frmDeal;
        }

        /// <summary>
        ///     update the decks variable after the dropdown is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbDecks_DropDownClosed(object sender, EventArgs e) {
            ComboBox decks = sender as ComboBox;
            Decks  = (int)decks.SelectedItem;
        }

        /// <summary>
        ///     update the player object's name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_TextChanged(object sender, EventArgs e) {
            TextBox input = sender as TextBox;
            Player1.Name = input.Text;
        }

        /// <summary>
        ///     start the game from here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeal_Click(object sender, EventArgs e) {
            Button btnSent = sender as Button;
            //btnSent.Parent.SendToBack();
            //btnSent.Parent.Hide();
            //btnSent.Parent.Visible = false;
            btnSent.Parent.Dispose();
            lblPlayerHand.Text = Player1.Name + "\'s Hand";
            //check if the Shoe has been built or if the # of decks was changed from default.
            if (drawPile == null || drawPile.GetDecks() != Decks) {
                drawPile = new Shoe(Decks);
            }
            PlayingGame = true;
            StartGame();
        }

        /// <summary>
        ///     function to start up the game with the initial draws for each player.
        /// </summary>
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

        /// <summary>
        ///     draw the hand provided in the provided box
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="textBox"></param>
        private void DisplayHand(BJPlayer hand, RichTextBox textBox) {
            textBox.Clear();
            textBox.Text = hand.Flop();
            if (hand.Bust) {
                textBox.Text += Environment.NewLine + hand.Name + " busted!";
            } else if (hand.Stand) {
                textBox.Text += Environment.NewLine + hand.Name + " stands.";
            }
            
        }
        
        /// <summary>
        ///     receives the specified player and associated text box and 
        ///     provides logic to perform the turn for the player, depending on
        ///     the specific player's bust and stand properties.
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="textBox"></param>
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

        /// <summary>
        ///     logic to decide how the dealer takes it's turn
        /// </summary>
        private void DealerTurn() {
            if (!Player1.Bust && !Player1.BlackJack && ((Player1.Score > Dealer.Score) || Dealer.Score < 18)) {
                do {
                    TakeTurn(Dealer, rtbDealer);
                } while (!Dealer.Bust && !Dealer.Stand);
            } else {
                Dealer.Stand = true;
            }
            DisplayHand(Dealer, rtbDealer);
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
            rtbWinner.SelectionAlignment = HorizontalAlignment.Center;
            rtbWinner.ReadOnly = true;
            rtbWinner.ScrollBars = RichTextBoxScrollBars.None;
            rtbWinner.TabStop = false;
            rtbWinner.Text = Environment.NewLine + player.Name + " wins!" + Environment.NewLine;
            rtbWinner.Dock = DockStyle.Fill;
            rtbWinner.Font = new Font("Microsoft Sans Serif", 22F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            rtbWinner.ReadOnly = true;
            Winner.Controls.Add(rtbWinner);

            //setting up the rest of the winner display form
            //Winner.Parent = this.ParentForm;
            Winner.Height = 150;
            Winner.Width = 250;
            Winner.MinimizeBox = false;
            Winner.MaximizeBox = false;
            Winner.StartPosition = FormStartPosition.CenterParent;
            Winner.ShowDialog();

            StartGame();
        }

        /// <summary>
        ///     logic to quit the game when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }

        /// <summary>
        ///     logic for determining if the user can perform their turn
        ///     when the "Hit" button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHit_Click(object sender, EventArgs e) {
            TakeTurn(Player1, rtbPlayer);
            if (Player1.Bust || Player1.BlackJack || Player1.Stand) {
                Dealer.Turn = true;
                DealerTurn();
            }
        }

        /// <summary>
        ///     end the user's turn and redraw their hand.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStand_Click(object sender, EventArgs e) {
            Player1.Stand = true;
            DisplayHand(Player1, rtbPlayer);
            Dealer.Turn = true;
            DealerTurn();
        }
    }
}
