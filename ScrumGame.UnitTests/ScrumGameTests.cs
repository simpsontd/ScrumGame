using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScrumGame;

namespace ScrumGame.UnitTests
{
    [TestClass]
    public class ScrumGameTests
    {
        [TestMethod]
        //Fails as RollDice is null was not passed
        public void RollMethod_Roll_ReturnsOutOfRange()
        {
            //Arrange
            var roll = new MainForm();

            //Act and Assert
            //Throws Out of Range Exception
            Assert.ThrowsException<System.ArgumentNullException>(() => roll.DiceTotal);
        }
        [TestMethod]
        //Passes test
        public void RollMethod_Roll_BelowOne()
        {
            //Arrange
            var roll = new MainForm();
            var num = roll.DiceTotal;

            //Act and Assert
            //Checks if number is within 1 to 7
            if (num < 7 || num > 1)
            {
                Console.WriteLine("Current number " + num + " in range.");

            }
            else
            {
                Assert.Fail(num + " is out of range!");
            }

        }

        //Used on MainForm to test buttons to see if clickable
        //private void TestBtn_Click(object sender, EventArgs e)
        //{
        //    buttonName.PerformClick();
        //}



    }
}
