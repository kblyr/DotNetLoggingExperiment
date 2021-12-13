namespace DotNetLogging;

sealed class DotNetLogger : IDotNetLogger
{
    readonly ILogger<DotNetLoggingInternalSourceContext> _logger;

    public DotNetLogger(ILogger<DotNetLoggingInternalSourceContext> logger)
    {
        _logger = logger;
    }

    public IDisposable BeginScope<TState>(TState state) => _logger.BeginScope(state);

    public bool IsEnabled(LogLevel logLevel) => _logger.IsEnabled(logLevel);

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter) => _logger.Log(logLevel, eventId, state, exception, formatter);
}
