using System.Collections.Generic;

namespace ThreeBytes.Core.Email.Abstract
{
    public interface IEmailDispatcher
    {
        ISendBatchEmailResult Dispatch(IList<IEmailMessage> emails);
        ISendEmailResult Dispatch(IEmailMessage email);
    }
}
