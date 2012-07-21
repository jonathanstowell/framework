namespace ThreeBytes.Core.Bootstrapper.Extensions.Mvc
{
    public static class ViewKeyGenerator
    {
        public static string GetViewKey(string componentname)
        {
            string result;

            if (componentname.Contains("Mobile"))
            {
                string[] keySplit = componentname.Split('.');
                int lastIndex = keySplit.Length;
                result = string.Format("{0}.{1}.{2}", keySplit[lastIndex - 3], keySplit[lastIndex - 2], keySplit[lastIndex - 1]);
            }
            else
            {
                string[] keySplit = componentname.Split('.');
                int lastIndex = keySplit.Length;
                result = string.Format("{0}.{1}", keySplit[lastIndex - 2], keySplit[lastIndex - 1]);
            }

            return result;
        }
    }
}
