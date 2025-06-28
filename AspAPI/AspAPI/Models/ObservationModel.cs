namespace AspAPI.Models
{
    public class ObservationModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<DataEntry> Datas { get; set; } = new List<DataEntry>();
    }
    public class DataEntry
    {
        public DateTime SamplingTime { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
    }

    public class Property
    {
        public object Value { get; set; } = null!;
        public string Label { get; set; } = string.Empty;
    }
}
