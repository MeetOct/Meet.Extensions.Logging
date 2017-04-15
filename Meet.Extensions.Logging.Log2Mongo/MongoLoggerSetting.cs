using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meet.Extensions.Logging.Log2Mongo
{
    public class MongoLoggerSetting
    {
        public string ConnString { get; set; }

        public string Database { get; set; }

        public string Collection { get; set; }

        public LogLevel Loglevel { get; set; }
    }
}
