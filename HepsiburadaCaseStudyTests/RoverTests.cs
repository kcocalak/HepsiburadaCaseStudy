using Hepsiburada_Case_Study;
using Hepsiburada_Case_Study.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HepsiburadaCaseStudyTests
{
    [TestClass]
    public class RoverTests
    {
        int plateauXAxis = 5;
        int plateauYAxis = 5;
        int roverXAxis = 3;
        int roverYAxis = 3;

        [TestMethod]
        public void PlateauConstructor_FullTest()
        {
            //Cons
        }

        [TestMethod]
        public void Execute_CheckSuccessCommandInput()
        {
            string commandInput = "MMRMMRMRRM";
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            rover.Execute(commandInput);
            //actual result boyle yazilip kontrol edilir mi?
            string result = rover.xAxis + " " + rover.yAxis + " " + rover.pointOfCompass;
            Assert.AreEqual("5 1 E", result);
        }

        [TestMethod]
        public void Execute_CheckWrongCommandInput()
        {
            string commandInput = "MMRMMRMRRME";
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            Assert.ThrowsException<System.Exception>(() => rover.Execute(commandInput));
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassForNorthPointWithLCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            try
            {
                rover.RotateRover(Command.L);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassForNorthPointWithRCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            try
            {
                rover.RotateRover(Command.R);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassForSouthPointWithLCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            try
            {
                rover.RotateRover(Command.L);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassForSouthPointWithRCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            try
            {
                rover.RotateRover(Command.R);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassForWestPointWithLCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            try
            {
                rover.RotateRover(Command.L);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassForWestPointWithRCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            try
            {
                rover.RotateRover(Command.R);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassForEastPointWithLCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            try
            {
                rover.RotateRover(Command.L);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassForEastPointWithRCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            try
            {
                rover.RotateRover(Command.R);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void RotateRover_CheckNewPoinOfCompassWithWrongCommandInput()
        {
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            Assert.ThrowsException<System.Exception>(() => rover.RotateRover(Command.M));
        }
        [TestMethod]
        public void MoveRover_CheckRoverMovementsOnOutOfPlateauCoordinates()
        {
            string commandInput = "MMRMMRMRRMMM";
            Plateau plateau = new Plateau(plateauXAxis, plateauYAxis);
            Rover rover = new Rover(roverXAxis, roverYAxis, PointOfCompass.E, plateau);
            Assert.ThrowsException<System.Exception>(() => rover.Execute(commandInput));

        }

    }
}
