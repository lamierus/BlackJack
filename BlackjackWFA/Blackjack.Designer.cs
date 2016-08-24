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
            this.lblDealerHand = new System.Windows.Forms.Label();
            this.rtbDealer = new System.Windows.Forms.RichTextBox();
            this.lblPlayerHand = new System.Windows.Forms.Label();
            this.rtbPlayer = new System.Windows.Forms.RichTextBox();
            this.lblDealerScore = new System.Windows.Forms.Label();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.gbDealer = new System.Windows.Forms.GroupBox();
            this.gbPlayer = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // btnHit
            // 
            this.btnHit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHit.Location = new System.Drawing.Point(57, 590);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(150, 80);
            this.btnHit.TabIndex = 0;
            this.btnHit.Text = "Hit";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // btnStand
            // 
            this.btnStand.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStand.Location = new System.Drawing.Point(241, 590);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(150, 80);
            this.btnStand.TabIndex = 1;
            this.btnStand.Text = "Stand";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(397, 645);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(55, 25);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // lblDealerHand
            // 
            this.lblDealerHand.AutoSize = true;
            this.lblDealerHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerHand.Location = new System.Drawing.Point(12, 12);
            this.lblDealerHand.Name = "lblDealerHand";
            this.lblDealerHand.Size = new System.Drawing.Size(123, 20);
            this.lblDealerHand.TabIndex = 5;
            this.lblDealerHand.Text = "Dealer\'s Hand";
            // 
            // rtbDealer
            // 
            this.rtbDealer.BackColor = System.Drawing.SystemColors.Window;
            this.rtbDealer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDealer.Location = new System.Drawing.Point(397, 12);
            this.rtbDealer.Name = "rtbDealer";
            this.rtbDealer.ReadOnly = true;
            this.rtbDealer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbDealer.Size = new System.Drawing.Size(50, 30);
            this.rtbDealer.TabIndex = 6;
            this.rtbDealer.TabStop = false;
            this.rtbDealer.Text = "";
            // 
            // lblPlayerHand
            // 
            this.lblPlayerHand.AutoSize = true;
            this.lblPlayerHand.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerHand.Location = new System.Drawing.Point(12, 293);
            this.lblPlayerHand.Name = "lblPlayerHand";
            this.lblPlayerHand.Size = new System.Drawing.Size(119, 20);
            this.lblPlayerHand.TabIndex = 7;
            this.lblPlayerHand.Text = "Player\'s Hand";
            // 
            // rtbPlayer
            // 
            this.rtbPlayer.BackColor = System.Drawing.SystemColors.Window;
            this.rtbPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPlayer.Location = new System.Drawing.Point(397, 293);
            this.rtbPlayer.Name = "rtbPlayer";
            this.rtbPlayer.ReadOnly = true;
            this.rtbPlayer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.rtbPlayer.Size = new System.Drawing.Size(50, 30);
            this.rtbPlayer.TabIndex = 8;
            this.rtbPlayer.TabStop = false;
            this.rtbPlayer.Text = "";
            // 
            // lblDealerScore
            // 
            this.lblDealerScore.AutoSize = true;
            this.lblDealerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDealerScore.Location = new System.Drawing.Point(344, 12);
            this.lblDealerScore.Name = "lblDealerScore";
            this.lblDealerScore.Size = new System.Drawing.Size(47, 16);
            this.lblDealerScore.TabIndex = 9;
            this.lblDealerScore.Text = "Score:";
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerScore.Location = new System.Drawing.Point(344, 293);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(47, 16);
            this.lblPlayerScore.TabIndex = 10;
            this.lblPlayerScore.Text = "Score:";
            // 
            // gbDealer
            // 
            this.gbDealer.BackColor = System.Drawing.SystemColors.Control;
            this.gbDealer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbDealer.Location = new System.Drawing.Point(16, 36);
            this.gbDealer.Name = "gbDealer";
            this.gbDealer.Size = new System.Drawing.Size(375, 254);
            this.gbDealer.TabIndex = 11;
            this.gbDealer.TabStop = false;
            this.gbDealer.Tag = "gbDealer";
            // 
            // gbPlayer
            // 
            this.gbPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbPlayer.Location = new System.Drawing.Point(16, 316);
            this.gbPlayer.Name = "gbPlayer";
            this.gbPlayer.Size = new System.Drawing.Size(375, 254);
            this.gbPlayer.TabIndex = 12;
            this.gbPlayer.TabStop = false;
            this.gbPlayer.Tag = "gbPlayer";
            // 
            // Blackjack
            // 
            this.AcceptButton = this.btnHit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 676);
            this.Controls.Add(this.gbPlayer);
            this.Controls.Add(this.gbDealer);
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.lblDealerScore);
            this.Controls.Add(this.rtbPlayer);
            this.Controls.Add(this.lblPlayerHand);
            this.Controls.Add(this.rtbDealer);
            this.Controls.Add(this.lblDealerHand);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnStand);
            this.Controls.Add(this.btnHit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(478, 714);
            this.MinimumSize = new System.Drawing.Size(478, 714);
            this.Name = "Blackjack";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blackjack";
            this.Activated += new System.EventHandler(this.Blackjack_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label lblDealerHand;
        private System.Windows.Forms.RichTextBox rtbDealer;
        private System.Windows.Forms.Label lblPlayerHand;
        private System.Windows.Forms.RichTextBox rtbPlayer;
        private System.Windows.Forms.Label lblDealerScore;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.GroupBox gbDealer;
        private System.Windows.Forms.GroupBox gbPlayer;
    }
}

