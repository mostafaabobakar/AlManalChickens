//using AlManalChickens.Domain.DTO.HelperDTO.Images;
using Microsoft.AspNetCore.Http;

namespace AlManalChickens.Domain.Common.Helpers
{
    public interface IHelper
    {
        //public ValidateImgDTO ValidateImgTypeSize(IFormFile Photo,long? MaxSize = 5);
        public string Upload(IFormFile Photo, int FileName);

        //Task<string> UploadFileUsingApi(UploadImageDto model);
        public string GetRole(string role, string lang);
        public string CreatePDF(string controllerAction, int id);
    }
}
