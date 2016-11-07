using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float rollSpeed = 1000f;
    public GameObject gears;
    List<Rigidbody2D> gearRigidbodies;

    void Awake()
    {
        gearRigidbodies = new List<Rigidbody2D>();

        foreach (Transform child in gears.transform)
        {
            gearRigidbodies.Add(child.gameObject.GetComponent<Rigidbody2D>());
        }
    }

    void Update()
    {
        AxisMovement();
        UpdateCamera();
    }
    void AxisMovement()
    {
        float input = Input.GetAxis("Horizontal");
        for (int i = 0; i < gearRigidbodies.Count; i++)
        {
            int dir = i % 2;
            if (dir == 0)
                dir = -1;
            gearRigidbodies[i].angularVelocity = input * dir * rollSpeed;
        }
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

        float minGearVelocity = float.MaxValue;
        foreach (Rigidbody2D gear in gearRigidbodies)
        {
            minGearVelocity = Mathf.Min(Mathf.Abs(gear.angularVelocity), minGearVelocity);
        }

        float gearDirection = 1f;
        foreach (Rigidbody2D gear in gearRigidbodies)
        {
            gear.angularVelocity = Mathf.Sign(gear.angularVelocity) * minGearVelocity;
            gear.AddTorque(gearDirection * rollDirection * rollSpeed * Time.deltaTime);
            gearDirection *= -1f;
        }
    }

    void UpdateCamera()
    {
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = transform.position.x;
        Camera.main.transform.position = newCameraPos;
    }
}
