namespace AlManalChickens.Domain.Entities.Cities_Tables
{
    public class City : BaseEntity
    {
        public virtual ICollection<Region> Regions { get; set; }

    }
}
