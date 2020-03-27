using RedTrustCodeTest.RTQueue;
using System;
using System.Threading;

namespace RedTrustCodeTest.Extensions
{
    public static class RTQueueExtensions
    {
        public static void Consume(this QueueRT queue)
        {
            Thread currentThread = Thread.CurrentThread;
            string threadName = currentThread.Name ?? "No Name Provided";
            while (queue.Count() > 0)
            {
                Console.WriteLine($"{queue.Dequeue()} - Thread Name: {threadName}");
            }
        }
    }
}
