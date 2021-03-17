using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    abstract class Restaurant : ParkElement
    {
        protected int maxCapacity;
        protected int maintainCost;
        protected int serviceTime;
        protected int foodCost;
        public Restaurant(int x, int y, int buildcost, int maxCapacity, int maintainCost, int serviceTime, int foodCost) : base(x, y, buildcost)
        {
            this.maxCapacity = maxCapacity;
            this.maintainCost = maintainCost;
            this.serviceTime = serviceTime;
            this.foodCost = foodCost;
        }

        public override void ModifyGuest(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
