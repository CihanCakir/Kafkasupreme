using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace kafka.stream.consumer
{

    static class TimerExpo
    {

        static Timer _timer;
        static List<DateTime> _results = new List<DateTime>();
        public static void Start()
        {

            // Part 1: set up the timer for 3 seconds.
            var timer = new Timer(10000);
            // To add the elapsed event handler:
            // ... Type "_timer.Elapsed += " and press tab twice.
            timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            timer.Enabled = true;
            _timer = timer;
        }
        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Part 2: add DateTime for each timer event.
            _results.Add(DateTime.Now);
        }

        public static void PrintTimes(string message)
        {
            CacheExpo cache = new CacheExpo();
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();

            //loglama burada oalacak
            // Print all the recorded times from t<he timer.
            if (_results.Count > 0)
            {
                
                foreach (var time in _results)
                {
                    keyValuePairs.Add(message, Convert.ToString(DateTime.Now.AddMilliseconds(10)));

                }

            }
            else
            {
                cache.Set("KafkaStream", keyValuePairs, 10);
                cache.GetStream();
            }


        }
    }
}
