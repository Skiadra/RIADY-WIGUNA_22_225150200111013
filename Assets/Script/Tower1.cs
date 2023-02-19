using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tower1 : MonoBehaviour
{
    public int health;
    public int damage;
    public Color myColor;
    public static int towerID;
    public Transform target;
    public GameObject shootItem;
    public Transform partToRotate;
    public AudioSource audioFile;
    private float interval;
    public float shootDelay;
    public int cost;
    public float range;
    public string enemyTag = "Enemy";

    void Start()
    {   
        InvokeRepeating("UpdateTarget", 0f, .5f);
        interval = shootDelay;
    }

    void Update()
    {
        interval -= Time.deltaTime;
        if (target == null)
            return;
            

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation  = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, 0f, rotation.z);

        if (interval <= 0.02f)
        {
            shotItem();
            interval = shootDelay;
        }
    }

    void shotItem()
    {
        shootItem.transform.GetChild(0).GetComponent<SpriteRenderer>().color = myColor;
        GameObject shotItem = Instantiate(shootItem, partToRotate.position, partToRotate.rotation);
        audioFile.Play();
        Bullet bullet = shotItem.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }

    }
    public void MinusHealth()
    {
        health--;
        if (health <= 0)
        {
            Debug.Log("Tower 1 Destroyed!");
            Destroy(gameObject);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDis = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float disToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (disToEnemy < shortestDis)
            {
                shortestDis = disToEnemy;
                nearestEnemy = enemy;
            }
        }
        GameObject[] bosses = GameObject.FindGameObjectsWithTag("Boss");
        foreach(GameObject boss in bosses)
        {
            float disToEnemy = Vector2.Distance(transform.position, boss.transform.position);
            if (disToEnemy < shortestDis)
            {
                shortestDis = disToEnemy;
                nearestEnemy = boss;
            }
        }

        if (nearestEnemy != null && shortestDis <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }
    void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
