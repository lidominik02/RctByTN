using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace RctByTN.Model
{
    public class RctModel
    {
        private bool isParkOpen;
        private Int32 cash;
        private Int32 income;
        private Int32 outcome;
        private Int32 gameTime;
        private List<Guest> guestList;
        private List<ParkElement> parkElementList;
        private Random rnd;

        private const Int32 GameBuildCost = 250;
        private const Int32 GameMaintainCost = 50;
        private const Int32 RestaurantBuildCost = 200;
        private const Int32 RestaurantMaintainCost = 50;
        private const Int32 RoadBuildCost = 20;
        private const Int32 PlantBuildCost = 100;
        private const Int32 BuildTime = 3000;
        private const Int32 GameUseTime = 5000;
        private const Int32 RestaurantUseTime = 15000;
        private const Int32 RestaurantTicketServiceTime = 10;
        public static Int32 MaintainCostInterval = 5000;

        public event EventHandler<ParkElementEventArgs> ElementChanged;
        public event EventHandler CashChanged;
        public event EventHandler NotEnoughCash;

        public bool IsParkOpen { get => isParkOpen; set => isParkOpen = value; }
        public int Cash { get => cash; set => cash = value; }
        public int Income { get => income; set => income = value; }
        public int Outcome { get => outcome; set => outcome = value; }
        public int GameTime { get => gameTime; set => gameTime = value; }
        public List<Guest> GuestList { get => guestList; set => guestList = value; }
        public List<ParkElement> ParkElementList { get => parkElementList; set => parkElementList = value; }

        public RctModel()
        {
            GuestList = new List<Guest>();
            ParkElementList = new List<ParkElement>();
            IsParkOpen = false;
            income = outcome = 0;
            cash = 1000;
            gameTime = 0;
            rnd = new Random();
        }

        public void TimeElapsed()
        {
            gameTime++;
            FindDestination();
            MoveGuests();
            if (gameTime % 5 == 0)
            {
                AddGuest();
            }
        }

        private void FindDestination()
        {
            //TODO
            //add priorities for cheaper games/restaurants
            //games without path can't be destiantion
            foreach (Guest guest in GuestList)
            {
                if (guest.Status == GuestStatus.Searching)
                    continue;
                var games = ParkElementList.Where(p => p.GetType().IsSubclassOf(typeof(Game))).ToList();
                //if guest is hungry
                if (guest.Hunger < guest.Mood)
                {
                    var restaurants = ParkElementList.Where(p => p.GetType() == typeof(Restaurant)).ToList();
                    if (restaurants.Any())
                    {
                        var rndRest = restaurants[rnd.Next(restaurants.Count)];
                        guest.Destination = (rndRest.X, rndRest.Y+1);
                        guest.Status = GuestStatus.Searching;
                        return;
                    }
                }
                //if guest is bored
                else if (games.Any())
                {
                    var rndGame = games[rnd.Next(games.Count)];
                    guest.Destination = (rndGame.X, rndGame.Y+1);
                    Debug.WriteLine("des: x:{0} y:{1}", guest.Destination.Item1, guest.Destination.Item2);
                    Debug.WriteLine("g: x:{0} y:{1}", guest.X, guest.Y);
                    guest.Status = GuestStatus.Searching;
                }
            }
        }

        private bool GoUp(List<ParkElement> roadsAround, Guest guest)
        {
            if (roadsAround.Exists(item => item.Y == guest.Y && item.X == (guest.X - 1)))
            {
                Debug.WriteLine("x--");
                guest.PrevCoords = (guest.X, guest.Y);
                guest.X--;
                return true;
            }
            return false;
        }

        private bool GoDown(List<ParkElement> roadsAround, Guest guest)
        {
            if (roadsAround.Exists(item => item.Y == guest.Y && item.X == (guest.X + 1)))
            {
                Debug.WriteLine("x++");
                guest.PrevCoords = (guest.X, guest.Y);
                guest.X++;
                return true;
            }
            return false;
        }
        private bool GoRight(List<ParkElement> roadsAround, Guest guest)
        {
            if (roadsAround.Exists(item => item.Y == (guest.Y + 1) && item.X == guest.X))
            {
                Debug.WriteLine("y++");
                guest.PrevCoords = (guest.X, guest.Y);
                guest.Y++;
                return true;
            }
            return false;
        }
        private bool GoLeft(List<ParkElement> roadsAround, Guest guest)
        {
            if (roadsAround.Exists(item => item.Y == guest.Y - 1 && item.X == guest.X))
            {
                guest.PrevCoords = (guest.X, guest.Y);
                guest.Y--;
                return true;
            }
            return false;
        }

        private void MoveGuests()
        {
            foreach(Guest guest in guestList.ToList())
            {
                var desVectorX = guest.X - guest.Destination.Item1;
                var desVectorY = guest.Y - guest.Destination.Item2;

                if ((guest.X,guest.Y)==guest.Destination)
                {
                    var foundBuilding = ParkElementList.Find(item => item.X == guest.Destination.Item1 && item.Y == (guest.Destination.Item2 - 1));
                    EnterElement(guest, foundBuilding as Building);
                }
                Debug.WriteLine("gMOVE: x:{0} y:{1}", guest.X, guest.Y);
                if (guest.Status == GuestStatus.Searching || guest.Status == GuestStatus.Stuck)
                {
                    if (guest.Status == GuestStatus.Stuck)
                    {
                        Debug.WriteLine("last crossroad: x:{0} y:{1}", guest.LastCrossRoad.Item1, guest.LastCrossRoad.Item2);
                        desVectorX = guest.X - guest.LastCrossRoad.Item1;
                        desVectorY = guest.Y - guest.LastCrossRoad.Item2;
                        if ((guest.X, guest.Y) == guest.LastCrossRoad)
                        {
                            desVectorX = guest.X - guest.Destination.Item1;
                            desVectorY = guest.Y - guest.Destination.Item2;
                            guest.Status = GuestStatus.Searching;
                        }
                    } 

                    Debug.WriteLine("desVector: ({0},{1})",desVectorX,desVectorY);

                    if(!(desVectorX == 0 && desVectorY == 0))
                    {
                        Debug.WriteLine("desVectorX != 0 && desVectorY != 0");
                        var roadsAround = parkElementList.Where(item =>
                        {
                            return item.GetType() == typeof(Road)
                            && Distance(item.X, item.Y, guest.X, guest.Y) == 1;
                        }).ToList();

                        if(roadsAround.Count >= 3)
                        {
                            guest.LastCrossRoad = (guest.X, guest.Y);
                        }

                        roadsAround.ForEach(item => Debug.WriteLine("roads: {0} {1}", item.X, item.Y));
                        if(roadsAround.Count > 1)
                        {
                            roadsAround.Remove(roadsAround.Find(item => item.X == guest.PrevCoords.Item1 && item.Y == guest.PrevCoords.Item2));
                        }
                        else if(roadsAround.Count==1 && roadsAround[0].X == guest.PrevCoords.Item1 && roadsAround[0].Y == guest.PrevCoords.Item2)
                        {
                            desVectorX = guest.X - guest.LastCrossRoad.Item1;
                            desVectorY = guest.Y - guest.LastCrossRoad.Item2;
                            guest.Status = GuestStatus.Stuck;
                        }

                        bool goRightThanLeft = desVectorY <= 0;
                        bool goUpThanDown = desVectorX >= 0;
                        bool isGoHorizontal = Math.Abs(desVectorY) <= Math.Abs(desVectorX);
                        
                        if(isGoHorizontal)
                        {
                            Debug.WriteLine("isGoHorizontal");
                            if (goUpThanDown)
                            {
                                Debug.WriteLine("isGoUp");
                                if (GoUp(roadsAround, guest)) { }
                                else
                                {
                                    if(goRightThanLeft)
                                    {
                                        if (GoRight(roadsAround, guest)) { }
                                        else if (GoLeft(roadsAround, guest)) { }
                                        else if(GoDown(roadsAround,guest)) { }
                                    }
                                    else
                                    {
                                        if (GoLeft(roadsAround, guest)) { }
                                        else if (GoRight(roadsAround, guest)) { }
                                        else if (GoDown(roadsAround, guest)) { }
                                    }
                                }
                            }
                            else
                            {
                                if (GoDown(roadsAround, guest)) { }
                                else
                                {
                                    if (goRightThanLeft)
                                    {
                                        if (GoRight(roadsAround, guest)){ }
                                        else if (GoLeft(roadsAround, guest)) { }
                                        else if(GoUp(roadsAround, guest)) { }
                                    }
                                    else
                                    {
                                        if (GoLeft(roadsAround, guest)) { }
                                        else if (GoRight(roadsAround, guest)) { }
                                        else if (GoUp(roadsAround, guest)) { }
                                    }
                                }
                            }
                        }
                        else //isGoVertical
                        {
                            Debug.WriteLine("isGoVertical");
                            if (goRightThanLeft)
                            {
                                if (GoRight(roadsAround, guest)) { }
                                else
                                {
                                    if (goUpThanDown)
                                    {
                                        if (GoUp(roadsAround, guest)) { }
                                        else if (GoDown(roadsAround, guest)) { }
                                        else if (GoLeft(roadsAround, guest)) { }
                                    }
                                    else
                                    {
                                        if (GoDown(roadsAround, guest)) { }
                                        else if (GoUp(roadsAround, guest)) { }
                                        else if (GoLeft(roadsAround, guest)) { }

                                    }
                                }
                            }
                            else
                            {
                                Debug.WriteLine("isGoLeft");
                                //go left
                                if (GoLeft(roadsAround, guest)) { }
                                else
                                {
                                    if (goUpThanDown)
                                    {
                                        if (GoUp(roadsAround, guest)) { }
                                        else if (GoDown(roadsAround, guest)) { }
                                        else if (GoRight(roadsAround, guest)) { }
                                    }
                                    else
                                    {
                                        if (GoDown(roadsAround, guest)) { }
                                        else if (GoUp(roadsAround, guest)) { }
                                        else if (GoRight(roadsAround, guest)) { }
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }
        }

        private void EnterElement(Guest guest, Building building)
        {
            guestList.Remove(guest);
            guest.Status = GuestStatus.Waiting;
            building.WaitingList.Add(guest);
            if (building.WaitingList.Count >= building.MinCapacity)
            {
                StartElement(building);
            }
        }

        private void StartElement(Building building)
        {
            building.Status = ElementStatus.Operate;
            building.UserList = building.WaitingList.ToList();
            building.UserList.ForEach(item => item.Status = GuestStatus.Busy);
            building.WaitingList.Clear();
            OnElementChanged(building);

            SetInterval(GameUseTime, () =>
            {
                building.Status = ElementStatus.InWaiting;
                OnElementChanged(building);
            });

            /*
            foreach(Guest guest in building.UserList)
            {
                guest.X = guest.Destination.Item1;
                guest.Y = guest.Destination.Item2;
                guest.Status = GuestStatus.Aimless;
                guest.Money -= building.UseCost;
                guest.Mood += building.Modifier;
                guestList.Add(guest);
            }
            building.UserList.Clear();
            FindDestination(); */
        }

        private void AddGuest()
        {
            var entrance = parkElementList.Find(item => item.GetType() == typeof(Entrance));
            bool hasGame = ParkElementList.Exists(item => item.GetType().IsSubclassOf(typeof(Game)));
            bool hasRoad = ParkElementList.Exists(item => item.GetType() == typeof(Road));
            if (hasRoad && hasGame)
            {
                if (!GuestList.Exists(item => item.X == entrance.X - 1 && item.Y == entrance.Y))
                {
                    Guest newGuest = new Guest(entrance.X - 1, entrance.Y, false);
                    newGuest.PrevCoords = (entrance.X - 1, entrance.Y);
                    guestList.Add(newGuest);
                }
            }
        }

        public void Build(Int32 x, Int32 y,Int32 selectedTab,Int32 cost,Int32 minCapacity)
        {
            if (isParkOpen)
                return;

            ParkElement newElement = null;
            switch (selectedTab)
            {
                case 0:
                    newElement = new RollerCoaster(x,y,minCapacity,10,GameBuildCost,cost,GameUseTime,GameMaintainCost);
                    break;
                case 1:
                    newElement = new GiantWheel(x, y, minCapacity, 10, GameBuildCost, cost, GameUseTime, GameMaintainCost);
                    break;
                case 2:
                    newElement = new Carousel(x, y, minCapacity, 10, GameBuildCost, cost, GameUseTime, GameMaintainCost);
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
                case 10:
                    newElement = new Entrance(x,y);
                    break;
            }

            if(newElement != null)
            {
                if(cash - newElement.BuildCost >= 0)
                {
                    cash -= newElement.BuildCost;
                    outcome += newElement.MaintainCost + newElement.BuildCost;
                    OnCashChanged();

                    SetInterval(BuildTime, () =>
                    {
                        newElement.Status = ElementStatus.InWaiting;
                        OnElementChanged(newElement);
                    });
                    parkElementList.Add(newElement);
                    OnElementChanged(newElement);
                }
                else
                {
                    OnNotEnoughCash();
                }
            }
        }

        private void OnNotEnoughCash()
        {
            if(NotEnoughCash != null)
            {
                NotEnoughCash(this, EventArgs.Empty);
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

        private double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(Math.Abs(x1 - x2), 2) + Math.Pow(Math.Abs(y1 - y2), 2));
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

        public void MaintainCostPay()
        {
            parkElementList
                .ForEach(item =>{
                    Cash -= item.MaintainCost;
                    outcome += item.MaintainCost;
                });
            OnCashChanged();
        }

    }
}
