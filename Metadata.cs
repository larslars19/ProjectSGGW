namespace Projekt
{
    public struct Metadata
    {
        public DateOnly? dateOfBirth;
        public Location? placeOfBirth;
        public string? citizenship;
        public char? sex;
        public int? height;
        public int? weight;
        public string? eyeColor;
        public string? hairColor;
        public string? features;
        public string? photo;

        public Metadata()
        {

        }

        public Metadata(DateOnly? dateOfBirth, Location? placeOfBirth, string? citizenship, char? sex,
            int? height, int? weight, string? eyeColor, string? hairColor, string? features, string? photo)

        {
            this.dateOfBirth = dateOfBirth;
            this.placeOfBirth = placeOfBirth;
            this.citizenship = citizenship;
            this.sex = sex;
            this.height = height;
            this.weight = weight;
            this.eyeColor = eyeColor;
            this.hairColor = hairColor;
            this.features = features;
            this.photo = photo;
        }
        public void AddDateOfBirth(DateOnly dateOfBirth)
        {
            this.dateOfBirth = dateOfBirth;
        }
    }

}