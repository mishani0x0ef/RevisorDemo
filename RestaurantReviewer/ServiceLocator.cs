using Ninject;
using RestaurantReviewer.Contracts.Services;
using RestaurantReviewer.Services;

namespace RestaurantReviewer
{
    public class ServiceLocator
    {
        private IKernel _kernel;

        public ServiceLocator()
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
