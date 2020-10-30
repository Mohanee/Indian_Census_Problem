using NUnit.Framework;
using System.Collections.Generic;
using IndianStateCensusProblem;
using IndianStateCensusProblem.DTO;
using static IndianStateCensusProblem.CensusAnalyser;

namespace CensualAnalyserTestNew
{
    public class Tests
    {
        //CensusAnalyser.CensusAnalyser censusAnalyser;
        //correcrt headers
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";

        //correct file paths
        static string indianStateCensusFilePath = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\Indian_Census_Problem\CensualAnalyserTestNew\CSV Files\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\Indian_Census_Problem\CensualAnalyserTestNew\CSV Files\IndiaStateCode.csv";

        //wrong file paths
        static string wrongIndianStateCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string wrongIndianStateCodeFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";

        //wrong headers
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\Indian_Census_Problem\CensualAnalyserTestNew\CSV Files\WrongIndiaStateCensusData.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\WrongIndiaStateCode.csv";

        //wrong file types
        static string wrongIndianStateCensusFileType = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\Indian_Census_Problem\CensualAnalyserTestNew\CSV Files\IndiaStateCensusData.txt";
        static string wrongIndianStateCodeFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\IndiaStateCode.txt";

        //delimiters
        static string delimiterIndianCensusFilePath = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\Indian_Census_Problem\CensualAnalyserTestNew\CSV Files\DelimiterIndiaStateCensusData.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\RAJAT-DAMMU\Desktop\GitProjects\Indian_Census_Problem\CensualAnalyserTestNew\CSV Files\DelimiterIndiaStateCode.csv";


        //US Census FilePath
        static string usCensusHeaders = "State Id,State,Population,Housing units,Total area,Water area,Land area,Population Density,Housing Density";
        static string usCensusFilepath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.csv";
        static string wrongUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USData.csv";
        static string wrongUSCensusFileType = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\USCensusData.txt";
        static string wrongHeaderUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\WrongHeaderUSCensusData.csv";
        static string delimeterUSCensusFilePath = @"C:\Users\Dell\source\repos\CensusAnalyser\CensusAnalyserTest\CsvFiles\USCsvFiles\DelimiterUSCensusData.csv";

        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusTypeException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusTypeException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileDelimiter_WhenRead_ShouldReturnCustomException()
        {
            var censusDelimiterException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusDelimiterException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileHeader_WhenRead_ShouldReturnCustomException()
        {
            var censusHeaderException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusHeaderException.eType);
        }
    }

}