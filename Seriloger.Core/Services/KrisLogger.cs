using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Seriloger.Core.Settings;
using System;

namespace Seriloger.Core.Services
{
    public class KrisLogger : IKrisLogger
    {
        private readonly Logger _log;

        public KrisLogger(SerilogSettings settings)
        {
            string template = "{Timestamp:yyyy-MM-dd HH:mm:ss.ff} | {Level:u3} | {Message:lj}{Exception} | Action: '{ActionName}'{NewLine}";

            _log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                //.WriteTo.Console()

                .WriteTo.File(
                    path: settings.FileDebugPath,
                    outputTemplate: template,
                    restrictedToMinimumLevel: LogEventLevel.Verbose,
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1))

                .WriteTo.File(
                    path: settings.FileErrorPath,
                    outputTemplate: template,
                    restrictedToMinimumLevel: LogEventLevel.Error,
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1))

                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(settings.Uri))
                {
                    AutoRegisterTemplate = true,
                    MinimumLogEventLevel = Enum.Parse<LogEventLevel>(settings.LogLevel),
                    CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true), // for Kibana
                    IndexFormat = settings.IndexFormat
                })
                .CreateLogger();

        }
        public void LogDebug(string messageTemplate, params object[] propertyValues)
        {
            _log.Debug(messageTemplate, propertyValues);
        }

        public void LogWarning(string messageTemplate, params object[] propertyValues)
        {
            _log.Warning(messageTemplate, propertyValues);
        }

        public void LogError(string messageTemplate, params object[] propertyValues)
        {
            _log.Error(messageTemplate, propertyValues);
        }
    }
}
