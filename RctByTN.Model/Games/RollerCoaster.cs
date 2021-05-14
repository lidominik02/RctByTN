using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public class RollerCoaster : Game
    {
        public RollerCoaster(int x, int y, int minCapacity, int maxCapacity, int buildCost, int useCost, int useTime, int maintainCost, int ticketPrice)
            : base(x, y, minCapacity, maxCapacity, buildCost, useCost, useTime, maintainCost, ticketPrice)
        {
        }

        public override void ModifyGuest(Guest guest)
        {
            base.ModifyGuest(guest);
            guest.Mood += 20;
        }
    }
}
