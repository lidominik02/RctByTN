using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public class ParkElementEventArgs : EventArgs
    {
        private ParkElement _element;

        public ParkElement Element { get { return _element; } }

        public ParkElementEventArgs(ParkElement element)
        {
            _element = element;
        }
    }
}
