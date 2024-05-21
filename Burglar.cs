using System;
using System.Text.Json;

namespace Projekt
{
    [Serializable]
    public class Burglar : BasicCriminal
	{
		public double stolenValue { get; set; }

        public Burglar(string firstName, string lastName, string[] aliaces, CriminalStatus status, Metadata? metadata,
            Location[] knownLocations, Syndicate? syndicate, string verdict, double stolenValue) :
            base(firstName, lastName, aliaces, status, metadata, knownLocations, syndicate, verdict)
        {
            this.stolenValue = stolenValue;
            speciality = CrimeType.Burglarly;
        }

        public void SetStolenValue(int value)
        {
            this.stolenValue = value;
        }
        public override void Wypisz()
        {
            Console.WriteLine($"Złodziej\nImię i nazwisko: {firstName} {lastName}\nStatus: {Status} " +
                $"\nSkradziona suma: {stolenValue}\n\n");
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public static new Burglar FromString(string data)
        {
            return JsonSerializer.Deserialize<Burglar>(data);
        }
    }
}

