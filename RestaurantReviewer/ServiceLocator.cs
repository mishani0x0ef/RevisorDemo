using Ninject;
using RestaurantReviewer.Contracts.Services;
using RestaurantReviewer.Services;

namespace RestaurantReviewer
{
    // Singleton class. Only one instance of it exists.
    public class ServiceLocator
    {
        private IKernel _kernel;

        private static object _locker = new object();
        private static ServiceLocator _instance;
        public static ServiceLocator Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (_locker)
                {
                    return _instance ?? (_instance = new ServiceLocator());
                }
            }
        }

        private ServiceLocator()
        {
            _kernel = new StandardKernel();
            RegisterDependencies();
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        private void RegisterDependencies()
        {
            _kernel.Bind<IPlaceProvider>().To<PlaceProvider>().InSingletonScope();
            _kernel.Bind<IPlaceService>().To<PlaceService>();
            _kernel.Bind<Revisor>().ToSelf();
        }
    }
}
