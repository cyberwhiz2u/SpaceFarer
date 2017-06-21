using System.Text.RegularExpressions;

namespace Utility
{
    public static class InputValidator
    {
        public static bool IsValidInput(string input)
        {
            if (InputIsNullOrEmpty(input)) return false;

            if (!InputContainsAuthorisedCommands(input)) return false;

            return true;
        }

        public static bool InputIsNullOrEmpty(string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        public static bool InputContainsAuthorisedCommands(string input)
        {
            Regex Validator = new Regex(@"^[FBLR]+$");

            return Validator.IsMatch(input);
        }
    }
}
