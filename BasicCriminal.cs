using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Projekt
{
    public enum CriminalStatus
    {
        Wanted=1, Custody, InPrison, Killed, Released
    }

    public enum CrimeType
    {
        Burglarly=1, Murder, Violence, Drug_dealing, Human_trafficking, Corruption, Terrorism
    }


    [JsonDerivedType(typeof(Burglar))]
    [JsonDerivedType(typeof(Murderer))]
    public abstract class BasicCriminal : ICriminal
	{
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string[] aliaces { get; set; }
        public CriminalStatus Status { get; set; }
        public Metadata? metadata { get; set; }
        public CrimeType speciality { get; set; }
        public Location[] knownLocations { get; set; }
        public Syndicate? syndicate { get; set; }
        public string verdict { get; set; }

        protected BasicCriminal(string firstName, string lastName, string[] aliaces, CriminalStatus status, Metadata? metadata,
            Location[] knownLocations, Syndicate? syndicate, string verdict)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.aliaces = aliaces;
            Status = status;
            this.metadata = metadata;
            this.knownLocations = knownLocations;
            this.syndicate = syndicate;
            this.verdict = verdict;
        }

        public abstract void Wypisz();

        public void ChangeStatus(CriminalStatus status)
        {
            this.Status = status;
        }
        public void AddNewLocation(Location location)
        {
            knownLocations = knownLocations.Append(location).ToArray();
        }
        public void ChangeVerdict(string verdict)
        {
            this.verdict = verdict;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public static object FromString(string data)
        {
            throw new NotImplementedException();
        }

    }
}

