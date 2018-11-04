using System;
using PipServices3.Commons.Config;
using PipServices3.Commons.Refer;
using PipServices3.Commons.Reflect;
using PipServices3.Components.Build;
using PipServices3.Container.Config;

namespace PipServices3.Container.Refer
{
    /// <summary>
    /// Container managed references that can be created from container configuration.
    /// </summary>
    /// See <see cref="ManagedReferences"/>
    public sealed class ContainerReferences : ManagedReferences
    {
        /// <summary>
        /// Puts components into the references from container configuration.
        /// </summary>
        /// <param name="config">a container configuration with information of components to be added.</param>
        public void PutFromConfig(ContainerConfig config)
        {
            foreach (var componentConfig in config)
            {
                object component = null;
                object locator = null;

                try
                {
                    // Create component dynamically
                    if (componentConfig.Type != null)
                    {
                        locator = componentConfig.Type;
                        component = TypeReflector.CreateInstanceByDescriptor(componentConfig.Type);
                    }
                    // Or create component statically
                    else if (componentConfig.Descriptor != null)
                    {
                        locator = componentConfig.Descriptor;
                        IFactory factory = _builder.FindFactory(locator);
                        component = _builder.Create(locator, factory);
                        if (component == null)
                            throw new ReferenceException(null, locator);
                        locator = _builder.ClarifyLocator(locator, factory);
                    }

                    // Check that component was created
                    if (component == null)
                    {
                        throw new CreateException("CANNOT_CREATE_COMPONENT", "Cannot create component")
                                .WithDetails("config", config);
                    }

                    // Add component to the list
                    _references.Put(locator, component);

                    // Configure component
                    var configurable = component as IConfigurable;
                    configurable?.Configure(componentConfig.Config);

                    // Set references to factories
                    if (component is IFactory)
                    {
                        var referenceable = component as IReferenceable;
                        referenceable?.SetReferences(this);
                    }
                }
                catch (Exception ex)
                {
                    throw new ReferenceException(null, locator).WithCause(ex);
                }
            }
        }
    }
}
