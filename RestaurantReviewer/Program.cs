using System;

namespace RestaurantReviewer
{
    class Program
    {
        static void Main(string[] args)
        {
            var revisor = ServiceLocator.Instance.Resolve<Revisor>();
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
