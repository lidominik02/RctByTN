using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public abstract class ParkElement
    {
        protected Int32 x;
        protected Int32 y;
        protected Int32 buildCost;
        protected ElementStatus status;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int BuildCost { get => buildCost; set => buildCost = value; }
        public ElementStatus Status { get => status; set => status = value; }

        public ParkElement(Int32 x, Int32 y, Int32 buildcost)
        {
            this.X = x;
            this.Y = y;
            this.BuildCost = buildcost;
        }

        public abstract void ModifyGuest(Guest guest);
    }
}
