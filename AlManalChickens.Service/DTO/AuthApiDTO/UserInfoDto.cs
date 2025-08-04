using AlManalChickens.Domain.Enums;

namespace AlManalChickens.Services.DTO.AuthApiDTO;

public class UserInfoDto
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public UserType UserType { get; set; }
    public string? ProfilePicture { get; set; }
    public bool AllowNotify { get; set; }
    public string? Token { get; set; }

    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }


    public string PostCode { get; set; }
    public string Lat { get; set; }
    public string Lng { get; set; }
    public string Location { get; set; }

    public string CompanyName { get; set; }
}