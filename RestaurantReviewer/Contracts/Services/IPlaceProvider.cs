using System.Collections.Generic;
using RestaurantReviewer.Contracts.Entities;

namespace RestaurantReviewer.Contracts.Services
{
    public interface IPlaceProvider
    {
        IEnumerable<Place> GetPlaces();
    }
}
