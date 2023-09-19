using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using ZdalyTest.Models;

namespace ZdalyTest.Services
{
    public class CsvService
    {
        private readonly string _csvFilePath;

        public CsvService()
        
        {
            // Set the path to your CSV file here
            _csvFilePath = @"C:\Users\rajas\source\repos\ZdalyTest\ZdalyTest\Data\data.csv";
        }

        public List<Data> ReadDataFromCsv()
        {
            try
            {
                // Read the CSV file as text and preprocess the header row
                var csvText = File.ReadAllText(_csvFilePath);
                csvText = csvText.Replace("\"", ""); // Remove double quotes from the header row

                // Use a StringReader to read the preprocessed CSV text
                using (var reader = new StringReader(csvText))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";", // Set the delimiter to semicolon
                    HasHeaderRecord = true // Indicates that the file has a header row
                }))
                {
                    return csv.GetRecords<Data>().ToList();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here (e.g., log or throw)
                throw;
            }
        }
    }
}
