namespace BlackjackWFA {
    partial class NewGame {
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDecks = new System.Windows.Forms.Label();
            this.cboxDecks = new System.Windows.Forms.ComboBox();
            this.btnDeal = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(15, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 15);
            this.lblName.TabIndex = 3;
            this.lblName.Tag = "lblName";
            this.lblName.Text = "Enter your Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(15, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 20);
            this.txtName.TabIndex = 3;
            this.txtName.Tag = "txtName";
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDecks
            // 
            this.lblDecks.AutoSize = true;
            this.lblDecks.Location = new System.Drawing.Point(145, 10);
            this.lblDecks.Name = "lblDecks";
            this.lblDecks.Size = new System.Drawing.Size(129, 13);
            this.lblDecks.TabIndex = 4;
            this.lblDecks.Tag = "lblDecks";
            this.lblDecks.Text = "Number of Decks in Shoe";
            // 
            // cboxDecks
            // 
            this.cboxDecks.Location = new System.Drawing.Point(145, 25);
            this.cboxDecks.Name = "cboxDecks";
            this.cboxDecks.Size = new System.Drawing.Size(128, 21);
            this.cboxDecks.TabIndex = 4;
            this.cboxDecks.Tag = "cbDecks";
            this.cboxDecks.DropDownClosed += new System.EventHandler(this.cboxDecks_DropDownClosed);
            // 
            // btnDeal
            // 
            this.btnDeal.Location = new System.Drawing.Point(45, 50);
            this.btnDeal.Name = "btnDeal";
            this.btnDeal.Size = new System.Drawing.Size(200, 30);
            this.btnDeal.TabIndex = 1;
            this.btnDeal.Tag = "btnDeal";
            this.btnDeal.Text = "Deal me in!";
            this.btnDeal.UseVisualStyleBackColor = true;
            this.btnDeal.Click += new System.EventHandler(this.btnDeal_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuit.Location = new System.Drawing.Point(45, 85);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(200, 30);
            this.btnQuit.TabIndex = 2;
            this.btnQuit.Tag = "btnQuit";
            this.btnQuit.Text = "I don\'t want to play.";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // NewGame
            // 
            this.AcceptButton = this.btnDeal;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnQuit;
            this.ClientSize = new System.Drawing.Size(289, 124);
            this.ControlBox = false;
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDecks);
            this.Controls.Add(this.cboxDecks);
            this.Controls.Add(this.btnDeal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGame";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "frmDeal";
            this.Text = "New Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDecks;
        private System.Windows.Forms.ComboBox cboxDecks;
        private System.Windows.Forms.Button btnDeal;
        private System.Windows.Forms.Button btnQuit;
    }
}