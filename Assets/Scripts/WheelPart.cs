using UnityEngine;

public class WheelPart : GearTarget
{
    public float turnSpeed = 10000f;
    WheelJoint2D joint;
    Rigidbody2D myBody;

    void Awake()
    {
        joint = GetComponent<WheelJoint2D>();
        myBody = GetComponent<Rigidbody2D>();
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
        myBody.angularVelocity = -direction * turnSpeed * Time.deltaTime;
    }
}
