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
    /// <summary>
    /// Creates default container components (loggers, counters, caches, locks, etc.) by their descriptors.
    /// </summary>
    /// See <see cref="Factory"/>, <see cref="DefaultInfoFactory"/>, <see cref="DefaultLoggerFactory"/>,
    /// <see cref="DefaultCountersFactory"/>, <see cref="DefaultConfigReaderFactory"/>, <see cref="DefaultCacheFactory"/>,
    /// <see cref="DefaultCredentialStoreFactory"/>, <see cref="DefaultDiscoveryFactory"/>
    public class DefaultContainerFactory : CompositeFactory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services", "factory", "container", "default", "1.0");

        /// <summary>
        /// Create a new instance of the factory and sets nested factories.
        /// </summary>
        /// <param name="factories">factories a list of nested factories</param>
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
