using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RctByTN.Model
{
    class RctModel
    {
        private bool isParkOpen;
        private Int32 cash;
        private Int32 income;
        private Int32 outcome;
        private List<Guest> guestList;
        private List<ParkElement> parkElementList;

        private const Int32 GameBuildCost = 250;
        private const Int32 GameTicketCost = 50;
        private const Int32 GameMaintainCost = 50;
        private const Int32 RestaurantBuildCost = 200;
        private const Int32 RestaurantMaintainCost = 50;
        private const Int32 RestaurantTicketServiceTime = 10;
        private const Int32 RestaurantFoodCost = 20;
        private const Int32 RoadBuildCost = 20;
        private const Int32 PlantBuildCost = 100;
        private const Int32 BuildTime = 3000;

        public event EventHandler<ParkElementEventArgs> ElementChanged;
        public event EventHandler CashChanged;

        public bool IsParkOpen { get => isParkOpen; set => isParkOpen = value; }
        public int Cash { get => cash; set => cash = value; }
        public int Income { get => income; set => income = value; }
        public int Outcome { get => outcome; set => outcome = value; }
        public List<Guest> GuestList { get => guestList; set => guestList = value; }
        public List<ParkElement> ParkElementList { get => parkElementList; set => parkElementList = value; }

        public RctModel()
        {
            GuestList = new List<Guest>();
            ParkElementList = new List<ParkElement>();
            IsParkOpen = false;
            income = outcome = 0;
            cash = 1000;
        }

        public void Build(Int32 x, Int32 y,Int32 selectedTab,Int32 cost,Int32 minCapacity)
        {
            if (isParkOpen)
                return;

            ParkElement newElement = null;
            switch (selectedTab)
            {
                case 0:
                    newElement = new RollerCoaster(x,y,minCapacity,10,cost, GameBuildCost,GameMaintainCost);
                    break;
                case 1:
                    newElement = new GiantWheel(x, y, minCapacity, 10,cost, GameBuildCost, GameMaintainCost);
                    break;
                case 2:
                    newElement = new Carousel(x, y, minCapacity, 10, cost, GameBuildCost, GameMaintainCost);
                    break;
                case 3:
                    newElement = new HotDogVendor(x, y, RestaurantBuildCost, 10, RestaurantMaintainCost, RestaurantTicketServiceTime, cost);
                    break;
                case 4:
                    newElement = new IceCreamVendor(x, y, RestaurantBuildCost, 10, RestaurantMaintainCost, RestaurantTicketServiceTime, cost);
                    break;
                case 5:
                    newElement = new CottonCandyVendor(x, y, RestaurantBuildCost, 10, RestaurantMaintainCost, RestaurantTicketServiceTime, cost);
                    break;
                case 6:
                    newElement = new Road(x, y, RoadBuildCost,0);
                    break;
                case 7:
                    newElement = new Grass(x, y, PlantBuildCost,0);
                    break;
                case 8:
                    newElement = new Tree(x, y, PlantBuildCost,0);
                    break;
                case 9:
                    newElement = new Bush(x, y, PlantBuildCost,0);
                    break;
            }

            if(newElement != null)
            {
                cash -= newElement.BuildCost;
                outcome += newElement.MaintainCost;
                OnCashChanged();

                SetInterval(BuildTime, () =>
                 {
                     newElement.Status = ElementStatus.InWaiting;
                     OnElementChanged(newElement);
                 });
                parkElementList.Add(newElement);
                OnElementChanged(newElement);
            }
        }

        private void OnElementChanged(ParkElement newElement)
        {
            if (ElementChanged != null)
            {
                ElementChanged(this, new ParkElementEventArgs(newElement));
            }
        }

        private void OnCashChanged()
        {
            if(CashChanged != null)
            {
                CashChanged(this, EventArgs.Empty);
            }
        }

        private async void SetInterval(Int32 millisecond, Action action)
        {
            await Task.Run(async () =>{
                await Task.Delay(millisecond);
                action();
            });
        }

        public bool IsFreeArea(int x, int y,int selectedTab)
        {
            bool returnValue = IsFreeArea(x,y);

            if(selectedTab < 6)
            {
                returnValue = returnValue ||
                    IsFreeArea(x-1, y) ||
                    IsFreeArea(x, y-1) ||
                    IsFreeArea(x-1, y-1);
            }

            return returnValue;
        }

        private bool IsFreeArea(int x,int y)
        {
            return parkElementList.Exists(item => {
                bool withArea = false;
                if (item.AreaSize == 4)
                {
                    withArea = item.X - 1 == x && item.Y == y ||
                               item.X - 1 == x && item.Y - 1 == y ||
                               item.X == x && item.Y - 1 == y;
                }
                return (item.X == x && item.Y == y) || withArea;
            });
        }

    }
}
