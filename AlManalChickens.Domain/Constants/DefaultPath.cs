using AlManalChickens.Domain.Common.Extensions;
using AlManalChickens.Domain.Model;

namespace AlManalChickens.Domain.Constants
{
    public static class DefaultPath
    {
        public readonly static string DomainUrl = "https://localhost:7293/";
        //public readonly static string DomainUrl = "";


        public static string GeneralLocalizationPath => Path.Combine(Hosting.WebRootPath, "Localization", "general-localization.json").ToUniformedPath();
        public static string ReportslLocalizationPath => Path.Combine(Hosting.WebRootPath, "Localization", "reports-localization.json").ToUniformedPath();
        public static string ValidationLocalizationPath => Path.Combine(Hosting.WebRootPath, "Localization", "fluent-validation-localization.json").ToUniformedPath();
    }

}
