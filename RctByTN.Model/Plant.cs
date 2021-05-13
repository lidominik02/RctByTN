using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public abstract class Plant : ParkElement
    {
        public Plant(int x, int y, int buildcost, int maintainCost) : base(x, y, buildcost, maintainCost)
        {
        }

        public override void ModifyGuest(Guest guest)
        {
            /*
            var rnd = new Random();
            if(rnd.Next(5) == 3)
                guest.Mood++; */
            guest.Mood += 5;
        }
    }
}
