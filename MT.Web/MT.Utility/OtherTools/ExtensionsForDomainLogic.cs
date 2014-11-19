using System.Collections.Generic;

namespace MT.Utility.OtherTools
{
    public static class ExtensionsForDomainLogic
    {
        ///<summary>
        /// Changes source elements for elements of collection starting from index.
        /// </summary>
        public static IList<T> PutRange<T>(this IList<T> source, int index, IList<T> collection)
        {
            for (int i = index; i < index + collection.Count; i++)
            {
                source[i] = collection[i - index];
            }

            return source;
        }
    }
}
