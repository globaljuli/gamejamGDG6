using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    public GameObject Bullet;
    public Transform show;
    public float maxSpeed;
    public float jumpTakeOffSpeed;

    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //animator = GetComponent<Animator>();
    }

    protected override void ComputeVelocity()
    {
       
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, show.position + new Vector3(0.8f,0,0), show.rotation);
        }

        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    /*ATTACKS*/

    public void Hit(int damage)
    {
        healthPoints -= damage;
        Debug.Log("Enemy attacked with" + damage + " left" + healthPoints);
        PlayHitAnimation();
    }

    protected void PlayHitAnimation()
    {

    }

    private void ShootBullet()
    {
        GameObject bullet = Instantiate(Bullet);
        float xDisplacement = 0.8f;
        if (!facingRight)
        {
            xDisplacement *= -1f;
        }

        Vector2 bulletPosition = transform.position + new Vector3(xDisplacement, 0, 0);
        bullet.GetComponent<Bullet>().Initialize(bulletPosition, facingRight);
    }
}