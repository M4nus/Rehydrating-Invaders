using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonPersistant<AudioManager>
{
    public void DestroyAudio()
    {
        Destroy(gameObject);
    }
}
