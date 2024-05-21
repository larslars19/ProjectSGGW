using System;
namespace Projekt
{
	public class BurglarFactory : CriminalFactory
	{
        public override Burglar Build()
        {
            this.Check();
            return new Burglar(firstName,
                                lastName,
                                aliaces,
                                (CriminalStatus)Status,
                                metadata,
                                knownLocations,
                                syndicate,
                                verdict,
                                stolenValue);
        }
        public double stolenValue = 0;
        public void SetStolenValue(double value)
        {
            this.stolenValue = value;
        }
    }
}

