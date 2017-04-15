using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Meet.Extensions.Logging.Log2Mongo
{
    public class MongoLoggerProvider: ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, MongoLogger> _loggers = new ConcurrentDictionary<string, MongoLogger>();
        private readonly LogLevel _logLevel;

        public MongoLoggerProvider(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, new MongoLogger(categoryName, (logLevel) => logLevel >= _logLevel));
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
