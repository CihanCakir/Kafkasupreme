using System;
using System.Collections.Generic;
using System.Text;
using Confluent.Kafka;
using Confluent.Kafka.Serialization;



namespace kafka.stream.consumer
{
    public class BookingConsumer : IBookingConsumer
    {


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
                TimerExpo.Start();

                consumer.OnMessage += (_, msg) =>
                {
                    TimerExpo.Start();

                    // burada cache başlatılacak 10 dakika sonra timer ile cache de tutalanlar log dosyasına yazılacak
                    message(msg.Value);
                    // Message Başaldığı andan itibaren sayç başlayacak eğerki mesaj içeriği toplam 10dakikaya ulaşınca log dosyasına 10 dakikadan itibaaren loga tüm düşürülen istekler yazılacak.
                    // Part 3: call PrintTimes every 3 seconds.
                    while (true)
                    {
                        System.Threading.Thread.Sleep(5000);

                    }


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
