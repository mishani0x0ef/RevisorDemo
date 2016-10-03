using System;

namespace RestaurantReviewer.Contracts.Entities
{
    public interface IClosable
    {
        bool IsClosed { get; }
        void Close();

        event EventHandler OnClosed;
    }
}
