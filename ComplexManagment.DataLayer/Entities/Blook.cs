namespace ComplexManagment.DataLayer.Entities
{
    public class Blook
    {
        public Blook()
        {
            Units = new();
            UsageTypes = new();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitCount { get; set; }
        public int ComplexId { get; set; }
        public Complex Complex { get; set; }

        public HashSet<BlockUsageType> UsageTypes { get; set; }
        public List<Unit> Units { get; set; }
    }
}
