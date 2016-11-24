using UnityEngine;

public class SpringPart : GearTarget
{
    public float pushForce = 100f;
    public float lengthMax = 2f;
    public float retractSpeed = 2f;
    public float expandSpeed = 20f;

    public GameObject springEnd;

    FixedJoint2D joint;
    Rigidbody2D myBody;
    bool isExpanding;

    void Awake()
    {
        joint = GetComponent<FixedJoint2D>();
        myBody = GetComponent<Rigidbody2D>();
        transform.rotation = transform.parent.rotation;
        Attach(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>());
    }

    public void Attach(Rigidbody2D mainBody)
    {
        joint.connectedBody = mainBody;
        Vector2 relativeToMainPosition = transform.position - joint.connectedBody.transform.position;
        joint.connectedAnchor = Quaternion.Euler(0, 0, -mainBody.transform.eulerAngles.z) * relativeToMainPosition;
    }

    public override void Turn(float direction)
    {
        base.Turn(direction);
        Vector3 endLocalPos = springEnd.transform.localPosition;
        if (direction > 0)
        {
            if (endLocalPos.x == 0 && !isExpanding)
            {
                isExpanding = true;
            }

        }
        else if (direction < 0)
        {
            if (endLocalPos.x < 0 && !isExpanding)
            {
                endLocalPos.x = Mathf.Min(endLocalPos.x + -direction * retractSpeed * Time.deltaTime, 0);
                springEnd.transform.localPosition = endLocalPos;
            }
        }
    }

    void Update()
    {
        Vector3 pos = springEnd.transform.localPosition;
        if (isExpanding)
        {
            pos.x -= expandSpeed * Time.deltaTime;
            if (pos.x <= -lengthMax)
            {
                pos.x = -lengthMax;
                isExpanding = false;
            }
            springEnd.transform.localPosition = pos;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isExpanding || collision.gameObject.layer != LayerMask.NameToLayer("Level"))
        {
            return;
        }
        isExpanding = false;
        if (collision.contacts.Length > 0)
        {
            Vector2 springOrientation = Quaternion.Euler(0, 0, transform.parent.eulerAngles.z) * Vector3.right;
            Vector2 pushDirection = collision.contacts[0].normal + springOrientation;
            myBody.AddForce(pushDirection.normalized * pushForce);
        }
    }
}
