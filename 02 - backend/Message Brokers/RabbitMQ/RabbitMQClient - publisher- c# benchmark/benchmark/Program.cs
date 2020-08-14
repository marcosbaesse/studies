using System;
using publisher;

namespace benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            SimplePublisher.Publish("Hello World");
        }
    }
}
