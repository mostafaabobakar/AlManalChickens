﻿using System.ComponentModel.DataAnnotations;

namespace AlManalChickens.Domain.Entities.SettingTables
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public string Address { get; set; }

        public string CondtionsArClient { get; set; }
        public string CondtionsEnClient { get; set; }

        public string CondtionsArProvider { get; set; }
        public string CondtionsEnProvider { get; set; }

        public string AboutUsArClient { get; set; }
        public string AboutUsEnClient { get; set; }

        public string AboutUsArProvider { get; set; }
        public string AboutUsEnProvider { get; set; }

        public string SenderNameSms { get; set; } = "test";
        public string UserNameSms { get; set; } = "test";
        public string PasswordSms { get; set; } = "test";

        public string ApplicationId { get; set; }
        public string SenderId { get; set; }

        //4jawaly mobily elyamam
        public string SmsProvider { get; set; } = "test";
        public string ChangeLangCondtionClient(string lang = "ar")
        {

            return AAITHelper.HelperMsg.creatMessage(lang, CondtionsArClient, CondtionsEnClient);
        }
        public string ChangeLangCondtionProvider(string lang = "ar")
        {

            return AAITHelper.HelperMsg.creatMessage(lang, CondtionsArProvider, CondtionsEnProvider);
        }
        public string ChangeLangAboutUsClient(string lang = "ar")
        {

            return AAITHelper.HelperMsg.creatMessage(lang, AboutUsArClient, AboutUsEnClient);
        }
        public string ChangeLangAboutUsProvider(string lang = "ar")
        {

            return AAITHelper.HelperMsg.creatMessage(lang, AboutUsArProvider, AboutUsEnProvider);
        }
    }
}
