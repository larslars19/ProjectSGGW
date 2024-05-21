namespace Projekt
{
    [Serializable]
    public struct Location
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Location(double lat, double lon)
        {
            Longitude = lon;
            Latitude = lat;
        }      
    }
}