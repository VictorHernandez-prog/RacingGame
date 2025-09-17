using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 offset = new Vector3 (0f, 0f, -10f);
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
