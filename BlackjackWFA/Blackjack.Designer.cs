namespace BlackjackWFA {
    partial class Blackjack {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Blackjack));
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.lblDecks = new System.Windows.Forms.Label();
            this.cbDecks = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnHit
            // 
            this.btnHit.Location = new System.Drawing.Point(12, 590);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(150, 80);
            this.btnHit.TabIndex = 0;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = true;
            // 
            // btnStand
            // 
            this.btnStand.Location = new System.Drawing.Point(168, 590);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(150, 80);
            this.btnStand.TabIndex = 1;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(324, 647);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(128, 23);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblDecks
            // 
            this.lblDecks.AutoSize = true;
            this.lblDecks.Location = new System.Drawing.Point(324, 590);
            this.lblDecks.Name = "lblDecks";
            this.lblDecks.Size = new System.Drawing.Size(129, 13);
            this.lblDecks.TabIndex = 3;
            this.lblDecks.Text = "Number of Decks in Shoe";
            // 
            // cbDecks
            // 
            this.cbDecks.FormattingEnabled = true;
            this.cbDecks.Location = new System.Drawing.Point(324, 606);
            this.cbDecks.Name = "cbDecks";
            this.cbDecks.Size = new System.Drawing.Size(128, 21);
            this.cbDecks.TabIndex = 4;
            this.cbDecks.Text = "# of Decks";
            this.cbDecks.SelectedIndexChanged += new System.EventHandler(this.cbDecks_SelectedIndexChanged);
            // 
            // Blackjack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 682);
            this.Controls.Add(this.cbDecks);
            this.Controls.Add(this.lblDecks);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 720);
            this.MinimumSize = new System.Drawing.Size(480, 720);
            this.Name = "Blackjack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blackjack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblDecks;
        private System.Windows.Forms.ComboBox cbDecks;
    }
}

