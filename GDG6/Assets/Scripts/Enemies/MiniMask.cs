using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public abstract class MiniMask : Enemy
    {
        private static int healthPoints = 1;
        private int attackPoints = 1;
        protected bool dead = false;
        protected Animator movementAnimator;
        private static int masksAlive = 0;

        protected void Start()
        {
            masksAlive++;
            Debug.Log("Masks alive: "+masksAlive);
            movementAnimator = transform.parent.GetComponent<Animator>();
        }

        protected abstract void ThrowDice();
        
        protected IEnumerator WaitSeconds(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            if (!dead)
            {
                ThrowDice();
            }
        }

        public override void Hit(int damage)
        {
            Debug.Log("MaskHit");
            healthPoints -= damage;
            if (healthPoints <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            if (dead) return;
            masksAlive--;
            dead = true;
            if (movementAnimator != null) {movementAnimator.enabled = false;}
            StartCoroutine(DeathCoroutine());
            Destroy(gameObject, 2.5f);
        }

        private IEnumerator DeathCoroutine()
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<Animator>().enabled = false;
            float t = 0;
            while (t < 1f)
            {
                t += Time.deltaTime;
                GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, t);
                yield return null;
            }
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            if (masksAlive == 0)
            {
                Debug.Log("Load Level 2 omg!");
                //load level 2
            }
        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player") && !dead)
            {
                other.gameObject.GetComponent<PlayerController>().Hit(attackPoints);
            }
        }
    }
}