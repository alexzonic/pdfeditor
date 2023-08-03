namespace ConsoleClient
{
    internal static class Commands
    {
        public const string Help = "--help";
        public const string CutUntil = "cut-until";
        public const string CutAfter = "cut-after";
        public const string CutPart = "cut-part";
        public const string CutPages = "cut-pages";
        public const string CutAllPagesExcept = "cut-all-except";

        public static class Options
        {
            public const string PageNumber = "--page";
            public const string PagesCount = "--pagesCount";
            public const string Pages = "--pages";
        }
    }
}