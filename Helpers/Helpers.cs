using System;

namespace URL_Shortener.Helpers
{
    public class Helpers
    {
        public static string RandomLimitedLengthString(string OriginalUrl)
        {
            var stringBytes = System.Text.Encoding.UTF8.GetBytes(OriginalUrl);
            var urlEncodedInBase64 = System.Convert.ToBase64String(stringBytes);

            // Return the last 10 characters of the base64 string
            // Also, remove possible symbol characters from this string, we only need [0-9a-zA-Z]

            var urlEncodedWithoutSpecialChars = urlEncodedInBase64.Replace("=", "").Replace('+', '-').Replace('/', '_').Trim();
            //var base64UrlEncodedString = Base64UrlTextEncoder.Encode(stringBytes);

            return urlEncodedWithoutSpecialChars.Substring(urlEncodedWithoutSpecialChars.Length - 10); // get the last 10 characters
        }

        public static string ConvertUrlToShortenedForm(string urlPrefix, string OriginalUrl)
        {
            var shortUrl = string.Empty;
            try
            {
                if (System.Uri.IsWellFormedUriString(OriginalUrl, System.UriKind.RelativeOrAbsolute))
                {
                    // just use the generated random string and associate it in the DB with the original URL
                    shortUrl = $"{urlPrefix}/{RandomLimitedLengthString(OriginalUrl)}";
                    // store randomlyGeneratedString to database, along with, associate with original URL!
                }
            }
            catch (Exception ex)
            {
                shortUrl = "Invalid URL - Enter a new one...";
                throw new ArgumentException("User entered an invalid URL!", ex);
            }

            return shortUrl;
        }
    }
}
