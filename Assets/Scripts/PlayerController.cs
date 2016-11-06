using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float rollSpeed = 1000f;

    Rigidbody2D myRigidbody;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

	void Update()
    {
        UpdateMovement();
        UpdateCamera();
    }

    void UpdateMovement()
    {
        float rollDirection = 0;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rollDirection = 1f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rollDirection = -1f;
        }

        myRigidbody.AddTorque(rollDirection * rollSpeed * Time.deltaTime);
    }

    void UpdateCamera()
    {
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = transform.position.x;
        Camera.main.transform.position = newCameraPos;
    }
}
