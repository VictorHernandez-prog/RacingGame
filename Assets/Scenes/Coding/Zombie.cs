using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Timer timer;
    public float timeBonus = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = FindFirstObjectByType<Timer>(); // finds the one on your Canvas
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Coliision)
    {
        if (Coliision.CompareTag("Car"))
        {
            timer.AddTime(timeBonus);
            Destroy(gameObject);
        }
    }
    }
