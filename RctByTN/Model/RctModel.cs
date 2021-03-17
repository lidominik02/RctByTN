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

        private const Int32 GameBuildCost = 500;
        private const Int32 GameTicketCost = 50;
        private const Int32 GameMaintainCost = 15;
        private const Int32 RestaurantBuildCost = 500;
        private const Int32 RoadBuildCost = 500;
        private const Int32 PlantBuildCost = 500;
        private const Int32 BuildTime = 3000;

        public event EventHandler<ParkElementEventArgs> ElementChanged;

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
            //TODO: to find out the amount of starting cash
            //cash = ???
        }

        public void Build(Int32 x, Int32 y,Int32 selectedTab)
        {
            ParkElement newElement = null;
            switch (selectedTab)
            {
                case 0:
                    newElement = new RollerCoaster(x,y,0,10,GameTicketCost,GameMaintainCost,GameBuildCost);
                    break;
                case 1:
                    newElement = new GiantWheel(x, y, 0, 10, GameTicketCost, GameMaintainCost, GameBuildCost);
                    break;
                case 2:
                    newElement = new Carousel(x, y, 0, 10, GameTicketCost, GameMaintainCost, GameBuildCost);
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    newElement = new Road(x,y,RoadBuildCost);
                    break;
                case 8:
                    break;
                case 9:
                    break;
            }

            if(newElement != null)
            {
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

        private async void SetInterval(Int32 millisecond, Action action)
        {
            await Task.Run(async () =>{
                await Task.Delay(millisecond);
                action();
            });
        }
    }
}
