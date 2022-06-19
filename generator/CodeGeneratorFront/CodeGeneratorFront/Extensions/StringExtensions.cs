using PluralizeService.Core;

namespace CodeGeneratorFront
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input) => input[0].ToString().ToUpper() + input.Substring(1);
        public static string FirstCharToLower(this string input) => input[0].ToString().ToLower() + input.Substring(1);
        public static string Plural(this string input) => PluralizationProvider.Pluralize(input);

        public static string Tap1(this string input) => "    " + input;
        public static string Tap2(this string input) => "       " + input;
        public static string Tap3(this string input) => "           " + input;
    }
}
