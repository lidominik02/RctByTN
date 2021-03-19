using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    abstract class Game : ParkElement
    {
        protected Int32 minCapacity;
        protected Int32 maxCapacity;
        protected Int32 ticketCost;
        //protected Int32 maintainCost;

        public Game(int x, int y, int minCapacity, int maxCapacity, int buildcost, int ticketCost, int maintainCost) : base(x, y, buildcost, maintainCost)
        {
            this.minCapacity = minCapacity;
            this.maxCapacity = maxCapacity;
            this.ticketCost = ticketCost;
            this.AreaSize = 4;
            //this.maintainCost = maintainCost;
        }

        public override void ModifyGuest(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
