using AlManalChickens.Controllers.Shared;
using AlManalChickens.Domain.Constants;
using AlManalChickens.Services.Api.Contract.General;
using AlManalChickens.Services.Api.Contract.More;
using AlManalChickens.Services.DTO.More;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlManalChickens.Controllers.Api
{
    [ApiExplorerSettings(GroupName = "MoreAPI")]
    public class MoreController : BaseAPIController
    {
        private readonly IUserContext _userContext;
        private readonly IMoreService _moreService;

        public MoreController(IServiceProvider serviceProvider)
        {
            _userContext = (IUserContext)serviceProvider.GetService(typeof(IUserContext));
            _moreService = (IMoreService)serviceProvider.GetService(typeof(IMoreService));
        }

        /// <summary>
        /// AboutUs  عن التطبيق
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///     {
        ///       "AboutApplication" : "عن التطبيق",
        ///      }
        ///     
        /// </remarks>
        /// <param lang="ar">ar or en</param>
        /// <returns>Return String </returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>
        [AllowAnonymous]
        [HttpGet(ApiRoutes.More.AboutUs)]
        public async Task<IActionResult> AboutUs()
        {
            try
            {
                var result = await _moreService.AboutUs(Lang);
                return Ok(new { data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "" });
            }
        }

        /// <summary>
        /// CommonQuestions  الأسئلة الشائعة  
        /// </summary>
        /// <remarks>
        /// Sample response:
        /// 
        ///     {
        ///       "Question" : "Question",
        ///       "Answer" : "Answer",
        ///      }
        ///     
        /// </remarks>
        /// <param lang="ar">ar or en</param>
        /// <returns>Return Object Of Points</returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>
        [AllowAnonymous]
        [HttpGet(ApiRoutes.More.CommonQuestions)]
        public async Task<IActionResult> CommonQuestions()
        {
            try
            {
                var result = await _moreService.CommonQuestions(Lang);
                return Ok(new { data = result });

            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "" });
            }
        }

        
        [AllowAnonymous]
        [HttpGet(ApiRoutes.More.TermsAndConditions)]
        public async Task<IActionResult> TermsAndConditions([FromHeader] string lang = "ar")
        {
            try
            {
                var result = await _moreService.TermsAndConditions(Lang);
                return Ok(new { data = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { msg = "" });
            }
        }

        /// <summary>
        /// ContactWithUs  تواصل معنا  
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// <param lang="ar">ar or en</param>
        /// <returns>Return Object Of Points</returns>
        /// <response code="200">Sucess</response>
        /// <response code="400">BadRequest Or Exption</response>
        /// <response code="500">internal server error</response>
        [AllowAnonymous]
        [HttpPost(ApiRoutes.More.ContactWithus)]
        public async Task<IActionResult> ContactWithUs([FromForm] ContactWithUsDto contactWithUs)
        {
            try
            {

                if (await _moreService.ContactWithUs(contactWithUs))
                    return Ok(new { Message = Lang == "ar" ? "تم الارسال بنجاح" : "Sended Successfully" });

                return BadRequest(new { Message = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ""});
            }
        }

    }
}
