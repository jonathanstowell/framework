using System.Collections.Generic;
using ThreeBytes.Core.Service.Abstract;
using ThreeBytes.Email.Dispatch.Widget.Entities;

namespace ThreeBytes.Email.Dispatch.Widget.Service.Abstract
{
    public interface IEmailDispatchWidgetEmailMessageService : IKeyedGenericService<EmailDispatchWidgetEmailMessage>
    {
        IList<EmailDispatchWidgetEmailMessage> GetMostRecent(int take, string applicationName);
    }
}
