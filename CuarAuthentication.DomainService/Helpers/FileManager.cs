using System;

namespace CuarAuthentication.DomainService.Helpers
{
    public class FileManager
    {
        public static byte[] ConvertBase64ToByte(string content)
        {
            if (content.Contains(","))
            {
                content = content.Substring(content.IndexOf(",") + 1);
               return Convert.FromBase64String(content);
            }
            return null;
        }

        public static string ConvertBytToeBase64(byte[] content,string contentType)
        {
            string contentBase64 = Convert.ToBase64String(content);
            if (!contentBase64.Contains(","))
            {
                contentBase64 = $"data:{contentType};base64,"+ contentBase64;
            }
            return contentBase64;
        }
    }
}
