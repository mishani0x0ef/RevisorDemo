using System;
using RestaurantReviewer.Contracts.Services;
using RestaurantReviewer.Contracts.Entities;
using RestaurantReviewer.Services;
using System.Collections.Generic;

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

            RegisterObservation(provider.GetPlaces());
        }

        public void StartRevision()
        {
            var places = _provider.GetPlaces();

            ReviewPlaces(places);
            _service.CloseBadPlaces();
            ShowReport(places);
        }

        private void RegisterObservation(IEnumerable<Place> places)
        {
            foreach(var place in places)
            {
                // Revisor observe changes in open/closed status of places.
                place.OnClosed += PlaceClosed;
            }
        }

        private void ReviewPlaces(IEnumerable<Place> places)
        {
            foreach (var place in places)
            {
                if (place.IsClosed) continue;

                Console.WriteLine($"Place:{place.Name}, Rating: {place.Rating}\nInput new rating:");

                var rating = ReadRating();
                _service.SetRaing(place.PlaceId, rating);
            }            
        }

        private void PlaceClosed(object sender, EventArgs e)
        {
            var place = sender as Place;

            Console.WriteLine($"Sorry, but our place {place.Name} will be closed.");
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

        private void ShowReport(IEnumerable<Place> places)
        {
            Console.WriteLine("Chose report type: 1 - for CSV, 2 - for custom report.");

            var reportType = ReadReportType();
            var reportingService = ReportingServiceProvider.GetReportingService(reportType);
            var report = reportingService.GenerateReport(places);

            Console.Write(report);
        }

        private ReportType ReadReportType()
        {
            var reportTypeStr = Console.ReadLine();

            switch (reportTypeStr)
            {
                case "1":
                    return ReportType.Csv;
                case "2":
                    return ReportType.Custom;
                default:
                    throw new ArgumentException("Invalid report type.");
            }
        }
    }
}
