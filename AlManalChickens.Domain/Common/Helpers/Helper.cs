using AlManalChickens.Domain.Enums;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using QRCoder;
using System.Drawing;
using static AlManalChickens.Domain.Constants.DefaultPath;

namespace AlManalChickens.Domain.Common.Helpers
{
    public class Helper : IHelper
    {
        private readonly IWebHostEnvironment HostingEnvironment;
        private IConverter _converter;
        public static string translateFolderPath { get; set; } = null;

        public Helper(IConverter converter, IWebHostEnvironment hostingEnvironment)
        {
            HostingEnvironment = hostingEnvironment;
            _converter = converter;
        }


        public string Upload(IFormFile Photo, int FileName)
        {
            string folderName = Enum.GetName(typeof(FileName), FileName);
            string uniqueFileName = string.Empty;
            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(HostingEnvironment.WebRootPath, $"images/{folderName}");
                if (!Directory.Exists(uploadsFolder))
                    Directory.CreateDirectory(uploadsFolder);

                uniqueFileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(Photo.FileName);
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return $"images/{folderName}/" + uniqueFileName;
        }


        #region Roles

        public string GetRole(string role, string lang)
        {
            return role switch
            {
                "AdminBranch" => AAITHelper.HelperMsg.creatMessage(lang, "سوبر ادمن", "AdminBranch"),
                "Admin" => AAITHelper.HelperMsg.creatMessage(lang, "أدمن", "Admin"),
                "Mobile" => AAITHelper.HelperMsg.creatMessage(lang, "موبايل", "Mobile"),
                "Advertisment" => AAITHelper.HelperMsg.creatMessage(lang, "الاعلانات", "Advertisment"),
                "SocialMedia" => AAITHelper.HelperMsg.creatMessage(lang, "مواقع التواصل الاجتماعى", "SocialMedia"),
                "Notifications" => AAITHelper.HelperMsg.creatMessage(lang, "الاشعارات", "Notifications"),
                "SendSmsMsg" => AAITHelper.HelperMsg.creatMessage(lang, "ارسال رسالة sms", "SendSmsMsg"),
                "ContactUs" => AAITHelper.HelperMsg.creatMessage(lang, "الشكاوى والمقترحات", "ContactUs"),
                "Setting" => AAITHelper.HelperMsg.creatMessage(lang, "الاعدادات", "Setting"),
                "Clients" => AAITHelper.HelperMsg.creatMessage(lang, "مستخدمي التطبيق", "Clients"),
                "Category" => AAITHelper.HelperMsg.creatMessage(lang, "الأقسام", "Category"),
                "Specification" => AAITHelper.HelperMsg.creatMessage(lang, "الخصائص", "Specification"),
                "Cities" => AAITHelper.HelperMsg.creatMessage(lang, "المدن", "Cities"),
                "Regoins" => AAITHelper.HelperMsg.creatMessage(lang, "الاحياء", "Regoins"),
                "Packagees" => AAITHelper.HelperMsg.creatMessage(lang, "الباقات", "Packagees"),
                "ProductReport" => AAITHelper.HelperMsg.creatMessage(lang, "البلاغات", "ProductReport"),
                _ => role
            };
        }

        #endregion

        public static string StatusText(int stutes, string lang = "ar")
        {
            string text = "";
            switch (stutes)
            {
                case (int)OrderStatus.NewOrder:
                    text = (lang == "ar" ? "طلب جديد" : "New Order");
                    break;
                case (int)OrderStatus.ClientAccept:
                    text = (lang == "ar" ? "تم الموافقه من قبل العميل ع العرض" : "The offer has been approved by the customer");
                    break;
                case (int)OrderStatus.ClientCancel:
                    text = (lang == "ar" ? "تم رفض من قبل العميل ع العرض" : "The offer has been refused by the customer");
                    break;
                case (int)OrderStatus.ProviderSendOffer:
                    text = (lang == "ar" ? "تم ارسال العرض من قبل مقدم الخدمه" : "The offer was sent by the service provider");
                    break;
                case (int)OrderStatus.ClientPay:
                    text = (lang == "ar" ? "تم الدفع من قبل العميل" : "Paid by the customer");
                    break;
                case (int)OrderStatus.Finished:
                    text = (lang == "ar" ? "تم انهاء الطلب" : "Request completed");
                    break;

            }
            return text;
        }

        #region QrCode
        public static byte[] GenerateQrcode(string textCode)
        {
            byte[] QrCode = null;

            if (textCode != null)
            {
                QRCodeGenerator qr = new QRCodeGenerator();
                QRCodeData data = qr.CreateQrCode(textCode, QRCodeGenerator.ECCLevel.Q);
                QRCode code = new QRCode(data);

                Bitmap bitMap = code.GetGraphic(20);
                QrCode = BitmapToBytesCode(bitMap);
                return QrCode;
            }
            return QrCode;
        }

        private static byte[] BitmapToBytesCode(Bitmap image)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        #endregion

