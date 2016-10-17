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
    public partial class NewGame : Form {
        public int ReturnNumDecks { get; set; }
        public BJPlayer ReturnPlayer { get; set; }
        private BindingList<int> NumDecksList = new BindingList<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public NewGame(BJPlayer player, int numDecks) {
            InitializeComponent();

            cboxDecks.DataSource = NumDecksList;
            cboxDecks.SelectedIndex = NumDecksList.IndexOf(numDecks);

            ReturnPlayer = player;
            txtName.Text = ReturnPlayer.Name;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtName_TextChanged(object sender, EventArgs e) {
            ReturnPlayer.Name = txtName.Text;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboxDecks_DropDownClosed(object sender, EventArgs e) {
            ReturnNumDecks = (int)cboxDecks.SelectedItem;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeal_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
