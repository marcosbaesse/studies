﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using publisher;

namespace benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();
            
            for (var i = 0; i < 1; i++)
            for (var j = 0; j < 100; j++)
            {
                tasks.Add(Task.Run(() => SimplePublisher.Publish("queue" + i, "Hello World")));
                // tasks.Add(Task.Run(() => {
                //     Console.WriteLine("Ok");
                // }));
            }

            Console.Write(tasks.Count);

            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("ok");
        }
    }
}
