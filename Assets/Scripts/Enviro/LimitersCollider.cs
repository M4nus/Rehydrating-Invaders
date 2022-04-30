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
                    AliensManager.Instance.canMove = false;
                    break;
            }
        }
    }
}
