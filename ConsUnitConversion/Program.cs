using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsUnitConversion
{
    class Program
    {
        delegate double ConvertUnit(double value);
        
        

        public double MileToKm(double mile)
        {
            return mile * 1.609344;
        }

        public double CelsiusToKelvin(double celsius)
        {
            return celsius + 273.15;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            double input = 20f;

            ConvertUnit cu = new ConvertUnit(p.MileToKm);
            double km = cu(input);
            Console.WriteLine($"{input} miles = {Math.Round(km, 3)} km");

            cu = new ConvertUnit(p.CelsiusToKelvin);
            double kelvin = cu(input);
            Console.WriteLine($"{input} °C = {Math.Round(kelvin, 3)} Kelvin");

            // anonieme methodenaanroep
            cu = delegate (double lbs) { return lbs * 0.45359237; };
            double kg = cu(input);
            Console.WriteLine($"{input} lbs = {Math.Round(kg, 3)} kg");

            // lambda expressie
            cu = cal => cal * 4.184;
            double kj = cu(input);
            Console.WriteLine($"{input} cal = {Math.Round(kj, 3)} kJ");

            Console.ReadKey();
        }
    }
}
