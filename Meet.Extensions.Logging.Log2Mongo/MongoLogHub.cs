using MongoDB.Driver;
using System;

namespace Meet.Extensions.Logging.Log2Mongo
{
    internal static class MongoLogHub
    {
        private static string _connString;
        private static string _database;
        private static string _collection;
        private static MongoClient _client;
        private static object _obj = new object();
        public static void InitHub(MongoLoggerSetting setting)
        {
            if (string.IsNullOrWhiteSpace(setting.ConnString))
            {
                throw new ArgumentNullException("MongoDB链接字符串不能为空");
            }
            if (string.IsNullOrWhiteSpace(setting.Database))
            {
                throw new ArgumentNullException("database不能为空");
            }
            if (string.IsNullOrWhiteSpace(setting.Collection))
            {
                throw new ArgumentNullException("collection不能为空");
            }
            _database = setting.Database;
            _collection = setting.Collection;
            _connString = setting.ConnString;
        }

        internal static MongoClient Client
        {
            get
            {
                if (_client == null)
                {
                    lock (_obj)
                    {
                        if (_client == null)
                        {
                            _client = new MongoClient(_connString);
                        }
                    }
                }
                return _client;
            }
        }

        internal static void PutLogs<TModel>(TModel model)
        {
            var mongoDatabase = Client.GetDatabase(_database);
            var mongoCollection = mongoDatabase.GetCollection<TModel>(_collection);
            try
            {
                mongoCollection.InsertOne(model);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
