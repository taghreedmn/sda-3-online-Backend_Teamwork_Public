using System.ComponentModel.DataAnnotations;

namespace FusionTech.src.Entity
{
    public class RatedBy
    {
        public Guid RatedId { get; set; }
        public float Rating { get; set; }

        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string Comment { get; set; }
        public Guid VideoGameVersionId  { get; set; }
        public Guid PersonId { get; set; }
    }
}