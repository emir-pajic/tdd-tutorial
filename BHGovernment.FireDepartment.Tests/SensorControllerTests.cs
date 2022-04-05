using BHGovernment.FireDepartment.API.Contracts;
using BHGovernment.FireDepartment.API.Controllers;
using BHGovernment.FireDepartment.API.Model;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BHGovernment.FireDepartment.Tests
{
    public class SensorControllerTests
    {
        [Fact]
        public async void GetAllSensors_Returns_Ok()
        {
            //Arrange
            Mock<ISensorService> mockSensorService = new Mock<ISensorService>();

            var listToReturn = new List<Sensor>()
            {
                new Sensor()
                {
                    SensorId = "BHGOV_MO_0123",
                    SensorFriendlyName = "Mostar Ortiješ Sensor",
                    SensorLocation = "Mostar",
                    Active = true
                },
                new Sensor()
                {
                    SensorId = "BHGOV_KO_GHGHF23",
                    SensorFriendlyName = "Konjic Center Sensor",
                    SensorLocation = "Konjic",
                    Active = true
                },
            };

            mockSensorService.Setup(x => x.GetSensors()).Returns(Task.FromResult(listToReturn));

            var sut = new SensorController(mockSensorService.Object);

            //Act
            var response = await sut.GetAllSensors();

            var data = (response as OkObjectResult).Value;

            var sensors = (List<Sensor>)data;

            //Assert
            response.Should().BeOfType<OkObjectResult>();

            Assert.NotNull(sensors);
            Assert.NotEmpty(sensors);
        }

        [Fact]
        public async void GetAllSensors_Returns_NoContent()
        {
            //Arrange
            Mock<ISensorService> mockSensorService = new Mock<ISensorService>();

            var listToReturn = new List<Sensor>();

            mockSensorService.Setup(x => x.GetSensors()).Returns(Task.FromResult(listToReturn));


            var sut = new SensorController(mockSensorService.Object);


            //Act
            var response = await sut.GetAllSensors();


            //Assert

            response.Should().BeOfType<NoContentResult>();
        }

        [Fact]
        public async void GetAllActiveSensors_Returns_Ok()
        {
            //Arrange
            Mock<ISensorService> mockSensorService = new Mock<ISensorService>();

            var listToReturn = new List<Sensor>()
            {
                new Sensor()
                {
                    SensorId = "BHGOV_MO_0123",
                    SensorFriendlyName = "Mostar Ortiješ Sensor",
                    SensorLocation = "Mostar",
                    Active = true
                },
            };

            mockSensorService.Setup(x => x.GetSensors()).Returns(Task.FromResult(listToReturn));


            var sut = new SensorController(mockSensorService.Object);


            //Act
            var response = await sut.GetAllActiveSensors();


            //Assert

            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void GetAllActiveSensors_Returns_NoContent()
        {
            //Arrange
            Mock<ISensorService> mockSensorService = new Mock<ISensorService>();
            var listToReturn = new List<Sensor>();

            mockSensorService.Setup(x => x.GetSensors()).Returns(Task.FromResult(listToReturn));
            var sut = new SensorController(mockSensorService.Object);


            //Act
            var response = await sut.GetAllActiveSensors();


            //Assert
            response.Should().BeOfType<NoContentResult>();
        }
    }
}
