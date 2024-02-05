using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceLib;

namespace ClassLib.Tests
{
    [TestClass()]
    public class DiceTests
    {

        private Dice DiceWrongAmount = new() {Id = 1, Color="black", SideAmount= 67 };
        private Dice DiceWrongColor = new() { Id = 2, Color = "g", SideAmount = 5 };
        [TestMethod()]
        public void SideValTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DiceWrongAmount.SideVal());
        }

        [TestMethod()]
        public void ColorValTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DiceWrongColor.ColorVal());
        }
    }
}