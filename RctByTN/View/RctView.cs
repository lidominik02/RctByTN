using RctByTN.Model;
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
        private const Int32 ParkHeight = 13;
        private const Int32 ParkWidth = 25;

        private RctModel _model;
        private Button[,] _buttonGrid;
        private bool _isParkElementSelected;
        public RctView()
        {
            InitializeComponent();
            _isParkElementSelected = false;
        }

        private void RctView_Load(object sender, EventArgs e)
        {
            _model = new RctModel();
            this.MinimumSize = new Size(1300, 900);
            this.MaximumSize = new Size(1300, 900);
            GenerateTable();
        }

        public void GenerateTable()
        {
            _buttonGrid = new Button[ParkHeight, ParkWidth];
            this.buttonGridPanel.ColumnCount = ParkWidth;
            this.buttonGridPanel.RowCount = ParkHeight;
            this.buttonGridPanel.ColumnStyles.Clear();
            this.buttonGridPanel.RowStyles.Clear();

            for (int i = 0; i < ParkWidth; i++)
            {
                this.buttonGridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1250 / ParkWidth));
            }
            for (int i = 0; i < ParkHeight; i++)
            {
                this.buttonGridPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 650 / ParkHeight));
            }

            for (Int32 i = 0; i < ParkHeight; i++)
            {
                for (Int32 j = 0; j < ParkWidth; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Size = new Size(50, 50);
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    _buttonGrid[i, j].Margin = new Padding(0);
                    _buttonGrid[i, j].Dock = DockStyle.Fill;
                    _buttonGrid[i, j].Click += buttonGrid_Click;
                    buttonGridPanel.Controls.Add(_buttonGrid[i, j]);
                }
            }
        }

        private void buttonGrid_Click(object sender, EventArgs e)
        {
            if(!_isParkElementSelected)
            {
                MessageBox.Show("Az építés megkezdése előtt válassza ki az építésre szánt park elemet!"
                    , "Az építés megkezdése sikertelen!",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void openEditButton_Click(object sender, EventArgs e)
        {
            _model.IsParkOpen = !_model.IsParkOpen;
            if (_model.IsParkOpen)
            {
                openEditButton.Text = "Park szerkesztése";
            }
            else
            {
                openEditButton.Text = "Park megnyitása";
            }
        }
    }
}
