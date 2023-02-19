using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    float walkDelay = 1f;
    public float speed;
    public static int killed;
    public AudioSource audioHit;
    public int health;
    private Transform target;
    public GameObject impactEffect;
    private int wavepointIndex = 0;
    float timer;



    // Start is called before the first frame update
    void Start()
    {
        killed = 0;
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
            audioHit.Play();
            GameObject effect = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effect, 1f);
            Destroy(collide.GameObject());
        }

        if(collide.tag == "Guard")
        {
            Health.healthCount--;
            Destroy(gameObject);
        }

    }

    public void LoseHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            killed++;
            Currency.currencyCount++;
            Debug.Log(killed);
            Destroy(gameObject);
        }
    }
}
