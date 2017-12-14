﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable,
            Action<T> action)
        {
            foreach (T item in enumerable) { action(item); }
        }
    }
}
