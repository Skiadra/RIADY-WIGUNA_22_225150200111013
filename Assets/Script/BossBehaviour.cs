using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public float walkDelay = 1f;
    public float speed;
    public static int killed = 0;
    public static int health;
    public int bossHealth;
    public static bool bossKilled;
    private Transform target;
    public GameObject impactEffect;
    private int wavepointIndex = 0;
    float timer;



    // Start is called before the first frame update
    void Start()
    {
        health = bossHealth;
        timer = walkDelay;
        target = Waypoints.points[wavepointIndex];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime, Space.World);

        if (Vector2.Distance(transform.position, target.position) <= 0.02)
        {
            if (timer <= 0.02)
            {
                timer = walkDelay;
                GetNextWaypoint();
            } else
            {
                timer -= Time.deltaTime;
                return;
            }
        }
        // timer -= Time.deltaTime;
        // if (timer <= 0)
        // {
        //     transform.position = new Vector2(transform.position.x + speed*dir.x, transform.position.y + speed*dir.y);
        //     timer = walkDelay;
        // }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }



    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.tag == "Bullet")
        {
            GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, 1f);
            Destroy(collide.GameObject());

        }

        if(collide.tag == "Guard")
        {
            Health.healthCount-= 4;
            if(Health.healthCount>0)
            {
                bossKilled = true;
            }
            Destroy(gameObject);
        }

    }

    public void BossHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            bossKilled = true;
            Debug.Log(killed);
            Destroy(gameObject);
        }
    }
}
