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
        protected Int32 maintainCost;
        protected Int32 areaSize;
        protected ElementStatus status;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int BuildCost { get => buildCost; set => buildCost = value; }
        public int MaintainCost { get => maintainCost; set => maintainCost = value; }
        public ElementStatus Status { get => status; set => status = value; }
        public int AreaSize { get => areaSize; set => areaSize = value; }

        public ParkElement(Int32 x, Int32 y, Int32 buildcost, Int32 maintainCost)
        {
            this.X = x;
            this.Y = y;
            this.BuildCost = buildcost;
            this.MaintainCost = maintainCost;
            this.Status = ElementStatus.InBuild;
            this.AreaSize = 1;
        }

        public abstract void ModifyGuest(Guest guest);
    }
}
