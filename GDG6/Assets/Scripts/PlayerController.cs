using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    public GameObject Bullet;
    public float maxSpeed;
    public float jumpTakeOffSpeed;
    public Animator PlayerAnimator;
    private bool facingRight;
    public int healthPoints;
    private SfxManager sfx;
    
    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;   
            spriteRenderer = GetComponent<SpriteRenderer>();
            //animator = GetComponent<Animator>();
            healthPoints = 4;
        }
        else
        {
            Destroy(this);
        }
    }

    protected override void Start()
    {
        sfx = SfxManager.Instance;
        base.Start();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        if (move.x != 0) {
            PlayerAnimator.SetBool("run", true);
        } else
        {
            PlayerAnimator.SetBool("run", false);
        }

        if (move.x > 0.1f)
        {
            facingRight = true;
        }
        else if(move.x < -0.1f)
        {
            facingRight = false;
        }
        
        
        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            PlayerAnimator.SetTrigger("jump");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        spriteRenderer.flipX = facingRight;
        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    /*ATTACKS*/

    public void Hit(int damage)
    {
        healthPoints -= damage;
//        Debug.Log("Enemy attacked with" + damage + " left " + healthPoints);
        PlayHitAnimation();
        if (healthPoints == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Game.instance.GameOver();
    }

    protected void PlayHitAnimation()
    {

    }

    private void ShootBullet()
    {
        sfx.Play(sfx.shoot);
        GameObject bullet = Instantiate(Bullet);
        float xDisplacement = 0.8f;
        if (!facingRight)
        {
            xDisplacement *= -1f;
        }

        Vector2 bulletPosition = transform.position + new Vector3(xDisplacement, 0, 0);
        bullet.GetComponent<Bullet>().Initialize(bulletPosition, facingRight);
    }
    
    public static PlayerController Instance;
    
    
}