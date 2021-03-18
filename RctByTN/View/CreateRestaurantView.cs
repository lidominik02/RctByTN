using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RctByTN.View
{
    public partial class CreateRestaurantView : Form
    {
        private Int32 _foodCost;

        public Int32 FoodCost { get => _foodCost; set => _foodCost = value; }
        public CreateRestaurantView()
        {
            InitializeComponent();
        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void notAcceptedButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void acceptedButton_Click(object sender, EventArgs e)
        {
            _foodCost = Int32.Parse(priceTextBox.Text);
        }
    }
}
