using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Projekt
{
    public struct Criminals : IDataBase
    {
        public BasicCriminal[] AllCriminals { get; set; }

        static readonly string filePath = @"/Users/ela.larsen/Desktop/Test.json";


        public BasicCriminal? FindCriminalByLastName(string name)
        { 
            foreach (var criminal in AllCriminals)
            {
                if (criminal.lastName == name)
                {
                    return criminal;
                }
            }
            return null;
        }

        public void ReadCriminals()
        {
            using StreamReader sr = File.OpenText(filePath);
            string text = sr.ReadToEnd();
            var node = JsonNode.Parse(text);
            AllCriminals = new BasicCriminal[0];
            foreach (var i in node.AsArray())
            {
                var type = i["speciality"].Deserialize<CrimeType>();
                if (type == CrimeType.Burglarly)
                {
                    AddCriminals(Burglar.FromString(i.ToJsonString()));
                }
                else if (type == CrimeType.Murder)
                {
                    AddCriminals(Murderer.FromString(i.ToJsonString()));
                }
                //else if (type == CrimeType.Violence)
                //{
                //    AddCriminals(Violence.FromString(i.ToJsonString()));
                //}
                //else if (type == CrimeType.Drug_Dealing)
                //{
                //    AddCriminals(Drug_Dealer.FromString(i.ToJsonString()));
                //}
                //else if (type == CrimeType.Human_trafficking)
                //{
                //    AddCriminals(Human_Trafficker.FromString(i.ToJsonString()));
                //}
                //else if (type == CrimeType.Corruption)
                //{
                //    AddCriminals(Corruptionist.FromString(i.ToJsonString()));
                //}
                //else if (type == CrimeType.Terrorism)
                //{
                //    AddCriminals(Terrorist.FromString(i.ToJsonString()));
                //}
            }
        }

        public void SaveCriminals()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true
            };
            string text = JsonSerializer.Serialize(AllCriminals, options);
            using StreamWriter sw = File.CreateText(Criminals.filePath);
            sw.Write(text);
        }

        public void AddCriminals(ICriminal person)
        {
            AllCriminals = AllCriminals.Append((BasicCriminal)person).ToArray();
        }
    }
}

