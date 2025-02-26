📌 JSON and Data Handling in C#
🔹 Practice Problems
1️⃣ Basic JSON Handling
1. Create a JSON object for a Student with fields: name, age, and subjects (array).
2. Convert a C# object (Car class) into JSON format.
3. Read a JSON file and extract only specific fields (e.g., name, email).
4. Merge two JSON objects into one.
5. Validate JSON structure using Newtonsoft.Json.Schema.
6. Convert a list of C# objects into a JSON array.
7. Parse JSON and filter only those records where age > 25.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class Car
{
   public string Make { get; set; }
   public string Model { get; set; }
   public int Year { get; set; }
}

class Program
{
   static void Main()
   {
       // 1 Create a JSON object for a Student
       var student = new
       {
           Name = "John Doe",
           Age = 20,
           Subjects = new string[] { "Math", "Physics", "Computer Science" }
       };
       Console.WriteLine("\n JSON Object for Student:");
       Console.WriteLine(JsonConvert.SerializeObject(student, Formatting.Indented));

       //  Convert a C# object (Car class) into JSON format
       Car car = new Car { Make = "Toyota", Model = "Corolla", Year = 2022 };
       Console.WriteLine("\n Car Object to JSON:");
       Console.WriteLine(JsonConvert.SerializeObject(car, Formatting.Indented));

       //  Read a JSON file and extract only specific fields (name, email)
       string jsonFile = "[{'name': 'Alice', 'email': 'alice@example.com'},{'name': 'Bob', 'email': 'bob@example.com'}]";
       JArray jsonArray = JArray.Parse(jsonFile);
       Console.WriteLine("\ Extracted Fields (Name & Email):");
       foreach (var item in jsonArray)
           Console.WriteLine($"Name: {item["name"]}, Email: {item["email"]}");

       //  Merge two JSON objects
       string json1 = "{ \"Name\": \"John\", \"Age\": 25 }";
       string json2 = "{ \"Email\": \"john@example.com\", \"City\": \"New York\" }";
       JObject obj1 = JObject.Parse(json1);
       JObject obj2 = JObject.Parse(json2);
       obj1.Merge(obj2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
       Console.WriteLine("\ Merged JSON Object:");
       Console.WriteLine(obj1);

       //  Validate JSON structure using Schema
       string schemaJson = "{" +
           "'type': 'object', 'properties': { 'Name': { 'type': 'string' }, 'Age': { 'type': 'integer' } }, 'required': ['Name', 'Age'] }";
       JSchema schema = JSchema.Parse(schemaJson);
       JObject obj = JObject.Parse(json1);
       bool isValid = obj.IsValid(schema, out IList<string> errors);
       Console.WriteLine($"\ JSON Validation: {isValid}");
       if (!isValid) errors.ToList().ForEach(Console.WriteLine);

       //  Convert a list of C# objects into a JSON array
       List<Car> cars = new List<Car>
       {
           new Car { Make = "Toyota", Model = "Camry", Year = 2021 },
           new Car { Make = "Honda", Model = "Civic", Year = 2022 }
       };
       Console.WriteLine("\ List of Cars to JSON Array:");
       Console.WriteLine(JsonConvert.SerializeObject(cars, Formatting.Indented));

       //  Parse JSON and filter only records where age > 25
       string peopleJson = "[{\"name\": \"Alice\", \"age\": 30}, {\"name\": \"Bob\", \"age\": 24}, {\"name\": \"Charlie\", \"age\": 28}]";
       JArray peopleArray = JArray.Parse(peopleJson);
       var filteredPeople = peopleArray.Where(obj => (int)obj["age"] > 25);
       Console.WriteLine("\ Filtered People (Age > 25):");
       Console.WriteLine(JsonConvert.SerializeObject(filteredPeople, Formatting.Indented));
   }
}
	



________________


1. s.2️⃣ Hands-on Practice Problems
2. Read a JSON file and print all keys and values.
3. Convert a list of C# objects into a JSON array.
4. Filter JSON data: Print only users older than 25 years.
5. Validate an email field using JSON Schema.
6. Merge two JSON files into a single JSON object.
7. Convert JSON to XML format.
8. Convert CSV data into JSON.
9. Generate a JSON report from database record
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;

class Car
{
   public string Make { get; set; }
   public string Model { get; set; }
   public int Year { get; set; }
}

class Program
{
   static void Main()
   {
       // 1️ Read a JSON file and print all keys and values
       string jsonFile = "{\"name\": \"Alice\", \"email\": \"alice@example.com\", \"age\": 30}";
       JObject jsonObj = JObject.Parse(jsonFile);
       Console.WriteLine("\n1️ JSON Keys and Values:");
       foreach (var item in jsonObj)
           Console.WriteLine($"{item.Key}: {item.Value}");

       // 2️ Convert a list of C# objects into a JSON array
       List<Car> cars = new List<Car>
       {
           new Car { Make = "Toyota", Model = "Camry", Year = 2021 },
           new Car { Make = "Honda", Model = "Civic", Year = 2022 }
       };
       Console.WriteLine("\n2️ List of Cars to JSON Array:");
       Console.WriteLine(JsonConvert.SerializeObject(cars, Formatting.Indented));

       // 3️ Filter JSON data: Print only users older than 25 years
       string peopleJson = "[{\"name\": \"Alice\", \"age\": 30}, {\"name\": \"Bob\", \"age\": 24}, {\"name\": \"Charlie\", \"age\": 28}]";
       JArray peopleArray = JArray.Parse(peopleJson);
       var filteredPeople = peopleArray.Where(obj => (int)obj["age"] > 25);
       Console.WriteLine("\n3️ Filtered People (Age > 25):");
       Console.WriteLine(JsonConvert.SerializeObject(filteredPeople, Formatting.Indented));

       // 4️ Validate an email field using JSON Schema
       string schemaJson = "{" +
           "'type': 'object', 'properties': { 'email': { 'type': 'string', 'format': 'email' } }, 'required': ['email'] }";
       JSchema schema = JSchema.Parse(schemaJson);
       JObject obj = JObject.Parse(jsonFile);
       bool isValid = obj.IsValid(schema, out IList<string> errors);
       Console.WriteLine($"\n4️ Email Validation: {isValid}");
       if (!isValid) errors.ToList().ForEach(Console.WriteLine);

       // 5️ Merge two JSON files into a single JSON object
       string json1 = "{ \"Name\": \"John\", \"Age\": 25 }";
       string json2 = "{ \"Email\": \"john@example.com\", \"City\": \"New York\" }";
       JObject obj1 = JObject.Parse(json1);
       JObject obj2 = JObject.Parse(json2);
       obj1.Merge(obj2, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Union });
       Console.WriteLine("\n5️ Merged JSON Object:");
       Console.WriteLine(obj1);

