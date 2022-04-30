using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    public float speed;

    private void OnEnable()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Fall();
    }

    private void Fall()
    {
        if(!AliensManager.Instance.canMove)
        {
            rigidbody.velocity = Vector2.zero;
            return;
        }

        rigidbody.velocity = Vector2.down * speed * Time.fixedDeltaTime;
    }
}
