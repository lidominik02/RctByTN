using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public abstract class Building : ParkElement
    {
        protected List<Guest> _waitingList;
        protected List<Guest> _userList;
        protected int _minCapacity;
        protected int _maxCapacity;
        protected int _useCost;
        protected int _useTime;
        protected int _modifier;

        public List<Guest> WaitingList { get => _waitingList; set => _waitingList = value; }
        public List<Guest> UserList { get => _userList; set => _userList = value; }
        public int MinCapacity { get => _minCapacity; set => _minCapacity = value; }
        public int MaxCapacity { get => _maxCapacity; set => _maxCapacity = value; }
        public int UseCost { get => _useCost; set => _useCost = value; }
        public int UseTime { get => _useTime; set => _useTime = value; }
        public int Modifier { get => _modifier; set => _modifier = value; }


        public Building(int x, int y, int minCapacity, int maxCapacity, int buildcost, int usecost, int usetime, int maintainCost) : base(x,y,buildcost,maintainCost)
        {
            this.MinCapacity = minCapacity;
            this.MaxCapacity = maxCapacity;
            this.UseCost = usecost;
            this.UseTime = usetime;
            this.Modifier = 20;
            this.WaitingList = new List<Guest>();
            this.UserList = new List<Guest>();
        }
    }
}
