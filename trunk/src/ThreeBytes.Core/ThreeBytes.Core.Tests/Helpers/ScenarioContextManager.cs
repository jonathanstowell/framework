using TechTalk.SpecFlow;

namespace ThreeBytes.Core.Tests.Helpers
{
    public static class ScenarioContextManager
    {
        public static void Set(string key, object item)
        {
            ScenarioContext.Current[key] = item;
        }

        public static T Get<T>(string key)
        {
            if (!ScenarioContext.Current.ContainsKey(key))
                return default(T);

            return (T)ScenarioContext.Current[key];
        }

        public static T GetOrReturnNew<T>(string key) where T : class, new()
        {
            if (!ScenarioContext.Current.ContainsKey(key))
                return new T();

            return (T)ScenarioContext.Current[key];
        }

        public static bool Contains(string key)
        {
            return ScenarioContext.Current.ContainsKey(key);
        }
    }
}
