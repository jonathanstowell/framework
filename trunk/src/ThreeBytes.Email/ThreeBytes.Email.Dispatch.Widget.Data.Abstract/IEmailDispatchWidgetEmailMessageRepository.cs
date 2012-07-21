using System.Collections.Generic;
using ThreeBytes.Core.Data.Abstract;
using ThreeBytes.Email.Dispatch.Widget.Entities;

namespace ThreeBytes.Email.Dispatch.Widget.Data.Abstract
{
    public interface IEmailDispatchWidgetEmailMessageRepository : IKeyedGenericRepository<EmailDispatchWidgetEmailMessage>
    {
        IList<EmailDispatchWidgetEmailMessage> GetMostRecent(int take, string applicationName);
    }
}
