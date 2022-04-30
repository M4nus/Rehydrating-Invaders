using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(!AliensManager.Instance.canMove)
        {
            rigidbody.velocity = Vector2.zero;
            return;
        }

        rigidbody.velocity = new Vector2(AliensManager.Instance.multiplier * AliensManager.Instance.speed * Time.fixedDeltaTime, -AliensManager.Instance.fallingSpeed * Time.fixedDeltaTime);
    }

    public void Shoot()
    {
        Debug.Log("shoot");
        Instantiate(AliensManager.Instance.waterBallPrefab, transform.position, Quaternion.identity);
    }
}
