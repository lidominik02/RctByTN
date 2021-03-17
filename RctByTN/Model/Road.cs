using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    class Road : ParkElement
    {
        public Road(int x, int y, int buildcost) : base(x, y, buildcost)
        {
        }

        public override void ModifyGuest(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}
