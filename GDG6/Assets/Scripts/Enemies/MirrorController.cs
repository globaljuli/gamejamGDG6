using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : Enemy {

    private Vector3 position;
    private SfxManager sfx;
    public GameObject Bullet;


    public override void Hit(int damage)
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Rebound(Vector3 position)
    {
        //sfx.Play(sfx.shoot);
        GameObject bullet = Instantiate(Bullet);
        float xDisplacement = 1f;
        float yDisplacement = position.y;
        
        Vector2 bulletPosition = new Vector3(xDisplacement, position.y);
        Debug.Log("B: " + position);
        Debug.Log("Bullet back:" + bulletPosition);
        bullet.GetComponent<Bullet>().Initialize(bulletPosition, false);
    }

}
