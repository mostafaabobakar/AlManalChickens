using AAITHelper;

namespace AlManalChickens.Domain.Entities.Chat
{
    public class HubConnection
    {
        public int Id { get; set; }
        public string ContextId { get; set; }
        public DateTime DateTime { get; set; } = HelperDate.GetCurrentDate();

        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationDbUser User { get; set; }
    }
}
