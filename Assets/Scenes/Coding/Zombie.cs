using UnityEngine;

public class Zombie : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D Collosion)
    {
        if (Collosion.CompareTag("Car"))
        {

            Destroy(gameObject);

        }
    }
    }
