using ThreeBytes.Core.Entities.Abstract;
using ThreeBytes.Core.Entities.Concrete;

namespace ThreeBytes.Logging.Exceptions.Management.Entities
{
    public class ExceptionManagement : BusinessObject<ExceptionManagement>, IBusinessObject<ExceptionManagement>
    {
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string InnerException { get; set; }
    }
}
