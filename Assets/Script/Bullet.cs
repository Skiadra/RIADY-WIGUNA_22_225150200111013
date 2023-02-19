using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Bullet : MonoBehaviour
{
    public Transform graphics;
    private Transform target;
    public int damage;
    public AudioSource hitSound;
    Vector2 dir;
    public LayerMask enemyLayer;
    public float flySpeed;
    public float rotateSpeed;

    public void Seek(Transform _target)
    {
        target = _target;
        dir = target.position - transform.position;
    }

    public void Init(int dmg)
    {
        damage = dmg;
    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.tag == "Out")
        {
            Destroy(gameObject);
        }
        if (collide.tag == "Enemy")
        {
            collide.GetComponent<MonsterBehaviour>().LoseHealth(damage);
        }
        if (collide.tag == "Boss")
        {
            collide.GetComponent<BossBehaviour>().BossHealth(damage);
        }
    }

    void Update()
    {
        Rotate();
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float distanceFrame = flySpeed*Time.deltaTime;


        transform.Translate(dir.normalized * distanceFrame, Space.World);
    }

    void Rotate()
    {
        graphics.Rotate(new Vector3( 0, 0, rotateSpeed*Time.deltaTime));
    }

}
