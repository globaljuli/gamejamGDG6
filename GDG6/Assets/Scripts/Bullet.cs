﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.4f;
    private int counter = 0;
    private int attackPoints = 1;
    private bool exploding = false;

    private void Update()
    {
        counter++;
        if (counter > 200)
        {
            transform.position = new Vector3(-6, 0);
            counter = 0;
            exploding = false;
        }
        
        if (!exploding)
        {
            MoveX(speed);
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
        
        StartCoroutine(DestroyBullet());
        if (other.gameObject.CompareTag("Enemy"))
        {
            //HIT ENEMY
        }
    }

    private IEnumerator DestroyBullet()
    {
        //Destroy(GetComponent<BoxCollider2D>());
        exploding = true;
        //GetComponent<Animator>().SetTrigger("Explode");
        float animationDuration = 1f;
        yield return new WaitForSeconds(animationDuration);
        //Destroy(gameObject);
    }
}