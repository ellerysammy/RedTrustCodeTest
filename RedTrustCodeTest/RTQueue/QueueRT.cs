using System;
using System.Collections.Concurrent;

namespace RedTrustCodeTest.RTQueue
{
    public class QueueRT
    {
        private readonly ConcurrentQueue<string> rtqueue = new ConcurrentQueue<string>();

        public event EventHandler ItemEnqueue;

        protected virtual void OnItemEnqueue()
        {
            ItemEnqueue?.Invoke(this, EventArgs.Empty);
        }

        public void Enqueue(string item)
        {
            rtqueue.Enqueue(item);
            OnItemEnqueue();
        }

        public string Dequeue()
        {
            string result_item = string.Empty;
            _ = rtqueue.TryDequeue(out result_item);
            return result_item;
        }

        public int Count(){
            return rtqueue.Count;
        }

    }
}
