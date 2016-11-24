using UnityEngine;

public class SlotController : MonoBehaviour
{
    GearTarget target;
    string currentPartName;

    public void Turn(float direction)
    {
        if (target)
        {
            target.Turn(direction);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(clickPos, transform.position) < 0.5f)
            {
                switch (currentPartName)
                {
                    default:
                        SpawnPart("Wheel");
                        break;
                    case "Wheel":
                        SpawnPart("Spring");
                        break;
                    case "Spring":
                        SpawnPart("");
                        break;
                }
            }
        }

    }

    void SpawnPart(string name)
    {
        currentPartName = name;
        if (target != null)
        {
            Destroy(target.gameObject);
        }
        if (name != "")
        {
            GameObject gameObject = (GameObject)Instantiate(Resources.Load(name), transform.position, Quaternion.identity, transform);
            if (gameObject)
            {
                target = gameObject.GetComponent<GearTarget>();
            }
        }
    }
}
