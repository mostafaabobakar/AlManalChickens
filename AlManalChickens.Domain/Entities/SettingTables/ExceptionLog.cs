using AAITHelper;

namespace AlManalChickens.Domain.Entities.SettingTables
{
    public class ExceptionLog
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ServiceName { get; set; }
        public string Exception { get; set; }
        public DateTime Date { get; set; } = HelperDate.GetCurrentDate();
    }
}
