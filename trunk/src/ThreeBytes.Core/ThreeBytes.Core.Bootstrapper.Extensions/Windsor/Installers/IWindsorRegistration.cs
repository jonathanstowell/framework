using Castle.Windsor;

namespace ThreeBytes.Core.Bootstrapper.Extensions.Windsor.Installers
{
    public interface IWindsorRegistration
    {
        void Install(IWindsorContainer container);
    }
}
