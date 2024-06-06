namespace LifestyleChecker.Framework.Contracts
{
    public interface IAireLogger<T> : IAireLogger where T : class
    {
    }

    public interface IAireLogger
    {
        void LogInformation(string functionName, string message, params object[] args);
        void LogCritical(string functionName, string message, params object[] args);
        void LogDebug(string functionName, string message, params object[] args);
        void LogError(string functionName, Exception ex, string message, params object[] args);
        void LogError(string functionName, string message, params object[] args);
        void LogTrace(string functionName, string message, params object[] args);
        void LogWarning(string functionName, string message, params object[] args);
    }
}
