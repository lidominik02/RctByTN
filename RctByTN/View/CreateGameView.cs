using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RctByTN.View
{
    public partial class CreateGameView : Form
    {
        private Int32 _ticketCost;
        private Int32 _minCapacity;

        public Int32 TicketCost { get => _ticketCost; }
        public Int32 MinCapacity { get => _minCapacity; }
        public CreateGameView()
        {
            InitializeComponent();
            _minCapacity = 0;
            _ticketCost = 0;
        }

        private void notAcceptedButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acceptedButton_Click(object sender, EventArgs e)
        {
            try
            {
                _ticketCost = Int32.Parse(ticketPriceTextBox.Text);
                _minCapacity = Int32.Parse(minCapacityTextBox.Text);
            }
            catch (Exception)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void CreateGameView_Load(object sender, EventArgs e)
        {
            acceptedButton.Enabled = false;
        }

        private void ticketPriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void minCapacityTextBox_TextChanged(object sender, EventArgs e)
        {
            bool IsNullOrEmptyInputs = String.IsNullOrEmpty(minCapacityTextBox.Text)
                       ||  String.IsNullOrEmpty(ticketPriceTextBox.Text);
            acceptedButton.Enabled = !IsNullOrEmptyInputs;
        }
    }
}
