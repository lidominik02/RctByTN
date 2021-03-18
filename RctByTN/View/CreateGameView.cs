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

        public Int32 TicketCost { get => _ticketCost; set => _ticketCost = value; }
        public Int32 MinCapacity { get => _minCapacity; set => _minCapacity = value; }
        public CreateGameView()
        {
            InitializeComponent();
        }

        private void notAcceptedButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acceptedButton_Click(object sender, EventArgs e)
        {
            _ticketCost = Int32.Parse(ticketPriceTextBox.Text);
            _minCapacity = Int32.Parse(minCapacityTextBox.Text);
        }
    }
}
