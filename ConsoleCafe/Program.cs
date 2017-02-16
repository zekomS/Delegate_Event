using LibCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCafe
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPints = 10;
            PintDish pintDish = new PintDish(numberOfPints);
            pintDish.PintStarted += PintDish_PintStarted;

            for (int i = 0; i < numberOfPints ; i++)
            {
                try
                {
                    pintDish.AddPint();
                    Console.WriteLine($"Pint {pintDish.PintCount} added");
                } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }

        private static void PintDish_PintStarted(object sender, EventArgs e)
        {
            Console.WriteLine($"Brewing Pint...");
        }
    }
}
