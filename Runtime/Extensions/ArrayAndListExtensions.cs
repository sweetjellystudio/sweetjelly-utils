using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SWeetJelly
{
    public static class ArrayAndListExtensions
    {
#region Array
        /// <summary>
        /// Executes a specified action on each element of the array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to iterate over.</param>
        /// <param name="action">The action to perform on each element of the array.</param>
        public static void ForEach<T>(this T[] array, Action<T> action)
        {
            for(int i = 0; i < array.Length; i++)
            {
                action(array[i]);
            }
        }

        /// <summary>
        /// Returns the index of the first occurrence of a specified element in the array.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to search.</param>
        /// <param name="t">The element to locate in the array.</param>
        /// <returns>
        /// The index of the first occurrence of the specified element in the array, if found;
        /// otherwise, -1.
        /// </returns>
        public static int IndexOf<T>(this T[] array, T t)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(t)) return i;
            }

            return -1;
        }

        /// <summary>
        /// Finds the first element in the array that satisfies the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        /// <param name="array">The array to search.</param>
        /// <param name="action">The condition to test each element against.</param>
        /// <returns>The first element in the array that satisfies the condition, or the default value of type T if no such element is found.</returns>
        public static T Find<T>(this T[] array, Func<T, bool> action)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if(action(array[i])) return array[i];
            }

            return default(T);
        }

        /// <summary>
        /// Removes the specified item from the array and returns a new array without the item.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the array.</typeparam>
        /// <param name="array">The array to remove the item from.</param>
        /// <param name="itemToRemove">The item to remove from the array.</param>
        /// <returns>A new array without the specified item.</returns>
        public static IList<T> Remove<T>(this T[] array, T itemToRemove)
        {
            var result = new List<T>();

            for(int i = 0; i < array.Length; i++)
            {
                if(!array[i].Equals(itemToRemove))
                {
                    result.Add(array[i]);
                }
            }

            return result;
        }
#endregion

#region List
        public static void RefreshWith<T>(this List<T> list, IEnumerable<T> items)
        {
            list.Clear();
            list.AddRange(items);
        }
