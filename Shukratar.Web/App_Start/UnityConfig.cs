using System;
using Microsoft.Practices.Unity;
using Shukratar.Shared.Bootstrap;

namespace Shukratar.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> Container =
            new Lazy<IUnityContainer>(() => new AppContainer(new PerRequestLifetimeManager(), false));

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
    }
}