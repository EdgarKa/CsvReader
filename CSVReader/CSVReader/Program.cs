using System.Text;
using System.Text.Json;

namespace CSVReader
{
    public class Program
    {
        static void Main(string[] args)
        {
            ReadAndPostAsync().Wait();

        }

        static async Task ReadAndPostAsync()
        {
            string path = @"..\..\..\Resources\Test.csv";
            if (!File.Exists(path))
            {
                Console.WriteLine($"File doesn't exist, make sure the path is in the \"Resources\" folder");
                Environment.Exit(1);
            }

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None, 64 * 1024, FileOptions.SequentialScan))
            using (var sr = new StreamReader(fs))
            {
                string line = sr.ReadLine(); // ignore first line
                while ((line = sr.ReadLine()) != null)
                {
                    CSVData csvLine = CSVData.FromCsv(line);
                    await SendLineAsync(csvLine);
                }
            }
        }

        static async Task<bool> SendLineAsync(CSVData data)
        {
            using var client = new HttpClient();
            
            string strJson = JsonSerializer.Serialize<CSVData>(data);

            HttpContent content = new StringContent(strJson, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7298/api/Customer", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Console.WriteLine(result);
                return true;
            }
            else
            {
                Console.WriteLine($"Failed with code {response.StatusCode}");
                return false;
            }
        }
    }
}