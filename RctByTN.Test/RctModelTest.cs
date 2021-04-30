using Microsoft.VisualStudio.TestTools.UnitTesting;
using RctByTN.Model;
using System.Linq;
using System.Threading;

namespace RctByTN.Test
{
    [TestClass]
    public class RctModelTest
    {
        private RctModel _model;

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

        [TestMethod]
        public void RctModelIsFreeAreaTest_FreeAreaTest()
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
        public void RctModelIsFreeAreaTest_OneAreaSize1()
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
        public void RctModelIsFreeAreaTest_OneAreaSize2()
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
        public void RctModelIsFreeAreaTest_FourAreaSize1()
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

        [TestMethod]
        public void RctModelCampaignTest1()
        {
            _model.StartCampaign();
            Assert.IsTrue(_model.IsCampaign);
            Thread.Sleep(11000);
            Assert.IsFalse(_model.IsCampaign);
        }

    }
}
