using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seriloger.Core.Services
{
    public class KrisLogger : IKrisLogger
    {
        private readonly Logger _log;

        public KrisLogger()
        {
            _log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    @"C:\logs\seriloger\seriloger_debug.txt",
                    fileSizeLimitBytes: 1_000_000,
                    rollOnFileSizeLimit: true,
                    shared: true,
                    flushToDiskInterval: TimeSpan.FromSeconds(1))
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
                {
                    AutoRegisterTemplate = true,
                    MinimumLogEventLevel = LogEventLevel.Debug,
                    CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true),
                    IndexFormat = "seriloger-logs-{0:yyyy.MM.dd}"
                })
                .CreateLogger();

        }
        public void LogDebug(string msg)
        {
            _log.Debug(msg);
        }

        public void LogError(string msg)
        {
            _log.Error(msg);
        }
    }
}
