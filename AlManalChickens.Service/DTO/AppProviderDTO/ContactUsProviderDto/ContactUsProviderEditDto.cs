﻿using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Services.DTO.AppProviderDTO.ContactUsProviderDto
{
    public class ContactUsProviderAddDto
    {
        [Required]
        public string userName { get; set; }
        /// <summary>
        /// email or phone
        /// </summary>   
        [Required]
        public string email { get; set; }
        [Required]
        public string msg { get; set; }
    }
}
