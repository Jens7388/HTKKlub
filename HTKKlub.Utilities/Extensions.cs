using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HTKKlub.Utilities
{
    public static class Extensions
    {
        /// <summary>
        /// Replaces an <see cref="ObservableCollection{T}"/> with a provided <see cref="IEnumerable{T}"/>,
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="observableCollection"></param>
        /// <param name="collection"></param>
        public static void ReplaceWith<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> collection)
        {
            if(collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            observableCollection.Clear();
            foreach(T item in collection)
            {
                observableCollection.Add(item);
            }
        }

        /// <summary>
        /// Returns the inner most innerException
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Exception GetOriginalException(this Exception ex)
        {
            return ex.InnerException == null ? ex : ex.InnerException.GetOriginalException();
        }
    }
}