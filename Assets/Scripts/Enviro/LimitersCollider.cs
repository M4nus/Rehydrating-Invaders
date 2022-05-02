using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum LimiterType
{
    LeftWall,
    RightWall,
    EndLine
}

public class LimitersCollider : MonoBehaviour
{
    public LimiterType limiterType;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Alien"))
        {
            switch(limiterType)
            {
                case LimiterType.LeftWall:
                    AliensManager.Instance.ToggleDirection();
                    break;

                case LimiterType.RightWall:
                    AliensManager.Instance.ToggleDirection();
                    break;

                case LimiterType.EndLine:
                    collision.transform.GetChild(1).gameObject.SetActive(true);
                    StartCoroutine(AliensManager.Instance.TeleportAlien(collision.transform));
                    AliensManager.Instance.UpdateAliens();
                    Destroy(collision.gameObject, 2f);
                    break;
            }
        }
    }
}
