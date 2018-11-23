using System.Collections;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    private const float TOP = 6f;
    private const float SIDE = 8f;

    protected Vector2 _top = new Vector2(0, TOP);
    protected Vector2 _left = new Vector2(-SIDE, 0);
    protected Vector2 _right = new Vector2(SIDE, 0);
    protected Vector2 _topLeft = new Vector2(-SIDE, TOP);
    protected Vector2 _topRight = new Vector2(SIDE, TOP);
    
    protected GameObject Spawn(GameObject enemy, Vector2 position)
    {
        return Instantiate(enemy, position, Quaternion.identity);
    }
    
    protected T Spawn<T>(GameObject enemy, Vector2 position)
    {
        return Instantiate(enemy, position, Quaternion.identity).GetComponent<T>();
    }
}