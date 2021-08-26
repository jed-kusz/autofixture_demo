using System;
using AutoFixture;
using Domain;
using FluentAssertions;
using UnitTests.Extensions;
using Xunit;

namespace UnitTests
{
    public class OrderTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void IsValid_ValidLocationData_ReturnsTrue()
        {
            // Arrange
            var order = fixture.BuildOrder().Create();

            // Act
            // Assert
            order.IsValid().Should().BeTrue();
        }

        [Fact]
        public void IsValid_InvalidPickupLocationData_ReturnsFalse()
        {
            // Arrange
            var invalidZipCode = fixture.Create<string>();
            var invalidPickupLocation = fixture
                .BuildLocation()
                .With(l => l.ZipCode, invalidZipCode)
                .Create();

            var order = fixture
                .BuildOrder()
                .With(o => o.PickupLocation, invalidPickupLocation)
                .Create();

            // Act
            // Assert
            order.IsValid().Should().BeFalse();
        }
        
        [Fact]
        public void IsValid_InvalidDestinationLocationData_ReturnsFalse()
        {
            // Arrange
            var locationWithInvalidZipCode = fixture
                .BuildLocation()
                .With(l => l.ZipCode, fixture.Create<string>())
                .Create();
            var order = fixture
                .BuildOrder()
                .With(o => o.DestinationLocation, locationWithInvalidZipCode)
                .Create();

            // Act
            
            // Assert
            order.IsValid().Should().BeFalse();
        }
    }
}
