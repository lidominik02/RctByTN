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
        public CreateGameView()
        {
            InitializeComponent();
        }

        private void notAcceptedButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
