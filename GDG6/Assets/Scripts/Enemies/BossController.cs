using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossController : Enemy {

    public GameObject Cupcake;
    public GameObject Mask;
    public GameObject[] EnemiesAray;
    public GameObject Bullet;

    public float waveTimer = 0;
    public Vector3 initialPosition = new Vector3(7.75f, -1.24f, -3f);

    public int healthPoints = 50;
    public int attackPoints = 1;
    public float moveSpeed = 1;

    public Boolean firstWave = false;
    public Boolean secondWave = false;
    public Boolean thirdWave = false;
    public Boolean fourthWave = false;
    public Boolean fifthWave = false;
    public Boolean sixthWave = false;
    public Boolean seventhhWave = false;
    public Boolean eigthWave = false;
    public Boolean ninthWave = false;
    public Boolean tenthWave = false;

	// Use this for initialization
	void Start () {
        BossHealthBar.instance.Init(healthPoints);
    }

    // Update is called once per frame
    void Update () {
        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, step);

        Debug.Log(healthPoints);
        waveTimer += Time.deltaTime;
        if(waveTimer >= 1 && !firstWave)
        {
            FirstWave();
            firstWave = true;
        }
        else if (waveTimer >= 3 && !secondWave)
        {
            SecondWave();
            secondWave = true;
        }
        else if (waveTimer >= 8 && !thirdWave)
        {
            ThirdWave();
            thirdWave = true;
        }
        else if (waveTimer >= 15 && !fourthWave)
        {
            FourthWave();
            fourthWave = true;
        }
        else if (waveTimer >= 20 && !fifthWave)
        {
            FifthWave();
            fifthWave = true;
        }
        else if (waveTimer >= 30 && !sixthWave)
        {
            SixthWave();
            fifthWave = true;
        }
        else if (waveTimer >= 30 && !seventhhWave)
        {
            SeventhWave();
            fifthWave = true;
        }
        else if (waveTimer >= 30 && !eigthWave)
        {
            EigthWave();
            fifthWave = true;
        }
        else if (waveTimer >= 30 && !ninthWave)
        {
            NinthWave();
            fifthWave = true;
        }
    }

    private void FirstWave()
    {

        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[0]);
        }
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
        Instantiate(EnemiesAray[3]);
    }

    private void ThirdWave()
    {
        for (int i = 0; i < 3; i++)
        {
            ShootBullet();
        }

    }

    private void FourthWave()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[2]);
        }

    }

    private void FifthWave()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[1]);
        }
        Instantiate(EnemiesAray[4]);
        Instantiate(EnemiesAray[4]);
    }

    private void SixthWave()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(EnemiesAray[2]);
        }
        Instantiate(EnemiesAray[3]);
        Instantiate(EnemiesAray[4]);
    }

    private void SeventhWave()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(EnemiesAray[0]);
        }
        Instantiate(EnemiesAray[3]);
        Instantiate(EnemiesAray[4]);
    }

    private void EigthWave()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(EnemiesAray[1]);
        }
        Instantiate(EnemiesAray[3]);
        Instantiate(EnemiesAray[4]);
    }

    private void NinthWave()
    {
        for (int i = 0; i < 2; i++)
        {
            Instantiate(EnemiesAray[1]);
        }
        Instantiate(EnemiesAray[3]);
        Instantiate(EnemiesAray[4]);
    }

    private void ShootBullet()
    {

        GameObject bullet = Instantiate(Bullet);
        float xDisplacement = -0.8f;


        Vector2 bulletPosition = transform.position + new Vector3(xDisplacement, 0, 0);
        bullet.GetComponent<Bullet>().Initialize(bulletPosition, false);
    }

    public override void Hit(int damage)
    {
        healthPoints -= damage;
        BossHealthBar.instance.UpdateHealth(healthPoints);
    }
}
