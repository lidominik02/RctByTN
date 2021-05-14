using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public class HotDogVendor : Restaurant
    {
        public HotDogVendor(int x, int y, int maxCapacity, int buildCost, int useCost, int serviceTime, int maintainCost, int foodCost) : base(x, y, maxCapacity, buildCost, useCost, serviceTime, maintainCost, foodCost)
        {
        }

        public override void ModifyGuest(Guest guest)
        {
            base.ModifyGuest(guest);
            guest.Hunger += 10;
        }
    }
}
