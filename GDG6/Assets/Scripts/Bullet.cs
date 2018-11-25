using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.4f;
    private int attackPoints = 1;
    private bool exploding = false;
    private int counter;

    
    public void Initialize(Vector3 initialPosition, bool facingRight)
    {
        if (!facingRight)
        {
            FlipX();
        }

        transform.position = initialPosition;
    }
    
    private void Update()
    {
        counter++;
        if (!exploding)
        {
            MoveX(speed);
            if (counter > 100 )
            {
                Destroy(gameObject);
            }
        }
        
    }

    private void MoveX(float displacement)
    {
        Vector3 v3 = transform.position;
        v3.x += displacement;
        transform.position = v3;
    }

    public void FlipX()
    {
        speed = -speed;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");
        if (other.gameObject.CompareTag("Player"))
        {
            return;
        }
        StartCoroutine(DestroyBullet());
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Hit(attackPoints);
        }
    }


    private IEnumerator DestroyBullet()
    {
        Destroy(GetComponent<BoxCollider2D>());
        exploding = true;
        GetComponent<Animator>().SetTrigger("Explode");
        float animationDuration = 0.3f;
        yield return new WaitForSeconds(animationDuration);
        Destroy(gameObject);
    }

}