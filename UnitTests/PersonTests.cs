using AutoFixture;
using FluentAssertions;
using Xunit;

namespace UnitTests
{
    public class PersonTests
    {
        private Fixture fixture = new Fixture();

        [Fact]
        public void Person_NamePassedToConstructor_ReturnsSameName()
        {
            // Arrange
            var person = fixture.Create<Person>();

            // Act
            // Assert
            person.Name.Should().NotBeNull();
            person.Name.Should().NotBe(default);
        }

        public class Person
        {
            public string Name { get; set; }

            public Person(string name)
            {
                Name = name;
            }
        }
    }
}
