using Microsoft.VisualStudio.TestTools.UnitTesting;
using RctByTN.Model;

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
    }
}
