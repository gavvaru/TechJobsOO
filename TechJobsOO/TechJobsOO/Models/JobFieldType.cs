using System.ComponentModel.DataAnnotations;

namespace TechJobsOO.Models
{
    public enum JobFieldType
    {
        // Enum representing the JobField properties of a Job
        // that can be viewed and searched.

        Employer,
        Location,
        CoreCompetency,
        PositionType,
        All
    }
}
