using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibCafe
{
    public delegate void PintStartedHandler(object sender, EventArgs e);

    public class PintDish
    {
        public event PintStartedHandler PintStarted;
        private int pintCount;

        public int PintCount { get { return pintCount; } } // c#6.0 enkel get in property: set enkel in constructor
        public int MaxPints { get; }

        public PintDish(int maxPints)
        {
            MaxPints = maxPints;
        }

        public void AddPint()
        {
            if (pintCount >= MaxPints) throw new Exception("Dish full, order cancelled");
            PintStarted?.Invoke(this, EventArgs.Empty);
            pintCount++;
        }
    }
}
