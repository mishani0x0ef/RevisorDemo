namespace RestaurantReviewer.Contracts.Services
{
    public interface IPlaceService
    {
        void SetRaing(int placeId, int rating);
        void CloseBadPlaces();
    }
}
