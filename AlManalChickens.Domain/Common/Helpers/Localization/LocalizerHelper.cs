using AlManalChickens.Domain.Constants;
using Newtonsoft.Json;

namespace AlManalChickens.Domain.Common.Helpers.Localization
{
    public static class LocalizerHelper
    {
        public static string? LocalizeMessage(string key, string lang, string? path = null)
        {
            if (string.IsNullOrEmpty(path))
                path = DefaultPath.GeneralLocalizationPath;

            return Localize(path, key, lang);
        }

        public static string? LocalizeReport(string key, string lang, string? path = null)
        {
            if (string.IsNullOrEmpty(path))
                path = DefaultPath.ReportslLocalizationPath;

            return Localize(path, key, lang);
        }

        public static string LocalizeValidation(string key, string lang, string? path = null, params object[] inputs)
        {
            if (string.IsNullOrEmpty(path))
                path = DefaultPath.ValidationLocalizationPath;

            var message = Localize(path, key, lang);
            if (message == null)
                return string.Empty;

            return string.Format(message, inputs);
        }

        public static string? Localize(string path, string key, string lang)
        {
            if (string.IsNullOrEmpty(key))
                return string.Empty;

            var json = File.ReadAllText(path);
            List<LocalizerDTO>? localization = JsonConvert.DeserializeObject<List<LocalizerDTO>>(json);

            if (localization == null || !localization.Any())
                return string.Empty;

            var target = localization.FirstOrDefault(x => x.key == key);
            if (target != null)
            {
                return lang == "ar" ? target.ValueAr : target.ValueEn;
            }
            return key;
        }
    }

    internal class LocalizerDTO
    {
        public string? key { get; set; }
        public string? ValueAr { get; set; }
        public string? ValueEn { get; set; }
    }
}
