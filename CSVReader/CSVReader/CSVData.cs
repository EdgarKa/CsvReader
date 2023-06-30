using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class CSVData
    {
        public string CustomerReference {get; set; }
        public string CustomerName {get; set; }
        public string Address1 {get; set; }
        public string Address2 {get; set; }
        public string Town {get; set; }
        public string County {get; set; }
        public string Country {get; set; }
        public string Postcode {get; set; }

        public static CSVData FromCsv(string line)
        {
            string[] splitter = line.Split(',');
            CSVData data = new CSVData();
            data.CustomerReference = splitter[0];
            data.CustomerName = splitter[1];
            data.Address1 = splitter[2];
            data.Address2 = splitter[3];
            data.Town = splitter[4];
            data.County = splitter[5];
            data.Country = splitter[6];
            data.Postcode = splitter[7];
            return data;
        }
    }
}
