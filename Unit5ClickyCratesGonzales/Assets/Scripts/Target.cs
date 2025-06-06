using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public ParticleSystem explosionPartical;
    public int pointValue;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    private GameManager gamemanager;
    private Rigidbody targetRb;
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gamemanager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() 
    {
        if (gamemanager.isGameActive) 
        {
            Destroy(gameObject);
            Instantiate(explosionPartical, transform.position, explosionPartical.transform.rotation);
            gamemanager.UpdateScore(pointValue);


        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy (gameObject);
        if (gameObject.CompareTag("Bad")) 
        {
            gamemanager.GameOver();

        }
       
    }

    Vector3 RandomForce() 
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque() 
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos() 
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
