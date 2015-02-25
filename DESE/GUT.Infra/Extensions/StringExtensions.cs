using System.Globalization;
using Newtonsoft.Json;

namespace GUT.Infra.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);// serializer.Serialize(obj);
        }

        public static string RemoveFileNameSpecialCaracters(this string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                fileName = fileName.Replace("\\", "")
                                   .Replace("/", "")
                                   .Replace(":", "")
                                   .Replace("*", "")
                                   .Replace("?", "")
                                   .Replace("\"", "")
                                   .Replace("<", "")
                                   .Replace(">", "");
            }

            return fileName;
        }

    }
}
