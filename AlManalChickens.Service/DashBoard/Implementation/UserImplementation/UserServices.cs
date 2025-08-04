using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Entities.UserTables;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.ViewModel.Users;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.UserInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AlManalChickens.Services.DashBoard.Implementation.UserImplementation
{
    public class UserServices : IUserServices
    {
        private readonly ApplicationDbContext _context;

        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<UsersViewModel>> GetUsers()
        {
            var Users = await _context.Users.Where(u => u.Type == UserType.Client)
                                            .Select(u => new UsersViewModel
                                            {
                                                Id = u.Id,
                                                UserName = u.FullName,
                                                Email = u.Email,
                                                Phone = u.PhoneNumber,
                                                Image = DefaultPath.DomainUrl + u.ProfilePicture,
                                                IsActive = u.IsActive
                                            }).ToListAsync();
            return Users;
        }
        public async Task<bool> ChangeState(string UserId)
        {
            ApplicationDbUser user = await _context.Users.FindAsync(UserId);
            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();
            return user.IsActive;
        }
    }
}
