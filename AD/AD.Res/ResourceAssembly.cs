using System.Reflection;

namespace AD.Res
{
    public class ResourceAssembly
    {
        /**
         <summary>
        Gets the current resource assembly.
        </summary>
         */
        public static Assembly GetAssembly => Assembly.GetExecutingAssembly();
        /// <summary>
        /// Gets the namespace of the currently running resource assembly.
        /// </summary>
        /// <returns></returns>
        public static string GetNamespace => $"{typeof(ResourceAssembly).Namespace}.";
    }
}
