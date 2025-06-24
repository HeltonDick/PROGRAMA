using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Address
    {
        public int Id { get; set; }
        public string? Street1 { get; set; }
        public string? Street2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? AddressType { get; set; }

        public bool Validate() {
            bool isValid = true;

            isValid = !string.IsNullOrEmpty(this.Street1) &&
                (this.Id > 0) &&
                !string.IsNullOrEmpty(this.Street2) &&
                !string.IsNullOrEmpty(this.City) &&
                !string.IsNullOrEmpty(this.State) &&
                !string.IsNullOrEmpty(this.PostalCode) &&
                !string.IsNullOrEmpty(this.Country) &&
                !string.IsNullOrEmpty(this.AddressType);

            return isValid;
        }

        public Address Retrive() {
            return new Address();
        }

        public void save(Address adress) {

        }
    }
}
