using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileToFile.Models
{
    public class AddressModel
    {
        public AddressModel()
        {
            Addresses = new List<Models.Address>();
        }

        public List<Address> Addresses {get; set;}       
    }

    public class Address
    {       

        public string CityName { get; set; }

        public string CityCode { get; set; }

        public string DistrictName { get; set; }

        public string ZipCode { get; set; }
        
    }
}
