using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningSon : MonoBehaviour
{
    public int bossCount;
    public GameObject bossUI;
    public GameObject winUI;
    public bool updated = false;

    void Start()
    {
        InvokeRepeating("CheckStat", 0f, .1f);
    }
    void CheckStat()
    {
        if (MonsterSpawn.spawned == bossCount)
        {
            bossUI.SetActive(true);
        }

        if (BossBehaviour.bossKilled)
        {
            bossUI.SetActive(false);
            winUI.SetActive(true);
        } else
        {
            winUI.SetActive(false);
        }

    }
}
