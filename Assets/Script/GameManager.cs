using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public AudioSource BGM;
    void Awake() { instance = this;}
    public Spawner spawner;
    public Health health;
    public Currency currency;

    void Start()
    {
        MonsterSpawn.spawned = 0;
        BossBehaviour.bossKilled = false;
        GetComponent<Health>().Init();
        GetComponent<Currency>().Init();
        BGM.Play();
    }

    void Update()
    {
        if (MonsterSpawn.spawned >= 20)
        {
            BGM.Stop();
        }
    }


}
