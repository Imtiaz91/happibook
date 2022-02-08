using System.Text.RegularExpressions;

namespace Happibook.Core.Extensions
{
    public static class StringExtension
    {
        public static string RemoveSpaces(this string reportName)
        {
            return Regex.Replace(reportName, @"\s+", string.Empty);
        }
    }
}
