using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCannon : MonoBehaviour
{

    public float shootSpeed;
    public GameObject bullet;
    public Transform barrelEnd;
    public int maxBullets;

    private List<GameObject> bullets = new List<GameObject>();
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Shoot());
    }

    private void FixedUpdate()
    {
        Vector3 pPos = player.position;
        float angle = Mathf.Atan2(transform.position.x - pPos.x, transform.position.z - pPos.z) * 180 / Mathf.PI;
        print(angle);
        transform.rotation = Quaternion.Euler(0, angle + 90, 0);
    }

    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootSpeed);
        for(int i = 0; i < bullets.Count; i++)
        {
            if(bullets[i] == null)
            {
                bullets.Remove(bullets[i]);
            }
        }
        if (bullets.Count < maxBullets)
        {
            GameObject b = Instantiate(bullet, barrelEnd.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 90));
            b.GetComponent<Bullet>().enemy = true;
            bullets.Add(b);
        }
        StartCoroutine(Shoot());
    }
}
