using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public abstract class Game : Building
    {
        public Game(int x, int y, int minCapacity, int maxCapacity, int buildcost, int usecost, int usetime, int maintainCost) : base(x, y,minCapacity,maxCapacity, buildcost, usecost, usetime, maintainCost)
        {
            this.AreaSize = 4;
        }

        public override void ModifyGuest(Guest guest)
        {
            guest.Mood += 3;
            guest.Hunger--;
            guest.Money -= UseCost;
        }
    }
}
