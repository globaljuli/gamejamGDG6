using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int healthPoints;
    public int attackPoints;
    public float moveSpeed;
    public GameObject Player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<PlayerController>().Hit(this.attackPoints);
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
