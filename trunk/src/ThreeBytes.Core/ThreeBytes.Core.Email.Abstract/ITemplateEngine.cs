using System.Collections.Generic;

namespace ThreeBytes.Core.Email.Abstract
{
    public interface ITemplateEngine
    {
        string GetTemplatedBody(string template, IDictionary<string, string> model = null);
    }
}