        #region Generate Pdf
        public string CreatePDF(string controllerAction, int id)
        {
            var pdfname = String.Format("{0}.pdf", id);
            var globalSettings = new GlobalSettings
            {
                ColorMode = DinkToPdf.ColorMode.Color,
                Orientation = DinkToPdf.Orientation.Portrait,
                PaperSize = DinkToPdf.PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = Path.Combine(HostingEnvironment.WebRootPath, "pdf", pdfname)
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,

                //بياخد  لينك اى صفحة لتحويلها ل pdf

                Page = $"{Constants.DefaultPath.DomainUrl}{controllerAction}/{id}"

            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }

            };
            _converter.Convert(pdf);

            //var myfile = System.IO.File.ReadAllBytes($"wwwroot/pdf/{pdfname}");

            //return File(myfile, System.Net.Mime.MediaTypeNames.Application.Pdf);

            //return globalSettings.Out;
            return $"pdf/{id}.pdf";
        }
        #endregion

        public static string getFileTranslate(Lang.Translate lang, string key)
        {
            //var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"Common/Translate.json");
            //var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"..\\AlManalChickens.Domain\\Common\\Translate.json");

            if (translateFolderPath == null)
            {
                try
                {
                    translateFolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"Common\\Translate.json");
                    File.ReadAllText(translateFolderPath);
                }
                catch (Exception ex)
                {
                    translateFolderPath = Path.Combine(Directory.GetCurrentDirectory(), $"..\\AlManalChickens.Domain\\Common\\Translate.json");
                    File.ReadAllText(translateFolderPath);
                }
            }

            var JSON = File.ReadAllText(translateFolderPath);
            dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(JSON);

            dynamic mainRoot = jsonObj[key];
            string text = mainRoot[lang.ToString()].ToString();
            return text;
        }


        public static int GetRandomNumber(int numberOfDigits = 6)
        {
            Random random = new Random();
            int minValue = (int)Math.Pow(10, numberOfDigits - 1);
            int maxValue = (int)Math.Pow(10, numberOfDigits) - 1;
            return random.Next(minValue, maxValue);
        }

        //public ValidateImgDTO ValidateImgTypeSize(IFormFile Photo, long? MaxSizeInMB)
        //{
        //    var allowedExtensions = new List<string> { ".jpg", ".png", ".jpeg", "webp" };

        //    var isTypeCorrect = allowedExtensions.Contains(Path.GetExtension(Photo.FileName).ToLower());
        //    var isSizeCorrect = Photo.Length <= MaxSizeInMB * 1024 * 1024;
        //    return new ValidateImgDTO
        //    {
        //        ImgSizeValidation = isSizeCorrect,
        //        ImgTypeValidation = isTypeCorrect
        //    };
        //}

        //public async Task<string> UploadFileUsingApi(UploadImageDto model)
        //{
        //    var apiUrl = $"{DashBordUrl.baseUrlHost}api/v1/UploadImage";
        //    try
        //    {
        //        using (var httpClient = new HttpClient())
        //        {
        //            var formData = new MultipartFormDataContent();

        //            // Use the stream without explicitly disposing it
        //            var fileContent = new StreamContent(model.image.OpenReadStream());
        //            fileContent.Headers.ContentType = new MediaTypeHeaderValue("multipart/form-data");
        //            formData.Add(fileContent, "image", model.image.FileName);

        //            formData.Add(new StringContent(model.fileName.ToString()), "fileName");

        //            var response = await httpClient.PostAsync($"{apiUrl}", formData);

        //            string jsonString = await response.Content.ReadAsStringAsync();
        //            var responseObject = JsonConvert.DeserializeAnonymousType(jsonString, new { filePath = "" });
        //            return responseObject.filePath;

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //public static async Task<bool> SendNotifyAsync(ApplicationDbContext db, string textAr, string textEn, string fkProvider, int stutes)
        //{
        //    var user = await db.Users.Where(x => x.Id == fkProvider).FirstOrDefaultAsync();
        //    if (user.TypeUser == (int)Enums.AllEnums.User_Type.Client)
        //    {
        //        NotifyClient notifyClient = new NotifyClient()
        //        {
        //            Date = HelperDate.GetCurrentDate(),
        //            FKUser = fkProvider,
        //            Show = false,
        //            TextAr = textAr,
        //            TextEn = textEn,
        //            Type = stutes
        //        };
        //        await db.NotifyClients.AddAsync(notifyClient);
        //        await db.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        NotifyDelegt notifyDelegt = new NotifyDelegt()
        //        {
        //            Date = HelperDate.GetCurrentDate(),
        //            FKUser = fkProvider,
        //            Show = false,
        //            TextAr = textAr,
        //            TextEn = textEn,
        //            Type = stutes
        //        };
        //        await db.NotifyDelegts.AddAsync(notifyDelegt);
        //        await db.SaveChangesAsync();
        //    }
        //    var Fcm = await db.Settings.FirstOrDefaultAsync();

        //    var AllDeviceids = await db.DeviceIds.Where(x => x.FkUser == fkProvider).Select(x => new DeviceIdModel()
        //    {
        //        DeviceId = x.DeviceId_,
        //        DeviceType = x.DeviceType,
        //        FkUser = x.FkUser,
        //        ProjectName = x.ProjectName

        //    }).ToListAsync();
        //    HelperFcm.SendPushNotification(Fcm.ApplicationId, Fcm.SenderId, AllDeviceids, null, textAr, stutes);
        //    return true;
        //}
    }
}
