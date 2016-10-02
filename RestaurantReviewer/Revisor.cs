using System;
using RestaurantReviewer.Contracts.Services;

namespace RestaurantReviewer
{
    public class Revisor
    {
        private readonly IPlaceProvider _provider;
        private readonly IPlaceService _service;

        public Revisor(IPlaceProvider provider, IPlaceService service)
        {
            _provider = provider;
            _service = service;
        }

        public void StartRevision()
        {
            foreach (var place in _provider.GetPlaces())
            {
                if (place.IsClosed) continue;

                Console.WriteLine($"Place:{place.Name}, Rating: {place.Rating}\nInput new rating:");
                var rating = ReadRating();
                _service.SetRaing(place.PlaceId, rating);
            }

            _service.CloseBadPlaces();
        }

        private int ReadRating()
        {
            var newRatingStr = Console.ReadLine();
            int rating;
            if (!int.TryParse(newRatingStr, out rating))
            {
                throw new ArgumentException("Wrong rating.");
            }
            return rating;
        }
    }
}
