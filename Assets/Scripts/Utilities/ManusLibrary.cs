using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ManusLibrary
{
    public static class ManusLibrary
    {
        public static T RandomElement<T>(this IList<T> list)
        {
            return list[Random.Range(0, list.Count)];
        }

        public static void Fade(this TextMeshProUGUI text, float alpha, float duration)
        {
            Color tmpColor = text.color;
            float timeElapsed = 0f;

            while(timeElapsed < duration)
            {
                tmpColor.a = Mathf.Lerp(tmpColor.a, alpha, timeElapsed / duration);
                timeElapsed += Time.deltaTime * 0.1f;
                text.color = tmpColor;
            }
            tmpColor.a = alpha;
            text.color = tmpColor;
        }

        public static void ChangeText(this TextMeshProUGUI text, string newText)
        {
            text.text = newText;
        }
    }
}

