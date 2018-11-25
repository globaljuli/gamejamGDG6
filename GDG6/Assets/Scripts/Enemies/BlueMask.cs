using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public class BlueMask : Mask
    {
        public float moveSpeed = 1f;

        private void Awake()
        {
            StartCoroutine(WaitSeconds(5f));
        }

        protected override void ThrowDice()
        {
            int dice = Random.Range(0, 10);
            if (dice <3 )
            {
                StartCoroutine(WaitSeconds(1f));
            }
            else
            {
                if (dice == 9)
                {
                    SfxManager.Instance.Play(SfxManager.Instance.evilLaugh);
                }
                StartCoroutine(MoveTowardsPlayer());
                StartCoroutine(WaitSeconds(3f));
            }
        }

        private IEnumerator MoveTowardsPlayer()
        {
            yield return new WaitForEndOfFrame();
            float t = 0;
            Vector2 initialPos = transform.position;
            Vector2 distance = (PlayerController.Instance.transform.position - transform.position);
            Vector2 finalPos = (distance/distance.magnitude) * moveSpeed;
            while (t < 2f)
            {
                t += Time.deltaTime;
                if(dead) {continue;}
                transform.position = Vector2.Lerp(initialPos, finalPos, t / 2f);
                yield return null;
            }
        }
    }
}