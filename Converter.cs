using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;

namespace Csv2Json
{
    class Converter
    {
        /// <summary>
        /// Parses a csv file at csvPath and saved the json serialized data to a file at jsonPath
        /// </summary>
        /// <param name="csvPath"></param>
        /// <param name="jsonPath"></param>
        public static void Convert(string csvPath, string jsonPath)
        {
            File.WriteAllText(jsonPath, Convert(csvPath));
        }
        /// <summary>
        /// Parses a csv file at csvPath and returns the json serialized data as a string
        /// </summary>
        /// <param name="csvPath"></param>
        public static string Convert(string csvPath)
        {
            using (var reader = new StreamReader(csvPath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var csvRecords = csv.GetRecords<dynamic>();
                    return JsonConvert.SerializeObject(csvRecords.ToList());
                }
            }
        }
    }
}
