using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
namespace DistillingBot
{
    public class MainThread
    {
        GamePlayModule gamePlayer;
        public MainThread()
        {
            //ameReader = new GameReadModule();
            //gameSolver = new PuzzleSolveModule();
            gamePlayer = new GamePlayModule(this);
            
        }
        public static void MySleep(int milli)
        {
            for(int i=0;i<milli;i++)
            for (int loop = 0; loop < 600000; loop++) { }
        }
    
        public void Run()
        {
           
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            watch.Stop();

            
            while (true)
            {
                gamePlayer.playCommands();
                Thread.Sleep(15000);
                GC.Collect();
            }
            
        }
    }
}
