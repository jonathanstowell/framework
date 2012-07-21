using System.Collections.Generic;
using ThreeBytes.Core.Email.Abstract;

namespace ThreeBytes.Core.Email.Concrete
{
    public class SendBatchEmailResult : ISendBatchEmailResult
    {
        public bool Success { get { return Failed == 0; } }

        public IList<ISendEmailResult> SentResults { get; set; }
        public IList<ISendEmailResult> FailedResults { get; set; } 
        public int Sent { get { return SentResults.Count; } }
        public int Failed { get { return FailedResults.Count; } }
    }
}
