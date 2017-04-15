using Microsoft.Extensions.Logging;

namespace Meet.Extensions.Logging.Log2Mongo
{
    public static class MongoLoggerFactoryExtensions
    {
        public static ILoggerFactory AddLogging2MongoExtension(this ILoggerFactory factory, MongoLoggerSetting setting)
        {
            MongoLogHub.InitHub(setting);
            factory.AddProvider(new MongoLoggerProvider(setting.LogLevel));
            return factory;
        }
    }
}
