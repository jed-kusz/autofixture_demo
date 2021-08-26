using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public Order(Guid id, 
            Location pickupLocation, 
            Location destinationLocation, 
            List<string> items)
        {
            Id = id;
            PickupLocation = pickupLocation;
            DestinationLocation = destinationLocation;
            Items = items;
        }

        public Guid Id { get; set; }
        public Location PickupLocation { get; set; }
        public Location DestinationLocation { get; set; }
        public List<string> Items { get; set; }

        public bool IsValid()
        {
            return PickupLocation.IsValid() && DestinationLocation.IsValid();
        }
    }
}