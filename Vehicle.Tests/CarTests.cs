using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vehicle;
using Rhino.Mocks;

namespace Vehicle.Tests
{
    [TestClass]
    public class CarTests
    {
        private IEngine engineMock;
        private Car car;

        [TestInitialize]
        public void Init()
        {
            engineMock = MockRepository.GenerateMock<IEngine>();
            car = new Car(engineMock, "abc-1234");
        }

        [TestMethod]
        public void GetPlate()
        {
            //Arrange
            string plate = null;
            //Act
            plate = car.GetPlate();
            //Assert
            Assert.IsNotNull(plate);

        }

        [TestMethod]
        public void AccelerateTo200rpm()
        {
            //Arrange
            engineMock.Expect(e => e.GetRpm()).Return(0);

            //Act
            car.Accelerate(200);

            //Assert
            engineMock.AssertWasCalled(e => e.SetRpm(200));
        }

        [TestMethod]
        public void CalculatesSpeed()
        {
            //Arrange
            engineMock.Expect(e => e.GetRpm()).Return(200);

            //Act
            int speed = car.GetSpeed();

            //Assert
            Assert.AreEqual(20, speed, "should be 20kph");
        }

        [TestMethod]
        public void ReturnOverheatingStatusWhenTemperatureIsGreatedThanMax()
        {
            //Arrange
            engineMock.Expect(e => e.GetTemp()).Return(new Temperature(car.MaxEngineTemp + 1));

            //Act
            string status = car.GetStatus();

            //Assert
            Assert.AreEqual("overheating", status);
        }
    }
}
