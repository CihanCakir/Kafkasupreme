using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;
using Microsoft.Extensions.Logging;

namespace kafka.stream.consumer
{
    public class BookingConsumer : IBookingConsumer
    {
        private readonly ILogger _logger;

        public void Listen(Action<string> message)
        {
         

            var config = new Dictionary<string, object>
            {
                {"group.id", "booking_consumer" },
                                {"bootstrap.servers", "localhost:9092" },
                                                {"enable.auto.commit", "false" }


            };
            using (var consumer = new Consumer<Null, string>(config, null, new StringDeserializer(Encoding.UTF8)))
            {
                consumer.Subscribe("timemanagement_booking");

                consumer.OnMessage += (_, msg) =>
                {
                    Stopwatch sw = Stopwatch.StartNew();

                    // Message Başaldığı andan itibaren sayç başlayacak eğerki mesaj içeriği toplam 10dakikaya ulaşınca log dosyasına 10 dakikadan itibaaren loga tüm düşürülen istekler yazılacak.
                   
                        message(msg.Value);

                };
                while (true)
                {
                    //time out süresi 
                    consumer.Poll(100);
                }
            };

        }
    }
}
