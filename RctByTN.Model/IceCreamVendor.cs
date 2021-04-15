using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public class IceCreamVendor : Restaurant
    {
        public IceCreamVendor(int x, int y, int buildcost, int maxCapacity, int maintainCost, int serviceTime, int foodCost) : base(x, y, buildcost, maxCapacity, maintainCost, serviceTime, foodCost)
        { }
    }
}
