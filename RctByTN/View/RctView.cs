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
        private Button[,] _buttonGrid;
        public RctView()
        {
            InitializeComponent();
        }

        private void RctView_Load(object sender, EventArgs e)
        {
            GenerateTable();
        }

        public void GenerateTable()
        {
            Int32 ySize = 13;
            int xSize = 25;
            _buttonGrid = new Button[ySize, xSize];
            this.buttonGridPanel.ColumnCount = xSize;
            this.buttonGridPanel.RowCount = ySize;
            this.buttonGridPanel.ColumnStyles.Clear();
            this.buttonGridPanel.RowStyles.Clear();

            for (int i = 0; i < xSize; i++)
            {
                this.buttonGridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1250 / xSize));
            }
            for (int i = 0; i < ySize; i++)
            {
                this.buttonGridPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 650 / ySize));
            }

            for (Int32 i = 0; i < ySize; i++)
            {
                for (Int32 j = 0; j < xSize; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Size = new Size(50, 50);
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    _buttonGrid[i, j].Margin = new Padding(0);
                    _buttonGrid[i, j].Dock = DockStyle.Fill;
                    buttonGridPanel.Controls.Add(_buttonGrid[i, j]);
                }
            }
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
