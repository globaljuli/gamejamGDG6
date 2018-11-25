using System.Collections;
using UnityEngine;

namespace DefaultNamespace.Enemies
{
    public class YellowMask : Mask
    {
        private void Awake()
        {
            StartCoroutine(WaitSeconds(3f));
        }
        
        protected override void ThrowDice()
        {
            int dice = Random.Range(0, 5);
            if (dice == 0 || dice>3 )
            {
                StartCoroutine(WaitSeconds(1f));
            }
            else
            {
                movementAnimator.SetTrigger("Pattern"+dice.ToString());
                Debug.Log("Doing patter "+dice);
                StartCoroutine(WaitSeconds(6f));
            }
        }
    }
}