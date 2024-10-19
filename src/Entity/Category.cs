namespace FusionTech.src.Entity
{
    public class Category
    {

        public Guid CategoryId { get; set; }
        public required string CategoryName { get; set; }
        public virtual ICollection<VideoGameInfo> VideoGameInfos { get; set; }

    }
}
