using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileToFile.Models
{
    public class CSVModel
    {
        public CSVModel()
        {
            CSVLines = new List<CSVLine>();
        }

        public List<CSVLine> CSVLines { get; set; }
    }


    public class CSVLine
    {
        public string CityName { get; set; }

        public string CityCode { get; set; }

        public string DistrictName { get; set; }

        public string ZipCode { get; set; }
    }




}
