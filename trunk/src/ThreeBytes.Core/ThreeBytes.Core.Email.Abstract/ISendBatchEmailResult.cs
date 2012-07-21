using System.Collections.Generic;

namespace ThreeBytes.Core.Email.Abstract
{
    public interface ISendBatchEmailResult
    {
        bool Success { get; }
        IList<ISendEmailResult> SentResults { get; set; }
        IList<ISendEmailResult> FailedResults { get; set; }
        int Sent { get; }
        int Failed { get; }
    }
}
