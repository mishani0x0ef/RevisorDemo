namespace RestaurantReviewer.Contracts.Entities
{
    public abstract class Place : IClosable
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public bool IsClosed { get; private set; }
        public virtual void Close()
        {
            IsClosed = true;
        }
    }
}
