using Microsoft.Extensions.Logging;

namespace Common.Factories
{
    public static class CustomLoggingFactory
    {
        public static ILoggerFactory CreateInformationLoggingFactory =>
            LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddFilter(level => level == LogLevel.Information);
            });
    }
}