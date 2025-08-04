namespace AlManalChickens.Services.DTO.DashbordDTO.AuthDTO
{
    public class AddMultipleRolesToUserDto
    {
        public string userId { get; set; }
        public IEnumerable<string> rolesId { get; set; }
    }
}
