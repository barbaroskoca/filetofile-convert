using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FileToFile.Tests
{
    [TestClass()]
    public class FileToFileConvertTests
    {
        [TestMethod()]
        public void TestCase1()
        {
            //csv to xml test case

            var FileToFileconvert = FileToFileConvert.Instance;

            int expectedCountOfZipCodessForAntalya = 83;

            string expectedFirstZipCode = "07630";

            string inputType = ".csv";
            string inputDirectory = @"SampleDatas\sample_data.csv";

            string outputType = ".xml";
            string outputDirectory = @"SampleDatas\sample_data_" + Guid.NewGuid().ToString() + ".xml";

            string filterData = "Antalya";
            string sortBy = "CityName";
            bool sortAscending = true;
            bool multiSorting = false;
            string sortBy2 = "";
            bool sortAscending2 = false;

            FileToFileconvert.ExportToFile(FileToFileconvert.GetFilteredList(inputDirectory, inputType, filterData, sortBy, sortAscending, multiSorting, sortBy2, sortAscending2), outputDirectory, outputType);

            var xMLModel = FileToFileconvert.LoadXML(outputDirectory);

            int countOfZipCodes = 0;
            string firstZipCode = "";

            foreach (var item in xMLModel.XMLElements)
            {
                foreach (var district in item.District)
                {
                    foreach (var zipp in district.Zip)
                    {
                        if (countOfZipCodes == 0)
                        {
                            firstZipCode = zipp.ZipCode;
                        }
                        countOfZipCodes++;
                    }
                }

            }

            //Is file created check with system.IO File Exists
            Assert.IsTrue(System.IO.File.Exists(outputDirectory));

            //Has file returned expected values of count
            Assert.AreEqual(expectedCountOfZipCodessForAntalya, countOfZipCodes);

            //Has file has the same zipcode for first row
            Assert.AreEqual(expectedFirstZipCode, firstZipCode);
        }

        [TestMethod()]
        public void TestCase2()
        {
            //csv to csv test case

            var FileToFileconvert = FileToFileConvert.Instance;

            int expectedCountOfZipCodessForAntalya = 3234;

            string expectedFirstZipCode = "01720";

            string inputType = ".csv";
            string inputDirectory = @"SampleDatas\sample_data.csv";

            string outputType = ".csv";
            string outputDirectory = @"SampleDatas\sample_data_" + Guid.NewGuid().ToString() + ".csv";

            string filterData = "";
            string sortBy = "CityName";
            bool sortAscending = true;
            bool multiSorting = true;
            string sortBy2 = "DistrictName";
            bool sortAscending2 = true;

            FileToFileconvert.ExportToFile(FileToFileconvert.GetFilteredList(inputDirectory, inputType, filterData, sortBy, sortAscending, multiSorting, sortBy2, sortAscending2), outputDirectory, outputType);

            var cSVModel = FileToFileconvert.LoadCSV(outputDirectory);

            int countOfZipCodes = 0;
            string firstZipCode = "";

            foreach (var item in cSVModel.CSVLines)
            {
                if (countOfZipCodes == 1)
                {
                    firstZipCode = item.ZipCode;
                }
                countOfZipCodes++;


            }

            //Is file created check with system.IO File Exists
            Assert.IsTrue(System.IO.File.Exists(outputDirectory));

            //Has file returned expected values of count
            Assert.AreEqual(expectedCountOfZipCodessForAntalya, countOfZipCodes);

            //Has file has the same zipcode for first row
            Assert.AreEqual(expectedFirstZipCode, firstZipCode);
        }

        [TestMethod()]
        public void TestCase3()
        {
            //xml to csv test case

            var FileToFileconvert = FileToFileConvert.Instance;

            int expectedCountOfZipCodessForAntalya = 122;

            string expectedFirstZipCode = "06980";

            string inputType = ".xml";
            string inputDirectory = @"SampleDatas\sample_data.xml";

            string outputType = ".csv";
            string outputDirectory = @"SampleDatas\sample_data_" + Guid.NewGuid().ToString() + ".csv";

            string filterData = "Ankara";
            string sortBy = "CityName";
            bool sortAscending = true;
            bool multiSorting = true;
            string sortBy2 = "ZipCode";
            bool sortAscending2 = false;

            FileToFileconvert.ExportToFile(FileToFileconvert.GetFilteredList(inputDirectory, inputType, filterData, sortBy, sortAscending, multiSorting, sortBy2, sortAscending2), outputDirectory, outputType);

            var cSVModel = FileToFileconvert.LoadCSV(outputDirectory);

            int countOfZipCodes = 0;
            string firstZipCode = "";

            foreach (var item in cSVModel.CSVLines)
            {
                if (countOfZipCodes == 1)
                {
                    firstZipCode = item.ZipCode;
                }
                countOfZipCodes++;


            }

            //Is file created check with system.IO File Exists
            Assert.IsTrue(System.IO.File.Exists(outputDirectory));

            //Has file returned expected values of count
            Assert.AreEqual(expectedCountOfZipCodessForAntalya, countOfZipCodes);

            //Has file has the same zipcode for first row
            Assert.AreEqual(expectedFirstZipCode, firstZipCode);
        }
    }
}