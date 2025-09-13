using UnityEngine;

public class CatInput : MonoBehaviour
{
    CarMovement CarMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        CarMovement = GetComponent<CarMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            inputVector.x = 1;
        }
        if (Input.GetKey(KeyCode.D))
        { 
            inputVector.x -= 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y -= 1;
        }
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y = 1;

        }
        inputVector = inputVector.normalized;

        CarMovement.SetInputVector(inputVector);

    }
}