       // 6️ Convert JSON to XML format
       XmlDocument xmlDoc = JsonConvert.DeserializeXmlNode(jsonFile, "Root");
       Console.WriteLine("\n6️ JSON to XML:");
       Console.WriteLine(xmlDoc.OuterXml);

       // 7️ Convert CSV data into JSON
       string csvData = "Name,Age\nAlice,30\nBob,24\nCharlie,28";
       var csvLines = csvData.Split('\n');
       var headers = csvLines[0].Split(',');
       var jsonArray = new JArray();
       for (int i = 1; i < csvLines.Length; i++)
       {
           var values = csvLines[i].Split(',');
           var jsonObject = new JObject();
           for (int j = 0; j < headers.Length; j++)
               jsonObject[headers[j]] = values[j];
           jsonArray.Add(jsonObject);
       }
       Console.WriteLine("\n7️ CSV to JSON:");
       Console.WriteLine(JsonConvert.SerializeObject(jsonArray, Formatting.Indented));

       // 8️ Generate a JSON report from database records (Mock Data)
       var dbRecords = new List<Dictionary<string, object>>
       {
           new Dictionary<string, object> { { "ID", 1 }, { "Name", "Alice" }, { "Age", 30 } },
           new Dictionary<string, object> { { "ID", 2 }, { "Name", "Bob" }, { "Age", 24 } }
       };
       Console.WriteLine("\ JSON Report from Database:");
       Console.WriteLine(JsonConvert.SerializeObject(dbRecords, Formatting.Indented));
   }
}
	

________________








🏏 Problem Statement: IPL and Censorship Analyzer


This C# version of the IPL and Censorship Analyzer provides data processing, JSON manipulation, and file handling using Newtonsoft.Json & File I/O operations.
🚀 Next Steps: Enhance the project with database integration and real-time API handling! 🔥
🎯 Objective
Develop a C# application that reads IPL match data from JSON and CSV files, processes the data based on defined censorship rules, and writes the sanitized data back to new files.
________________


📌 Requirements
1️⃣ Input Data Formats
The application should support:
* JSON Input: IPL match data in JSON format.
* CSV Input: IPL match data in CSV format.
2️⃣ Censorship Rules
The program should apply the following censorship rules:
1. Mask Team Names → Replace part of the team name with "***".
   * Example: "Mumbai Indians" → "Mumbai ***"
