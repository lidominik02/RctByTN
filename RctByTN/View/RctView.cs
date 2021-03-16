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

namespace RctByTN.View
{
    public partial class RctView : Form
    {
        private const Int32 ParkHeight = 13;
        private const Int32 ParkWidth = 23;

        private RctModel _model;
        private Button[,] _buttonGrid;
        private Int32 _selectedTab;
        public RctView()
        {
            InitializeComponent();
            _selectedTab = -1;
        }

        private void RctView_Load(object sender, EventArgs e)
        {
            _model = new RctModel();
            _model.ElementChanged += new EventHandler<ParkElementEventArgs>(Game_ElementChanged);
            GenerateTable();
        }

        private void Game_ElementChanged(Object sender, ParkElementEventArgs e)
        {
            RefreshTable(e.Element);
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
                this.buttonGridPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,
                                                                        1 / Convert.ToSingle(ParkWidth)));
            }
            for (int i = 0; i < ParkHeight; i++)
            {
                this.buttonGridPanel.RowStyles.Add(new RowStyle(SizeType.Percent,
                                                                        1 / Convert.ToSingle(ParkHeight)));
            }

            for (Int32 i = 0; i < ParkHeight; i++)
            {
                for (Int32 j = 0; j < ParkWidth; j++)
                {
                    _buttonGrid[i, j] = new Button();
                    _buttonGrid[i, j].Size = new Size(50, 50);
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    _buttonGrid[i, j].Margin = new Padding(0);
                    //_buttonGrid[i, j].Dock = DockStyle.Fill;
                    _buttonGrid[i, j].Click += buttonGrid_Click;
                    buttonGridPanel.Controls.Add(_buttonGrid[i, j]);
                }
            }
        }

        private void RefreshTable(ParkElement element)
        {
                switch (element.Status)
                {
                    case ElementStatus.Operate:
                        _buttonGrid[element.X, element.Y].BackColor = Color.Green;
                        break;
                    case ElementStatus.InWaiting:
                        _buttonGrid[element.X, element.Y].BackColor = Color.Orange;
                        break;
                    case ElementStatus.InBuild:
                        _buttonGrid[element.X, element.Y].BackColor = Color.Red;
                        break;
                }
        }

        private void buttonGrid_Click(object sender, EventArgs e)
        {
            var cgv = new CreateRestaurantView();
            cgv.Show();
            //_model.Build(_selectedTab);
        }

        private void parkElementPanel_Click(object sender, EventArgs e)
        {
            _selectedTab = ((Button)sender).TabIndex;
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

        private void cancelPictureBox_Click(object sender, EventArgs e)
        {
            _selectedTab = -1;
        }
    }
}
