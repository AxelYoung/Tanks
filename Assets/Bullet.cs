using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int maxRicochet;
    public GameObject ps;
    public bool enemy;

    private int totalRicochet;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = -transform.up * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (totalRicochet == maxRicochet)
            {
                DestroyBullet();
            }
            Vector3 v = Vector3.Reflect(transform.up, collision.contacts[0].normal);
            float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(90, rot, 0);
            totalRicochet += 0;
        }
        if(collision.gameObject.tag == "Player" && enemy)
        {
            collision.gameObject.GetComponent<PlayerController>().Death();
            DestroyBullet();
        }
        if (collision.gameObject.tag == "Enemy" && !enemy)
        {
            collision.gameObject.GetComponent<Enemy>().Death();
            DestroyBullet();
        }
        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
        {
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
        Instantiate(ps, gameObject.transform.position, ps.transform.rotation);
    }
}
