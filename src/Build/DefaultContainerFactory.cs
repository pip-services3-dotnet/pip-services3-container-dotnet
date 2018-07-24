using PipServices.Commons.Refer;
using PipServices.Components.Auth;
using PipServices.Components.Build;
using PipServices.Components.Config;
using PipServices.Components.Cache;
using PipServices.Components.Connect;
using PipServices.Components.Count;
using PipServices.Components.Info;
using PipServices.Components.Log;

namespace PipServices.Container.Build
{
    public class DefaultContainerFactory : CompositeFactory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "container", "default", "1.0");

        public DefaultContainerFactory(params IFactory[] factories)
            : base(factories)
        {
            Add(new DefaultInfoFactory());
            Add(new DefaultLoggerFactory());
            Add(new DefaultCountersFactory());
            Add(new DefaultConfigReaderFactory());
            Add(new DefaultCacheFactory());
            Add(new DefaultCredentialStoreFactory());
            Add(new DefaultDiscoveryFactory());
        }
    }
}
