namespace WpfMvvm
{
    using Ninject.Modules;

    /// <summary>
    /// Default module for the application
    /// </summary>
    public class DependencyContainer : NinjectModule
    {
        /// <inheritdoc />
        public override void Load()
        {
            // Binding Service interface to service implementation
            //Bind<IService>().To<ServicesImpl>();

        }
    }
}
