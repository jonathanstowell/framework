using System.Collections.Generic;

namespace ThreeBytes.Core.DataStructures
{
    public class NavigationNode
    {
        public string Name { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public int Order { get; set; }
        public IDictionary<string, object> RouteValues { get; set; }
        public IDictionary<string, object> HtmlAttributes { get; set; }
        public List<NavigationNode> Children { get; set; }

        public NavigationNode()
        {
            Children = new List<NavigationNode>();
        }

        public override bool Equals(object obj)
        {
            NavigationNode other = obj as NavigationNode;

            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Equals(other);
        }

        public virtual bool Equals(NavigationNode other)
        {
            if (Name == other.Name)
                return true;

            return false;
        }
    }
}
