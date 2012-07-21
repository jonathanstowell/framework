using System;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace ThreeBytes.Core.Web.WCF.Unity
{
    public class WebServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            WebServiceHost postServiceHost = new WebServiceHost(serviceType, baseAddresses);
            return postServiceHost;
        }
    }
}
