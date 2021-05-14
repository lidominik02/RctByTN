using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public abstract class Game : Building
    {
        public Game(int x, int y, int minCapacity, int maxCapacity, int buildCost, int useCost, int useTime, int maintainCost, int ticketPrice) : base(x, y,minCapacity,maxCapacity, buildCost, useCost, useTime, maintainCost, ticketPrice)
        {
            this.AreaSize = 4;
        }

        public override void ModifyGuest(Guest guest)
        {
            guest.Hunger -= 10;
            if(!guest.HasCoupon)
                guest.Money -= ServiceCost;
        }
    }
}
