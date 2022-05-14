using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrelEnd;
    public int maxBullets;

    private List<GameObject> bullets = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, -Vector3.up);

        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i] == null)
                {
                    bullets.Remove(bullets[i]);
                }
            }
            if(bullets.Count < maxBullets)
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        GameObject b = Instantiate(bullet, barrelEnd.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90));
        b.GetComponent<Bullet>().enemy = false;
        bullets.Add(b);
    }
}
