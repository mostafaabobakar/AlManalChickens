using AlManalChickens.Services.DTO.ChatDTO;

namespace AlManalChickens.Services.Api.Contract.Chat
{
    public interface IChatService
    {
        Task<bool> AddNewMessage(string SenderId, string ReceiverId, int OrderId, string Text, int Type = 0, int Duration = 0);
        Task<List<string>> GetDevicesId(string UserId);
        Task<string> GetReceiverName(string UserId);
        Task<string> GetReceiverImg(string UserId);
        Task<List<ListUsersMyChatDto>> GetListUsersMyChat(string UserId, string lang);
        Task<List<ListMessageTwoUsersDto>> GetListMessageTwoUsersDto(string UserId, int OrderId, int pageNumber);
    }
}
