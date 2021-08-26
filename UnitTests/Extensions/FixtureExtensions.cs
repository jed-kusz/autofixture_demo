using System;
using System.Linq;
using AutoFixture;
using AutoFixture.Dsl;
using Domain;

namespace UnitTests.Extensions
{
    public static class FixtureExtensions
    {
        public static IPostprocessComposer<Location> BuildLocation(this Fixture fixture)
        {
            var rng = new Random();

            var zipCode = "";
            for (int i = 0; i < 5; i++)
            {
                zipCode += rng.Next(0, 9);
            }
            zipCode = zipCode.Insert(2, "-");

            return fixture
                .Build<Location>()
                .With(x => x.ZipCode, zipCode);
        }

        public static IPostprocessComposer<Order> BuildOrder(this Fixture fixture)
        {
            var pickupLocation = fixture.BuildLocation().Create();
            var destinationLocation = fixture.BuildLocation().Create();

            return fixture
                .Build<Order>()
                .With(x => x.PickupLocation, pickupLocation)
                .With(x => x.DestinationLocation, destinationLocation);
        }
    }
}
