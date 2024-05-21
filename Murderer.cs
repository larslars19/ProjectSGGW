using System;
using System.Text.Json;

namespace Projekt
{
    [Serializable]
    public class Murderer : BasicCriminal
	{
        public int killCount { get; set; }
        public string[] knownVictims { get; set; }

        public Murderer(string firstName, string lastName, string[] aliaces, CriminalStatus status, Metadata? metadata, Location[] knownLocations, Syndicate? syndicate, string verdict, int killCount, string[] knownVictims) :
            base(firstName, lastName, aliaces, status, metadata, knownLocations, syndicate, verdict)
        {
            this.killCount = killCount;
            this.knownVictims = knownVictims;
            this.speciality = CrimeType.Murder;
        }

        public void AddVictim (string? name)
        {
            killCount++;
            if (name != null)
            {
                knownVictims = knownVictims.Append(name).ToArray();
            }
        }

        public override void Wypisz()
        {
            Console.WriteLine($"Morderca\nImię i nazwisko: {firstName} {lastName}\nStatus: {Status} " +
                $"\nIlość ofiar: {killCount} \nZnane ofiary: {string.Join(", ", knownVictims)}\n\n");
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public static new Murderer FromString(string data)
        {
            return JsonSerializer.Deserialize<Murderer>(data);
        }

    }
}

