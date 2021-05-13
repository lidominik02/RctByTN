using Microsoft.VisualStudio.TestTools.UnitTesting;
using RctByTN.Model;
using System;
using System.Linq;
using System.Threading;

namespace RctByTN.Test
{
    [TestClass]
    public class RctModelTest
    {
        private RctModel _model;
        private Random _rnd;

        [TestInitialize]
        public void Initialize()
        {
            _model = new RctModel();
        }

        [TestMethod]
        public void RctModelConstructorTest()
        {
            Assert.AreEqual(_model.IsParkOpen,false);
            Assert.AreEqual(_model.Income, 0);
            Assert.AreEqual(_model.Outcome, 0);
            Assert.AreEqual(_model.Cash, 10000);
            Assert.AreEqual(_model.GameTime, 0);
            Assert.AreEqual(_model.GuestList.Count, 0);
            Assert.AreEqual(_model.ParkElementList.Count, 0);
        }
        
        #region Build tests
        [TestMethod]
        public void RctModelBuildRoadTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11,11,6,0,0);
            bool isRoadBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Road));
            Assert.IsTrue(isRoadBuilded);
        }

        [TestMethod]
        public void RctModelBuildRoadTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            var road = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Road));

            Assert.AreEqual(road.Status,ElementStatus.InBuild);
            Thread.Sleep(4000);
            Assert.AreEqual(road.Status, ElementStatus.InWaiting);
        }

        [TestMethod]
        public void RctModelBuildRollerCoasterTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 0, 0, 0);
            bool isRollerCoasterBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(RollerCoaster));
            Assert.IsTrue(isRollerCoasterBuilded);
        }

        [TestMethod]
        public void RctModelBuildRollerCoasterTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 0, 0, 0);
            var rollerCoaster = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(RollerCoaster)) as RollerCoaster;

            Assert.AreEqual(rollerCoaster.Status, ElementStatus.InBuild,"InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(rollerCoaster.Status, ElementStatus.InWaiting,"InWaiting status test");
            Assert.AreEqual(rollerCoaster.ServiceCost,0,"UseCost test");
            Assert.AreEqual(rollerCoaster.MinCapacity, 0,"Mincost test");
        }

        [TestMethod]
        public void RctModelBuildGiantWheelTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 1, 0, 0);
            bool isGiantWheelBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(GiantWheel));
            Assert.IsTrue(isGiantWheelBuilded);
        }

        [TestMethod]
        public void RctModelBuildGiantWheelTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 1, 0, 0);
            var giantWheel = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(GiantWheel)) as GiantWheel;

            Assert.AreEqual(giantWheel.Status, ElementStatus.InBuild, "InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(giantWheel.Status, ElementStatus.InWaiting, "InWaiting status test");
            Assert.AreEqual(giantWheel.ServiceCost, 0, "UseCost test");
            Assert.AreEqual(giantWheel.MinCapacity, 0, "Mincost test");
        }

        [TestMethod]
        public void RctModelBuildCarouselTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 2,0, 0);
            bool isCarouselBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Carousel));
            Assert.IsTrue(isCarouselBuilded);
        }

        [TestMethod]
        public void RctModelBuildCarouselTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 2, 0, 0);
            var carousel = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Carousel)) as Carousel;

            Assert.AreEqual(carousel.Status, ElementStatus.InBuild, "InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(carousel.Status, ElementStatus.InWaiting, "InWaiting status test");
            Assert.AreEqual(carousel.ServiceCost, 0, "UseCost test");
            Assert.AreEqual(carousel.MinCapacity, 0, "Mincost test");
        }

        [TestMethod]
        public void RctModelBuildHotDogVendorTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 3, 0, 0);
            bool isHotDogVendorBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(HotDogVendor));
            Assert.IsTrue(isHotDogVendorBuilded);
        }

        [TestMethod]
        public void RctModelBuildHotDogVendorTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 3, 0, 0);
            var hotDogVendor = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(HotDogVendor)) as HotDogVendor;

            Assert.AreEqual(hotDogVendor.Status, ElementStatus.InBuild, "InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(hotDogVendor.Status, ElementStatus.InWaiting, "InWaiting status test");
            Assert.AreEqual(hotDogVendor.ServiceCost, 0, "UseCost test");
            Assert.AreEqual(hotDogVendor.MinCapacity, 0, "Mincost test");
        }

        [TestMethod]
        public void RctModelBuildIceCreamVendorTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 4, 0, 0);
            bool isIceCreamVendorBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(IceCreamVendor));
            Assert.IsTrue(isIceCreamVendorBuilded);
        }

        [TestMethod]
        public void RctModelBuildIceCreamVendorTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 4, 0, 0);
            var iceCreamVendor = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(IceCreamVendor)) as IceCreamVendor;

            Assert.AreEqual(iceCreamVendor.Status, ElementStatus.InBuild, "InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(iceCreamVendor.Status, ElementStatus.InWaiting, "InWaiting status test");
            Assert.AreEqual(iceCreamVendor.ServiceCost, 0, "UseCost test");
            Assert.AreEqual(iceCreamVendor.MinCapacity, 0, "Mincost test");
        }

        [TestMethod]
        public void RctModelBuildCottonCandyVendorTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 5, 0, 0);
            bool isCottonCandyVendorBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(CottonCandyVendor));
            Assert.IsTrue(isCottonCandyVendorBuilded);
        }

        [TestMethod]
        public void RctModelBuildCottonCandyVendorTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 5, 0, 0);
            var cottonCandyVendor = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(CottonCandyVendor)) as CottonCandyVendor;

            Assert.AreEqual(cottonCandyVendor.Status, ElementStatus.InBuild, "InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(cottonCandyVendor.Status, ElementStatus.InWaiting, "InWaiting status test");
            Assert.AreEqual(cottonCandyVendor.ServiceCost, 0, "UseCost test");
            Assert.AreEqual(cottonCandyVendor.MinCapacity, 0, "Mincost test");
        }

        [TestMethod]
        public void RctModelBuildGrassTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 7, 0, 0);
            bool isGrassBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Grass));
            Assert.IsTrue(isGrassBuilded);
        }

        [TestMethod]
        public void RctModelBuildGrassTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 7, 0, 0);
            var grass = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Grass)) as Grass;

            Assert.AreEqual(grass.Status, ElementStatus.InBuild, "InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(grass.Status, ElementStatus.InWaiting, "InWaiting status test");
            Assert.AreEqual(grass.AreaSize, 1, "AreaSize test");
            Assert.AreEqual(grass.BuildCost, 100, "BuildCost test");
        }

        [TestMethod]
        public void RctModelBuildTreeTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 8, 0, 0);
            bool isTreeBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Tree));
            Assert.IsTrue(isTreeBuilded);
        }

        [TestMethod]
        public void RctModelBuildTreeTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 8, 0, 0);
            var tree = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Tree)) as Tree;

            Assert.AreEqual(tree.Status, ElementStatus.InBuild, "InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(tree.Status, ElementStatus.InWaiting, "InWaiting status test");
            Assert.AreEqual(tree.AreaSize, 1, "AreaSize test");
            Assert.AreEqual(tree.BuildCost, 100, "BuildCost test");
        }

        [TestMethod]
        public void RctModelBuildBushTest_BuildTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 9, 0, 0);
            bool isBushBuilded = _model.ParkElementList
                                .Exists(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Bush));
            Assert.IsTrue(isBushBuilded);
        }

        [TestMethod]
        public void RctModelBuildBushTest_StateTest()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 9, 0, 0);
            var bush = _model.ParkElementList
                .Find(item => item.X == 11 && item.Y == 11 && item.GetType() == typeof(Bush)) as Bush;

            Assert.AreEqual(bush.Status, ElementStatus.InBuild, "InBuild status test");
            Thread.Sleep(4000);
            Assert.AreEqual(bush.Status, ElementStatus.InWaiting, "InWaiting status test");
            Assert.AreEqual(bush.AreaSize, 1, "AreaSize test");
            Assert.AreEqual(bush.BuildCost, 100, "BuildCost test");
        }

        #endregion

        #region Private method tests
        [TestMethod]
        public void RctModel_IsFreeAreaTest_FreeAreaTest()
        {
            _model.ParkElementList.Clear();

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    if (!(i == 12 && j == 11))
                    {
                        Assert.IsFalse(_model.IsNotFreeArea(i, j, 6), "index" + i.ToString() + " " + j.ToString());
                    }
                }
            }
        }

        [TestMethod]
        public void RctModel_IsFreeAreaTest_OneAreaSize1()
        {
            _model.ParkElementList.Clear();
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(10, 7, 7, 0, 0);
            _model.Build(10, 8, 8, 0, 0);
            _model.Build(10, 9, 9, 0, 0);

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    if (i == 10 && j == 10)
                    {
                        Assert.IsTrue(_model.IsNotFreeArea(i, j, 6));
                    }
                    else if (i == 10 && j == 9)
                    {
                        Assert.IsTrue(_model.IsNotFreeArea(i, j, 6));
                    }
                    else if (i == 10 && j == 8)
                    {
                        Assert.IsTrue(_model.IsNotFreeArea(i, j, 6));
                    }
                    else if (i == 10 && j == 7)
                    {
                        Assert.IsTrue(_model.IsNotFreeArea(i, j, 6));
                    }
                    else
                    {
                        Assert.IsFalse(_model.IsNotFreeArea(i, j, 6));
                    }
                }
            }

        }

        [TestMethod]
        public void RctModel_IsFreeAreaTest_OneAreaSize2()
        {
            _model.ParkElementList.Clear();
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(10, 7, 7, 0, 0);
            _model.Build(10, 8, 8, 0, 0);
            _model.Build(10, 9, 9, 0, 0);

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 23; j++)
                {
                    if (i == 10 && j == 10)
                    {
                        Assert.IsTrue(_model.IsNotFreeArea(i, j, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i, j + 1, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i + 1, j, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i + 1, j + 1, 0));
                    }
                    else if (i == 10 && j == 9)
                    {
                        Assert.IsTrue(_model.IsNotFreeArea(i, j, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i, j + 1, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i + 1, j, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i + 1, j + 1, 0));
                    }
                    else if (i == 10 && j == 8)
                    {
                        Assert.IsTrue(_model.IsNotFreeArea(i, j, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i, j + 1, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i + 1, j, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i + 1, j + 1, 0));
                    }
                    else if (i == 10 && j == 7)
                    {
                        Assert.IsTrue(_model.IsNotFreeArea(i, j, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i, j + 1, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i + 1, j, 0));
                        Assert.IsTrue(_model.IsNotFreeArea(i + 1, j + 1, 0));
                    }
                    else
                    {
                        Assert.IsFalse(_model.IsNotFreeArea(i, j, 6));
                    }
                }
            }

        }

        [TestMethod]
        public void RctModel_IsFreeAreaTest_FourAreaSize1()
        {
            _model.ParkElementList.Clear();
            _model.Build(10, 10, 0, 0, 0);

            Assert.IsTrue(_model.IsNotFreeArea(10, 10, 6));
            Assert.IsTrue(_model.IsNotFreeArea(9, 10, 6));
            Assert.IsTrue(_model.IsNotFreeArea(10, 9, 6));
            Assert.IsTrue(_model.IsNotFreeArea(9, 9, 6));
        }

        [TestMethod]
        public void RctModelIsFreeAreaTest_FourAreaSize2()
        {
            _model.ParkElementList.Clear();
            _model.Build(10, 10, 0, 0, 0);

            Assert.IsTrue(_model.IsNotFreeArea(10, 10, 0));
            Assert.IsTrue(_model.IsNotFreeArea(9, 10, 0));
            Assert.IsTrue(_model.IsNotFreeArea(10, 9, 0));
            Assert.IsTrue(_model.IsNotFreeArea(9, 9, 0));

            Assert.IsTrue(_model.IsNotFreeArea(10, 11, 0));
            Assert.IsTrue(_model.IsNotFreeArea(10, 10, 0));
            Assert.IsTrue(_model.IsNotFreeArea(9, 11, 0));
            Assert.IsTrue(_model.IsNotFreeArea(9, 10, 0));

            Assert.IsTrue(_model.IsNotFreeArea(11, 10, 0));
            Assert.IsTrue(_model.IsNotFreeArea(10, 10, 0));
            Assert.IsTrue(_model.IsNotFreeArea(11, 9, 0));
            Assert.IsTrue(_model.IsNotFreeArea(10, 9, 0));

            Assert.IsTrue(_model.IsNotFreeArea(11, 11, 0));
            Assert.IsTrue(_model.IsNotFreeArea(10, 10, 0));
            Assert.IsTrue(_model.IsNotFreeArea(10, 11, 0));
            Assert.IsTrue(_model.IsNotFreeArea(11, 10, 0));
        }

        #endregion

        #region Campaign tests
        [TestMethod]
        public void RctModelCampaignTest1()
        {
            _model.StartCampaign();
            Assert.IsTrue(_model.IsCampaign);
            Thread.Sleep(11000);
            Assert.IsFalse(_model.IsCampaign);
        }
        #endregion

        #region Add guest tests
        [TestMethod]
        public void RctModel_Add_Zero_Guest_Without_Road_Entrance_Or_Game_Test()
        {
            _model.ParkElementList.Clear();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_One_Guest_Without_Road_Entrance_Or_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber,0);
        }

        [TestMethod]
        public void RctModel_Add_Two_Guest_Without_Road_Entrance_Or_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.AddGuest();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Multiple_Guest_Without_Road_Entrance_Or_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.AddGuest();
            _model.AddGuest();
            _model.AddGuest();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Zero_Guest_Without_Road_Or_Entrance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 1, 0, 0);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_One_Guest_Without_Road_Or_Entrance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 1, 0, 0);
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Two_Guest_Without_Road_Or_Entrance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 1, 0, 0);
            _model.AddGuest();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Multiple_Guest_Without_Road_Or_Entrance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 1, 0, 0);
            _model.AddGuest();
            _model.AddGuest();
            _model.AddGuest();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Zero_Guest_Without_Game_Or_Entrance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_One_Guest_Without_Game_Or_Entrance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Two_Guest_Without_Game_Or_Entrance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            _model.AddGuest();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Multiple_Guest_Without_Game_Or_Entrance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            _model.AddGuest();
            _model.AddGuest();
            _model.AddGuest();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Zero_Guest_Without_Game_Or_Road_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_One_Guest_Without_Game_Or_Road_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Two_Guest_Without_Game_Or_Road_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.AddGuest();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Multiple_Guest_Without_Game_Or_Road_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.AddGuest();
            _model.AddGuest();
            _model.AddGuest();
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Zero_Guest_With_Entrance_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_One_Guest_With_Entrance_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Two_Guest_With_Enrtance_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Multiple_Guest_With_Enrtance_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Zero_Guest_With_Road_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_One_Guest_With_Road_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Two_Guest_With_Road_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Multiple_Guest_With_Road_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Zero_Guest_With_Road_And_Enrtance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_One_Guest_With_Road_And_Enrtance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Two_Guest_With_Road_And_Enrtance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_Multiple_Guest_With_Road_And_Enrtance_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }


        [TestMethod]
        public void RctModel_Add_Zero_Guest_With_Road_Enrtance_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 0);
        }

        [TestMethod]
        public void RctModel_Add_One_Guest_With_Road_Enrtance_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 1);
        }

        [TestMethod]
        public void RctModel_Add_Two_Guest_With_Road_Enrtance_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 2);
        }

        [TestMethod]
        public void RctModel_Add_Multiple_Guest_With_Road_Enrtance_And_Game_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 1, 0, 0);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            _model.AddGuest();
            _model.GuestList.ForEach(guest => guest.X--);
            int guestNumber = _model.GuestList.Count;
            Assert.AreEqual(guestNumber, 4);
        }
        #endregion

        #region Enter game tests

        [TestMethod]
        public void RctModel_Game_Modify_RollerCoaster_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 0, 10, 0);

            Thread.Sleep(4000);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Mood = 50;
            int exp = _model.GuestList.First().Mood + 20;
            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10);

            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();

            Thread.Sleep(6000);
            Assert.AreEqual(exp - 1, _model.GuestList.First().Mood, "Mood");
        }

        [TestMethod]
        public void RctModel_Game_Modify_Carousel_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 2, 10, 0);

            Thread.Sleep(4000);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Mood = 50;
            int exp = _model.GuestList.First().Mood + 10;
            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10);

            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();

            Thread.Sleep(6000);
            Assert.AreEqual(exp - 1, _model.GuestList.First().Mood, "Mood");
        }

        [TestMethod]
        public void RctModel_Game_Modify_GiantWheel_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 1, 10, 0);

            Thread.Sleep(4000);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Mood = 50;
            int exp = _model.GuestList.First().Mood + 15;
            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10);

            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();

            Thread.Sleep(6000);
            Assert.AreEqual(exp - 1, _model.GuestList.First().Mood, "Mood");
        }

        [TestMethod]
        public void RctModel_Guest_Enters_Game_It_Starts_Test() 
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            //two blocks of road
            _model.Build(11, 11, 6, 20, 0);
            _model.Build(10, 11, 6, 20, 0);
            //Giant wheel
            _model.Build(10, 10, 1, 0, 0);
            Thread.Sleep(4000);
            _model.AddGuest();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            var building = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10 && item.GetType() == typeof(GiantWheel)) as GiantWheel;
            Assert.AreEqual(0, building.WaitingList.Count);
            Assert.AreEqual(1, building.UserList.Count);
            Assert.AreEqual(ElementStatus.Operate,building.Status);
        }
        
        [TestMethod]
        public void RctModel_Game_Starts_Guest_Mood_Increased()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            //two blocks of road
            _model.Build(11, 11, 6, 20, 0);
            _model.Build(10, 11, 6, 20, 0);
            //Giant wheel
            _model.Build(10, 10, 1, 0, 0);
            Thread.Sleep(4000);
            _model.AddGuest();
            int prevMood = _model.GuestList.First().Mood;
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            Thread.Sleep(6000);
            var building = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10 && item.GetType() == typeof(GiantWheel)) as GiantWheel;
            Assert.IsTrue(prevMood < _model.GuestList.First().Mood);
        }
        
        [TestMethod]
        public void RctModel_Guest_Enters_Game_NeedToWait_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            //two blocks of road
            _model.Build(11, 11, 6, 20, 0);
            _model.Build(10, 11, 6, 20, 0);
            //Giant wheel
            _model.Build(10, 10, 1, 0, 2);
            Thread.Sleep(4000);
            _model.AddGuest();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.AddGuest();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            var building = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10 && item.GetType() == typeof(GiantWheel)) as GiantWheel;
            Assert.AreEqual(ElementStatus.Operate, building.Status);
        }

        
        [TestMethod]
        public void RctModel_Two_Guests_Mood_Increased()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            //two blocks of road
            _model.Build(11, 11, 6, 20, 0);
            _model.Build(10, 11, 6, 20, 0);
            //Giant wheel
            _model.Build(10, 10, 1, 0, 2);
            Thread.Sleep(4000);
            _model.AddGuest();
            _model.GuestList[0].Mood = 50;
            int prevMood1 = _model.GuestList.First().Mood;
            _model.TimeElapsed();
            //the first one has entered the game => second=first
            _model.AddGuest();
            _model.GuestList[1].Mood = 50;
            int prevMood2 = _model.GuestList.First().Mood;
            _model.TimeElapsed();
            _model.TimeElapsed();
            var building = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10 && item.GetType() == typeof(GiantWheel)) as GiantWheel;
            Assert.AreEqual(ElementStatus.Operate, building.Status);
            Thread.Sleep(6000);
            Assert.IsTrue(prevMood2 < _model.GuestList[1].Mood);
            //Thread.Sleep(12000);
            Assert.IsTrue(prevMood1 < _model.GuestList[0].Mood);
        }

        [TestMethod]
        public void RctModel_Two_Guests_Money_Decreased()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            //two blocks of road
            _model.Build(11, 11, 6, 20, 0);
            _model.Build(10, 11, 6, 20, 0);
            //Giant wheel
            _model.Build(10, 10, 1, 100, 2);
            Thread.Sleep(4000);
            _model.AddGuest();
            int prevMoney1 = _model.GuestList[0].Money;
            _model.TimeElapsed();
            //the first one has entered the game => second=first
            _model.AddGuest();
            int prevMoney2 = _model.GuestList[1].Money;
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            var building = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10 && item.GetType() == typeof(GiantWheel)) as GiantWheel;
            Assert.AreEqual(ElementStatus.Operate, building.Status);
            Thread.Sleep(6000);
            Assert.IsTrue(prevMoney1 > _model.GuestList[0].Money);
            Assert.IsTrue(prevMoney2 > _model.GuestList[1].Money);
            //Thread.Sleep(12000);
        }


        [TestMethod]
        public void RctModel_Guest_NeedToWait_Mood_Decreased_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            //two blocks of road
            _model.Build(11, 11, 6, 20, 0);
            _model.Build(10, 11, 6, 20, 0);
            //Giant wheel
            _model.Build(10, 10, 1, 0, 20);
            Thread.Sleep(4000);
            _model.AddGuest();
            int prevMood1 = _model.GuestList.First().Mood;
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.AddGuest();
            int prevMood2 = _model.GuestList.First().Mood;
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            Thread.Sleep(5000);
            var building = _model.ParkElementList
                    .Find(item => item.X == 10 && item.Y == 10 && item.GetType() == typeof(GiantWheel)) as GiantWheel;
            Assert.IsTrue(prevMood1 > building.WaitingList.First().Mood);
            Assert.IsTrue(prevMood2 > building.WaitingList.ElementAt(1).Mood);
        }
        [TestMethod]
        public void RctModel_Guest_Mood_Decreased_Leave_Park_Test()
        {
                _model.ParkElementList.Clear();
                _model.Build(12, 11, 10, 0, 0);
                //two blocks of road
                _model.Build(11, 11, 6, 20, 0);
                _model.Build(10, 11, 6, 20, 0);
                //Giant wheel
                _model.Build(10, 10, 1, 0, 20);
                Thread.Sleep(4000);
                _model.AddGuest();
                _model.GuestList.First().Mood = 0;
                _model.TimeElapsed();
                _model.TimeElapsed();
                _model.TimeElapsed();
                 _model.TimeElapsed();
                var building = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10 && item.GetType() == typeof(GiantWheel)) as GiantWheel;
            Assert.AreEqual(11, _model.GuestList.First().Destination.Item1);
            Assert.AreEqual(11, _model.GuestList.First().Destination.Item2);
        }
        #endregion

        #region FindDestination Test

        [TestMethod]
        public void RctModel_FindDestinationTest_OneGame_Cheap()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 1, 50, 1);

            _model.AddGuest();

            int expX = 10;
            int expY = 11;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX,actX,"X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_OneGame_Mid()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 1, 250, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 500;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 10;
            int expY = 11;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_OneGame_Exp()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 1, 450, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 500;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 10;
            int expY = 11;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_OneGame_TooExp()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 1, 5000, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 500;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 11;
            int expY = 11;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Cheap_And_Exp_Enough_Money()
        {
            // Guest with enough money will choose the expensive game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 350, 1);
            _model.Build(7, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 500;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 10;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;


            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Cheap_And_Exp_Not_Enough_Money()
        {
            // Guest with not enough money will choose the cheaper game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 350, 1);
            _model.Build(7, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 250;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 7;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Cheap_And_Exp_No_Money()
        {
            // Guest with not enough money will choose the cheaper game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 350, 1);
            _model.Build(7, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 0;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 11;
            int expY = 11;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Cheap_And_Mid_Enough_Money()
        {
            // Guest with enough money will choose the expensive game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 250, 1);
            _model.Build(7, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 500;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 10;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;


            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Cheap_And_Mid_Not_Enough_Money()
        {
            // Guest with not enough money will choose the cheaper game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 250, 1);
            _model.Build(7, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 250;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 7;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Cheap_And_Mid_No_Money()
        {
            // Guest with not enough money will choose the cheaper game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 350, 1);
            _model.Build(7, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 0;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 11;
            int expY = 11;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Mid_And_Exp_Enough_Money()
        {
            // Guest with enough money will choose the expensive game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 350, 1);
            _model.Build(7, 9, 1, 250, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 500;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 10;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;


            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Mid_And_Exp_Not_Enough_Money()
        {
            // Guest with not enough money will choose the cheaper game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 350, 1);
            _model.Build(7, 9, 1, 250, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 300;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 7;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_TwoGame_Mid_And_Exp_No_Money()
        {
            // Guest with not enough money will choose the cheaper game
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 9, 1, 350, 1);
            _model.Build(7, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 0;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 11;
            int expY = 11;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_ThreeGame_Exp()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 6, 0, 0);
            _model.Build(6, 11, 6, 0, 0);
            _model.Build(5, 11, 6, 0, 0);
            _model.Build(4, 11, 6, 0, 0);
            _model.Build(4, 10, 6, 0, 0);
            _model.Build(10, 9, 1, 450, 1);
            _model.Build(7, 9, 1, 250, 1);
            _model.Build(4, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 500;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 10;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_ThreeGame_Mid()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 6, 0, 0);
            _model.Build(6, 11, 6, 0, 0);
            _model.Build(5, 11, 6, 0, 0);
            _model.Build(4, 11, 6, 0, 0);
            _model.Build(4, 10, 6, 0, 0);
            _model.Build(10, 9, 1, 450, 1);
            _model.Build(7, 9, 1, 250, 1);
            _model.Build(4, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 450;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 7;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_ThreeGame_Cheap()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 6, 0, 0);
            _model.Build(6, 11, 6, 0, 0);
            _model.Build(5, 11, 6, 0, 0);
            _model.Build(4, 11, 6, 0, 0);
            _model.Build(4, 10, 6, 0, 0);
            _model.Build(10, 9, 1, 450, 1);
            _model.Build(7, 9, 1, 250, 1);
            _model.Build(4, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 200;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 4;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_FindDestinationTest_ThreeGame_None()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 6, 0, 0);
            _model.Build(6, 11, 6, 0, 0);
            _model.Build(5, 11, 6, 0, 0);
            _model.Build(4, 11, 6, 0, 0);
            _model.Build(4, 10, 6, 0, 0);
            _model.Build(10, 9, 1, 450, 1);
            _model.Build(7, 9, 1, 250, 1);
            _model.Build(4, 9, 1, 50, 1);

            _model.AddGuest();

            _model.GuestList.First().Money = 0;
            _model.GuestList.First().Status = GuestStatus.Aimless;

            _model.FindDestination();

            int expX = 11;
            int expY = 11;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        #endregion

        #region Restaurant Test
        
        [TestMethod]
        public void RctModel_Restaurant_Choose_Test_Not_Hungry()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(10, 9, 0, 10, 1);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 6, 0, 0);
            _model.Build(7, 9, 4, 10, 0);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Hunger = 100;

            _model.FindDestination();

            int expX = 10;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_Restaurant_Choose_Test_Hungry()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(10, 10, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(7, 10, 6, 0, 0);
            _model.Build(10, 9, 0, 10, 1);
            _model.Build(7, 9, 4, 10, 0);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Hunger = _model.GuestList.First().Mood - 35;

            _model.FindDestination();

            int expX = 7;
            int expY = 10;
            int actX = _model.GuestList.First().Destination.Item1;
            int actY = _model.GuestList.First().Destination.Item2;

            Assert.AreEqual(expX, actX, "X coordinate");
            Assert.AreEqual(expY, actY, "Y coordinate");
        }

        [TestMethod]
        public void RctModel_Restaurant_Operate_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 10, 3, 10, 0);
            _model.Build(7, 10, 0, 100, 1);

            Thread.Sleep(4000);

            _model.AddGuest();
            
            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Hunger = _model.GuestList.First().Mood - 35;
            
            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10);

            Assert.AreEqual(ElementStatus.InWaiting,res.Status);

            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();

            Assert.AreEqual(ElementStatus.Operate, res.Status);
        }
        
        [TestMethod]
        public void RctModel_Restaurant_EnterOne_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 10, 3, 10, 0);
            _model.Build(7, 10, 0, 100, 1);

            Thread.Sleep(4000);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Hunger = _model.GuestList.First().Mood - 35;

            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10) as Restaurant;

            Assert.AreEqual(ElementStatus.InWaiting, res.Status);

            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            Assert.AreEqual(1, res.UserList.Count, "Enter");
            Assert.AreEqual(ElementStatus.Operate, res.Status);
        }

        [TestMethod]
        public void RctModel_Restaurant_EnterTwo_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 10, 3, 10, 2);
            _model.Build(7, 10, 0, 100, 1);

            Thread.Sleep(4000);

            _model.AddGuest();
            _model.TimeElapsed();
            _model.AddGuest();

            _model.GuestList[0].Status = GuestStatus.Aimless;
            _model.GuestList[0].Hunger = _model.GuestList.First().Mood - 35;
            _model.GuestList[1].Status = GuestStatus.Aimless;
            _model.GuestList[1].Hunger = _model.GuestList[1].Mood - 35;
            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10) as Restaurant;

            Assert.AreEqual(ElementStatus.InWaiting, res.Status);

            _model.TimeElapsed();
            Assert.AreEqual(1, res.UserList.Count, "Enter");
            _model.TimeElapsed();
            Assert.AreEqual(1, res.WaitingList.Count, "wait");
            Assert.AreEqual(ElementStatus.Operate, res.Status);
            res.UserList[0].Hunger = 100;
            Thread.Sleep(3000);
            _model.TimeElapsed();
            Assert.AreEqual(0, res.WaitingList.Count, "wait");
            Assert.AreEqual(1, res.UserList.Count, "Enter");
        }

        
        [TestMethod]
        public void RctModel_Restaurant_Modify_HotDog_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 10, 3, 10, 0);
            _model.Build(7, 10, 0, 100, 1);

            Thread.Sleep(4000);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Hunger = _model.GuestList.First().Mood - 35;
            int exp = _model.GuestList.First().Hunger + 10;
            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10);

            Assert.AreEqual(ElementStatus.InWaiting, res.Status);

            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();

            Assert.AreEqual(ElementStatus.Operate, res.Status);

            Thread.Sleep(2200);
            Assert.AreEqual(exp-1, _model.GuestList.First().Hunger,"Hunger");
        }

        [TestMethod]
        public void RctModel_Restaurant_Modify_IceCream_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 10, 4, 10, 0);
            _model.Build(7, 10, 0, 100, 1);

            Thread.Sleep(4000);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Hunger = _model.GuestList.First().Mood - 35;
            int exp = _model.GuestList.First().Hunger + 15;
            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10);

            Assert.AreEqual(ElementStatus.InWaiting, res.Status);

            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();

            Assert.AreEqual(ElementStatus.Operate, res.Status);

            Thread.Sleep(2200);
            Assert.AreEqual(exp - 1, _model.GuestList.First().Hunger, "Hunger");
        }

        [TestMethod]
        public void RctModel_Restaurant_Modify_CottonCandy_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(10, 10, 5, 10, 0);
            _model.Build(7, 10, 0, 100, 1);

            Thread.Sleep(4000);

            _model.AddGuest();

            _model.GuestList.First().Status = GuestStatus.Aimless;
            _model.GuestList.First().Hunger = _model.GuestList.First().Mood - 35;
            int exp = _model.GuestList.First().Hunger + 20;
            _model.FindDestination();

            var res = _model.ParkElementList
                .Find(item => item.X == 10 && item.Y == 10);

            Assert.AreEqual(ElementStatus.InWaiting, res.Status);

            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();
            _model.TimeElapsed();

            Assert.AreEqual(ElementStatus.Operate, res.Status);

            Thread.Sleep(2200);
            Assert.AreEqual(exp - 1, _model.GuestList.First().Hunger, "Hunger");
        }

        #endregion

        #region Plant test

        [TestMethod]
        public void RctModel_Grass_Modify_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(6, 11, 6, 0, 0);
            _model.Build(10, 12, 7, 0, 0);
            _model.Build(7, 10, 0, 100, 1);

            _model.AddGuest();
            int before = _model.GuestList[0].Mood;
            _model.TimeElapsed();
            int after = _model.GuestList[0].Mood;

            Assert.IsTrue(before < after);
        }

        [TestMethod]
        public void RctModel_Tree_Modify_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(6, 11, 6, 0, 0);
            _model.Build(10, 12, 8, 0, 0);
            _model.Build(7, 10, 0, 100, 1);

            _model.AddGuest();
            int before = _model.GuestList[0].Mood;
            _model.TimeElapsed();
            int after = _model.GuestList[0].Mood;

            Assert.IsTrue(before < after);
        }

        [TestMethod]
        public void RctModel_Bush_Modify_Test()
        {
            _model.ParkElementList.Clear();
            _model.Build(12, 11, 10, 0, 0);
            _model.Build(11, 11, 6, 0, 0);
            _model.Build(10, 11, 6, 0, 0);
            _model.Build(9, 11, 6, 0, 0);
            _model.Build(8, 11, 6, 0, 0);
            _model.Build(7, 11, 6, 0, 0);
            _model.Build(6, 11, 6, 0, 0);
            _model.Build(10, 12, 9, 0, 0);
            _model.Build(7, 10, 0, 100, 1);

            _model.AddGuest();
            int before = _model.GuestList[0].Mood;
            _model.TimeElapsed();
            int after = _model.GuestList[0].Mood;

            Assert.IsTrue(before < after);
        }
        #endregion
    }
}
