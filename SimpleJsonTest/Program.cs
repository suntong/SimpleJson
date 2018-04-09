using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using SimpleJson;
using SimpleJsonTest.Properties;

namespace SimpleJsonTest
{
    public class Program
    {
        public static void Main()
        {
            Test1();
            Test2();
            TestJsFile();
            TestProperties_ResourceManager();
            TestProperties_Properties();
        }
        public static void Test1()
        {
            string input = @"{
  ""CPU"": ""Intel"",
  ""Cores"": 8,
  ""Drives"": [
    ""DVD read/writer"",
    ""500 gigabyte hard drive""
  ]
}";
            Console.WriteLine(input);

            object obj = SimpleJson.SimpleJson.DeserializeObject(input);


            var root = (IDictionary<string, object>)obj;

            Console.WriteLine(root.Count);

            Console.WriteLine(root.ContainsKey("CPU"));
            Console.WriteLine(root["CPU"]); // "Intel"
            Console.WriteLine(root["Cores"]); // "Intel"

            Console.WriteLine(root.ContainsKey("Drives"));
            Console.WriteLine(root["Drives"]); // 
        }

        public static void Test2()
        {
            var jsonString = @"{
  ""inputs"" : [""a"", ""b"", ""c""],
  ""outputs"" : [""c"", ""d"", ""e""]
}";
            dynamic sys = SimpleJson.SimpleJson.DeserializeObject(jsonString);

            //foreach (var attr in sys)
            //{
            //    foreach (var name in attr)
            //    {
            //        Console.WriteLine("In {0} with name: {1}", attr, name);
            //    }
            //}

            Console.WriteLine(sys["inputs"][0]);
            Console.WriteLine(sys["outputs"][1]);

            // Convert to List<string>
            var i = (List<object>)sys["inputs"];
            var isl = i.Cast<string>().ToList();
            var isl2 = ((List<object>)sys["inputs"]).Cast<string>().ToList();
        }
        public static void TestJsFile()
        {
            string jsonString="";

            string fn = "Program.json";
            if (File.Exists(fn))
                jsonString = File.ReadAllText(fn, Encoding.UTF8);

            object obj = SimpleJson.SimpleJson.DeserializeObject(jsonString);
            Console.WriteLine(obj);
        }

        public static void TestProperties_ResourceManager()
        {
            string scenario = Resources.ResourceManager.GetString("Scenario");
            if (scenario != null)
                Console.WriteLine(scenario);
            else
                Console.WriteLine("Resource Properties not found!");
        }

        public static void TestProperties_Properties()
        {
            string scenario = Properties.Resources.Scenario;
            if (scenario != null)
                Console.WriteLine(scenario);
            else
                Console.WriteLine("Resource Properties not found!");
        }

    }
}