#endregion

        /// <summary>
        /// Determines whether a collection is null or has no elements
        /// without having to enumerate the entire collection to get a count.
        /// </summary>
        /// <param name="collection">collection to evaluate</param>
        public static bool IsNullOrEmpty<T>(this IList<T> collection)
        {
            return (collection == null || collection.Count == 0);
        }

        // Uses LINQ's Any() method to determine if the collection is empty,
        // so there is some GC overhead.
        //public static bool IsNullOrEmpty<T>(this IList<T> collection) {
        //    return collection == null || !collection.Any();
        //}

        /// <summary>
        /// Swaps two elements in the list at the specified indices.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="indexA">The index of the first element.</param>
        /// <param name="indexB">The index of the second element.</param>
        public static void Swap<T>(this IList<T> list, int indexA, int indexB) {
            (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        }

        /// <summary>
        /// Displays each element in the collection by applying the specified function to it.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to display.</param>
        /// <param name="function">The function to apply to each element.</param>
        public static void Display<T>(this IList<T> collection, Func<T, string> function)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                Debug.Log(function(collection[i]));
            }
        }

        /// <summary>
        /// Checks if the specified value is within the range of the collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="value">The value to check.</param>
        /// <returns><c>true</c> if the value is within the range of the collection; otherwise, <c>false</c>.</returns>
        public static bool IsInRange<T>(this IList<T> collection, int value)
        {
            return (value >= 0 && value < collection.Count);
        }

        /// <summary>
        /// Determines whether the collection contains any element that satisfies the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to search.</param>
        /// <param name="searchFun">The condition to test each element against.</param>
        /// <returns><c>true</c> if the collection contains any element that satisfies the condition; otherwise, <c>false</c>.</returns>
        public static bool Has<T>(this IList<T> collection, Func<T, bool> searchFun)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                if (searchFun(collection[i])) return true;
            }

            return false;
        }

        /// <summary>
        /// Determines whether two collections are equal by comparing their elements.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collections.</typeparam>
        /// <param name="c1">The first collection to compare.</param>
        /// <param name="c2">The second collection to compare.</param>
        /// <returns><c>true</c> if the collections are equal; otherwise, <c>false</c>.</returns>
        public static bool CollectionEquals<T>(this IList<T> c1, IList<T> c2)
        {
            if (ReferenceEquals(c1, c2))
                return true;

            if (c1 == null || c2 == null)
                return false;

            if (c1.Count != c2.Count)
                return false;

            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            for (int i = 0; i < c1.Count; i++)
            {
                if (!comparer.Equals(c1[i], c2[i]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Determines whether the specified index is the last index in the collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to check.</param>
        /// <param name="index">The index to check.</param>
        /// <returns><c>true</c> if the specified index is the last index in the collection; otherwise, <c>false</c>.</returns>
        public static bool IsLast<T>(this IList<T> collection, int index)
        {
            return collection.Count - 1 == index;
        }

        /// <summary>
        /// Calculates the sum of the elements in the collection using the specified sum function.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="collection">The collection to calculate the sum for.</param>
        /// <param name="sumFun">The function used to calculate the sum for each element.</param>
        /// <returns>The int sum of the elements in the collection.</returns>
        public static int Sum<T>(this IList<T> collection, Func<T, int> sumFun)
        {
            int sum = 0;

            for(int i = 0; i < collection.Count; i++)
            {
                sum += sumFun(collection[i]);
            }

            return sum;
        }

        /// <summary>
        /// Calculates the sum of the elements in the collection using the specified sum function.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="collection">The collection to calculate the sum for.</param>
        /// <param name="sumFun">The function to use for calculating the sum of each element.</param>
        /// <returns>The float sum of the elements in the collection.</returns>
        public static float Sum<T>(this IList<T> collection, Func<T, float> sumFun)
        {
            float sum = 0;

            for (int i = 0; i < collection.Count; i++)
            {
                sum += sumFun(collection[i]);
            }

            return sum;
        }

        /// <summary>
        /// Gets a random item from the specified collection.
        /// </summary>
        /// <typeparam name="T">The type of items in the collection.</typeparam>
        /// <param name="collection">The collection to get a random item from.</param>
        /// <returns>A random item from the collection.</returns>
        public static T GetRandomItem<T>(this IList<T> collection)
        {
            return collection[Random.Range(0, collection.Count)];
        }

        /// <summary>
        /// Gets the element at the specified index from the collection, or returns a random element if the index is out of range.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to retrieve the element from.</param>
        /// <param name="index">The index of the element to retrieve.</param>
        /// <returns>The element at the specified index, or a random element if the index is out of range.</returns>
        public static T GetByIndexOrRandom<T>(this IList<T> collection, int index)
        {
            if (collection.IsInRange(index))
            {
                return collection[index];
            }

            return collection.GetRandomItem();
        }

        /// <summary>
        /// Finds a random element in the collection that satisfies the specified condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to search in.</param>
        /// <param name="action">The condition that the element must satisfy.</param>
        /// <returns>A random element from the collection that satisfies the condition, or the default value of type T if no such element is found.</returns>
        public static T FindRandomOrder<T>(this IList<T> collection, Func<T, bool> action) 
        {
            var tabsIndices = new List<int>(collection.Count);
            for (int i = 0; i < collection.Count; i++) tabsIndices.Add(i);

            while (tabsIndices.Count > 0)
            {
                var i = Random.Range(0, tabsIndices.Count);

                var index = tabsIndices[i];
                tabsIndices.RemoveAt(i);

                if (action(collection[index]))
                {
                    return collection[index];
                }
            }

            return default(T);
        }

        /// <summary>
        /// Shuffles the elements in the collection using the Durstenfeld implementation of the Fisher-Yates algorithm.
        /// This method modifies the input collection in-place, ensuring each permutation is equally likely, and returns the collection for method chaining.
        /// Reference: http://en.wikipedia.org/wiki/Fisher-Yates_shuffle
        /// </summary>
        /// <param name="collection">The collection to be shuffled.</param>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <returns>The shuffled collection.</returns>
        public static IList<T> Shuffle<T>(this IList<T> collection) {
            int count = collection.Count;
            while (count > 1) {
                --count;
                int index = Random.Range(0,count + 1);
                (collection[index], collection[count]) = (collection[count], collection[index]);
            }
            return collection;
        }

        /// <summary>
        /// Generates an array of unique random object IDs from the given collection of integers.
        /// </summary>
        /// <typeparam name="T">The type of the objects in the collection.</typeparam>
        /// <param name="collection">The collection of integers.</param>
        /// <param name="count">The number of unique random object IDs to generate.</param>
        /// <returns>An array of unique random object IDs.</returns>
        public static IList<int> GetUniqueRandomObjectIDs<T>(IList<int> collection, int count)
        {
#if UNITY_EDITOR
            if (count >= collection.Count)
            {
                Debug.LogError("Array is to small!");
            }

            if (count == 1)
                Debug.LogWarning("Don't use GetUniqueRandomObjectIDs if count is 1!");
#endif

            List<int> objectIDs = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int randomValue = -1;

                do
                {
                    randomValue = Random.Range(0, collection.Count);
                }
                while (objectIDs.FindIndex(x => x == randomValue) != -1);

                objectIDs.Add(randomValue);
            }

            return objectIDs;
        }

        /// <summary>
        /// Returns an array of unique random objects from the given list.
        /// </summary>
        /// <typeparam name="T">The type of objects in the list.</typeparam>
        /// <param name="collection">The list of objects.</param>
        /// <param name="count">The number of unique random objects to retrieve.</param>
        /// <returns>An array of unique random objects.</returns>
        public static IList<T> GetUniqueRandomObjects<T>(IList<T> collection, int count)
        {
#if UNITY_EDITOR
            if (count >= collection.Count)
            {
                Debug.LogError("Array is to small!");
            }

            if (count == 1)
                Debug.LogWarning("Don't use GetUniqueRandomObjects if count is 1!");
#endif

            List<int> objectIDs = new List<int>();
            IList<T> resultList = new List<T>();

            for (int i = 0; i < count; i++)
            {
                int randomValue = -1;

                do
                {
                    randomValue = Random.Range(0, collection.Count);
                }
                while (objectIDs.FindIndex(x => x == randomValue) != -1);

                objectIDs.Add(randomValue);

                resultList.Add(collection[randomValue]);
            }

            return resultList;
        }

        /// <summary>
        /// Creates a new list that is a copy of the original list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The original list to be copied.</param>
        /// <returns>A new list that is a copy of the original list.</returns>
        public static IList<T> MakeCopy<T>(this IList<T> list)
        {
            var copy = new List<T>();
            for(int i = 0; i < list.Count; i++)
            {
                copy.Add(list[i]);
            }
            return copy;
        }

        /// <summary>
        /// Creates a new list that is a copy of the original list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <param name="list">The original list to be copied.</param>
        /// <returns>A new list that is a copy of the original list.</returns>
        public static IList<T> Clone<T>(this IList<T> list) {
            List<T> clone = new List<T>();
            foreach (T item in list) {
                clone.Add(item);
            }

            return clone;
        }

        /// <summary>
        /// Drops the last specified number of elements from the given collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to drop elements from.</param>
        /// <param name="count">The number of elements to drop from the end of the collection.</param>
        /// <returns>A new collection with the specified number of elements dropped from the end.</returns>
        public static IList<T> DropLast<T>(this IList<T> collection, int count)
        {
            if (count >= collection.Count) return new List<T>();

            IList<T> result = new List<T>(collection.Count- count);

            for (int i = 0; i < collection.Count - count; i++)
            {
                result.Add(collection[i]);
            }

            return result;
        }

        /// <summary>
        /// Sorts the elements in the collection based on the specified sort function.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <typeparam name="K">The type of the key used for sorting.</typeparam>
        /// <param name="collection">The collection to be sorted.</param>
        /// <param name="sortFun">The function used to extract the sort key from each element.</param>
        /// <returns>A new list containing the sorted elements.</returns>
        public static IList<T> Sort<T, K>(this IList<T> collection, Func<T, K> sortFun) where K: IComparable
        {
            var result = new List<T>(collection);

            result.Sort((t1, t2) => sortFun(t1).CompareTo(sortFun(t2)));

            return result;
        }

        /// <summary>
        /// Sorts the elements of the collection in reverse order based on the specified sort function.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <typeparam name="K">The type of the key used for sorting.</typeparam>
        /// <param name="collection">The collection to be sorted.</param>
        /// <param name="sortFun">The function used to extract the sort key from each element.</param>
        /// <returns>A new list containing the sorted elements in reverse order.</returns>
        /// <remarks>
        /// This method creates a new list containing the elements of the original collection and sorts them in reverse order
        /// based on the values returned by the specified sort function. The sort function should return a key that implements
        /// the <see cref="IComparable"/> interface.
        /// </remarks>
        public static IList<T> SortReverse<T, K>(this IList<T> collection, Func<T, K> sortFun) where K : IComparable
        {
            var result = new List<T>(collection);

            result.Sort((t1, t2) => -sortFun(t1).CompareTo(sortFun(t2)));

            return result;
        }

        /// <summary>
        /// Returns a subarray of the specified collection starting from the specified index and with the specified length.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to extract the subarray from.</param>
        /// <param name="index">The starting index of the subarray.</param>
        /// <param name="length">The length of the subarray.</param>
        /// <returns>A new list containing the subarray.</returns>
        public static IList<T> SubArray<T>(this IList<T> collection, int index, int length)
        {
            if(collection == null)
            {
                throw new ArgumentException(nameof(collection));
            }
            
            if(index < 0 || length <0 || index + length > collection.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            IList<T> result = new List<T>(length);

            for(int i=0; i< length; i++)
            {
                result.Add(collection[index + 1]);
            }

            return result;
        }

        /// <summary>
        /// Filters the elements of the specified collection based on a specified condition.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to filter.</param>
        /// <param name="func">The condition to test each element against.</param>
        /// <returns>A new list containing the elements from the original collection that satisfy the condition.</returns>
        public static IList<T> Filter<T>(this IList<T> collection, Func<T, bool> func)
        {
            var resultList = new List<T>();

            for(int i = 0; i < collection.Count; i++)
            {
                if (func(collection[i])) resultList.Add(collection[i]);
            }

            return resultList;
        }
    }
}