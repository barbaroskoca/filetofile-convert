using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileToFile.Models
{
   
    public class CSVLine
    {
        public string CityName { get; set; }

        public string CityCode { get; set; }

        public string DistrictName { get; set; }

        public string ZipCode { get; set; }
    }

    public class CSVModel
    {
        public List<CSVLine> CSVLines { get; set; }

        public CSVModel()
        {
            CSVLines = new List<CSVLine>();
        }

    }


}
