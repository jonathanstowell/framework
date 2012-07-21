using System;
using Microsoft.ServiceModel.Web;

namespace ThreeBytes.Core.Web.WCF.Unity
{
    public class WebServiceHost : WebServiceHost2
    {
        public WebServiceHost(object singletonInstance, params Uri[] baseAddresses)
            : base(singletonInstance, baseAddresses)
        {
        }

        public WebServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, false, baseAddresses)
        {
        }
    }
}
