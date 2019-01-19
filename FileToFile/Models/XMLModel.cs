using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FileToFile.Models
{
    [XmlRoot(ElementName = "Zip")]
    public class Zip
    {
        [XmlAttribute(AttributeName = "code")]
        public string ZipCode { get; set; }

    }

    [XmlRoot(ElementName = "District")]
    public class District
    {
        [XmlAttribute(AttributeName = "name")]
        public string DistrictName { get; set; }
        [XmlElement(ElementName = "Zip")]
        public List<Zip> Zip { get; set; }
    }

    [XmlRoot(ElementName = "City")]
    public class XMLElement
    {
        [XmlAttribute(AttributeName = "name")]
        public string CityName { get; set; }
        [XmlAttribute(AttributeName = "code")]
        public string CityCode { get; set; }
        [XmlElement(ElementName = "District")]
        public List<District> District { get; set; }


    }

    [XmlRoot(ElementName = "AddressInfo")]
    public class XMLModel
    {
        [XmlElement(ElementName = "City")]
        public List<XMLElement> XMLElements { get; set; }

    }
}
