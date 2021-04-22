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
        private int intolerance;
        private bool hasCoupon;
        private GuestStatus status;
        private (int, int) destination;
        private (int, int) prevCoords;
        private (int, int) lastCrossRoad;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Hunger { get => hunger; set { hunger = value > 0 ? (value > 100 ? 100 : value) : 0; } }
        public int Mood { get => mood; set { mood = value > 0 ? (value > 100 ? 100 : value) : 0; } }
        public int Money { get => money; set { money = value > 0 ? value : 0; } }
        public int Intolerance { get => intolerance; set { intolerance = value > 0 ? value : 0; } }
        public GuestStatus Status { get => status; set => status = value; }
        public bool HasCoupon { get => hasCoupon; set => hasCoupon = value; }
        public (int, int) Destination { get => destination; set => destination = value; }
        public (int, int) LastCrossRoad { get => lastCrossRoad; set => lastCrossRoad = value; }
        public (int, int) PrevCoords { get => prevCoords; set => prevCoords = value; }
        

        public Guest(int x, int y, int money,bool hasCoupon)
        {
            X = x;
            Y = y;
            HasCoupon = hasCoupon;
            Money = money;
            Hunger = 100; // 100/100 hungry
            Mood = 100;// 100/100 happy
            Status = GuestStatus.Aimless;
            Destination = (-1, -1);
            LastCrossRoad = (-1, -1);
            Intolerance = 0;
        }
    }
}
