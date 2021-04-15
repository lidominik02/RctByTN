using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public class Entrance : Road
    {
        public Entrance(int x, int y) : base(x, y, 0, 0)
        {
        }

        public override void ModifyGuest(Guest guest)
        {
            base.ModifyGuest(guest);
        }
    }
}
