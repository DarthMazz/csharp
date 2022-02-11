using System;
using System.Text.Json;
using System.Collections.Generic;

namespace json
{
    class Program
    {
        static void Main(string[] args)
        {
            var jsonString = System.IO.File.ReadAllText("./mydata.json", System.Text.Encoding.UTF8);
            var json = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonString);
            foreach (var item in json.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine(json[item]);
                var results = json[item] as Array;
                Console.WriteLine(results.GetValue(0));
            }

            // var results = json["titles"] as List<object>;
            // Console.WriteLine(json);
        }
    }
}
