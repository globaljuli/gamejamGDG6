using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour {

    public int healthPoints;
    public int attackPoints;
    public float moveSpeed;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<PlayerController>().Hit(this.attackPoints);
        }
    }

    protected void Hit(int damage)
    {
        this.healthPoints -= damage;
        PlayHitAnimation();
    }

    //TODO: Reproduce Hit animation
    internal abstract void PlayHitAnimation();

    protected abstract void Die();
}
