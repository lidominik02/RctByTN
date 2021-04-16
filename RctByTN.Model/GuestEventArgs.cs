using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public class GuestEventArgs : EventArgs
    {
        public Guest Guest { get; set; }

        public GuestEventArgs(Guest guest)
        {
            Guest = guest;
        }
    }
}
