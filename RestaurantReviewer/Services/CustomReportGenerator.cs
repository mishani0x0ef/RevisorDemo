using RestaurantReviewer.Contracts.Services;
using System.Collections.Generic;
using System.Text;
using RestaurantReviewer.Contracts.Entities;

namespace RestaurantReviewer.Services
{
    public class CustomReportGenerator : IReportingService
    {
        public string GenerateReport(IEnumerable<Place> places)
        {
            // StringBuilder is .NET class which implement Builder pattern.
            var builder = new StringBuilder();

            foreach(var place in places)
            {
                var status = place.IsClosed ? "closed" : "opened";
                builder.AppendLine($"Place '{place.Name}' have rating {place.Rating} and currently is {status}.");
            }

            return builder.ToString();
        }
    }
}
