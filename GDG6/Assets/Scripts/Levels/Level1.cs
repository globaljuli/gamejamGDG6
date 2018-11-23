using System.Collections;
using UnityEngine;

public abstract class Level1 : Level
{
    [SerializeField] private GameObject _goomba;

    private void Initialize()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        Spawn(_goomba, _top);
        yield return new WaitForSeconds(1);
        Spawn(_goomba, _right);
        yield return new WaitForSeconds(1);
        Spawn(_goomba, _left); //flip this guy
        //Spawn<Goomba>(_goomba, _left).Flip();
        yield return new WaitForSeconds(1);
        
    }
}