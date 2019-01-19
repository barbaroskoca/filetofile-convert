using FileToFile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FileToFile
{
    public class FileToFileConvert
    {

        #region Singleton Desing Pattern


        static FileToFileConvert _paxiumumConvert = null;

        private FileToFileConvert()
        {

        }

        public static FileToFileConvert Instance
        {
            get
            {
                if (_paxiumumConvert == null)
                {
                    _paxiumumConvert = new FileToFileConvert();
                }
                return _paxiumumConvert;
            }

        }

        #endregion


        /// <summary>
        /// LoadXML
        /// Loading Data From XML File.
        /// </summary>
        /// <param name="XMLPath">DATA path for XML Extension</param>
        public XMLModel LoadXML(string XMLPath)
        {
            if (string.IsNullOrWhiteSpace(XMLPath))
            {
                throw new FileNotFoundException($"File not found : {XMLPath}");
            }

            try
            {
                XmlReader reader = XmlReader.Create(XMLPath);
                XmlSerializer serializer = new XmlSerializer(typeof(XMLModel));
                XMLModel xmlModel = (XMLModel)serializer.Deserialize(reader);

                reader.Close();
                reader.Dispose();

                return xmlModel;
            }
            catch (Exception ex)
            {
                throw new Exception("XML Loading Exception\r\n" + ex.Message);
            }

        }


        /// <summary>
        /// LoadCSV
        /// Loading Data From CSV File.
        /// </summary>
        /// <param name="CSVPath">DATA path for CSV Extension</param>
        public CSVModel LoadCSV(string CSVPath)
        {
            try
            {
                StreamReader reader = new StreamReader(File.OpenRead(CSVPath));

                CSVModel csvModel = new CSVModel();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (!String.IsNullOrWhiteSpace(line))
                    {
                        string[] fields = line.Split(',');
                        if (fields.Length == 4)
                        {
                            CSVLine csvLine = new CSVLine();
                            csvLine.CityName = fields[0];
                            csvLine.CityCode = fields[1];
                            csvLine.DistrictName = fields[2];
                            csvLine.ZipCode = fields[3];
                            csvModel.CSVLines.Add(csvLine);
                        }
                    }

                }

                reader.Close();
                reader.Dispose();

                return csvModel;
            }
            catch (Exception ex)
            {
                throw new Exception("CSV Loading Exception\r\n" + ex.Message);
            }

        }

        /// <summary>
        /// LoadXML
        /// Exporting Data to File.
        /// </summary>
        /// /// <param name="filePath">DATA path for Export</param>
        public void ExportToFile(List<Address> addresses, string filePath, string fileExtension)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new DirectoryNotFoundException($"File Directory not found: {filePath}");
            }

            var sb = new StringBuilder();
            var stringWriter = new StringWriter(sb);

            switch (fileExtension)
            {
                case ".xml":
                    {
                        XmlTextWriter xmlWriter = new XmlTextWriter(stringWriter);
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("AddressInfo");

                        var cityNames = addresses.SelectMany(x => x.CityName, (p, t) => new { p.CityName, p.CityCode }).Distinct();

                        foreach (var item in cityNames)
                        {
                            xmlWriter.WriteStartElement("City");

                            xmlWriter.WriteStartAttribute("name");
                            xmlWriter.WriteString(item.CityName.ToString());
                            xmlWriter.WriteStartAttribute("code");
                            xmlWriter.WriteString(item.CityCode.ToString());
                            xmlWriter.WriteEndAttribute();

                            var districtNames = addresses.Where(x => x.CityCode == item.CityCode).Select(x => x.DistrictName).Distinct();
                            foreach (var districtName in districtNames)
                            {

                                xmlWriter.WriteStartElement("District");

                                xmlWriter.WriteStartAttribute("name");
                                xmlWriter.WriteString(districtName);
                                xmlWriter.WriteEndAttribute();

                                var zipCodes = addresses.Where(x => x.CityCode == item.CityCode && x.DistrictName == districtName).Select(x => x.ZipCode).Distinct();
                                foreach (var zipCode in zipCodes)
                                {
                                    xmlWriter.WriteStartElement("Zip");
                                    xmlWriter.WriteStartAttribute("code");
                                    xmlWriter.WriteString(zipCode);
                                    xmlWriter.WriteEndAttribute();
                                    // END of Zip element
                                    xmlWriter.WriteEndElement();
                                }

                                // END of District element
                                xmlWriter.WriteEndElement();
                            }
                            // END of City element
                            xmlWriter.WriteEndElement();

                        }

                        // END of AddressInfo element
                        xmlWriter.WriteEndElement();

                        xmlWriter.WriteEndDocument();
                        xmlWriter.Close();

                        sb.Remove(0, 39);
                        break;
                    }

                case ".csv":
                    {
                        sb.Append("\ufeff");
                        sb.AppendLine("CityName,CityCode,DistrictName,ZipCode");

                        foreach (var item in addresses)
                        {
                            var line = string.Format("{0},{1},{2},{3}", item.CityName, item.CityCode, item.DistrictName, item.ZipCode);
                            sb.AppendLine(line);
                        }

                        break;
                    }
            }

            File.WriteAllText(filePath, sb.ToString());

        }


        /// <summary>
        /// DataConverterByType
        /// You can add here new datatypes to convert.
        /// </summary>
        /// <param name="dataPath">Data path</param>
        /// <param name="formatType">Data Format type name</param>
        public virtual List<Address> DataConverterByType(string dataPath, string formatType)
        {
            List<Address> DataModel = new List<Address>();
            switch (formatType)
            {
                case ".xml":
                    {
                        var XMLDataModel = LoadXML(dataPath);

                        foreach (var item in XMLDataModel.XMLElements)
                        {
                            foreach (var district in item.District)
                            {
                                foreach (var zipp in district.Zip)
                                {
                                    Address address = new Models.Address();

                                    address.CityName = item.CityName;
                                    address.CityCode = item.CityCode;
                                    address.DistrictName = district.DistrictName;
                                    address.ZipCode = zipp.ZipCode;

                                    DataModel.Add(address);
                                }
                            }

                        }

                        break;
                    }

                case ".csv":
                    {
                        var CSVDataModel = LoadCSV(dataPath);

                        foreach (var item in CSVDataModel.CSVLines)
                        {
                            Address address = new Models.Address();

                            address.CityName = item.CityName;
                            address.CityCode = item.CityCode;
                            address.DistrictName = item.DistrictName;
                            address.ZipCode = item.ZipCode;

                            DataModel.Add(address);
                        }

                        break;
                    }

            }

            return DataModel;
        }

        /// <summary>
        /// GetFilteredList
        /// </summary>
        /// <param name="dataPath">Data path</param>
        /// <param name="formatType">Data Format type name</param>
        /// <param name="cityName">Filtered City name</param>
        /// <param name="sortBy">Sorted element name</param>
        /// <param name="sortAscending">Sorted Ascending or Descending</param>
        /// <param name="multiSorting">Multi sorting Enable or Disable name</param>
        /// <param name="sortBy2">Second sorted elemeent</param>
        /// <param name="sortAscending2">Sorted Ascending or Descending for second element</param>
        public virtual List<Address> GetFilteredList(string dataPath,
            string formatType,
            string cityName,
            string sortBy,
            bool sortAscending,
            bool multiSorting,
            string sortBy2,
            bool sortAscending2)
        {
            //LoadData
            var DataModel = DataConverterByType(dataPath, formatType);


            //If CityName Has Filtered Or Not
            var filteredList = cityName != "" ? DataModel.Where(x => x.CityName == cityName).ToList() : DataModel;

            if (multiSorting)
            {
                //multiSorting Ascending Line
                if (sortAscending)
                {
                    if (sortBy == "CityCode")
                    {

                        if (sortAscending2)
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityCode).ThenBy(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityCode).ThenBy(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderBy(x => x.CityCode).ThenBy(x => x.CityName).ToList();
                            }
                        }
                        else
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityCode).ThenByDescending(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityCode).ThenByDescending(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderBy(x => x.CityCode).ThenByDescending(x => x.CityName).ToList();
                            }
                        }


                    }
                    else if (sortBy == "DistrictName")
                    {

                        if (sortAscending2)
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.DistrictName).ThenByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderBy(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.DistrictName).ThenBy(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderBy(x => x.DistrictName).ThenBy(x => x.CityName).ToList();
                            }
                        }
                        else
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.DistrictName).ThenByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderBy(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.DistrictName).ThenByDescending(x => x.ZipCode).ToList();
                            }
                            else
                            {

                                filteredList = filteredList.OrderBy(x => x.DistrictName).ThenByDescending(x => x.CityName).ToList();
                            }
                        }
                    }
                    else if (sortBy == "ZipCode")
                    {


                        if (sortAscending2)
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.ZipCode).ThenBy(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderBy(x => x.ZipCode).ThenBy(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderBy(x => x.ZipCode).ThenBy(x => x.CityName).ToList();
                            }
                        }
                        else
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.ZipCode).ThenByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderBy(x => x.ZipCode).ThenByDescending(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderBy(x => x.ZipCode).ThenByDescending(x => x.CityName).ToList();
                            }
                        }
                    }
                    else
                    {

                        if (sortAscending2)
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityName).ThenBy(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityName).ThenBy(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityName).ThenBy(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderBy(x => x.CityName).ToList();
                            }
                        }
                        else
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityName).ThenByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityName).ThenByDescending(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderBy(x => x.CityName).ThenByDescending(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderBy(x => x.CityName).ToList();
                            }
                        }
                    }
                }//multiSorting Ascending Line END
                 //multiSorting Descending Line
                else
                {
                    if (sortBy == "CityCode")
                    {

                        if (sortAscending2)
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityCode).ThenBy(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityCode).ThenBy(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityCode).ThenBy(x => x.CityName).ToList();
                            }
                        }
                        else
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityCode).ThenByDescending(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityCode).ThenByDescending(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityCode).ThenByDescending(x => x.CityName).ToList();
                            }
                        }


                    }
                    else if (sortBy == "DistrictName")
                    {

                        if (sortAscending2)
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.DistrictName).ThenByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.DistrictName).ThenBy(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderByDescending(x => x.DistrictName).ThenBy(x => x.CityName).ToList();
                            }
                        }
                        else
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.DistrictName).ThenByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.DistrictName).ThenByDescending(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderByDescending(x => x.DistrictName).ThenByDescending(x => x.CityName).ToList();
                            }
                        }
                    }
                    else if (sortBy == "ZipCode")
                    {


                        if (sortAscending2)
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.ZipCode).ThenBy(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.ZipCode).ThenBy(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderByDescending(x => x.ZipCode).ThenBy(x => x.CityName).ToList();
                            }
                        }
                        else
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.ZipCode).ThenByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.ZipCode).ThenByDescending(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderByDescending(x => x.ZipCode).ThenByDescending(x => x.CityName).ToList();
                            }
                        }
                    }
                    else
                    {

                        if (sortAscending2)
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityName).ThenBy(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityName).ThenBy(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityName).ThenBy(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityName).ToList();
                            }
                        }
                        else
                        {
                            if (sortBy2 == "CityCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityName).ThenByDescending(x => x.CityCode).ToList();
                            }
                            else if (sortBy2 == "DistrictName")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityName).ThenByDescending(x => x.DistrictName).ToList();
                            }
                            else if (sortBy2 == "ZipCode")
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityName).ThenByDescending(x => x.ZipCode).ToList();
                            }
                            else
                            {
                                filteredList = filteredList.OrderByDescending(x => x.CityName).ToList();
                            }
                        }
                    }
                }
                //multiSorting Descending Line END                        
            }
            //SingleSorting 
            else
            {
                if (sortAscending)
                {
                    if (sortBy == "CityCode")
                    {
                        filteredList = filteredList.OrderBy(x => x.CityCode).ToList();
                    }
                    else if (sortBy == "DistrictName")
                    {
                        filteredList = filteredList.OrderBy(x => x.DistrictName).ToList();
                    }
                    else if (sortBy == "ZipCode")
                    {
                        filteredList = filteredList.OrderBy(x => x.ZipCode).ToList();
                    }
                    else
                    {
                        filteredList = filteredList.OrderBy(x => x.CityName).ToList();
                    }
                }
                else
                {
                    if (sortBy == "CityCode")
                    {
                        filteredList = filteredList.OrderByDescending(x => x.CityCode).ToList();
                    }
                    else if (sortBy == "DistrictName")
                    {
                        filteredList = filteredList.OrderByDescending(x => x.DistrictName).ToList();
                    }
                    else if (sortBy == "ZipCode")
                    {
                        filteredList = filteredList.OrderByDescending(x => x.ZipCode).ToList();
                    }
                    else
                    {
                        filteredList = filteredList.OrderByDescending(x => x.CityName).ToList();
                    }
                }

            }//SingleSorting END

            return filteredList.ToList();

        }


    }
}

