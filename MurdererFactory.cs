using System;
namespace Projekt
{
	public class MurdererFactory : CriminalFactory
	{
        public override Murderer Build()
        {
            this.Check();
            return new Murderer(firstName,
                                lastName,
                                aliaces,
                                (CriminalStatus)Status,
                                metadata,
                                knownLocations,
                                syndicate,
                                verdict,
                                killCount,
                                knownVictims);
        }

        private int killCount = 0;
        private string[] knownVictims = new string[0];

        public void SetKillCount(int killCount)
        {
            this.killCount = killCount;
        }
        public void AddKnownVictim(params string[] victim)
        {
            this.knownVictims = this.knownVictims.Concat(victim).ToArray();
        }

    }
}