2. Redact Player of the Match → Replace player names with "REDACTED".
3️⃣ Output Data Formats
* Generate censored JSON and censored CSV files after processing.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class Program
{
   static void Main()
   {
       string jsonFilePath = "ipl_data.json";
       string csvFilePath = "ipl_data.csv";
       string jsonOutputPath = "censored_ipl_data.json";
       string csvOutputPath = "censored_ipl_data.csv";
       
       // Process JSON File
       if (File.Exists(jsonFilePath))
       {
           string jsonContent = File.ReadAllText(jsonFilePath);
           JArray matches = JArray.Parse(jsonContent);
           ProcessIPLData(matches);
           File.WriteAllText(jsonOutputPath, JsonConvert.SerializeObject(matches, Formatting.Indented));
       }
       
       // Process CSV File
       if (File.Exists(csvFilePath))
       {
           var csvLines = File.ReadAllLines(csvFilePath).ToList();
           var headers = csvLines[0].Split(',');
           for (int i = 1; i < csvLines.Count; i++)
           {
               var values = csvLines[i].Split(',');
               values[1] = MaskTeamName(values[1]);
               values[2] = MaskTeamName(values[2]);
               values[5] = MaskTeamName(values[5]);
               values[6] = "REDACTED";
               csvLines[i] = string.Join(",", values);
           }
           File.WriteAllLines(csvOutputPath, csvLines);
       }
   }
   
   static void ProcessIPLData(JArray matches)
   {
       foreach (var match in matches)
       {
           match["team1"] = MaskTeamName(match["team1"].ToString());
           match["team2"] = MaskTeamName(match["team2"].ToString());
           match["winner"] = MaskTeamName(match["winner"].ToString());
           match["player_of_match"] = "REDACTED";
           
           var score = match["score"] as JObject;
           if (score != null)
           {
               foreach (var key in score.Properties().ToList())
               {
                   string newKey = MaskTeamName(key.Name);
                   score[newKey] = score[key.Name];
                   score.Remove(key.Name);
               }
           }
       }
   }
   
   static string MaskTeamName(string teamName)
   {
       var words = teamName.Split(' ');
       if (words.Length > 1)
           words[1] = "***";
       return string.Join(" ", words);
   }
}
	



________________


📝 Sample IPL Data
JSON Input (Before Censorship)
[
  {
    "match_id": 101,
    "team1": "Mumbai Indians",
    "team2": "Chennai Super Kings",
    "score": {
      "Mumbai Indians": 178,
      "Chennai Super Kings": 182
    },
    "winner": "Chennai Super Kings",
    "player_of_match": "MS Dhoni"
  },
  {
    "match_id": 102,
    "team1": "Royal Challengers Bangalore",
    "team2": "Delhi Capitals",
    "score": {
      "Royal Challengers Bangalore": 200,
      "Delhi Capitals": 190
    },
    "winner": "Royal Challengers Bangalore",
    "player_of_match": "Virat Kohli"
  }
]
________________


CSV Input (Before Censorship)
match_id,team1,team2,score_team1,score_team2,winner,player_of_match
101,Mumbai Indians,Chennai Super Kings,178,182,Chennai Super Kings,MS Dhoni
102,Royal Challengers Bangalore,Delhi Capitals,200,190,Royal Challengers Bangalore,Virat Kohli
________________


🎯 Expected Output (After Censorship)
JSON Output (After Censorship)
[
  {
    "match_id": 101,
    "team1": "Mumbai ***",
    "team2": "Chennai ***",
    "score": {
      "Mumbai ***": 178,
      "Chennai ***": 182
    },
    "winner": "Chennai ***",
    "player_of_match": "REDACTED"
  },
  {
    "match_id": 102,
    "team1": "Royal *** Bangalore",
    "team2": "Delhi ***",
    "score": {
      "Royal *** Bangalore": 200,
      "Delhi ***": 190
    },
    "winner": "Royal *** Bangalore",
    "player_of_match": "REDACTED"
  }
]
________________


CSV Output (After Censorship)
match_id,team1,team2,score_team1,score_team2,winner,player_of_match
101,Mumbai ***,Chennai ***,178,182,Chennai ***,REDACTED
102,Royal *** Bangalore,Delhi ***,200,190,Royal *** Bangalore,REDACTED
________________


🚀 Summary
Feature
	Description
	Read JSON/CSV
	Parse IPL data from files
	Apply Censorship
	Mask team names and redact player names
	Write to JSON/CSV
	Save modified data back to files
	Filtering & Masking
	Modify team names using MaskTeamName()