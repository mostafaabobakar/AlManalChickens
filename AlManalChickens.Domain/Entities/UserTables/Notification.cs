using AlManalChickens.Domain.Enums;

namespace AlManalChickens.Domain.Entities.UserTables
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string TextAr { get; set; }
        public string TextEn { get; set; }
        public DateTime DateTime { get; set; }
        public NotifyType Type { get; set; }
        public bool IsSeen { get; set; }
        public int? ItemId { get; set; }

        public virtual ApplicationDbUser User { get; set; }
    }
}
