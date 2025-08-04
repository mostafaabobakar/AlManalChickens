using AlManalChickens.Controllers.Shared;
using AlManalChickens.Services.Api.Contract.Auth;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.Api
{
    [ApiExplorerSettings(GroupName = "AppLogicAPI")]
    public class AppLogicController : BaseAPIController
    {
        private readonly IUserServices _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppLogicController(IUserServices userServices, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userServices;
            _httpContextAccessor = httpContextAccessor;
        }


        /// <summary>
        /// get user data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///   {
        /// "id": "c3eed5f3-ca71-4833-ace9-62ee3b608d95",
        /// "userName": "ahmed",
        /// "email": "ahmed@gmail.com",
        /// "phone": "01234567895",
        /// "lang": "ar",
        /// "closeNotify": false,
        /// "status": false,
        /// "imgProfile": "https://image.freepik.com/free-vector/user-icon_126283-435.jpg",
        /// "token": "",
        /// "typeUser": 1,
        /// "code": 1234,
        /// "activeCode": false
        ///  }
        /// </remarks>
        /// <param lang="ar">ar or en</param>
        /// <returns>return object of user </returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>
        /*
        [HttpGet(ApiRoutes.Identity.GetDataOfUser)]
        public async Task<IActionResult> GetDataOfUser()
        {
            try
            {
                var response = await _userService.GetUserInfo(UserId, Lang, "");
                if (response is not null)
                    return Ok(response);
                else
                {
                    return NotFound(HelperMsg.creatMessage(Lang, "لم يتم العثور علي هذا المستخدم", "Not Found"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.InnerException.Message);
            }
        }
        */


        /// <summary>
        ///update user data 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///   {
        /// "id": "c3eed5f3-ca71-4833-ace9-62ee3b608d95",
        /// "userName": "ahmed",
        /// "email": "ahmed@gmail.com",
        /// "phone": "01234567895",
        /// "lang": "ar",
        /// "closeNotify": false,
        /// "status": false,
        /// "imgProfile": "https://image.freepik.com/free-vector/user-icon_126283-435.jpg",
        /// "token": "",
        /// "typeUser": 1,
        /// "code": 1234,
        /// "activeCode": false
        ///  }
        /// </remarks>
        /// <param lang="userModel.lang">ar or en</param>
        /// <param userName="userModel.userName"></param>
        /// <param email="userModel.email"></param>
        /// <param phone="userModel.phone"></param>
        /// <param imgProfile="userModel.imgProfile"></param>
        /// <returns>return object of user </returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>
        /*[HttpPut(ApiRoutes.Identity.UpdateDataUser)]
        
        public async Task<IActionResult> UpdateDataUser([FromForm] UpdateUserDto userModel)
        {
            if (userModel.phone != null)
            {
                var phoneExist = await _userService.CheckValidatePhone(userModel.phone);
                if (phoneExist)
                {
                    return BadRequest(Helper.MsgRequiredValidation(EnumValidMsg.Auth.PhoneExisting.ToNumber(), Lang));
                }
            }
            if (userModel.email != null)
            {
                var emailExist = await _userService.CheckValidateEmail(userModel.email);
                if (emailExist)
                {
                    return BadRequest(Helper.MsgRequiredValidation(EnumValidMsg.Auth.EmailExisting.ToNumber(), Lang));
                }
            }

            try
            {
                await _userService.UpdateDataUser(userModel);
                return Ok(await _userService.GetUserInfo(UserId, Lang, ""));
            }
            catch (Exception ex)
            {
                return BadRequest(Helper.MsgValidation(EnumValidMsg.Auth.CheckData.ToNumber(), Lang));
            }
        }
        */

        /// <summary>
        /// get provider data
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///   {
        /// "id": "c3eed5f3-ca71-4833-ace9-62ee3b608d95",
        /// "userName": "ahmed",
        /// "email": "ahmed@gmail.com",
        /// "phone": "01234567895",
        /// "lang": "ar",
        /// "closeNotify": false,
        /// "status": false,
        /// "imgProfile": "https://image.freepik.com/free-vector/user-icon_126283-435.jpg",
        /// "token": "",
        /// "typeUser": 1,
        /// "code": 1234,
        /// "activeCode": false
        ///  }
        /// </remarks>
        /// <param lang="ar">ar or en</param>
        /// <returns>return object of user </returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>

        /*
        [HttpGet(ApiRoutes.Identity.GetDataOfProvider)]
        public async Task<IActionResult> GetDataOfProvider()
        {
            try
            {
                var response = await _userService.GetProviderInfo(UserId, Lang, "");
                if (response is not null)
                    return Ok(response);
                else
                {
                    return NotFound(HelperMsg.creatMessage(Lang, "لم يتم العثور علي هذا المستخدم", "Not Found"));
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.InnerException.Message);
            }
        }
        */

        /// <summary>
        /// Change app Language 
        /// </summary>
        /// <returns>return status code </returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>
        /*
        [HttpGet(ApiRoutes.Identity.RemoveAllNotify)]
        public async Task<IActionResult> RemoveAllNotify()
        {
            if (await _userService.DeleteAllNotify())
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        */


        /// <summary>
        /// Close Notification for users
        /// </summary>
        /// <param lang="changeNotifyEditDto.lang">ar or en</param>
        /// <param notify="changeNotifyEditDto.notify"></param>
        /// <returns>return status code </returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>
        /*
        [HttpPatch(ApiRoutes.Identity.ChangeNotify)]
        public async Task<IActionResult> ChangeNotify([FromBody] NotifyDto changeNotifyEditDto)
        {
            if (await _userService.ChangeNotify(new ChangeNotifyEditDto()
            {
                notify = changeNotifyEditDto.notify,
                userId = UserId,
                lang = Lang
            }))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }
        */

        /// <summary>
        /// List Notification for Client
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///    {
        /// "id": "1",
        /// "text": any,
        /// "date": 18/10/2021,
        /// "type":1,
        ///  }
        /// </remarks>
        /// <param lang="ar">ar or en</param>
        /// <returns>return object of notify </returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>
        /*[HttpGet(ApiRoutes.Identity.ListOfNotifyUser)]
        public async Task<IActionResult> ListOfNotifyUser()
        {
            return Ok(await _userService.ListOfNotifyUser(UserId, Lang));
        }*/

    }

}
