using System.Collections.Generic;
using System.Linq;
using ThreeBytes.Core.Email.Abstract;

namespace ThreeBytes.Core.Email.Concrete
{
    public class ThreeBytesTemplateEngine : ITemplateEngine
    {
        public string GetTemplatedBody(string template, IDictionary<string, string> model = null)
        {
            if (model != null)
            {
                template = model.Aggregate(template, (current, item) => current.Replace(string.Format("[{0}]", item.Key), item.Value));
            }

            return template;
        }
    }
}
