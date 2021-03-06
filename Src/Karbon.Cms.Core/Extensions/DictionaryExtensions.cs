﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karbon.Cms.Core
{
    internal static class DictionaryExtensions
    {
        /// <summary>
        /// Adds or updates the specified value for the given key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="dict">The dict.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            dict[key] = value;
        }
    }
}
