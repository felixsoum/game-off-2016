using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float rollSpeed = 100f;
    public GameObject gears;
    public GameObject slots;
    Transform[] gearTransforms = new Transform[8];
    SlotController[] slotControllers = new SlotController[8];

    void Awake()
    {
        for (int i = 0; i < 8; i++)
        {
            gearTransforms[i] = gears.transform.GetChild(i);
            slotControllers[i] = slots.transform.GetChild(i).GetComponent<SlotController>();
        }
    }

    void Update()
    {
        UpdateGears();
    }

    void UpdateGears()
    {
        float rollDirection = Input.GetAxis("Horizontal");
        for (int i = 0; i < 8; i++)
        {
            Transform gear = gearTransforms[i];
            SlotController slotController = slotControllers[i];
            float rotationValue = rollDirection * rollSpeed * Time.deltaTime;
            gear.Rotate(Vector3.forward, rotationValue);
            rollDirection *= -1f;
            slotController.Turn(rollDirection);
        }
    }
}
