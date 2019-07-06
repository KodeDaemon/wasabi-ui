using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WasabiUI.Forms.Core
{
    public static class CustomAttributeExtractorExtensions
    {
        
        public static List<T> GetAttributes<T>(this MemberInfo member, Type type) where T : Attribute
        {
            // determine whether to inherit based on the AttributeUsage
            // you could add a bool parameter if you like but I think it defeats the purpose of the usage
            var usage = typeof(T).GetCustomAttributes(typeof(AttributeUsageAttribute), true)
                .Cast<AttributeUsageAttribute>()
                .FirstOrDefault();
            var inherit = usage != null && usage.Inherited;

            return (
                    inherit
                        ? GetAttributesRecurse<T>(member, type)
                        : member.GetCustomAttributes(typeof(T), false).Cast<T>()
                )
                .Distinct()  // interfaces mean duplicates are a thing
                // note: attribute equivalence needs to be overridden. The default is not great.
                .ToList();
        }

        private static IEnumerable<T> GetAttributesRecurse<T>(MemberInfo member, Type type) where T : Attribute
        {
            // must use Attribute.GetCustomAttribute rather than MemberInfo.GetCustomAttribute as the latter
            // won't retrieve inherited attributes from base *classes*
            foreach (T attribute in Attribute.GetCustomAttributes(member, typeof(T), true))
                yield return attribute;

            // The most reliable target in the interface map is the property get method.
            // If you have set-only properties, you'll need to handle that case. I generally just ignore that
            // case because it doesn't make sense to me.
            PropertyInfo property;
            var target = (property = member as PropertyInfo) != null ? property.GetGetMethod() : member;


            foreach (var @interface in member.DeclaringType.GetInterfaces())
            {
                InterfaceMapping map;

                // The interface map is two aligned arrays; TargetMethods and InterfaceMethods.
                if (member.DeclaringType.IsInterface)
                {
                    map = type.GetInterfaceMap(@interface);
                }
                else
                { 
                    map = member.DeclaringType.GetInterfaceMap(@interface);
                }

                var memberIndex = Array.IndexOf(map.TargetMethods, target); // see target above
                if (memberIndex < 0) continue;

                // To recurse, we still need to hit the property on the parent interface.
                // Why don't we just use the get method from the start? Because GetCustomAttributes won't work.
                var interfaceMethod = property != null
                    // name of property get method is get_<property name>
                    // so name of parent property is substring(4) of that - this is reliable IME
                    ? @interface.GetProperty(map.InterfaceMethods[memberIndex].Name.Substring(4))
                    : (MemberInfo)map.InterfaceMethods[memberIndex];

                // Continuation is the word to google if you don't understand this
                foreach (var attribute in interfaceMethod.GetAttributes<T>(type))
                    yield return attribute;
            }
        }
    }
}
