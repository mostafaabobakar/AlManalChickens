namespace AlManalChickens.Services.DTO.DashbordDTO.AuthDTO
{
    public class AddMultipleRolesToUserApiDto
    {
        public string userId { get; set; }
        public List<string> rolesId { get; set; }
    }
}
