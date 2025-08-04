﻿using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.Entities.SettingTables
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Msg { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Date { get; set; }
    }
}
