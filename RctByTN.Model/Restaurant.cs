using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public abstract class Restaurant : Building
    {
        public Restaurant(int x, int y, int buildcost, int maxCapacity, int maintainCost, int serviceTime, int foodCost) : base(x,y,0,maxCapacity,buildcost,foodCost,serviceTime,maintainCost)
        {
            this.AreaSize = 4;
        }

        public override void ModifyGuest(Guest guest)
        {
            guest.Hunger += 30;
            guest.Mood+=10;
            guest.Money -= UseCost;
        }
    }
}
