using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterPrefabs;

    public GameObject GetMonster(string type)
    {
        for (int i = 0; i < monsterPrefabs.Length; i++)
        {
            if (monsterPrefabs[i].name == type)
            {
                GameObject newMonster = Instantiate(monsterPrefabs[i], transform);
                newMonster.name = type;
                return newMonster;
            }
        }
        return null;
    }
}
