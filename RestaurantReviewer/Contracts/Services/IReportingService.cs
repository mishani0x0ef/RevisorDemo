using RestaurantReviewer.Contracts.Entities;
using System.Collections.Generic;

namespace RestaurantReviewer.Contracts.Services
{
    public interface IReportingService
    {
        string GenerateReport(IEnumerable<Place> places);
    }
}
