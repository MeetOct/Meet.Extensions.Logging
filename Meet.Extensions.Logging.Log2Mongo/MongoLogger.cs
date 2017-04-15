using Microsoft.Extensions.Logging;
using System;

namespace Meet.Extensions.Logging.Log2Mongo
{
    public class MongoLogger: ILogger
    {
        private string _name;
        private Func<LogLevel, bool> _filter;
        public MongoLogger(string name, Func<LogLevel, bool> filter)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }
            _name = name;
            _filter = filter ?? ((loglevel) => loglevel >= LogLevel.Warning);
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }
            var model = new MongoLoggerModel()
            {
                Name = _name,
                LogLevel = logLevel.ToString(),
                EventId = eventId,
                State = state,
                Content = formatter(state, exception)
            };
            MongoLogHub.PutLogs(model);

        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _filter(logLevel);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new DisposableScope();
        }
    }

    class DisposableScope : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
