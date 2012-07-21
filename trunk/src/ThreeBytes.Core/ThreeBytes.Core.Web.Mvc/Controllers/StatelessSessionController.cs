using System.Web.Mvc;
using System.Web.SessionState;

namespace ThreeBytes.Core.Web.Mvc.Controllers
{
    [SessionState(SessionStateBehavior.Disabled)]
    public abstract class StatelessSessionController : BaseController
    {
    }
}
