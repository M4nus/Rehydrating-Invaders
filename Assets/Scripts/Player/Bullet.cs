using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 10f);
    }

    void FixedUpdate()
    {
        Fly();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject explosion = Instantiate(AliensManager.Instance.bulletExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 2f);

        if(collision.gameObject.layer == LayerMask.NameToLayer("Alien"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            AliensManager.Instance.UpdateAliens();
        }
    }

    private void Fly()
    {
        rb.velocity = Vector2.up * speed * Time.fixedDeltaTime;
    }
}
