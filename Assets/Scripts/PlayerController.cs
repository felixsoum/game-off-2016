using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public float rollSpeed = 100f;
    public GameObject gears;
    public GameObject slots;
    List<Transform> gearTransforms = new List<Transform>();
    List<GearTarget> gearTargets = new List<GearTarget>();

    void Awake()
    {
        foreach (Transform child in gears.transform)
        {
            gearTransforms.Add(child);
        }
        foreach (Transform child in slots.transform)
        {
            GearTarget gearTarget = child.GetComponentInChildren<GearTarget>();
            if (gearTarget)
            {
                gearTargets.Add(gearTarget);
            }
        }
    }

    void Update()
    {
        UpdateGears();
        UpdateCamera();
    }

    void UpdateGears()
    {
        float rollDirection = Input.GetAxis("Horizontal");
        foreach (Transform gear in gearTransforms)
        {
            gear.Rotate(Vector3.forward, rollDirection * rollSpeed * Time.deltaTime);
            rollDirection *= -1f;
        }
        foreach (GearTarget target in gearTargets)
        {
            target.Turn(rollDirection);
        }
    }

    void UpdateCamera()
    {
        Vector3 newCameraPos = Camera.main.transform.position;
        newCameraPos.x = transform.position.x;
        Camera.main.transform.position = newCameraPos;
    }
}
