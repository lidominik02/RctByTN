using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    class RctModel
    {
        bool isParkOpen;
        Int32 cash;
        Int32 income;
        Int32 outcome;
        List<Guest> guestList;
        List<ParkElement> parkElementList;

        public bool IsParkOpen { get => isParkOpen; set => isParkOpen = value; }
        public int Cash { get => cash; set => cash = value; }
        public int Income { get => income; set => income = value; }
        public int Outcome { get => outcome; set => outcome = value; }
        internal List<Guest> GuestList { get => guestList; set => guestList = value; }
        internal List<ParkElement> ParkElementList { get => parkElementList; set => parkElementList = value; }

        public RctModel()
        {
            GuestList = new List<Guest>();
            ParkElementList = new List<ParkElement>();
        }
    }
}
