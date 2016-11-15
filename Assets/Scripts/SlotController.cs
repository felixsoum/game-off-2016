using UnityEngine;

public class SlotController : MonoBehaviour
{
    GearTarget target;

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
                if (target == null)
                {
                    SpawnPart("Wheel");
                }
                else
                {
                    Destroy(target.gameObject);
                    target = null;
                }
            }
        }

    }

    void SpawnPart(string name)
    {
        GameObject gameObject = (GameObject)Instantiate(Resources.Load(name), transform.position, Quaternion.identity, transform);
        if (gameObject)
        {
            target = gameObject.GetComponent<GearTarget>();
        }
    }
}
