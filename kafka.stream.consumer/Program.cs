using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace kafka.stream.consumer
{
    class Program
    {
            

        static void Main(string[] args)
          {

            var bookConsumer = new BookingConsumer();
            bookConsumer.Listen(Console.WriteLine);

        }
       
    }
}
