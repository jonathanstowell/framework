using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeBytes.Core.Extensions.Dictionary
{
    public static class QueryString
    {
        public static string ToQueryString(this IDictionary<string, object> item)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("?");

            for (int i = 0; i < item.Count; i ++)
            {
                if (i == item.Count - 1)
                    sb.Append(item.ElementAt(i).Key + "=" + item.ElementAt(i).Value);
                else
                    sb.Append(item.ElementAt(i).Key + "=" + item.ElementAt(i).Value + "&");
            }

            return sb.ToString();
        }
    }
}
