using RestaurantReviewer.Contracts.Entities;
using RestaurantReviewer.Contracts.Services;
using System;

namespace RestaurantReviewer.Services
{
    public class ReportingServiceProvider
    {
        // Factory method. Get IReportingService depend on type of report that required.
        public static IReportingService GetReportingService(ReportType type)
        {
            switch (type)
            {
                case ReportType.Csv:
                    return new CsvReportGenerator();
                case ReportType.Custom:
                    return new CustomReportGenerator();
                default:
                    throw new ArgumentException("Unsupported report type.", nameof(type));
            }
        }
    }
}
