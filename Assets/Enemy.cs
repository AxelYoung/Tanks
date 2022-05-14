using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public GameObject deathParticle;

    private Rigidbody rb;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z);

        //print(distance);

        float h = distance.x / distance.z;
        float v = distance.z / distance.x;

        //print(h + "," + v);
        if (rb.velocity != Vector3.zero)
        {
            //transform.forward = rb.velocity;
        }

        Vector3 inputVector = new Vector3(h, 0, v);

        inputVector.Normalize();
        rb.AddForce(inputVector * speed);

        //print(inputVector);
    }

    public void Death()
    {
        Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation);
        Destroy(gameObject);
    }
}
