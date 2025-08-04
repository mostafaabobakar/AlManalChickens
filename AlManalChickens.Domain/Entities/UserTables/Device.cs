using AAITHelper;

namespace AlManalChickens.Domain.Entities.UserTables
{
    public class Device
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Identifier { get; set; }
        public string DeviceType { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateTime { get; set; } = HelperDate.GetCurrentDate();

        public virtual ApplicationDbUser user { get; set; }
    }
}
