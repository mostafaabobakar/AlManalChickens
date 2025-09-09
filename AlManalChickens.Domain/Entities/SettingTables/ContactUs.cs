using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.Entities.SettingTables
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Msg { get; set; }
        public int Gender { get; set; }
        public string Region { get; set; }
        public string PhoneNumber { get; set; }
        public int Type { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
    }
}
