using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    public MonsterPool Pool {get; set;}
    WinningSon boss;
    public static int spawned = 0;
    public AudioSource audioBoss;
    public float minTimer;
    public float maxTimer;
    public bool summonBoss;
    float timer;
    public void Start()
    {
        Pool = GetComponent<MonsterPool>();
        timer = minTimer;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0 && spawned < 20)
        {
            timer = UnityEngine.Random.Range(minTimer, maxTimer+1);
            int monsterIndex = UnityEngine.Random.Range(0,2);
            string type = String.Empty;

            switch (monsterIndex)
            {
                case 0:
                    type = "red"; break;
                case 1:
                    type = "white"; break;
            }
            spawned++;
            Pool.GetMonster(type);
        }
        if (summonBoss == false && spawned == 20)
        {
            audioBoss.Play();
            Pool.GetMonster("boss");
            summonBoss = true;
        }
    }
}
