using PipServices3.Commons.Refer;
using PipServices3.Components.Auth;
using PipServices3.Components.Build;
using PipServices3.Components.Config;
using PipServices3.Components.Cache;
using PipServices3.Components.Connect;
using PipServices3.Components.Count;
using PipServices3.Components.Info;
using PipServices3.Components.Log;

namespace PipServices3.Container.Build
{
    /// <summary>
    /// Creates default container components (loggers, counters, caches, locks, etc.) by their descriptors.
    /// </summary>
    /// See <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_build_1_1_factory.html">Factory</a>, 
    /// <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_info_1_1_default_info_factory.html">DefaultInfoFactory</a>, 
    /// <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_log_1_1_default_logger_factory.html">DefaultLoggerFactory</a>,
    /// <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_count_1_1_default_counters_factory.html">DefaultCountersFactory</a>, 
    /// <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_config_1_1_default_config_reader_factory.html">DefaultConfigReaderFactory</a>, 
    /// <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_cache_1_1_default_cache_factory.html">DefaultCacheFactory</a>,
    /// <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_auth_1_1_default_credential_store_factory.html">DefaultCredentialStoreFactory</a>, 
    /// <a href="https://pip-services3-dotnet.github.io/pip-services3-components-dotnet/class_pip_services_1_1_components_1_1_connect_1_1_default_discovery_factory.html">DefaultDiscoveryFactory</a>
    public class DefaultContainerFactory : CompositeFactory
    {
        public static readonly Descriptor Descriptor = new Descriptor("pip-services3", "factory", "container", "default", "1.0");

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
