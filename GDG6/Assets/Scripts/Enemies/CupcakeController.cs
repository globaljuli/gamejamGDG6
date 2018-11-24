using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeController : Enemy
{

    public int healthPoints = 1;
    public int attackPoints = 1;
    public float moveSpeed = 5;
    private float step;
    private Transform Player;
    public Animator CupcakeAnimator;
    public LayerMask groundMask;
    public Transform groundCheck;
    public Rigidbody2D rbCupcake;
    public float jumpForce = 2.0f;
    private bool dying = false;
    private Animation dieAnimation;



    // Use this for initialization
    void Start()
    {
        Player = PlayerController.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        // The step size is equal to speed times frame time.

        // Move our position a step closer to the target.
        //transform.position = Vector3.MoveTowards(transform.position, playerPos, step);

        Vector3 direction = Vector3.right;
        if (transform.position.x > Player.position.x)
        {
            direction = -direction;
        }
        MoveAtSpeed(direction * moveSpeed);


        if (Physics2D.Linecast(transform.position, groundCheck.position, groundMask) && !dying)
        {
            CupcakeAnimator.SetTrigger("jump");
            rbCupcake.velocity = new Vector2(0, jumpForce);
        }
    }

    private void MoveAtSpeed(Vector3 speed)
    {
        transform.position += speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().Hit(attackPoints);
            Hit(attackPoints);
        }
    }

    public override void Hit(int damage)
    {
        healthPoints -= damage;

        if(healthPoints <= 0 && !dying)
        {
            dying = true;
            Die();
        }

        PlayHitAnimation();
    }

    //TODO: Reproduce Hit animation
    public void PlayHitAnimation()
    {

    }

    public void Die()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        CupcakeAnimator.SetTrigger("die");
        Destroy(gameObject, 0.3f);

    }

}
