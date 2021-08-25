using System;
using System.Text.RegularExpressions;

namespace Domain
{
    public class Location
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StreetName { get; set; }
        public string Number { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }

        public bool IsValid()
        {
            return IsZipCodeValid();
        }

        private bool IsZipCodeValid()
        {
            Regex rx = new Regex(@"\b[1-9]{1}\d{4}-[1-9]{1}\d{3}\b");
            return rx.IsMatch(ZipCode);
        }
    }
}
