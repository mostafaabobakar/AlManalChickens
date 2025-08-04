using AlManalChickens.Domain.Enums;
using AlManalChickens.Domain.Model;
using AlManalChickens.Persistence;
using AlManalChickens.Services.DashBoard.Contract.HomeInterfaces;

namespace AlManalChickens.Services.DashBoard.Implementation.HomeImplementation
{
    public class HomeServices : IHomeServices
    {
        private readonly ApplicationDbContext _context;

        public HomeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public DashBoardHomeModel HomeIndex()
        {
            var data = (from st in _context.Settings
                        let UserCount = _context.Users.Where(x => x.Type == UserType.Client).Count()
                        select new DashBoardHomeModel
                        {
                            UserCount = UserCount
                        }).FirstOrDefault();

            return data;
        }
    }
}
