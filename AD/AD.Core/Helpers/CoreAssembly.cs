using System.Reflection;

namespace AD.Core
{
    public static class CoreAssembly
    {
        public static string GetAssemblyLocation => Assembly.GetExecutingAssembly().Location;
    }
}
