using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Fall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(AliensManager.Instance.waterBallExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);

        if(collision.gameObject.layer == LayerMask.NameToLayer("Earth"))
        {
            StartCoroutine(GraphicsManager.Instance.AddWater());
            Destroy(gameObject);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AliensManager.Instance.CheckForPlayerHits();
            Destroy(gameObject);
        }
    }

    private void Fall()
    {
        if(!AliensManager.Instance.canMove)
        {
            rb.velocity = Vector2.zero;
            return;
        }

        rb.velocity = Vector2.down * speed * Time.fixedDeltaTime;
    }
}
