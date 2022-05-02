using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(CameraShake.Instance.Shake(0.3f, 0.01f));
    }
}
