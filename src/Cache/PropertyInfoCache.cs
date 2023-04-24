using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace am.kon.packages.dac.common.Cache
{
    /// <summary>
    /// A static class to be used for caching of <see cref="ParameterInfo[]"/> data of different types to make it faster to get list of properties.
    /// </summary>
	public static class PropertyInfoCache
	{
        /// <summary>
        /// Dictioonary to store properties information of a type
        /// </summary>
		private static ConcurrentDictionary<Type, PropertyInfo[]> _cache = new ConcurrentDictionary<Type, PropertyInfo[]>();

        /// <summary>
        /// Get array of <see cref="PropertyInfo"/> for provided type
        /// </summary>
        /// <param name="type">Type to get list of properties for</param>
        /// <returns>Array of <see cref="PropertyInfo"/>.</returns>
        public static PropertyInfo[] GetProperties(Type type)
        {
            if (_cache.TryGetValue(type, out PropertyInfo[] value))
                return value;

            PropertyInfo[] propertyInfos = type.GetProperties();

            _cache.TryAdd(type, propertyInfos);

            return propertyInfos;
        }
    }
}

