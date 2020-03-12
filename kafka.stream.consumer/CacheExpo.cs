using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Caching;


namespace kafka.stream.consumer
{
    public class CacheExpo
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
            {
                return;
            }
            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        public void GetStream()
        {
            var result = Get<Dictionary<string, string>>("KafkaStream");
            LoggingExpo logging = new LoggingExpo();
            logging.Run(Convert.ToString(result));

        }


    }
}
