using System;
using System.Collections.Generic;
using System.Linq;

namespace Lecii.Standard {

    public static class AttributeHelper {

        /// <summary>
        /// return all type(class) that defind with type
        /// !Becareful it using Refection
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesWith(this Type type, bool inherit) {
            return from a in AppDomain.CurrentDomain.GetAssemblies()
                   from t in a.GetTypes()
                   where t.IsDefined(type, inherit)
                   select t;
        }

        /// <summary>
        /// return all type(class) that defind with type
        /// !Becareful it using Refection
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Type> GetClassesWith<TAttribute>(bool inherit)
            where TAttribute : System.Attribute {
            return from a in AppDomain.CurrentDomain.GetAssemblies()
                   from t in a.GetTypes()
                   where t.IsDefined(typeof(TAttribute), inherit)
                   select t;
        }

    }

}