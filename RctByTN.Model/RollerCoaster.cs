using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public class RollerCoaster : Game
    {
        public RollerCoaster(int x, int y, int minCapacity, int maxCapacity, int buildcost, int ticketCost, int useTime, int maintainCost) : base(x, y, minCapacity, maxCapacity, buildcost, ticketCost, useTime,maintainCost)
        { }
    }
}
