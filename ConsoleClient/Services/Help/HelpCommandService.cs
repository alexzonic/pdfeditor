namespace ConsoleClient.Services.Help
{
    internal static class HelpCommandService
    {
        public static IHelpCommandDetector GetDetector() => new HelpCommandDetector();
        public static IHelpCommandExecutor GetExecutor() => new HelpCommandExecutor();
    }
}