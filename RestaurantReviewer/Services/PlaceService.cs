using System.Linq;
using RestaurantReviewer.Contracts.Services;

namespace RestaurantReviewer.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceProvider _provider;

        public PlaceService(IPlaceProvider provider)
        {
            _provider = provider;
        }

        public void SetRaing(int placeId, int rating)
        {
            var place = _provider.GetPlaces().FirstOrDefault(p => p.PlaceId == placeId);
            if (place != null)
            {
                place.Rating = rating;
            }
        }

        public void CloseBadPlaces()
        {
            foreach (var place in _provider.GetPlaces())
            {
                if (place.Rating < 3)
                {
                    place.Close();
                }
            }
        }
    }
}
