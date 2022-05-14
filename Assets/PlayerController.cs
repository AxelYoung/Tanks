using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;

    public GameObject deathParticle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void Death()
    {
        Destroy(gameObject);
        Instantiate(deathParticle, gameObject.transform.position, deathParticle.transform.rotation);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
