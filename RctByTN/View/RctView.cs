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
        private Guest _spectatedGuest;
        Timer _timer;
        public RctView()
        {
            InitializeComponent();
            _selectedTab = -1;
        }

        private void RctView_Load(object sender, EventArgs e)
        {
            _model = new RctModel();
            _model.ElementChanged += new EventHandler<ParkElementEventArgs>(Game_ElementChanged);
            _model.CashChanged += new EventHandler(Game_CashChanged);
            _model.NotEnoughCash += new EventHandler(Game_NotEnoughCash);
            _model.GuestClicked += new EventHandler<GuestEventArgs>(Game_GuestClicked);
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(TimeElapsed);
            //_timer.Start();
            GenerateTable();
            _model.Build(12, 11, 10, 0, 0);
        }

        private void TimeElapsed(object sender, EventArgs e)
        {
            _model.TimeElapsed();
            RefreshTable();
            SpectateGuest();
            if (!_model.IsCampaign)
                campaignButton.Enabled = true;
        }

        private void Game_NotEnoughCash(object sender, EventArgs e)
        {
            MessageBox.Show("A kiválasztott építkezéshez nincs elég pénzed!"
                    , "Az építés megkezdése sikertelen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Game_CashChanged(object sender, EventArgs e)
        {
            cashLabel.Text = "Egyenleg: "+_model.Cash.ToString();
            incomeLabel.Text = "Bevétel: "+_model.Income.ToString();
            outcomeLabel.Text = "Kiadás: "+_model.Outcome.ToString();
        }

        private void Game_GuestClicked(object sender, GuestEventArgs e)
        {
            _spectatedGuest = e.Guest;
            SpectateGuest();
        }

        private void SpectateGuest()
        {
            if (_spectatedGuest == null)
            {
                guestPic.Image = Properties.Resources.no_guest;
                return;
            }
            guestPic.Image = Properties.Resources.guestface;
            var nl = Environment.NewLine;
            guestData.Text = "Egyenleg: " + _spectatedGuest.Money.ToString() + nl
                            + "Hangulat: " + _spectatedGuest.Mood.ToString() + nl
                            + "Éhség: " + _spectatedGuest.Hunger.ToString() + nl
                            + "Cél: " + _spectatedGuest.Destination.Item1.ToString()
                            + "  " + _spectatedGuest.Destination.Item2.ToString() + nl
                            + "Kupon: " + _spectatedGuest.HasCoupon;
        }

        private void Game_ElementChanged(Object sender, ParkElementEventArgs e)
        {
            var element = e.Element;
            switch (element.Status)
            {
                case ElementStatus.Operate:
                    if (element.GetType().IsSubclassOf(typeof(Game)))
                    {
                        _buttonGrid[element.X - 1, element.Y - 1].Image = Properties.Resources.operate1;
                        _buttonGrid[element.X, element.Y - 1].Image = Properties.Resources.operate3;
                        _buttonGrid[element.X - 1, element.Y].Image = Properties.Resources.operate2;
                        _buttonGrid[element.X, element.Y].Image = Properties.Resources.operate4;
                    }
                    else
                    {
                        _buttonGrid[element.X - 1, element.Y - 1].Image = Properties.Resources.eat1;
                        _buttonGrid[element.X, element.Y - 1].Image = Properties.Resources.eat3;
                        _buttonGrid[element.X - 1, element.Y].Image = Properties.Resources.eat2;
                        _buttonGrid[element.X, element.Y].Image = Properties.Resources.eat4;
                    }
                    break;
                case ElementStatus.InWaiting:
                    if (element.GetType() == typeof(Road))
                    {
                        _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.road;
                    }
                    else if(element.GetType() == typeof(Grass))
                    {
                        _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.grass;
                    }
                    else if(element.GetType() == typeof(Bush))
                    {
                        _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.bush;
                    }
                    else if(element.GetType() == typeof(Tree))
                    {
                        _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.tree;
                    }
                    else if(element.GetType() == typeof(Entrance))
                    {
                        _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.gate;
                    }
                    else if(element.GetType() == typeof(GiantWheel))
                    {
                        _buttonGrid[element.X - 1, element.Y - 1].BackgroundImage = Properties.Resources.giantwheel1;
                        _buttonGrid[element.X, element.Y - 1].BackgroundImage = Properties.Resources.giantwheel3;
                        _buttonGrid[element.X - 1, element.Y].BackgroundImage = Properties.Resources.giantwheel2;
                        _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.giantwheel4;
                        BuildParkElement(element, (button) => button.BackColor = Color.Gray);
                        BuildParkElement(element, (button) => button.Image = null);
                    }
                    else if (element.GetType() == typeof(HotDogVendor))
                    {
                        _buttonGrid[element.X - 1, element.Y - 1].BackgroundImage = Properties.Resources.hotdog1;
                        _buttonGrid[element.X, element.Y - 1].BackgroundImage = Properties.Resources.hotdog3;
                        _buttonGrid[element.X - 1, element.Y].BackgroundImage = Properties.Resources.hotdog2;
                        _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.hotdog4;
                        BuildParkElement(element, (button) => button.BackColor = Color.LightGreen);
                        BuildParkElement(element, (button) => button.Image = null);
                    }
                    else if(element.GetType() == typeof(CottonCandyVendor))
                    {
                        _buttonGrid[element.X - 1, element.Y - 1].BackgroundImage = Properties.Resources.cottoncandy1;
                        _buttonGrid[element.X, element.Y - 1].BackgroundImage = Properties.Resources.cottoncandy3;
                        _buttonGrid[element.X - 1, element.Y].BackgroundImage = Properties.Resources.cottoncandy2;
                        _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.cottoncandy4;
                        BuildParkElement(element, (button) => button.BackColor = Color.LightGreen);
                        BuildParkElement(element, (button) => button.Image = null);
                    }
                    else
                    {
                        BuildParkElement(element, (button) => button.Image = Properties.Resources.placeholder);
                    }
                    BuildParkElement(element, (button) => button.Image = null);
                    break;
                case ElementStatus.InBuild:
                    BuildParkElement(element, (button) => button.Image = Properties.Resources.buildsmall);
                    break;
            }
        }

        private void BuildParkElement(ParkElement element,Action<Button> action)
        {
            int x = element.X;
            int y = element.Y;
            if (element.AreaSize == 1)
            {
                action(_buttonGrid[x,y]);
            }
            else if(element.AreaSize == 4)
            {
                action(_buttonGrid[x, y]);
                action(_buttonGrid[x-1, y]);
                action(_buttonGrid[x, y-1]);
                action(_buttonGrid[x-1, y-1]);
            }
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
                    _buttonGrid[i,j].BackgroundImageLayout = ImageLayout.Stretch;
                    _buttonGrid[i, j].BackColor = Color.FromArgb(117,185,67);
                    _buttonGrid[i, j].FlatAppearance.BorderColor = Color.FromArgb(140,189,105);
                    _buttonGrid[i, j].FlatStyle = FlatStyle.Flat;
                    _buttonGrid[i, j].Margin = new Padding(0);
                    _buttonGrid[i, j].TabIndex = i * ParkWidth + j;
                    _buttonGrid[i, j].Click += buttonGrid_Click;
                    buttonGridPanel.Controls.Add(_buttonGrid[i, j]);
                }
            }
        }

        private void RefreshTable()
        {
            foreach(ParkElement element in _model.ParkElementList)
            {
                if (element.GetType() == typeof(Road))
                {
                    _buttonGrid[element.X, element.Y].BackgroundImage = Properties.Resources.road;
                }
                
                if(element.GetType().IsSubclassOf(typeof(Building)))
                {
                    _buttonGrid[element.X,element.Y].Text = (element as Building).WaitingList.Count.ToString();
                    _buttonGrid[element.X, element.Y].TextAlign = ContentAlignment.BottomRight;
                } 
            }

            foreach(Guest guest in _model.GuestList.ToList())
            {
                if (_model.GuestList.Count(g => g.X == guest.X && g.Y == guest.Y) > 1)
                {
                    _buttonGrid[guest.X, guest.Y].BackgroundImage = Properties.Resources.road_guest2;
                }
                else 
                {
                    _buttonGrid[guest.X, guest.Y].BackgroundImage = Properties.Resources.road_guest;
                }
            }
        }

        private void buttonGrid_Click(object sender, EventArgs e)
        {
            Int32 x = (sender as Button).TabIndex / ParkWidth;
            Int32 y = (sender as Button).TabIndex % ParkWidth;
            if (!_model.IsParkOpen)
            {

                if (_selectedTab == -1)
                {
                    MessageBox.Show("Az építés megkezdése előtt válassza ki az építésre szánt park elemet!"
                        , "Az építés megkezdése sikertelen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (_model.IsFreeArea(x, y, _selectedTab))
                {
                    MessageBox.Show("A kiválasztott terület foglalt, az építéshez válaszon ki a választott vidámpark elemnek megfelelő szabad területet"
                        , "Az építés megkezdése sikertelen!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (_selectedTab >= 0 && _selectedTab <= 2)
                {
                    var cgv = new CreateGameView();
                    if (cgv.ShowDialog() == DialogResult.OK)
                    {
                        _model.Build(x, y, _selectedTab, cgv.TicketCost, cgv.MinCapacity);
                    }
                }
                else if (_selectedTab >= 3 && _selectedTab <= 5)
                {
                    var crv = new CreateRestaurantView();
                    if (crv.ShowDialog() == DialogResult.OK)
                    {
                        _model.Build(x, y, _selectedTab, crv.FoodCost, 0);
                    }
                }
                else
                {
                    _model.Build(x, y, _selectedTab, 0, 0);
                }
            }
            else
            {
                _model.Build(x, y, 0, 0, 0);
            }
        }

        private void parkElementPanel_Click(object sender, EventArgs e)
        {
            _selectedTab = ((Button)sender).TabIndex;
            foreach (Button button in parkElementPanel1.Controls)
            {
                
                if (_selectedTab == button.TabIndex)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.FromArgb(177, 156, 217);
                }
                else
                {
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.BorderColor = Color.Empty;
                    button.FlatStyle = FlatStyle.Standard;
                }
            }
            foreach (Button button in parkElementPanel2.Controls)
            {
                if (_selectedTab == button.TabIndex)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 1;
                    button.FlatAppearance.BorderColor = Color.FromArgb(121, 96, 76);
                }
                else
                {
                    button.FlatAppearance.BorderSize = 0;
                    button.FlatAppearance.BorderColor = Color.Empty;
                    button.FlatStyle = FlatStyle.Standard;
                }
            }
        }

        private void nextPictureBox_Click(object sender, EventArgs e)
        {
            parkElementPanel1.Visible = !parkElementPanel1.Visible;
            parkElementPanel2.Visible = !parkElementPanel2.Visible;
        }

        private void openEditButton_Click(object sender, EventArgs e)
        {
            if (_model.IsParkOpen) {
                _model.IsParkOpen = false;
                foreach(Button button in _buttonGrid) button.FlatAppearance.BorderSize = 1;
                _timer.Stop();
            }
            else
            {
                _model.IsParkOpen = true;
                foreach (Button button in _buttonGrid) button.FlatAppearance.BorderSize = 0;
                _timer.Start();
            }
            openEditButton.Text = _model.IsParkOpen ?
                                    "Park szerkesztése"
                                    : "Park megnyitása";
            campaignButton.Enabled = _model.IsParkOpen;
        }

        private void cancelPictureBox_Click(object sender, EventArgs e)
        {
            _selectedTab = -1;
            foreach (Button button in parkElementPanel1.Controls)
            {
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = Color.Empty;
                button.FlatStyle = FlatStyle.Standard;
            }
            foreach (Button button in parkElementPanel2.Controls)
            {
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = Color.Empty;
                button.FlatStyle = FlatStyle.Standard;
            }
        }

        private void campaignButton_Click(object sender, EventArgs e)
        {
            _model.StartCampaign();
            campaignButton.Enabled = false;
        }
    }
}
