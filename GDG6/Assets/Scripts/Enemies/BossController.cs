using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossController : MonoBehaviour {

    public GameObject Cupcake;
    public GameObject Mask;
    public GameObject[] EnemiesAray;
    public GameObject Bullet;

    public float timer = 0;
    public Vector3 initialPosition = new Vector3(7.75f, -1.24f, -3f);

    public int bossHealth = 300;
    public int attackPoints = 1;
    public float moveSpeed = 1;

    public Boolean firstWave = false;
    public Boolean secondWave = false;
    public Boolean thirdWave = false;
    public Boolean fourthWave = false;
    public Boolean fifthWave = false;
    public Boolean sixthWave = false;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

        Debug.Log(bossHealth);
        timer += Time.deltaTime;
        if(timer >= 5 && !firstWave)
        {
            FirstWave();
            firstWave = true;
        }
        else if (timer >= 10 && !secondWave)
        {
            SecondWave();
            secondWave = true;
        }
        else if (timer >= 15 && !thirdWave)
        {
            ThirdWave();
            thirdWave = true;
        }
        else if (timer >= 30 && !fourthWave)
        {
            FourthWave();
            fourthWave = true;
        }
        else if (timer >= 40 && !fifthWave)
        {
            FifthWave();
            fifthWave = true;
        }
        else if (timer >= 50 && !sixthWave)
        {
            SixthtWave();
            sixthWave = true;
        }
    }

    private void FirstWave()
    {
        ShootBullet();

        //for (int i = 0; i < 3; i++)
        //{
        //    Instantiate(EnemiesAray[0]);
        //}
    }

    private void SecondWave()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[0]);
        }

        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[1]);
        }
    }

    private void ThirdWave()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[0]);
        }
        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[1]);
        }
        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[2]);
        }
    }

    private void FourthWave()
    {
        for (int i = 0; i < 14; i++)
        {
            Instantiate(EnemiesAray[0]);
        }
    }

    private void FifthWave()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(EnemiesAray[1]);
        }
        for (int i = 0; i < 5; i++)
        {
            Instantiate(EnemiesAray[2]);
        }
    }

    private void SixthtWave()
    {
        for (int i = 0; i < 5; i++)
        {
            //Instantiate 0 which is Cupcake
            Instantiate(EnemiesAray[0]);
        }
    }

    private void ShootBullet()
    {

        GameObject bullet = Instantiate(Bullet);
        float xDisplacement = -0.8f;


        Vector2 bulletPosition = transform.position + new Vector3(xDisplacement, 0, 0);
        bullet.GetComponent<Bullet>().Initialize(bulletPosition, false);
    }








}
