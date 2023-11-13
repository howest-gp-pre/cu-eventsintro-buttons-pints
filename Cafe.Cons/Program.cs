using Cafe.Lib;

namespace Cafe.Cons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPints = 10;
            PintDish pintDish = new PintDish(numberOfPints);
            pintDish.PintStarted += PintDish_PintStarted;
            pintDish.PintCompleted += PintDish_PintCompleted;
            pintDish.DishHalfway += (sender, e) => Console.WriteLine("Dish is half full");

            for (int i = 0; i < numberOfPints; i++)
            {
                Console.WriteLine("\n");
                try
                {
                    pintDish.AddPint();
                    //Console.WriteLine($"Added pint {pintDish.PintCount} to the dish");
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }



        private static void PintDish_PintStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Brewing pint...");
        }

        private static void PintDish_PintCompleted(object sender, PintCompletedEventArgs e)
        {
            Console.WriteLine($"{e.Brand} brewed by {e.Waiter}, cheers!");
        }
    }
}