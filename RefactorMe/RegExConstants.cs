namespace RefactorMe
{
    internal static class RegExConstants
    {
        public const string NamingPatternRegexMatch = "({[a-z]*:[^:]*})";
        public const string SectionRegexMatch = ":|{|}";
        public const string AttributeRegexMatch = @"\.";
    }
}