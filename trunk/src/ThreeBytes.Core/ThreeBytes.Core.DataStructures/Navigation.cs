using System.Collections.Generic;
using System.Linq;

namespace ThreeBytes.Core.DataStructures
{
    public class Navigation
    {
        public IList<NavigationNode> NavigationNodes { get; set; }

        public Navigation()
        {
            NavigationNodes = new List<NavigationNode>();
        }

        public void Add(IRegisterNavigation navigation)
        {
            AddInternal(navigation.Path);
        }

        private void AddInternal(NavigationNode path)
        {
            AddRecursive(NavigationNodes, path);
        }

        private void AddRecursive(IList<NavigationNode> navigationNodes, NavigationNode toAdd)
        {
            if (navigationNodes.Contains(toAdd))
            {
                foreach (var node in toAdd.Children)
                {
                    AddRecursive(navigationNodes.Single(x => x.Name == toAdd.Name).Children, node);
                }
            }
            else
                navigationNodes.Add(toAdd);
        }
    }
}
