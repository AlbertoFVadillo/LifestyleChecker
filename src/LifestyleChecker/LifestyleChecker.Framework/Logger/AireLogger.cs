using CorrelationId.Abstractions;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using LifestyleChecker.Framework.Contracts;

namespace LifestyleChecker.Framework.Logger
{
    [ExcludeFromCodeCoverage]
    public class AireLogger<T> : IAireLogger<T> where T : class
    {
        private readonly ICorrelationContextAccessor _correlationContextAccessor;
        private readonly ILogger _logger;

        /// <summary>Initializes a new instance of the <see cref="AireLogger{T}"/> class.</summary>
        /// <param name="logger">The logger.</param>
        /// <param name="correlationContextAccessor">The correlation context accessor.</param>
        public AireLogger(
            ILogger<T> logger,
            ICorrelationContextAccessor correlationContextAccessor)
        {
            _logger = logger;
            _correlationContextAccessor = correlationContextAccessor;
        }

        /// <summary>Logs the critical.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogCritical(string functionName, string message, params object[] args)
        {
            _logger.LogCritical(GetLogMessage(functionName, message), args);
        }

        /// <summary>Logs the debug.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogDebug(string functionName, string message, params object[] args)
        {
            _logger.LogDebug(GetLogMessage(functionName, message), args);
        }

        /// <summary>Logs the error.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="ex"></param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogError(string functionName, Exception ex, string message, params object[] args)
        {
            _logger.LogError(ex, GetLogMessage(functionName, message), args);
        }

        /// <summary>Logs the error.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogError(string functionName, string message, params object[] args)
        {
            _logger.LogError(GetLogMessage(functionName, message), args);
        }

        /// <summary>Logs the information.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogInformation(string functionName, string message, params object[] args)
        {
            _logger.LogInformation(GetLogMessage(functionName, message), args);
        }

        /// <summary>Logs the trace.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogTrace(string functionName, string message, params object[] args)
        {
            _logger.LogTrace(GetLogMessage(functionName, message), args);
        }

        /// <summary>Logs the warning.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        public void LogWarning(string functionName, string message, params object[] args)
        {
            _logger.LogWarning(GetLogMessage(functionName, message), args);
        }

        /// <summary>Gets the log message.</summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        private string GetLogMessage(string functionName, string message)
        {
            var objectName = $"Type: {typeof(T).FullName}";
            functionName = $"Function: {functionName}";
            message = $"Message: {message}";

            if (_correlationContextAccessor?.CorrelationContext?.CorrelationId != null)
            {
                var correlationId = $"CorrelationId: {_correlationContextAccessor.CorrelationContext.CorrelationId}";
                return $"{correlationId} - {objectName} - {functionName} - {message}";
            }

            return $"CorrelationId: null - {objectName} - {functionName} - {message}";
        }
    }
}
