using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public Order(Location pickupLocation, Location destinationLocation, List<string> items)
            : this(Guid.NewGuid(), pickupLocation, destinationLocation, items)
        {
        }

        public Order(Guid id, Location pickupLocation, Location destinationLocation, List<string> items)
        {
            Id = id;
            PickupLocation = pickupLocation;
            DestinationLocation = destinationLocation;
            Items = items;
        }

        public Guid Id { get; private set; }
        public Location PickupLocation { get; private set; }
        public Location DestinationLocation { get; private set; }
        public List<string> Items { get; private set; }

        public bool IsValid()
        {
            return PickupLocation.IsValid() && DestinationLocation.IsValid();
        }
    }
}
