using System;
namespace Projekt
{
    public abstract class CriminalFactory
    {
        public string? firstName;
        public string? lastName;
        public string[] aliaces = new string[0];
        public CriminalStatus? Status;
        public Metadata? metadata;
        public Location[] knownLocations = Array.Empty<Location>();
        public Syndicate? syndicate;
        public string? verdict;


        public void SetName(string name, string lastName)
        {
            this.firstName = name;
            this.lastName = lastName;
        }
        public void AddAliaces(string[] aliaces)
        {
            this.aliaces = this.aliaces.Concat(aliaces).ToArray();
        }
        public void SetStatus (CriminalStatus status)
        {
            this.Status = status;
        }
        public void SetMetadata (Metadata metadata)
        {
            this.metadata = metadata;
        }
        public void AddLocation(Location location)
        {
            this.knownLocations = this.knownLocations.Append(location).ToArray();
        }
        public void SetSyndicate(Syndicate syndicate)
        {
            this.syndicate = syndicate;
        }
        public void SetVerdict(string verdict)
        {
            this.verdict = verdict;
        }

        internal void Check()
        {
            if (firstName == null)
            {
                throw new Exception("Dodaj imię!");
            }
            if (lastName == null)
            {
                throw new Exception("Dodaj nazwisko!");
            }
            if (Status == null)
            {
                throw new Exception("Dodaj status!");
            }
        }

        public abstract ICriminal Build();
    }
}

