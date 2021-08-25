using System;
using AutoFixture;
using Domain;
using FluentAssertions;
using Xunit;

namespace UnitTests
{
    public class OrderTests
    {
        private readonly Fixture fixture;

        public OrderTests()
        {
            this.fixture = new Fixture();
        }

        [Fact]
        public void IsValid_ValidLocationData_ReturnsTrue()
        {
            // Arrange
            var order = fixture.Create<Order>();

            // Act
            var isValid = order.IsValid();

            // Assert
            isValid.Should().BeTrue();
        }
    }
}
