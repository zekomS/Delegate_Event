using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibCafe
{
    public delegate void PintStartedHandler(object sender, EventArgs e);
    public delegate void PintCompletedHandler(object sender, PintCompletedArgs e);
    public delegate void DishHalfwayHandler(object sender, EventArgs e);
    public delegate void DishCompletedHandler(object sender, StopwatchArgs e);

    public class PintDish
    {
        public event PintStartedHandler PintStarted;
        public event PintCompletedHandler PintCompleted;
        public event DishHalfwayHandler DishHalfWay;
        public event DishCompletedHandler DishCompleted;
        private Stopwatch t = new Stopwatch();
        private int pintCount;
        private bool timerStarted;

        public int PintCount { get { return pintCount; } } // c#6.0 enkel get in property: set enkel in constructor
        public int MaxPints { get; }
        //public Timer T { get => t; set => t = value; }

        public PintDish(int maxPints)
        {
            MaxPints = maxPints;
        }
        public void AddPint()
        {
            if (pintCount == 0) t.Start();
            if (pintCount >= MaxPints) throw new Exception("Dish full, order cancelled");
            if (pintCount == MaxPints / 2) DishHalfWay?.Invoke(this, EventArgs.Empty);
            PintStarted?.Invoke(this, EventArgs.Empty);
            pintCount++;
            PintCompleted?.Invoke(this, new PintCompletedArgs());
            if (pintCount == MaxPints) { t.Stop(); DishCompleted?.Invoke(this, new StopwatchArgs(t)); };
            }
        }
    }


    public class PintCompletedArgs : EventArgs
    {
        private static string[] Brands = { "Cara Pils", "Jupiler", "Stella Artois", "Bavik" };
        private static string[] Waiters = { "Jeff", "Carine", "Billy", "Julie" };
        public static Random random = new Random();

        public string Brand { get; }
        public string Waiter { get; }

        public PintCompletedArgs()
        {
            Brand = Brands[random.Next(0, Brands.Length)];
            Waiter = Waiters[random.Next(0, Waiters.Length)];
        }
    }
    public class StopwatchArgs : EventArgs
    {
        public Stopwatch stopwatch { get; set; }
    public StopwatchArgs(Stopwatch sw)
    {
        stopwatch = sw;

}
}

