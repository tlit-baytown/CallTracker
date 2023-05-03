using Microsoft.CSharp;
using System.CodeDom;

namespace CallTracker_Lib.extensions
{
    public static class TypeExtensions
    {
        public static string GetFriendlyName(this Type T)
        {
            using var provider = new CSharpCodeProvider();
            var typeRef = new CodeTypeReference(T);
            return provider.GetTypeOutput(typeRef);
        }
    }
}
