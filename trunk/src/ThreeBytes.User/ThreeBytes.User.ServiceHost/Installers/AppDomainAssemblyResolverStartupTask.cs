﻿using System;
using Bootstrap.Extensions.StartupTasks;

namespace ThreeBytes.User.ServiceHost.Installers
{
    public class AppDomainAssemblyResolverStartupTask : IStartupTask
    {
        public void Run()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (a, args) => EndpointConfig.AssemblyResolver.GetAssembly(args.Name);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}