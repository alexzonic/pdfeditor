namespace ConsoleClient.Services.Help
{
    public interface IHelpCommandDetector
    {
        bool Detect(string[] args);
    }
}