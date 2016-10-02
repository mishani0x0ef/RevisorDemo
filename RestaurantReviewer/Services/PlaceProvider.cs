using System.Collections.Generic;
using System.Linq;
using RestaurantReviewer.Contracts.Entities;
using RestaurantReviewer.Contracts.Services;

namespace RestaurantReviewer.Services
{
    public class PlaceProvider : IPlaceProvider
    {
        private List<Restaurant> _restaurants;
        private List<Bar> _bars;

        public PlaceProvider()
        {
            InitBars();
            InitRestaurance();
        }

        public IEnumerable<Place> GetPlaces()
        {
            foreach (var bar in _bars)
            {
                yield return bar;
            }
            foreach (var restaurant in _restaurants)
            {
                yield return restaurant;
            }
        }

        private void InitBars()
        {
            _bars = new List<Bar>
            {
                new Bar
                {
                    PlaceId = 1,
                    Name = "Old dog",
                    Rating = 5
                }
            };
        }

        private void InitRestaurance()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    PlaceId = 2,
                    Name = "Franko",
                    Rating = 4,
                    HaveCloseProtection = true
                },
                new Restaurant
                {
                    PlaceId = 3,
                    Name = "Legend",
                    Rating = 4
                }
            };
        }
    }
}
