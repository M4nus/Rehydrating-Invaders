using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ManusLibrary
{
    public static class ManusLibrary
    {
        public static T RandomElement<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }
    }
}

