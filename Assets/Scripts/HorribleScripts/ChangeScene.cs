using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool destroyAudio = false;

    private void OnEnable()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(index);

        if(destroyAudio)
        {
            AudioManager.Instance.DestroyAudio();
        }
    }
}
