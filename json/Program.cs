using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Text.Json.Nodes;

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
                // var results = json[item] as ;
                // Console.WriteLine(results.GetValue(0));
            }

            // var results = json["titles"] as List<object>;
            Console.WriteLine(json);
            var jnode = JsonSerializer.Deserialize<JsonNode>(jsonString);
            Console.WriteLine(jnode);
            Console.WriteLine(jnode["titles"]);
            var item0 = jnode["titles"][0][0][0];
            Console.WriteLine(item0);
            var list = jnode["titles"][0][0].AsArray();
            foreach (var jitem in list)
            {
                Console.WriteLine(jitem);
            }

            jnode["test"] = "test";
            Console.WriteLine(jnode.ToString());
            var options = new JsonSerializerOptions { WriteIndented = true };
            Console.WriteLine(jnode!.ToJsonString(options));
            // output:
        }
    }
}
