using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    class RctModel
    {
        private bool isParkOpen;
        private Int32 cash;
        private Int32 income;
        private Int32 outcome;
        private List<Guest> guestList;
        private List<ParkElement> parkElementList;

        public bool IsParkOpen { get => isParkOpen; set => isParkOpen = value; }
        public int Cash { get => cash; set => cash = value; }
        public int Income { get => income; set => income = value; }
        public int Outcome { get => outcome; set => outcome = value; }
        public List<Guest> GuestList { get => guestList; set => guestList = value; }
        public List<ParkElement> ParkElementList { get => parkElementList; set => parkElementList = value; }

        public RctModel()
        {
            GuestList = new List<Guest>();
            ParkElementList = new List<ParkElement>();
            IsParkOpen = false;
            income = outcome = 0;
            //TODO: to find out the amount of starting cash
            //cash = ???
        }
    }
}
