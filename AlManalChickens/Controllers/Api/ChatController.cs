using AlManalChickens.Controllers.Shared;
using AlManalChickens.Domain.Common.Helpers;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Domain.Enums;
using AlManalChickens.Services.Api.Contract.Chat;
using AlManalChickens.Services.Api.Contract.General;
using AlManalChickens.Services.DTO.ChatDTO;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.Api
{
    [ApiExplorerSettings(GroupName = "ChatAPI")]
    public class ChatController : BaseAPIController
    {
        private readonly IUserContext _userContext;
        private readonly IChatService _chatService;
        private readonly IHelper _helper;
        public ChatController(IServiceProvider serviceProvider)
        {
            _userContext = (IUserContext)serviceProvider.GetService(typeof(IUserContext));
            _chatService = (IChatService)serviceProvider.GetService(typeof(IChatService));
            _helper = (IHelper)serviceProvider.GetService(typeof(IHelper));
        }

        //دى هتجيب كل الشاتات الخاصه بشخص معين 
        [HttpPost(ApiRoutes.Chat.ListUsersMyChat)]
        public async Task<IActionResult> ListUsersMyChat()
        {
            try
            {
                List<ListUsersMyChatDto> ListUsers = await _chatService.GetListUsersMyChat(UserId, Lang);

                return new JsonResult (new { key = 1, data = ListUsers });
            }
            catch (Exception ex)
            {
                return new JsonResult (new { key = 0, data = ex.Message });
            }
        }

        // دى هتجيب كل الرسائل الى فى شات معين هنا كان الشات على الطلب لو اللوجيك على حاجه تانيه خلاف الطلب نظبطها للوجيك الى انا عاوزه
        [HttpPost(ApiRoutes.Chat.ListMessagesUser)]
        public async Task<ActionResult> ListMessagesUser(int OrderId, int pageNumber = 1)
        {
            List<ListMessageTwoUsersDto> ListMessages = await _chatService.GetListMessageTwoUsersDto(UserId, OrderId, pageNumber);

            return new JsonResult (new { key = 1, data = ListMessages });
        }

        // دى علشان الموبايل يقدر يرفع اى ملف فى الشات الفكره هنا انه بيرفع الملف عندى سواء كان صورة فيديو ...هرجعله لينك هيحطه عندى فى ال الرسائل عندى
        [HttpPost(ApiRoutes.Chat.UploadNewFile)]
        public ActionResult UploadFile([FromForm] UploadFileDto file)
        {
            string fileName = _helper.Upload(file.File, (int)FileName.ChatFiles);

            return new JsonResult (new { key = 1, data = fileName, msg = "تم الارسال" });
        }


    }
}
