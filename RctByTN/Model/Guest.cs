using System;
using System.Collections.Generic;
using System.Text;

namespace RctByTN.Model
{
    public class Guest
    {
        private int x;
        private int y;
        private int hunger;
        private int mood;
        private int money;
        private GuestStatus status;
        private bool hasCoupon;
        private (int,int) destination;

        public int X { get; set; }
        public int Y { get; set; }
        public int Money { get; set; }
        public int Hunger { get; set; }
        public int Mood { get; set; }
        public GuestStatus Status { get; set; }
        public bool HasCoupon { get; set; }
        public (int,int) Destination { get; set; }

        public Guest(int x, int y, bool hasCoupon)
        {
            X = x;
            Y = y;
            HasCoupon = HasCoupon;
            Money = 500;
            Hunger = 10; // 10/10 not hungry
            Mood = 5;// 10/10 happy
            Status = GuestStatus.Aimless;
        }
    }
}
