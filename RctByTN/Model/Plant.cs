﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    abstract class Plant : ParkElement
    {
        public Plant(int x, int y, int buildcost) : base(x, y, buildcost)
        {
        }

        public override void ModifyGuest(Guest guest)
        {
            throw new NotImplementedException();
        }
    }
}