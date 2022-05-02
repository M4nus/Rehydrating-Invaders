using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(!AliensManager.Instance.canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        rb.velocity = new Vector2(AliensManager.Instance.multiplier * AliensManager.Instance.speed * Time.fixedDeltaTime, -AliensManager.Instance.fallingSpeed * Time.fixedDeltaTime);
    }

    public void Shoot()
    {
        Instantiate(AliensManager.Instance.waterBallPrefab, transform.position, Quaternion.identity);
    }
}
