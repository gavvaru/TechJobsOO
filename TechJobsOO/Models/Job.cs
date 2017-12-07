namespace TechJobsOO.Models
{
    public class Job
    {
        public int ID { get; set; }
        private static int nextId = 1;
 //       internal static Job item;

        public string Name { get; set; }
        public Employer Employer { get; set; }
        public Location Location { get; set; }
        public CoreCompetency CoreCompetency { get; set; }
        public PositionType PositionType { get; set; }

        public Job()
        {
            ID = nextId;
            nextId++;
        }

    }
}
