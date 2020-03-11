using System;

namespace kafka.stream.consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookConsumer = new BookingConsumer();
            bookConsumer.Listen(Console.WriteLine);
            Console.WriteLine("Hello World!");
        }
    }
}
