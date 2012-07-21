using System;
using Microsoft.Practices.Unity;
using Microsoft.ServiceModel.Web;

namespace ThreeBytes.Core.Web.WCF.Unity
{
    public class UnityServiceHost : WebServiceHost2
    {
        public IUnityContainer unityContainer { get; set; }


        public UnityServiceHost(IUnityContainer unityContainer, Type serviceType)
            : base(serviceType)
        {
            this.unityContainer = unityContainer;
        }

        protected override void OnOpening()
        {
            base.OnOpening();

            if (Description.Behaviors.Find<UnityServiceBehavior>() == null)
            {
                Description.Behaviors.Add(new UnityServiceBehavior(unityContainer));
            }
        }
    }
}
