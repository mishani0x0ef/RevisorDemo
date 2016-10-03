using System;

namespace RestaurantReviewer.Contracts.Entities
{
    public abstract class Place : IClosable
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
        public bool IsClosed { get; private set; }

        public event EventHandler OnClosed;

        public virtual void Close()
        {
            if(!IsClosed)
            {
                IsClosed = true;
                // Place notify observers about event.
                OnClosed(this, new EventArgs());
            }
        }
    }
}
