using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using _2020_07_15.src.MrPotatoHead;
using System;

namespace _2020_07_15.test
{
    [TestClass]
    public class MrPotatoHeadTest
    {
        private readonly MrPotatoHead mrPotatoHead;
        private readonly Mock<IArm> leftArm = new Mock<IArm>();
        private readonly Mock<IArm> rightArm = new Mock<IArm>();
        private readonly Mock<IHat> hat = new Mock<IHat>();

        public MrPotatoHeadTest() {
            mrPotatoHead = new MrPotatoHead(hat.Object, leftArm.Object, rightArm.Object);
        }

        [TestMethod]
        public void MrPotatoHeadWaves_RightArmShouldWave()
        {
            mrPotatoHead.Wave();

            leftArm.Verify(l => l.Wave(), Times.Never());
            rightArm.Verify(r => r.Wave(), Times.Once());
        }

        //BAD, WHAT IF THE POTATO# WAS CALCULATED INCORRECTLY? YOU COPIED IT OVER AND YOUR TEST STILL PASSES
        [TestMethod]
        public void CalculatePotatoNumber_100()
        {
            double expectedPotatoNumber = GetExpectedPotatoNumber(100);
            double result = mrPotatoHead.CalculatePotatoNumber(100);
            Assert.AreEqual(expectedPotatoNumber, result);
        }

        private double GetExpectedPotatoNumber(int input) {
            double someSillyNumber = 12345 * (Math.Floor(input + input * (0.9)));
            return someSillyNumber;
        }
    }
}
