using System;
using System.Collections.Generic;

namespace SWeetJelly
{
    public static class DictionaryExtensions
    {
        #region Dictionary
        /// <summary>
        /// Adds the specified value to the dictionary at the given key, or adjusts the existing value if the key already exists.
        /// </summary>
        /// <typeparam name="T">The type of the key.</typeparam>
        /// <param name="dictionary">The dictionary to add or adjust the value in.</param>
        /// <param name="key">The key to add or adjust the value at.</param>
        /// <param name="value">The value to add or adjust.</param>
        /// <returns>The adjusted value at the given key.</returns>
        public static int AddOrAdjust<T>(this Dictionary<T, int> dictionary, T key, int value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] += value;
            else
                dictionary.Add(key, value);

            return dictionary[key];
        }

        /// <summary>
        /// Adds a new key-value pair to the dictionary or updates the value of an existing key.
        /// </summary>
        /// <typeparam name="T">The type of the dictionary keys.</typeparam>
        /// <param name="dictionary">The dictionary to add or update the key-value pair in.</param>
        /// <param name="key">The key to add or update.</param>
        /// <param name="value">The value to add or update.</param>
        /// <returns>The updated value associated with the key.</returns>
        public static int AddOrSet<T>(this Dictionary<T, int> dictionary, T key, int value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);

            return dictionary[key];
        }

        /// <summary>
        /// Executes the specified action for each key in the dictionary.
        /// </summary>
        /// <typeparam name="T">The type of the dictionary keys.</typeparam>
        /// <typeparam name="K">The type of the dictionary values.</typeparam>
        /// <param name="dictionary">The dictionary to iterate over.</param>
        /// <param name="action">The action to execute for each key.</param>
        public static void ForEachKey<T,K>(this Dictionary<T, K> dictionary, Action<T> action)
        {
            foreach(var key in dictionary.Keys)
            {
                action(key);
            }
        }

        /// <summary>
        /// Executes the specified action on each value in the dictionary.
        /// </summary>
        /// <typeparam name="T">The type of the dictionary keys.</typeparam>
        /// <typeparam name="K">The type of the dictionary values.</typeparam>
        /// <param name="dictionary">The dictionary to iterate over.</param>
        /// <param name="action">The action to execute on each value.</param>
        public static void ForEachValue<T, K>(this Dictionary<T, K> dictionary, Action<K> action)
        {
            foreach (var value in dictionary.Values)
            {
                action(value);
            }
        }

        #endregion

    }
}