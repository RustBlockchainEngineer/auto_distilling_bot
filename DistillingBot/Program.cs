using System;
using System.Threading;

namespace DistillingBot
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MainThread mainThread = new MainThread();
            Thread a = new Thread(mainThread.Run);
            a.Start();
        }
    }
}
