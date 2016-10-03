using RestaurantReviewer.Contracts.Services;
using System.Collections.Generic;
using RestaurantReviewer.Contracts.Entities;
using System.Text;

namespace RestaurantReviewer.Services
{
    public class CsvReportGenerator : IReportingService
    {
        public string GenerateReport(IEnumerable<Place> places)
        {
            // StringBuilder is .NET class which implement Builder pattern.
            var builder = new StringBuilder();
            builder.AppendLine(GetHeader());

            foreach(var place in places)
            {
                builder.AppendLine($"{place.Name}, {place.Rating}, {place.IsClosed}");
            }

            return builder.ToString();
        }

        private string GetHeader()
        {
            return "Name, Rating, Closed";
        }
    }
}
