using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1000f;

    Rigidbody myRigidbody;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
    }

	void Update()
    {
        UpdateMovement();
        UpdateCamera();
    }

    void UpdateMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDirection += Vector3.left;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection += Vector3.right;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDirection += Vector3.forward;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDirection += Vector3.back;
        }

        myRigidbody.AddForce(moveDirection.normalized * moveSpeed * Time.deltaTime);
    }

    void UpdateCamera()
    {
        Vector3 newCameraPos = transform.position;
        newCameraPos.y = 10f;
        Camera.main.transform.position = newCameraPos;
    }
}
