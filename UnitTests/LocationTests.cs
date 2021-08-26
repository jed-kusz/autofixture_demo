using AutoFixture;
using Domain;
using FluentAssertions;
using UnitTests.Extensions;
using Xunit;

namespace UnitTests
{
    public class LocationTests
    {
        private readonly Fixture fixture = new Fixture();

        [Fact]
        public void IsValid_ValidZipCode_ReturnsTrue()
        {
            // Arrange
            var location = fixture.BuildLocation().Create();
            
            // Act
            // Assert
            location.IsValid().Should().BeTrue();
        }

        [Fact]
        public void IsValid_InvalidZipCode_ReturnsFalse()
        {
            // Arrange
            var location = fixture.BuildLocation().Create();
            location.ZipCode = "a123-02312";

            // Act
            // Assert
            location.IsValid().Should().BeFalse();
        }
    }
}