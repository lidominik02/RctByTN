using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public abstract class Restaurant : Building
    {
        public Restaurant(int x, int y, int maxCapacity, int buildCost, int useCost, int serviceTime, int maintainCost, int foodCost) : base(x,y,0,maxCapacity,buildCost,useCost,serviceTime,maintainCost,foodCost)
        {
            this.AreaSize = 4;
        }

        public override void ModifyGuest(Guest guest)
        {
            guest.Mood += 10;
            guest.Money -= ServiceCost;
        }
    }
}
