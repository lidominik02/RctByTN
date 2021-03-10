using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RctByTN
{
    public partial class RctView : Form
    {
        public RctView()
        {
            InitializeComponent();
        }

        private void RctView_Load(object sender, EventArgs e)
        {

        }

        private void nextPictureBox_Click(object sender, EventArgs e)
        {
            if (parkElementPanel1.Visible)
            {
                parkElementPanel1.Visible = false;
                parkElementPanel2.Visible = true;
            }
            else
            {
                parkElementPanel1.Visible = true;
                parkElementPanel2.Visible = false;
            }
        }
    }
}
