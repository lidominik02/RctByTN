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

        #region Data members
        private bool isParkOpen;
        private bool isCampaign;
        private Int32 cash;
        private Int32 income;
        private Int32 outcome;
        private Int32 gameTime;
        private List<Guest> guestList;
        private List<ParkElement> parkElementList;
        private Random rnd;
        #endregion

        #region Constants
        private const Int32 GameBuildCost = 250;
        private const Int32 GameMaintainCost = 50;
        private const Int32 GameUseTime = 5000;
        private const Int32 GameUseCost = 100;
        private const Int32 RestaurantBuildCost = 200;
        private const Int32 RestaurantMaintainCost = 50;
        private const Int32 RestaurantUseTime = 2000;
        private const Int32 RestaurantUseCost = 100;
        private const Int32 RoadBuildCost = 20;
        private const Int32 PlantBuildCost = 100;
        private const Int32 BuildingMaxCapacity = 10;
        private const Int32 BuildTime = 3000;
        private const Int32 CampaignTime = 10000;
        public static Int32 MaintainCostInterval = 5000;
        #endregion

        #region Events
        public event EventHandler<ParkElementEventArgs> ElementChanged;
        public event EventHandler CashChanged;
        public event EventHandler NotEnoughCash;
        public event EventHandler<GuestEventArgs> GuestClicked;
        #endregion

        #region Properties
        public bool IsParkOpen { get => isParkOpen; set => isParkOpen = value; }
        public int Cash { get => cash; private set => cash = value; }
        public int Income { get => income; private set => income = value; }
        public int Outcome { get => outcome; private set => outcome = value; }
        public int GameTime { get => gameTime; private set => gameTime = value; }
        public List<Guest> GuestList { get => guestList; private set => guestList = value; }
        public List<ParkElement> ParkElementList { get => parkElementList; private set => parkElementList = value; }
        public bool IsCampaign { get => isCampaign; private set => isCampaign = value; }
        #endregion

        public RctModel()
        {
            GuestList = new List<Guest>();
            ParkElementList = new List<ParkElement>();
            IsParkOpen = false;
            isCampaign = false;
            income = outcome = 0;
            cash = 10000;
            gameTime = 0;
            rnd = new Random();
        }

        public void TimeElapsed()
        {
            gameTime++; 
            //FindDestination();
            MoveGuests();
            parkElementList.ForEach(item =>
            {
                if (item.GetType().IsSubclassOf(typeof(Building)))
                {
                    EnterWaitingGuestsToBuilding(item as Building);
                    if (gameTime % 7 == 0)
                        IncreaseWaitingGuestIntolerance(item as Building);
                    if(gameTime % 3 == 0)
                    {
                        ModifyWaitingGuestMood(item as Building);
                    }
                }
                else if(item.GetType().IsSubclassOf(typeof(Plant)))
                {
                    RoadsAround(item.X,item.Y).ForEach(road => 
                    {
                        guestList.Where(guest => guest.X == road.X && guest.Y == road.Y)
                                 .ToList()
                                 .ForEach(guest => item.ModifyGuest(guest));
                    });
                }
            });
            if (gameTime % 5 == 0)
            {
                AddGuest();
                MaintainCostPay();
            }
            if(isCampaign)
            {
                AddGuest();
            }

            guestList.ForEach(guest => {
                guest.Hunger--;
                guest.Mood--;
            });
        }

        public void StartCampaign()
        {
            isCampaign = true;
            SetInterval(CampaignTime,() => isCampaign = false);
        }

        private List<T> GetSpecificTypesFromParkElementList<T>() where T : ParkElement =>
            ParkElementList.Where(p => p.GetType().IsSubclassOf(typeof(T))).Cast<T>().ToList();

        private void FindDestination()
        {
            //TODO
            //add priorities for cheaper games/restaurants
            //games without path can't be destiantion
            foreach (Guest guest in GuestList.ToList())
            {
                if (guest.Status == GuestStatus.Searching)
                    continue;
                List<Game> games = GetSpecificTypesFromParkElementList<Game>();
                List<Restaurant> restaurants = GetSpecificTypesFromParkElementList<Restaurant>();
                //if guest is hungry
                if ((guest.Hunger < guest.Mood-30) && restaurants.Any())
                {
                        var rndRest = restaurants[rnd.Next(restaurants.Count)];
                        guest.Destination = (rndRest.X, rndRest.Y+1);
                        guest.Status = GuestStatus.Searching;
                        Debug.Write("Restaurant dest");
                        continue;
                }
                //if guest is bored
                else if (games.Any())
                {
                    
                    var exps = games.Where(game => game.UseCost >= guest.Money * 0.6 && game.UseCost <= guest.Money*0.9).ToList();
                    if (exps.Any())
                    {
                        var rndGame = exps[rnd.Next(exps.Count)];
                        Debug.WriteLine("g.money:{0} g.cost:{1} money*0.6:{2}", guest.Money, rndGame.UseCost, guest.Money * 0.6);
                        guest.Destination = (rndGame.X, rndGame.Y + 1);
                        guest.Status = GuestStatus.Searching;
                        Debug.Write("expensive chosen");
                        continue;
                    }
                    var meds = games.Where(game => game.UseCost >= guest.Money * 0.4 && game.UseCost < guest.Money*0.6).ToList();
                    if (meds.Any())
                    {
                        var rndGame = meds[rnd.Next(meds.Count)];
                        guest.Destination = (rndGame.X, rndGame.Y + 1);
                        guest.Status = GuestStatus.Searching;
                        Debug.Write("mid chosen");
                        continue;
                    }
                    var cheaps = games.Where(game => game.UseCost < guest.Money).ToList();
                    if (cheaps.Any())
                    {
                        var rndGame = cheaps[rnd.Next(cheaps.Count)];
                        guest.Destination = (rndGame.X, rndGame.Y + 1);
                        guest.Status = GuestStatus.Searching;
                        Debug.Write("Cheap chosen");
                        continue;
                    }
                    //Debug.WriteLine("des: x:{0} y:{1}", guest.Destination.Item1, guest.Destination.Item2);
                    //Debug.WriteLine("g: x:{0} y:{1}", guest.X, guest.Y);
                }
                Debug.WriteLine("-----leaving------");
                guest.Destination = (11, 11);
                guest.Status = GuestStatus.Searching;
            }
        }

        #region Guest Moving functions
        private void MoveGuests()
        {
            foreach (Guest guest in guestList.ToList())
            {
                var desVectorX = guest.X - guest.Destination.Item1;
                var desVectorY = guest.Y - guest.Destination.Item2;
                Debug.WriteLine("------Guest destination: x:{0} y:{1}", guest.Destination.Item1, guest.Destination.Item2);
                Debug.WriteLine("------Guest current pos: x:{0} y:{1}", guest.X, guest.Y);

                if ((guest.X, guest.Y) == guest.Destination)
                {
                    //Debug.Write("----------dest reached----------");
                    //Debug.WriteLine("guest dest: {0} {1}", guest.Destination.Item1, guest.Destination.Item2);
                    if (guest.Destination == (11, 11))
                    {
                        Debug.Write("----------entrance entered----------");
                        guestList.Remove(guest);
                        continue;
                    }
                    var destinationBuilding = ParkElementList.Find(item => item.X == guest.Destination.Item1 && item.Y == (guest.Destination.Item2 - 1));
                    EnterGuestToBuilding(guest, destinationBuilding as Building);
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

                    Debug.WriteLine("desVector: ({0},{1})", desVectorX, desVectorY);

                    if (!(desVectorX == 0 && desVectorY == 0))
                    {
                        Debug.WriteLine("desVectorX != 0 && desVectorY != 0");
                        var roadsAround = RoadsAround(guest.X, guest.Y);

                        if (roadsAround.Count >= 3)
                        {
                            guest.LastCrossRoad = (guest.X, guest.Y);
                        }

                        roadsAround.ForEach(item => Debug.WriteLine("roads: {0} {1}", item.X, item.Y));
                        if (roadsAround.Count > 1)
                        {
                            roadsAround.Remove(roadsAround.Find(item => item.X == guest.PrevCoords.Item1 && item.Y == guest.PrevCoords.Item2));
                        }
                        else if (roadsAround.Count == 1 && roadsAround[0].X == guest.PrevCoords.Item1 && roadsAround[0].Y == guest.PrevCoords.Item2)
                        {
                            desVectorX = guest.X - guest.LastCrossRoad.Item1;
                            desVectorY = guest.Y - guest.LastCrossRoad.Item2;
                            guest.Status = GuestStatus.Stuck;
                        }

                        bool goRightThanLeft = desVectorY <= 0;
                        bool goUpThanDown = desVectorX >= 0;
                        bool isGoHorizontal = Math.Abs(desVectorY) <= Math.Abs(desVectorX);

                        if (isGoHorizontal)
                        {
                            Debug.WriteLine("isGoHorizontal");
                            if (goUpThanDown)
                            {
                                Debug.WriteLine("isGoUp");
                                if (GoUp(roadsAround, guest)) { }
                                else
                                {
                                    if (goRightThanLeft)
                                    {
                                        if (GoRight(roadsAround, guest)) { }
                                        else if (GoLeft(roadsAround, guest)) { }
                                        else if (GoDown(roadsAround, guest)) { }
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
                                        if (GoRight(roadsAround, guest)) { }
                                        else if (GoLeft(roadsAround, guest)) { }
                                        else if (GoUp(roadsAround, guest)) { }
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
        #endregion

        private void EnterGuestToBuilding(Guest guest, Building building)
        {
            guestList.Remove(guest);
            guest.Status = GuestStatus.Waiting;
            building.WaitingList.Add(guest);
            if (building.GetType().IsSubclassOf(typeof(Road)))
            {
                guestList.Remove(guest);
            }
            EnterWaitingGuestsToBuilding(building);
        }

        private void EnterWaitingGuestsToBuilding(Building building)
        {
            int numberOfTheEnteringGuest = -1;

            if (building.WaitingList.Count >= building.MaxCapacity)
                numberOfTheEnteringGuest = building.MaxCapacity;
            else if (building.WaitingList.Count >= building.MinCapacity && building.WaitingList.Count > 0)
                numberOfTheEnteringGuest = building.WaitingList.Count;

            if (building.Status == ElementStatus.InWaiting && numberOfTheEnteringGuest != -1)
            {
                building.Status = ElementStatus.Operate;
                building.UserList = building.WaitingList.Take(numberOfTheEnteringGuest).ToList();
                building.WaitingList = building.WaitingList.Except(building.UserList).ToList();
                building.UserList.ForEach(item => item.Status = GuestStatus.Busy);
                OnElementChanged(building);

                SetInterval(building.UseTime , () =>
                {
                    building.Status = ElementStatus.InWaiting;
                    Cash -= building.UseCost;
                    //building.UserList.Clear();
                    OnElementChanged(building);
                    
                    foreach (Guest guest in building.UserList.ToList())
                    {
                        guest.X = guest.Destination.Item1;
                        guest.Y = guest.Destination.Item2;
                        guest.Status = GuestStatus.Aimless;
                        building.ModifyGuest(guest);
                        Cash += building.UseCost;
                        guestList.Add(guest);
                    }
                    building.UserList.Clear();
                    FindDestination();
                    OnElementChanged(building);  
                }); 
            }
        }

        private void IncreaseWaitingGuestIntolerance(Building building)
        {
            building.WaitingList.ForEach(guest => 
            {
                guest.Intolerance++;
            });
        }

        private void ModifyWaitingGuestMood(Building building)
        {
            foreach(Guest guest in building.WaitingList.ToList())
            {
                guest.Mood -= guest.Intolerance * 10;
                if (guest.Mood <= 0)
                {
                    guest.X = guest.Destination.Item1;
                    guest.Y = guest.Destination.Item2;
                    guest.Destination = (11, 11);
                    guest.Status = GuestStatus.Searching;
                    building.WaitingList.Remove(guest);
                    guestList.Add(guest);
                }
            }
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
                    Guest newGuest = new Guest(entrance.X - 1, entrance.Y, isCampaign ? gameTime % 2 == 0 : false);
                    newGuest.PrevCoords = (entrance.X - 1, entrance.Y);
                    guestList.Add(newGuest);
                    FindDestination();
                }
            }
        }

        public void Build(Int32 x, Int32 y,Int32 selectedTab,Int32 cost,Int32 minCapacity)
        {
            Guest result = guestList.Find(guest => guest.X == x && guest.Y == y);
            if(result!=null)
            OnGuestClicked(result);
                
            if (isParkOpen)
                return;

            ParkElement newElement = null;
            switch (selectedTab)
            {
                case 0:
                    newElement = new RollerCoaster(x,y,minCapacity,BuildingMaxCapacity,GameBuildCost,GameUseCost,GameUseTime,GameMaintainCost,cost);
                    break;
                case 1:
                    newElement = new GiantWheel(x, y, minCapacity, BuildingMaxCapacity, GameBuildCost, GameUseCost, GameUseTime, GameMaintainCost, cost);
                    break;
                case 2:
                    newElement = new Carousel(x, y, minCapacity, BuildingMaxCapacity, GameBuildCost, GameUseCost, GameUseTime, GameMaintainCost, cost);
                    break;
                case 3:
                    newElement = new HotDogVendor(x, y, BuildingMaxCapacity,RestaurantBuildCost, RestaurantUseCost, RestaurantUseTime, RestaurantMaintainCost, cost);
                    break;
                case 4:
                    newElement = new IceCreamVendor(x, y, BuildingMaxCapacity, RestaurantBuildCost, RestaurantUseCost, RestaurantUseTime, RestaurantMaintainCost, cost);
                    break;
                case 5:
                    newElement = new CottonCandyVendor(x, y, BuildingMaxCapacity, RestaurantBuildCost, RestaurantUseCost, RestaurantUseTime, RestaurantMaintainCost, cost);
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

        private List<ParkElement> RoadsAround(double x,double y)
        {
            return parkElementList.Where(item =>
            {
                return item.GetType() == typeof(Road)
                && Distance(item.X, item.Y, x, y) == 1;
            }).ToList();
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

        #region Private event methods
        private void OnNotEnoughCash()
        {
            if (NotEnoughCash != null)
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
            if (CashChanged != null)
            {
                CashChanged(this, EventArgs.Empty);
            }
        }

        private void OnGuestClicked(Guest guest)
        {
            if (GuestClicked != null)
            {
                GuestClicked(this, new GuestEventArgs(guest));
            }
        }
        #endregion

    }
}
