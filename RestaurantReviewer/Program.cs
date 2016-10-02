using System;

namespace RestaurantReviewer
{
    class Program
    {
        static void Main(string[] args)
        {
            var locator = new ServiceLocator();
            var revisor = locator.Resolve<Revisor>();
            while (true)
            {
                revisor.StartRevision();

                Console.WriteLine("Ratings was updated. Bad places was closed.");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
