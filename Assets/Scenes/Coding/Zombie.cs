using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Timer timer;
    private float BonusTime = 1f;
    float minDistance;
    float maxDistance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       timer = FindAnyObjectByType<Timer>();
        minDistance = Random.Range(-10f, 24f);
        maxDistance = Random.Range(25f, 40f);
    }

    // Update is called once per frame
    void ChangingAxis()
    {
        float x = Random.Range(minDistance, maxDistance);
        float y = Random.Range(minDistance, maxDistance);
        transform.position = new Vector3(x, y, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Car"))
        {

            timer.AddTime(BonusTime);
            ChangingAxis();

        }

    }
}
