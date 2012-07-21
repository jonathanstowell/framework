using System.ComponentModel;

namespace ThreeBytes.ProjectHollywood.Resources.Helpers
{
    public class LocalizedThreeBytesProjectHollywoodDisplayNameAttribute : DisplayNameAttribute
    {
        private readonly string resourceName;
        public LocalizedThreeBytesProjectHollywoodDisplayNameAttribute(string resourceName)
            : base()
        {
            this.resourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {
                return Resources.ResourceManager.GetString(this.resourceName);
            }
        }
    }
}
