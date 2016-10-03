using System.Configuration;

namespace RestaurantReviewer
{
    // Singleton class. Only one instance of it exists in app at the same time to avoid different settings.
    public class Settings
    {
        private static object _locker = new object();
        private static Settings _instance;
        public static Settings Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (_locker)
                {
                    return _instance ?? (_instance = new Settings());
                }
            }
        }

        private Settings()
        {
        }

        public int MinAllowedRating
        {
            get
            {
                var rating = ConfigurationManager.AppSettings["minAllowedRating"];
                return int.Parse(rating);
            }
        }
    }
}
