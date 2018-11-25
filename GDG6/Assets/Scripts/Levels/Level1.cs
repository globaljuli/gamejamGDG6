using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Level1 : Level
{
    private GameObject cupcake;

    int counter;
    private void Start()
    {
        cupcake = PrefabsManager.instance.Cupcake;
        StartCoroutine(Spawner1());
    }

    private IEnumerator Spawner1()
    {
//        Debug.Log("Hola");
        Spawn(cupcake, _top);
        yield return new WaitForSeconds(3);
        Spawn(cupcake, _right);
        yield return new WaitForSeconds(3);
        Spawn(cupcake, _left);
        yield return new WaitForSeconds(3);
        Spawn(cupcake, _topLeft);
        yield return new WaitForSeconds(3);
        Spawn(cupcake, _topRight);
        yield return new WaitForSeconds(3);
        
        StartCoroutine(Spawner2());
    }
    
    private IEnumerator Spawner2()
    {
        counter++;
        Spawn(cupcake, _top);
        yield return new WaitForSeconds(1);
        Spawn(cupcake, _right);
        yield return new WaitForSeconds(1);
        Spawn(cupcake, _topLeft);
        yield return new WaitForSeconds(1);
        Spawn(cupcake, _topRight);
        yield return new WaitForSeconds(1);
        if (counter < 1)
        {
            StartCoroutine(Spawner2());
        }
        else
        {
            yield return new WaitForSeconds(5);
            StartCoroutine(Spawner3());
        }
    }
    
    private IEnumerator Spawner3()
    {
//        Spawn(cupcake, _top + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        Spawn(cupcake, _top + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        Spawn(cupcake, _top + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        Spawn(cupcake, _top + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        Spawn(cupcake, _right + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        Spawn(cupcake, _left + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        Spawn(cupcake, _left + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        Spawn(cupcake, _topLeft + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        Spawn(cupcake, _topRight + new Vector2(Random.Range(-1f,1f),Random.Range(-1f,1f)));
//        
//        yield return new WaitForSeconds(11f);
        Instantiate(PrefabsManager.instance.MasksBoss);
        yield return null;
    }
}