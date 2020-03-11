using System;
using System.Collections.Generic;
using System.Text;

namespace kafka.stream.consumer
{
    public interface IBookingConsumer
    {
        void Listen(Action<string> message);
    }
}
