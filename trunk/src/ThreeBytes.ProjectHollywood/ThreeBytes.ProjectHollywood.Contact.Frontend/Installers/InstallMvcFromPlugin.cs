using System.Web.Mvc;
using Castle.Core;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using ThreeBytes.Core.Bootstrapper.Extensions.Mvc;
using ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers;
using ThreeBytes.Core.Commands.Abstract;
using ThreeBytes.Core.DataStructures;

namespace ThreeBytes.ProjectHollywood.Contact.Frontend.Installers
{
    public class InstallMvcFromPlugin : IWebWindsorRegistration
    {
        public void Install(IWindsorContainer container)
        {
            container.Register(
                AllTypes.FromThisAssembly().BasedOn<IController>().Configure(
                    component =>
                    {
                        component.Named(component.Implementation.Name);
                        component.LifeStyle.Is(LifestyleType.Transient);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<WebViewPage>().Configure(
                    component =>
                    {
                        component.Named(ViewKeyGenerator.GetViewKey(component.Implementation.FullName));
                        component.LifeStyle.Is(LifestyleType.Singleton);
                    }).WithService.Base(),
                AllTypes.FromThisAssembly().BasedOn<IRegisterRoutes>().Unless(x => x.IsAbstract).Configure(x => x.LifeStyle.Singleton).WithService.FromInterface(),
                AllTypes.FromThisAssembly().BasedOn<IRegisterNavigation>().Unless(x => x.IsAbstract).Configure(x => x.LifeStyle.Singleton).WithService.FromInterface(),
                AllTypes.FromThisAssembly().BasedOn<IPreCommand>().Unless(x => x.IsAbstract).Configure(x => x.LifeStyle.Transient)
            );
        }
    }
}
