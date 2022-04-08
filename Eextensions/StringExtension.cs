using System.Text;

namespace Ticket_System.Eextensions
{
    public static class StringExtension
    {
        public static string StringToBase64(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
        }
        public static string Base64ToString(this string base64)
        {
            if (string.IsNullOrWhiteSpace(base64))
                throw new ArgumentNullException(nameof(base64));
            return Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
    }
}
