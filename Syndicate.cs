namespace Projekt
{
    public struct Syndicate
    {
        public string name;
        public int population;
        public Location location;

        public Syndicate(string name, int population, Location location)
        {
            this.name = name;
            this.population = population;
            this.location = location;
        }
    }
}