using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour
{
    public int health;
    public int damage;
    public GameObject shootItem;
    public float interval;
    public int cost;

    void Start()
    {
        StartCoroutine(shootDelay());
    }

    IEnumerator shootDelay()
    {
        yield return new WaitForSeconds(interval);
        shotItem();
        StartCoroutine(shootDelay());
    }

    void shotItem()
    {
        GameObject shotItem = Instantiate(shootItem, transform);
    }
    public void MinusHealth()
    {
        health--;
        if (health <= 0)
        {
            Debug.Log("Tower 2 Destroyed!");
            Destroy(gameObject);
        }
    }
}
