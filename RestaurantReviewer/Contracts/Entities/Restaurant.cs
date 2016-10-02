namespace RestaurantReviewer.Contracts.Entities
{
    public class Restaurant : Place
    {
        public bool HaveCloseProtection { get; set; }

        public override void Close()
        {
            if (!HaveCloseProtection)
            {
                base.Close();
            }
        }
    }
}
