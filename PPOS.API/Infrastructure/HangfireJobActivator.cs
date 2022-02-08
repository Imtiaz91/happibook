using System;
using Hangfire;
using Happibook.Core.Infrastructure;
using Microsoft.Practices.Unity;

namespace Happibook.API.Infrastructure
{
    public class ContainerJobActivator : JobActivator
    {
        private readonly IUnityContainer container;

        public ContainerJobActivator(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.container = container;
        }

        public override object ActivateJob(Type jobType)
        {
            return this.container.Resolve(jobType);
        }

        public override JobActivatorScope BeginScope(JobActivatorContext context)
        {
            var child = this.container.CreateChildContainer();
            child.RegisterType<ISSHRequestInfo, Core.Infrastructure.RequestInfo>(new PerThreadLifetimeManager());
            return new UnityScope(child);
        }

        private class UnityScope : JobActivatorScope
        {
            private readonly IUnityContainer container;

            public UnityScope(IUnityContainer container)
            {
                this.container = container;
            }

            public override object Resolve(Type type)
            {
                return this.container.Resolve(type);
            }

            public override void DisposeScope()
            {
                this.container.Dispose();
            }
        }
    }
}