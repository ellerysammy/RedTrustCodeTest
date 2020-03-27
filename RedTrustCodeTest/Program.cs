using RedTrustCodeTest.Extensions;
using RedTrustCodeTest.RTQueue;
using RedTrustCodeTest.RTUtilities;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RedTrustCodeTest
{
    class Program
    {
        public static QueueRT queue = new QueueRT(); 
        public static Thread thr1 = new Thread(new ThreadStart(queue.Consume));
        public static Thread thr2 = new Thread(new ThreadStart(queue.Consume));
        static void Main(string[] args)
        {
            thr1.Name = "T1";
            thr2.Name = "T2";
            
            queue.ItemEnqueue += Queue_ItemEnqueue;

            string strItem = string.Empty;
            
            for (int i = 0; i < 1000; i++)
            {
                queue.Enqueue(RTUtilitie.GenerateString());
            }
            
            Console.ReadKey();
        }

        private static void Queue_ItemEnqueue(object sender, EventArgs e)
        {
            if (thr1.ThreadState == ThreadState.Unstarted)
            {
                thr1.Start();
            }
            else
            {
                if (thr1.ThreadState == ThreadState.Stopped)
                {
                    thr1.Join();
                }
            }

            if (thr2.ThreadState == ThreadState.Unstarted)
            {
                thr2.Start();
            }
            else
            {
                if (thr2.ThreadState == ThreadState.Stopped)
                {
                    thr2.Join();
                }
            }
        }

        
    }
}
