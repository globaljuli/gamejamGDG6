using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeController : MonoBehaviour
{

    public int healthPoints = 1;
    public int attackPoints = 1;
    public float moveSpeed = 10;
    private float step;
    public Transform Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // The step size is equal to speed times frame time.
        float step = moveSpeed * Time.deltaTime;

        // Move our position a step closer to the target.
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().Hit(attackPoints);
        }
    }

    public void Hit(int damage)
    {
        healthPoints -= damage;
        PlayHitAnimation();
    }

    //TODO: Reproduce Hit animation
    public void PlayHitAnimation()
    {

    }

    public void Die()
    {

    }
}
