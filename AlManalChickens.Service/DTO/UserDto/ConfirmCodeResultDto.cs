namespace AlManalChickens.Services.DTO.UserDto
{
    public class ConfirmCodeResultDto
    {
        public string userId { get; set; }
        public string phone { get; set; }
        public string userName { get; set; }
        public int code { get; set; }
        public int typeUser { get; set; }
    }
}
