﻿namespace AlManalChickens.Services.DTO.ChatDTO
{
    public class NewMessageDto
    {
        public int id { get; set; }
        public string message { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Date { get; set; }
        public int Type { get; set; }
        public int Duration { get; set; }
    }
}
