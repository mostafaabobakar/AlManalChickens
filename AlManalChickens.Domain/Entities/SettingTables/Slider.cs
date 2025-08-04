namespace AlManalChickens.Domain.Entities.SettingTables
{
    public class Slider
    {
        public int Id { get; set; }
        public string SliderName { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool IsActive { get; set; }

    }
}
