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
    private int healthPoints = 8;
    private SfxManager sfx;
    Coroutine disableShoot;
    public GameObject hurt;
    
    private SpriteRenderer spriteRenderer;
    //private Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;   
            spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (move.x > 0.1 || move.x < -0.1) {
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

        if (velocity.y < 0)
        {
            PlayerAnimator.SetBool("jumpDown", true);
        } else {
            PlayerAnimator.SetBool("jumpDown", false);
        }

        spriteRenderer.flipX = facingRight;
        //animator.SetBool("grounded", grounded);
        //animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

        targetVelocity = move * maxSpeed;
    }

    /*ATTACKS*/

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Mirror"))
        {
            Instantiate(PrefabsManager.instance.WhiteFadeOutCanvas);
            Destroy(this);
        }
    }
    
    public void Hit(int damage)
    {
        PlayerHealthBar.instance.RemovePetalo();
        healthPoints -= damage;
//        Debug.Log("Enemy attacked with" + damage + " left " + healthPoints);
        PlayHitAnimation();
        if (healthPoints == 0)
        {
            Die();
        }
        hurt.SetActive(true);
        hurt.GetComponent<SpriteRenderer>().flipX = facingRight;
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(DisableHurtAnimation());
    }

    private IEnumerator DisableHurtAnimation()
    {
        yield return new WaitForSeconds(0.25f);
        hurt.SetActive(false);
        GetComponent<SpriteRenderer>().enabled = true;
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

        PlayerAnimator.SetBool("shoot", true);
        if(disableShoot!= null)
        {
            StopCoroutine(disableShoot);
        }
        disableShoot = StartCoroutine(DisableShootAnimation());
    }

    private IEnumerator DisableShootAnimation( )
    {
        yield return new WaitForSeconds(0.3f);
        PlayerAnimator.SetBool("shoot", false);
    }

    public static PlayerController Instance;
    
    
}