using Microsoft.CSharp;
using NLog;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
